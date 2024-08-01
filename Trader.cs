using System;
using System.Collections.Generic;

public class Trader
{
    public List<Goods> GoodsList { get; set; }
    public decimal Money { get; set; }
    public City CurrentCity { get; set; }
    public Wagon Wagon { get; set; }

    public Trader(decimal initialMoney, Wagon wagon)
    {
        Money = initialMoney;
        Wagon = wagon;
        GoodsList = new List<Goods>();
    }

    public void BuyGoods(Goods goods)
    {
        if (Money >= goods.Cost && GoodsList.Count < Wagon.CarryingCapacity)
        {
            GoodsList.Add(goods);
            Money -= goods.Cost;
        }
    }

    public void SellGoods(City city)
    {
        decimal totalRevenue = 0;
        foreach (var goods in GoodsList)
        {
            totalRevenue += goods.GetSellingPrice();
        }

        Money += totalRevenue;
        GoodsList.Clear();
    }
}
