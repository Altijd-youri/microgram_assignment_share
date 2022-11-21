using Moq;

namespace Cuniculus.Test;

[TestClass]
public class CuniculusHostedServiceTest
{
    [TestMethod]
    public async Task StartAsync_CallsSetupAndStartReceiving()
    {
        var basicReceiverMock = new Mock<IBasicReceiver>();
        var router = new Mock<ICuniculusRouter>();
        var cancellationToken = new CancellationToken();
        var sut = new CuniculusHostedService(basicReceiverMock.Object, router.Object);
        
        await sut.StartAsync(cancellationToken);
        
        basicReceiverMock.Verify(receiver => receiver.SetupQueue(It.IsAny<IEnumerable<string>>()));
        basicReceiverMock.Verify(receiver => receiver.StartReceiving(It.IsAny<Action<EventMessage>>()));
    }
    
    [TestMethod]
    public async Task StopAsync_CallsDispose()
    {
        var basicReceiverMock = new Mock<IBasicReceiver>();
        var router = new Mock<ICuniculusRouter>();
        var cancellationToken = new CancellationToken();
        var sut = new CuniculusHostedService(basicReceiverMock.Object, router.Object);
        
        await sut.StopAsync(cancellationToken);
        
        basicReceiverMock.Verify(receiver => receiver.Dispose());
    }
}