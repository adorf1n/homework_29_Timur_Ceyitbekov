using System;
using System.Collections.Generic;
using System.Diagnostics;

public class Event : IEvent
{
    public EventType Type { get; set; }

    public Event(EventType type)
    {
        Type = type;
    }

    public void ApplyEffect(Trader trader, Wagon wagon, List<Goods> goods)
    {
        switch (Type)
        {
            case EventType.OrdinaryDay:
                break;
            case EventType.Rain:
                wagon.ChangeSpeed(-2);
                if (new Random().NextDouble() < 0.3)
                {
                    int index = new Random().Next(goods.Count);
                    goods[index].DegradeQuality();
                }
                break;
            case EventType.SmoothRoad:
                wagon.ChangeSpeed(2);
                break;
            case EventType.BrokenWheel:
                break;
            case EventType.River:
                break;
            case EventType.MetLocal:
                wagon.ChangeSpeed(new Random().Next(3, 7));
                break;
            case EventType.HighwayRobbers:
                break;
            case EventType.RoadsideInn:
                break;
            case EventType.GoodsSpoiled:
                if (goods.Count > 0)
                {
                    int index = new Random().Next(goods.Count);
                    goods[index].DegradeQuality();
                }
                break;
        }
    }
}
