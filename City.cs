using System;

public class City
{
    public string Name { get; set; }
    public int Distance { get; set; }

    public City(string name, int distance)
    {
        Name = name;
        Distance = distance;
    }

    public static City GenerateRandomCity(string[] cityNames)
    {
        Random random = new Random();
        string name = cityNames[random.Next(cityNames.Length)];
        int distance = random.Next(50, 101);
        return new City(name, distance);
    }
}
