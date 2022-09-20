using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dag09.Personen.Test;

[TestClass]
public class PersoonTest
{
    [TestMethod]
    public void Persoon_IsCreatedWithNaamAndLeeftijd()
    {
        const string Naam = "John Doe";
        const int Leeftijd = 50;

        Persoon sut = new (Naam, Leeftijd);
        
        Assert.AreEqual("John Doe", sut.Naam);
        Assert.AreEqual(50, sut.Leeftijd);
    }

    [TestMethod]
    public void Persoon_VerjaarMethod_IncreasedLeeftijdByOne()
    {
        Persoon sut = new ("John Doe", 50);

        sut.Verjaar();
        
        Assert.AreEqual(51, sut.Leeftijd);
    }

    [TestMethod]
    public void LeeftijdChangedEvent_isCalledInPersoonLeeftijdSetter()
    {
        Persoon sut = new ("John Doe", 50);
        LeeftijdChangedListener listener = new ();
        sut.LeeftijdChanged += listener.Handle;

        sut.Leeftijd = 25;
        
        Assert.AreEqual(true, listener.HasBeenCalled);
    }

    [TestMethod]
    public void LeeftijdChangedEvent_isCalledInPersoonVerjaarMethod()
    {
        Persoon sut = new ("John Doe", 50);
        LeeftijdChangedListener listener = new ();
        sut.LeeftijdChanged += listener.Handle;
        
        sut.Verjaar();
        
        Assert.AreEqual(true, listener.HasBeenCalled);
    }

    [TestMethod]
    public void LeeftijdChangedEvent_HasExpectedProperties()
    {
        Persoon sut = new ("John Doe", 50);
        LeeftijdChangedListener listener = new ();
        sut.LeeftijdChanged += listener.Handle;
        
        sut.Verjaar();
        
        Assert.AreEqual("John Doe", listener.Naam);
        Assert.AreEqual(51, listener.Args?.Leeftijd);
        Assert.AreEqual(50, listener.Args?.OudeLeeftijd);
    }
    
    [TestMethod]
    public void LeeftijdChangedEvent_HasExpectedSender()
    {
        Persoon sut = new ("John Doe", 50);
        LeeftijdChangedListener listener = new ();
        sut.LeeftijdChanged += listener.Handle;
        
        sut.Verjaar();
        
        Assert.AreEqual(sut, listener.Sender);
    }
}