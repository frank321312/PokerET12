namespace Poker12.Core.Jugadas;

public class EscaleraColor : IJugada
{
    public string Nombre => "Escalera de color";
    public byte Prioridad => 2;
    public Resultado Aplicar(List<Carta> cartas)
    {
        if (cartas.Count == 0)
        {
            throw new ArgumentException("No hay cartas");
        }

        bool sonCorazones = cartas.All(x => x.Palo == EPalo.Corazon);
        bool sonDiamantes = cartas.All(x => x.Palo == EPalo.Diamante);
        bool sonPicas = cartas.All(x => x.Palo == EPalo.Picas);
        bool sonTreboles = cartas.All(x => x.Palo == EPalo.Trebol);

        if (cartas.Count < 5)
        {
            throw new ArgumentException("No se puede realizar esta jugada");
        }

        if (sonCorazones || sonDiamantes || sonPicas || sonTreboles)
        {
            List<byte> cartasByte = [];
            List<byte> valoresByte = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13];
            var ordenadasPorValor = cartas.OrderBy(x => x.Valor);

            cartasByte = ordenadasPorValor.Select(x => (byte)x.Valor).ToList();

            var recortarValoresByte = valoresByte.Where(x => cartasByte.First() >= x && x <= cartasByte.Last()).ToList();

            var valor = recortarValoresByte.Count == 5 ? (byte)ordenadasPorValor.Last().Valor : (byte)0; 

            return new Resultado(Prioridad, valor);
        }

        return new Resultado(Prioridad, (byte)0);
    }
}
