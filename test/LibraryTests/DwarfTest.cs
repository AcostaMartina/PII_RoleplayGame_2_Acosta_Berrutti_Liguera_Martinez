using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace LibraryTests
{
    [TestFixture]
    public class DwarfTest
    {
        private Dwarf _dwarf;
        private Axe _axe;
        private Sword _sword;
        private Bow _bow;
        private Armor _armor;
        private Helmet _helmet;
        private Shield _shield;
        private Staff _staff;
        private Spell _spell;
        private SpellsBook _spellBook;

        [SetUp]
        public void Setup()
        {
            _dwarf = new Dwarf("Gimli");

            _axe = new Axe("Axe", 25, false);
            _sword = new Sword("Sword", 20, false);
            _bow = new Bow("Bow", 15, false);

            _armor = new Armor("Armor", 25, false);
            _helmet = new Helmet("Helmet", 18, false);
            _shield = new Shield("Shield", 14, false);

            _staff = new Staff("Staff", 100, 100, true);
            _spell = new Spell("Fire", 70, 70, true);
            _spellBook = new SpellsBook();
            _spellBook.AddSpell(_spell);
        }

        [Test]
        public void Dwarf_ShouldAddNonMagicalItemsCorrectly()
        {
            _dwarf.AddItem(_axe);
            _dwarf.AddItem(_sword);
            _dwarf.AddItem(_bow);
            _dwarf.AddItem(_armor);
            _dwarf.AddItem(_helmet);
            _dwarf.AddItem(_shield);

            int expectedAttack = _axe.Attack + _sword.Attack + _bow.Attack;
            int expectedArmor = _armor.Armor + _helmet.Armor + _shield.Armor;

            Assert.That(_dwarf.GetAttack(), Is.EqualTo(expectedAttack));
            Assert.That(_dwarf.GetArmor(), Is.EqualTo(expectedArmor));
        }

        [Test]
        public void Dwarf_ShouldNotAddMagicalItems()
        {
            _dwarf.AddItem(_staff);
            _dwarf.AddItem(_spell);
            _dwarf.AddItem(_spellBook);

            Assert.That(_dwarf.GetAttack(), Is.EqualTo(0));
            Assert.That(_dwarf.GetArmor(), Is.EqualTo(0));
        }

        [Test]
        public void Dwarf_ShouldCalculateAttackCorrectly()
        {
            _dwarf.AddItem(_axe);
            _dwarf.AddItem(_sword);
            _dwarf.AddItem(_bow);

            int totalAttack = _axe.Attack + _sword.Attack + _bow.Attack;
            Assert.That(_dwarf.GetAttack(), Is.EqualTo(totalAttack));
        }

        [Test]
        public void Dwarf_ShouldCalculateArmorCorrectly()
        {
            _dwarf.AddItem(_armor);
            _dwarf.AddItem(_helmet);
            _dwarf.AddItem(_shield);

            int totalArmor = _armor.Armor + _helmet.Armor + _shield.Armor;
            Assert.That(_dwarf.GetArmor(), Is.EqualTo(totalArmor));
        }

        [Test]
        public void Dwarf_ShouldTakeDamageCorrectly()
        {
            _dwarf.AddItem(_shield);
            int initialHealth = _dwarf.Health;

            _dwarf.Damage(60);

            int expectedHealth = initialHealth - (60 - _dwarf.GetArmor());
            Assert.That(_dwarf.Health, Is.EqualTo(expectedHealth));
        }

        [Test]
        public void Dwarf_ShouldNotGoBelowZeroHealth()
        {
            _dwarf.Damage(9999);
            Assert.That(_dwarf.Health, Is.EqualTo(0));
        }

        [Test]
        public void Dwarf_ShouldHealBackToFullHealth()
        {
            _dwarf.AddItem(_axe);
            _dwarf.Damage(40);

            _dwarf.Heal();
            Assert.That(_dwarf.Health, Is.EqualTo(100));
        }

        [Test]
        public void Dwarf_ShouldRemoveItemsCorrectly()
        {
            _dwarf.AddItem(_axe);
            _dwarf.AddItem(_sword);
            _dwarf.RemoveItem(_axe);

            int expectedAttack = _sword.Attack;
            Assert.That(_dwarf.GetAttack(), Is.EqualTo(expectedAttack));
        }

        [Test]
        public void Dwarf_ShouldHandleNoItemsGracefully()
        {
            Assert.That(_dwarf.GetAttack(), Is.EqualTo(0));
            Assert.That(_dwarf.GetArmor(), Is.EqualTo(0));
        }

        [Test]
        public void Dwarf_ItemsToString_ShouldContainReadableInfo()
        {
            string result = _axe.ToString();
            Assert.That(result, Does.Contain("axe").IgnoreCase);
            Assert.That(result, Does.Contain("attack"));
        }
    }
}
