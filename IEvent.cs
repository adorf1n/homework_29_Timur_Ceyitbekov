using System.Diagnostics;

public interface IEvent
{
    void ApplyEffect(Trader trader, Wagon wagon, List<Goods> goods);
}
