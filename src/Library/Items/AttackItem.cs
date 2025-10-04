namespace Ucu.Poo.RoleplayGame;
public class AttackItem
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
        set { _name = value; }
    }

    public int Attack
    {
        get { return _attack; }
        set { _attack = value; }
    }

    public bool isMagical
    {
        get { return _isMagical; }
        set { _isMagical = value; }
    }

    public override string ToString()
    {
        return $"Name: {_name}, Attack: {_attack}, IsMagical: {_isMagical}";
    }
}