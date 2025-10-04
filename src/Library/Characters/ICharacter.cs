namespace Ucu.Poo.RoleplayGame;

public interface ICharacter
{ 
        string Name { get; }
        int Health { get; }
    
        void AddItem(IItem item);
        void RemoveItem(IItem item);
    
        void Damage(int health);
        void Heal();
    
        int GetAttack();
        int GetArmor();
}