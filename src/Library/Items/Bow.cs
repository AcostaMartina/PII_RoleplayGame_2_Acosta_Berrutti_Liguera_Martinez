namespace Ucu.Poo.RoleplayGame;

public class Bow : AttackItem
{
    public Bow() : base("Bow", 15, false)
    {}

    public override string ToString()
    {
        return $"{base.ToString()}, Attack Value: {15}";
    }
}
