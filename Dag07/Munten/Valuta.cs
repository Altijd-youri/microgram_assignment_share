namespace Munten;

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

    public static Valuta operator +(Valuta a, Valuta b)
    {
        if (a.Muntsoort != b.Muntsoort)
            b = b.ConvertTo(a.Muntsoort);
        return new Valuta(a.Bedrag + b.Bedrag, a.Muntsoort);
    }
    
    public static Valuta operator *(Valuta a, Valuta b)
    {
        if (a.Muntsoort != b.Muntsoort)
            b = b.ConvertTo(a.Muntsoort);
        return new Valuta(a.Bedrag * b.Bedrag, a.Muntsoort);
    }

    public static Valuta operator *(decimal b, Valuta a) => a * b;
    public static Valuta operator *(Valuta a, decimal b) => new (a.Bedrag * b, a.Muntsoort);

    private static bool IsEqual(Valuta a, Valuta b)
    {
        if (a.Muntsoort != b.Muntsoort)
            b = b.ConvertTo(a.Muntsoort);
        return a.Bedrag == b.Bedrag;
    }
    public static bool operator ==(Valuta a, Valuta b) => IsEqual(a, b);
    
    public static bool operator !=(Valuta a, Valuta b) => !IsEqual(a, b);

    public static implicit operator Valuta(decimal a) => new Valuta(a, Muntsoort.Euro);
    public static implicit operator decimal(Valuta a)
    {
        return a.ConvertTo(Muntsoort.Euro).Bedrag;
    }
}