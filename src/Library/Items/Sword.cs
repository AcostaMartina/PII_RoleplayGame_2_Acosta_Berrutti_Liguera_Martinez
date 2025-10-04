namespace Ucu.Poo.RoleplayGame;

public class Sword: AttackItem
{
    public Sword() : base("Sword", 20, false)
    {}
   
    public override string ToString()
    {
        return $"{base.ToString()}, Attack Value: {15}";
    }
}
