namespace Characters;

public class Knight : ICharacter
{
    private int health = 100;

    public Knight(string name)
    {
        this.Name = name;
    }

    public string Name { get; set; }

    private List<Item> _items = new List<Item>();
    
    public void AddItem(Item item)
    {
        if (!item.IsMagical)
            _items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        _items.Remove(item);
    }

    public int GetAttack()
    {
        int total = 0;
        foreach (var item in items)
        {
            if (item is AttackItem atk)
                total += atk.Attack;
            if (item is HybridItem hyb)
                total += hyb.Attack;
        }
        return total;
    }


    public int GetArmor()
    {
        int total = 0;
        foreach (var item in items)
        {
            if (item is AttackItem atk)
                total += atk.Armor;
            if (item is HybridItem hyb)
                total += hyb.Armor;
        }
        return total;
    }


    public int Health
    {
        get
        {
            return this.health;
        }
        private set
        {
            this.health = value < 0 ? 0 : value;
        }
    }

    public void Damage(int power)
    {
        if (this.GetArmor() < power)
        {
            this.Health -= power - this.GetArmor();
        }
    }

    public void Heal()
    {
        this.Health = 100;
    }
}
