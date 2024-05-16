namespace Poker12.Core.Jugadas;
public class CartaAlta : IJugada
{
    public string Nombre => "Carta Alta";
    public byte Prioridad => 10;
    public Resultado Aplicar(List<Carta> cartas)
    {
        if (cartas.Count == 0)
            throw new ArgumentException("No hay cartas");

        var ordenadasPorValor = cartas.OrderBy(c => c.Valor);

        var valor = ordenadasPorValor.First().Valor == EValor.As ?
                        (byte)14 : // Aca use el valor 'Alto' del As
                        (byte)ordenadasPorValor.Last().Valor; // Como estan ordenadas, la ultima es la mayor 

        return new Resultado(Prioridad, valor);
    }
}
