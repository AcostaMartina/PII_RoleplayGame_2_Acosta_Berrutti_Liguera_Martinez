namespace Ucu.Poo.RoleplayGame
{
    public class SpellsBook : HybridItem
    {
        private List<Spell> _spells = new List<Spell>();

        public SpellsBook()
            : base("SpellBook", armor: 0, attack: 0, isMagical: true)
        {
        }

        public override int Attack
        {
            get
            {
                int value = 0;
                foreach (Spell spell in _spells)
                {
                    value += spell.Attack;
                }
                return value;
            }
        }

        public override int Armor
        {
            get
            {
                int value = 0;
                foreach (Spell spell in _spells)
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
}