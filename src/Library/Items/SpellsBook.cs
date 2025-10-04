namespace Ucu.Poo.RoleplayGame
{
    public class SpellsBook : HybridItem
    {
        public Spell[] Spells { get; set; }

        public SpellsBook(Spell[] spells)
            : base("SpellBook", armor: 0, attack: 0, isMagical: true)
        {
            this.Spells = spells;
        }

        public override int Attack
        {
            get
            {
                int value = 0;
                if (Spells != null)
                {
                    foreach (var spell in Spells)
                    {
                        value += spell.AttackValue;
                    }
                }
                return value;
            }
        }

        public override int Armor
        {
            get
            {
                int value = 0;
                if (Spells != null)
                {
                    foreach (var spell in Spells)
                    {
                        value += spell.DefenseValue;
                    }
                }
                return value;
            }
        }
    }
}