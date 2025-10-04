using Ucu.Poo.RoleplayGame;

SpellsBook book = new SpellsBook();
Spell spell = new Spell("spell", 70, 70, true);
book.AddSpell(spell);

Wizard gandalf = new Wizard("Gandalf");
Staff staff = new Staff("spell", 100, 100, true);
gandalf.AddItem(staff);

Dwarf gimli = new Dwarf("Gimli");
Axe axe = new Axe("axe", 25, false);
gimli.AddItem(axe);
Helmet helmet = new Helmet("armor", 18, false);
gimli.AddItem(helmet);
Shield shield = new Shield("armor", 14, false);
gimli.AddItem(shield);


Console.WriteLine($"Gimli has ❤️ {gimli.Health}");
Console.WriteLine($"Gandalf attacks Gimli with ⚔️ {gandalf.GetAttack()}");

gimli.Damage(gandalf.GetAttack());

Console.WriteLine($"Gimli has ❤️ {gimli.Health}");

gimli.Heal();

Console.WriteLine($"Gimli has ❤️ {gimli.Health}");

