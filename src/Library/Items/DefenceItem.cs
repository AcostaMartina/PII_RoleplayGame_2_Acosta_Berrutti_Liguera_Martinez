namespace Ucu.Poo.RoleplayGame;

public class DefenceItem : IItem
{
    private string _name;
    private int _armor;
    private bool _isMagical;

    public DefenceItem(string name, int armor, bool isMagical)
    {
        _name = name;
        _armor = armor;
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

    public int Armor
    {
        get { return _armor; }
    }

    public override string ToString()
    {
        return $"{Name} (Armor: {Armor}, Mágico: {IsMagical})";
    }
}
