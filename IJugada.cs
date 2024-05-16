namespace Poker12.Core.Jugadas;
/// <summary>
/// Esta estructura, representa el resultado de aplicar una Jugada a una colección de cartas
/// </summary>
/// <param name="Prioridad">Representa la importancia de la jugada, en base 1 desde Escalera Real en adelante.</param>
/// <param name="Valor">Si la jugada no se puede aplicar vale 0, caso contrario un valor mayor.</param>
public readonly record struct Resultado(byte Prioridad, byte Valor = 0);

public interface IJugada
{
    public string Nombre { get; }
    public byte Prioridad { get; }
    public Resultado Aplicar (List<Carta> cartas);
}