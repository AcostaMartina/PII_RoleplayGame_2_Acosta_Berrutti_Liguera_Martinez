namespace Ucu.Poo.RoleplayGame;

public class HybridItem : IItem
{
    private string _name;
    private int _armor;
    private int _attack;
    private bool _isMagical;

    public HybridItem(string name, int armor,int attack, bool isMagical)
    {
        _name = name;
        _armor = armor;
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

    public virtual int Armor
    {
        get { return _armor; }
    }
    public virtual int Attack
    {
        get { return _attack; }
    }
    public override string ToString()
    {
        return $"{Name} (Armor: {Armor}, Attack: {Attack}, Mágico: {IsMagical})";
    }

}