using System.Diagnostics;

namespace Dag07.Munten;

public struct Valuta
{
    public readonly Muntsoort Muntsoort;
    public readonly decimal Bedrag;

    public Valuta(decimal bedrag, Muntsoort muntsoort)
    {
        Muntsoort = muntsoort;
        Bedrag = bedrag;
    }

    public Valuta ConvertTo(Muntsoort convertToMuntsoort)
    {
        decimal localeValutaWaarde = (Muntsoort == Muntsoort.Gulden)
            ? Bedrag / Muntsoort.KoersTenOpzichtenVanGulden(convertToMuntsoort)
            : Bedrag * Muntsoort.KoersTenOpzichtenVanGulden(Muntsoort);
        return new Valuta(Math.Round(localeValutaWaarde, 2), convertToMuntsoort);
    }

    public override string ToString()
    {
        return $"{Bedrag:N2} {Muntsoort.afkortingRepresentatie()}";
    }
}