namespace Ucu.Poo.RoleplayGame;

public class SpellsBook
{
    private List<Spell> _spells = new  List<Spell>();
    
    
    public int Attack
    {
        get
        {
            int value = 0;
            foreach (Spell spell in this._spells)
            {
                value += spell.Attack;
            }
            return value;
        }
    }

    public int Armor
    {
        get
        {
            int value = 0;
            foreach (Spell spell in this._spells)
            {
                value += spell.Armor;
            }
            return value;
        }
    }

    public void AddSpell(Spell spell)
    {
        _spells.Add(spell);
    }

    public void RemoveSpell(Spell spell)
    {
        _spells.Remove(spell);
    }
}
