namespace Ucu.Poo.RoleplayGame;

public class AttackItem : IItem
{
    private string _name;
    private int _attack;
    private bool _isMagical;

    public AttackItem(string name, int attack, bool isMagical)
    {
        _name = name;
        _attack = attack;
        _isMagical = isMagical;
    }

    public string Name
    {
        get { return _name; }
    }

    public bool IsMagical
    {
        get { return _isMagical; }
    }

    public int Attack
    {
        get { return _attack; }
    }

    public override string ToString()
    {
        return $"{Name} (attack: {Attack}, Mágico: {IsMagical})";
    }
}
