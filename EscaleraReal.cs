using System.Runtime.InteropServices;
namespace Poker12.Core.Jugadas; 
public class EscaleraReal : IJugada 
{ 
    public string Nombre => "Escalera Real"; 
    public byte Prioridad => 1; 
    public Resultado Aplicar(List<Carta> cartas) 
    { 
        if (cartas.Count == 0) 
        { 
            throw new ArgumentException("No hay cartas");
        } 
        bool sonCorazones = cartas.All(x => x.Palo == EPalo.Corazon); 
        bool sonDiamantes = cartas.All(x => x.Palo == EPalo.Diamante); 
        bool sonPicas = cartas.All(x => x.Palo == EPalo.Picas); bool 
        sonTreboles = cartas.All(x => x.Palo == EPalo.Trebol); 
        
        if (cartas.Count < 5) 
        { 
            throw new ArgumentException("No se puede realizar esta jugada"); 
        } 
        
        if (sonCorazones || sonDiamantes || sonPicas || sonTreboles) 
        { 
            var ordenadasPorValor = cartas.OrderBy(x => x.Valor); 
            var filtrarJugada = ordenadasPorValor.Where(x => x.Valor == EValor.As || 
                                                        x.Valor == EValor.Diez || 
                                                        x.Valor == EValor.J || 
                                                        x.Valor == EValor.Q || 
                                                        x.Valor == EValor.K); 

            var valor = filtrarJugada.Count() == 5 ? (byte)14 : (byte)0; 
            return new Resultado(Prioridad, valor); 
        } 
        
        return new Resultado(Prioridad, (byte)0); 
    } 
}