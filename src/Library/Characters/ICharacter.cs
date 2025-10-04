namespace Characters;

public interface ICharacter
{ 
        string Name { get; }
        int Health { get; }
    
        void AddItem(Item item);
        void RemoveItem(Item item);
    
        void Damage(int health);
        void Heal();
    
        int GetAttack();
        int GetArmor();
}