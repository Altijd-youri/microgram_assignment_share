using System.Text;
using Moq;
using RabbitMQ.Client;

namespace Cuniculus.Test;

[TestClass]
public class BasicReceiverTest
{
    private readonly Mock<IModel> _channelMock = new ();
    private readonly Mock<IConnection> _connectionMock = new ();
    private readonly Mock<IConnectionFactory> _factoryMock = new ();
    private readonly Mock<ICuniculusOptions> _optionsMock = new ();
    private readonly Mock<ICuniculusContext> _contextMock = new ();
    
    [TestInitialize]
    public void CreateMocks()
    {
        _connectionMock.Setup(connection => connection.CreateModel())
            .Returns(_channelMock.Object);
        _factoryMock.Setup(factory => factory.CreateConnection())
            .Returns(_connectionMock.Object);
        _optionsMock.Setup(options => options.CreateFactory())
            .Returns(_factoryMock.Object);
        _optionsMock.Setup(options => options.ExchangeName).Returns("Bunnies");
        _optionsMock.Setup(options => options.QueueName).Returns("European");
        _contextMock.Setup(context => context.CreateChannel())
            .Returns(_channelMock.Object);
        _contextMock.Setup(context => context.Options)
            .Returns(_optionsMock.Object);
        
    }
    
    [TestMethod]
    public void SetupQueue_DeclaresAPersistentRabbitMQQueue()
    {
        var sut = new BasicReceiver(_contextMock.Object);
        var topics = new List<string>()
        {
            "behaviour",
            "health"
        };
        
        sut.SetupQueue(topics);

        _channelMock.Verify(channel => channel.QueueDeclare(
                "European", true, false, false, It.IsAny<Dictionary<string, object>>()
            ), 
            Times.Once
        );
    }
    
    [TestMethod]
    public void SetupQueue_BindRabbitMQExchangeForeachTopic()
    {
        var sut = new BasicReceiver(_contextMock.Object);
        var topics = new List<string>()
        {
            "behaviour",
            "health"
        };
        
        sut.SetupQueue(topics);
        
        _channelMock.Verify(channel => channel.QueueBind(
                "European", "Bunnies", "behaviour", It.IsAny<Dictionary<string, object>>()
            ), 
            Times.Once
        );
        _channelMock.Verify(channel => channel.QueueBind(
                "European", "Bunnies", "health", It.IsAny<Dictionary<string, object>>()
            ), 
            Times.Once
        );
    }
    
    [TestMethod]
    public void SetupQueue_ThrowsCuniculusException_IfNoTopicsAreProvied()
    {
        var sut = new BasicReceiver(_contextMock.Object);
        var topics = new List<string>();
        
        Action shouldThrowException = () => sut.SetupQueue(topics);

        var thrownException = Assert.ThrowsException<CuniculusException>(shouldThrowException);
        Assert.AreEqual("No topic(s) provided.", thrownException.Message);
    }
    
    [TestMethod]
    public void SetupQueue_ThrowsCuniculusException_IfCalledMoreThanOnce()
    {
        var sut = new BasicReceiver(_contextMock.Object);
        var topics = new List<string>()
        {
            "behaviour",
            "health"
        };
        
        sut.SetupQueue(topics);
        Action shouldThrowException = () => sut.SetupQueue(topics);
        
        var thrownException = Assert.ThrowsException<CuniculusException>(shouldThrowException);
        Assert.AreEqual("SetupQueue already done.", thrownException.Message);
    }
    
    [TestMethod]
    public void StartReceiving_MessageIsHandledAfterStartReceiving()
    {
        IBasicConsumer consumer = null;
        _channelMock.Setup(channel => channel.BasicConsume(
            "European", true, "", false, false, null, It.IsAny<IBasicConsumer>()))
            .Callback((string _, bool _, string _, bool _, bool _, IDictionary<string, object> _, IBasicConsumer innerConsumer) =>
            {
                consumer = innerConsumer;
            });
        bool handlerCalled = false;
        EventMessage handlerCalledWithMessage = null;
        Action<EventMessage> handler = (eventMessage) =>
        {
            handlerCalledWithMessage = eventMessage;
            handlerCalled = true;
        };
        var sut = new BasicReceiver(_contextMock.Object);
        var messageBytes = Encoding.Unicode.GetBytes("{ name: 'Oryctolagus cuniculus' }");
        var topics = new List<string>()
        {
            "behaviour",
            "health"
        };
        sut.SetupQueue(topics);
        
        sut.StartReceiving(handler);
        consumer?.HandleBasicDeliver("", 0, false, "Bunnies", "health", null, messageBytes);

        Assert.IsTrue(handlerCalled, "Handler was not called");
        Assert.AreEqual("{ name: 'Oryctolagus cuniculus' }",handlerCalledWithMessage?.Body);
        Assert.AreEqual("health",handlerCalledWithMessage?.Topic);
    }
    
    [TestMethod]
    public void StartReceiving_CreatesAEventingBasicConsumer()
    {
        IBasicConsumer consumer = null;
        _channelMock.Setup(channel => channel.BasicConsume(
                "European", true, "", false, false, null, It.IsAny<IBasicConsumer>()))
            .Callback((string _, bool _, string _, bool _, bool _, IDictionary<string, object> _, IBasicConsumer innerConsumer) =>
            {
                consumer = innerConsumer;
            });
        var sut = new BasicReceiver(_contextMock.Object);
        var topics = new List<string>()
        {
            "behaviour",
            "health"
        };
        Action<EventMessage> handler = (eventMessage) => { };
        sut.SetupQueue(topics);
        
        sut.StartReceiving(handler);
        
        Assert.IsNotNull(consumer);
        Assert.IsInstanceOfType(consumer, typeof(IBasicConsumer));
    }
    
    [TestMethod]
    public void StartReceiving_ThrowsCuniculusException_IfCalledMoreThanOnce()
    {
        Action<EventMessage> handler = (eventMessage) => {};
        var sut = new BasicReceiver(_contextMock.Object);
        var topics = new List<string> { "behaviour" };
        sut.SetupQueue(topics);
        
        sut.StartReceiving(handler);
        Action shouldThrowException = () => sut.StartReceiving(handler);
        
        var thrownException = Assert.ThrowsException<CuniculusException>(shouldThrowException);
        Assert.AreEqual("StartReceiving already done.", thrownException.Message);
    }
    
    [TestMethod]
    public void StartReceiving_ThrowsCuniculusException_IfCalledBeforeSetupQueue()
    {
        Action<EventMessage> handler = (eventMessage) => {};
        var sut = new BasicReceiver(_contextMock.Object);
        var topics = new List<string> { "behaviour" };
        
        Action shouldThrowException = () => sut.StartReceiving(handler);
        
        var thrownException = Assert.ThrowsException<CuniculusException>(shouldThrowException);
        Assert.AreEqual("SetupQueue not finished.", thrownException.Message);
    }
}