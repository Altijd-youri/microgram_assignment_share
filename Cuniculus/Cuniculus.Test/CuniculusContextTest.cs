using Moq;
using RabbitMQ.Client;

namespace Cuniculus.Test;

[TestClass]
public class CuniculusContextTest
{
    private readonly Mock<IModel> _channelMock = new ();
    private readonly Mock<IConnection> _connectionMock = new ();
    private readonly Mock<IConnectionFactory> _factoryMock = new ();
    private readonly Mock<ICuniculusOptions> _optionsMock = new ();
    
    [TestInitialize]
    public void CreateMocks()
    {
        _connectionMock.Setup(connection => connection.CreateModel())
            .Returns(_channelMock.Object);
        _factoryMock.Setup(factory => factory.CreateConnection())
            .Returns(_connectionMock.Object);
        _optionsMock.Setup(options => options.CreateFactory())
            .Returns(_factoryMock.Object);
    }

    [TestMethod] public void ConnectionProperty_UsesCuniculusOptionsCreateFactory()
    {
        
        var sut = new CuniculusContext(_optionsMock.Object);
        
        var result = sut.Connection;
        
        _optionsMock.Verify(options => options.CreateFactory(), Times.Once);
    }

    [TestMethod]
    public void ConnectionProperty_IsInitializedOnce_CreateFactoryAndCreateConnectionAreCalledOnce()
    {
        var sut = new CuniculusContext(_optionsMock.Object);

        var resultOne = sut.Connection;
        var resultTwo = sut.Connection;
        
        _optionsMock.Verify(context => context.CreateFactory(), Times.Once);
        _factoryMock.Verify(factory => factory.CreateConnection(), Times.Once);
    }
    
    [TestMethod]
    public void ConnectionProperty_IsInitializedOnce_DeclareExchangeIsCalled()
    {
        _optionsMock.Setup(options => options.ExchangeName).Returns("Bunnies");
        _channelMock.Setup(channel
            => channel.ExchangeDeclare("Bunnies", ExchangeType.Direct, true, false, null));
        var sut = new CuniculusContext(_optionsMock.Object);

        var result = sut.Connection;
        
        _channelMock.Verify(channel 
            => channel.ExchangeDeclare("Bunnies", ExchangeType.Direct, It.IsAny<bool>(), It.IsAny<bool>(), null), Times.Once);
    }

    [TestMethod]
    public void CreateChannel_CreatesAChannel()
    {
        var sut = new CuniculusContext(_optionsMock.Object);
        
        var result = sut.CreateChannel();
        
        Assert.IsInstanceOfType(result, typeof(IModel));
    }

    [TestMethod]
    public void UnmanagedResource_Connection_IsDisposedByContext()
    {
        var sut = new CuniculusContext(_optionsMock.Object);
        var makeConnection = sut.Connection;
        
        sut.Dispose();

        _connectionMock.Verify(connection
            => connection.Dispose(), Times.AtLeastOnce());
    }
}