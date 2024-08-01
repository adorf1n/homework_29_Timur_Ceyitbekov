public class Wagon
{
    public int CarryingCapacity { get; set; }
    public int Speed { get; set; }

    public Wagon(int carryingCapacity, int speed)
    {
        CarryingCapacity = carryingCapacity;
        Speed = speed;
    }

    public void ChangeSpeed(int delta)
    {
        Speed = Math.Max(1, Speed + delta); 
    }
}
