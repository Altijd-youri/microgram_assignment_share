namespace Cuniculus.Sample;

// [EventListener]
public class KlantbeheerEventListener
{
    private readonly ILogger _logger;
 
    public KlantbeheerEventListener(ILogger<KlantbeheerEventListener> logger)
    {
        _logger = logger;
    }
 
    // [Handler(topic: "MVM.Klantbeheer.KlantGeregistreerd")]
    public void Handle(KlantGeregistreerd evt)
    {
        // handle KlantGeregistreerd event ...
    }
 
    // [Handler(topic: "MVM.Klantbeheer.KlantVerhuisd")]
    public void Handle(KlantVerhuisd evt)
    {
        // handle KlantVerhuisd event ...
    }
}


