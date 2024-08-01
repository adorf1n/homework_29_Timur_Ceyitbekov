using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] cityNames = { "CityA", "CityB", "CityC", "CityD", "CityE", "CityF", "CityG" };
        Random random = new Random();

        Wagon wagon = new Wagon(carryingCapacity: 10, speed: 3);
        Trader trader = new Trader(initialMoney: 1000, wagon: wagon);

        GenerateGoods(trader, random);

        City destinationCity = City.GenerateRandomCity(cityNames);
        trader.CurrentCity = destinationCity;

        Console.WriteLine("Purchased Goods:");
        foreach (var goods in trader.GoodsList)
        {
            Console.WriteLine($"{goods.Type} - Weight: {goods.Weight}, Quality: {goods.Quality}, Cost: {goods.Cost}");
        }

        int distanceTraveled = 0;
        while (distanceTraveled < destinationCity.Distance)
        {
            EventType eventType = (EventType)random.Next(Enum.GetValues(typeof(EventType)).Length);
            Event currentEvent = new Event(eventType);

            currentEvent.ApplyEffect(trader, wagon, trader.GoodsList);

            Console.WriteLine($"Event: {eventType}");

            distanceTraveled += wagon.Speed;
            Console.WriteLine($"Distance traveled: {distanceTraveled} leagues");

            if (distanceTraveled >= destinationCity.Distance)
            {
                Console.WriteLine($"Arrived at {destinationCity.Name}");
                trader.SellGoods(destinationCity);
                Console.WriteLine($"Money after selling goods: {trader.Money:C}");
                break;
            }

            System.Threading.Thread.Sleep(1000); 
        }
    }

    static void GenerateGoods(Trader trader, Random random)
    {
        GoodsType[] types = (GoodsType[])Enum.GetValues(typeof(GoodsType));
        for (int i = 0; i < 10; i++)
        {
            GoodsType type = types[random.Next(types.Length)];
            int weight = random.Next(1, 5);
            Quality quality = Quality.Normal;
            decimal cost = random.Next(10, 50);
            Goods goods = new Goods(type, weight, quality, cost);

            trader.BuyGoods(goods);
        }
    }
}
