
using System;

public class Goods
{
    public GoodsType Type { get; set; }
    public int Weight { get; set; }
    public Quality Quality { get; set; }
    public decimal Cost { get; set; }

    public Goods(GoodsType type, int weight, Quality quality, decimal cost)
    {
        Type = type;
        Weight = weight;
        Quality = quality;
        Cost = cost;
    }

    public void DegradeQuality()
    {
        switch (Quality)
        {
            case Quality.Normal:
                Quality = Quality.SlightlySpoiled;
                break;
            case Quality.SlightlySpoiled:
                Quality = Quality.HalfSpoiled;
                break;
            case Quality.HalfSpoiled:
                Quality = Quality.AlmostGone;
                break;
            case Quality.AlmostGone:
                Quality = Quality.SpoiledRotten;
                break;
            case Quality.SpoiledRotten:
                break;
        }
    }

    public decimal GetSellingPrice()
    {
        decimal qualityCoefficient = Quality switch
        {
            Quality.Normal => 2m,
            Quality.SlightlySpoiled => 1.5m,
            Quality.HalfSpoiled => 1m,
            Quality.AlmostGone => 0.7m,
            Quality.SpoiledRotten => 0.5m,
            _ => 1m
        };

        return Cost * qualityCoefficient;
    }
}
