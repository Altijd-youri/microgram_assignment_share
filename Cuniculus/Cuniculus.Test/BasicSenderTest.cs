using System.Text;
using Moq;
using RabbitMQ.Client;

namespace Cuniculus.Test;

[TestClass]
public class BasicSenderTest
{
    private readonly Mock<IModel> _channelMock = new ();
    private readonly Mock<IConnection> _connectionMock = new ();
    private readonly Mock<IConnectionFactory> _factoryMock = new ();
    private readonly Mock<ICuniculusOptions> _optionsMock = new ();
    private readonly  Mock<ICuniculusContext> _contextMock = new ();
    
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
        _contextMock.Setup(context => context.CreateChannel())
            .Returns(_channelMock.Object);
        _contextMock.Setup(context => context.Options)
            .Returns(_optionsMock.Object);
    }
    
    [TestMethod]
    public void Send_CreatesAOneTimeUseChannel()
    {
        var message = new EventMessage("European", "{ name: 'Oryctolagus cuniculus' }");
        var sut = new BasicSender(_contextMock.Object);
        
        sut.Send(message);
        sut.Send(message);
        sut.Send(message);
        
        _contextMock.Verify(context => context.CreateChannel(), Times.Exactly(3));
    }

    [TestMethod]
    public void Send_BasicPublishTheEventMessage()
    {
        _channelMock.Setup(channel =>
            channel.BasicPublish("Bunnies", "European", false, null,It.IsAny<ReadOnlyMemory<byte>>()));
        var message = new EventMessage("European", "{ name: 'Oryctolagus cuniculus' }");
        var sut = new BasicSender(_contextMock.Object);
        
        sut.Send(message);
        
        _channelMock.Verify(channel 
            => channel.BasicPublish("Bunnies", "European", false, null,It.IsAny<ReadOnlyMemory<byte>>()), 
            Times.Once
        );
    }
}