namespace Dag07.Munten;

public static class MuntsoortExtensions
{
    public static string afkortingRepresentatie(this Muntsoort muntsoort)
    {
        return muntsoort switch
        {
            Muntsoort.Euro => "EUR",
            Muntsoort.Dukaat => "HD",
            Muntsoort.Gulden => "fl",
            Muntsoort.Florijn => "fl",
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    
    public static decimal KoersTenOpzichtenVanGulden(this Muntsoort muntsoort, Muntsoort conversieNaar)
    {
        return conversieNaar switch
        {
            Muntsoort.Euro => 2.20371M,
            Muntsoort.Dukaat => 5.1M,
            Muntsoort.Gulden => 1M,
            Muntsoort.Florijn => 1M,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

}