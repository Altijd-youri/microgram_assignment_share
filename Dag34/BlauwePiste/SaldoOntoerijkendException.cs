using System.Globalization;

namespace BlauwePiste;

public class SaldoOntoerijkendException : Exception
{
    public SaldoOntoerijkendException(decimal saldo, decimal bedrag)
        : base($"Uw saldo van {saldo.ToString("N2",new CultureInfo("nl-NL"))} Euro is ontoereikend om een bedrag van {bedrag.ToString("N2",new CultureInfo("nl-NL"))} mee te betalen")
    {
    }
}