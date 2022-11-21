using Microsoft.Extensions.Hosting;

namespace Cuniculus;

public class CuniculusHostedService : IHostedService
{
    private readonly IBasicReceiver _receiver;
    private readonly ICuniculusRouter _router;
 
    public CuniculusHostedService(IBasicReceiver basicReceiver, ICuniculusRouter router)
    {
        _receiver = basicReceiver;
        _router = router;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        void Handler(EventMessage eventMessage) => _router.Route(eventMessage);
        _receiver.SetupQueue(_router.Topics);
        _receiver.StartReceiving(Handler);
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _receiver.Dispose();
        return Task.CompletedTask;
    }
}