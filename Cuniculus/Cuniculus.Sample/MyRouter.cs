using Newtonsoft.Json;

namespace Cuniculus.Sample;

public class MyRouter : ICuniculusRouter
{
    private readonly KlantbeheerEventListener _klantbeheerEventListener;
    private readonly FacturatieEventListener _facturatieEventListener;
 
    public MyRouter(KlantbeheerEventListener klantbeheerEventListener, 
        FacturatieEventListener facturatieEventListener)
    {
        _klantbeheerEventListener = klantbeheerEventListener;
        _facturatieEventListener = facturatieEventListener;
    }
 
    public IEnumerable<string> Topics => new string[] 
    {
        "MVM.Klantbeheer.KlantGeregistreerd",
        "MVM.Klantbeheer.KlantVerhuisd",
        "MVM.Facturatie.FactuurIngediend",
    };
 
    public void Route(EventMessage eventMessage)
    {
        switch (eventMessage.Topic)
        {
            case "MVM.Klantbeheer.KlantGeregistreerd":
                KlantGeregistreerd klantGeregistreerdEvent = 
                    JsonConvert.DeserializeObject<KlantGeregistreerd>(eventMessage.Body);
                _klantbeheerEventListener.Handle(klantGeregistreerdEvent);
                break;
            case "MVM.Klantbeheer.KlantVerhuisd":
                KlantVerhuisd klantVerhuisdEvent = 
                    JsonConvert.DeserializeObject<KlantVerhuisd>(eventMessage.Body);
                _klantbeheerEventListener.Handle(klantVerhuisdEvent);
                break;
            case "MVM.Facturatie.FactuurIngediend":
                FactuurIngediend factuurIngediendEvent = 
                    JsonConvert.DeserializeObject<FactuurIngediend>(eventMessage.Body);
                _facturatieEventListener.Handle(factuurIngediendEvent);
                break;
            default:
                break;
        }
    }
}
