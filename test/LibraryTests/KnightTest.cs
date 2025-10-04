using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace LibraryTests
{
    [TestFixture]
    public class KnightTest
    {
        private Knight _knight;
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
            _knight = new Knight("Arthur");

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
        public void Knight_ShouldAddNonMagicalItemsCorrectly()
        {
            _knight.AddItem(_axe);
            _knight.AddItem(_sword);
            _knight.AddItem(_bow);
            _knight.AddItem(_armor);
            _knight.AddItem(_helmet);
            _knight.AddItem(_shield);

            int expectedAttack = _axe.Attack + _sword.Attack + _bow.Attack;
            int expectedArmor = _armor.Armor + _helmet.Armor + _shield.Armor;

            Assert.That(_knight.GetAttack(), Is.EqualTo(expectedAttack));
            Assert.That(_knight.GetArmor(), Is.EqualTo(expectedArmor));
        }

        [Test]
        public void Knight_ShouldNotAddMagicalItems()
        {
            _knight.AddItem(_staff);
            _knight.AddItem(_spell);
            _knight.AddItem(_spellBook);

            Assert.That(_knight.GetAttack(), Is.EqualTo(0));
            Assert.That(_knight.GetArmor(), Is.EqualTo(0));
        }

        [Test]
        public void Knight_ShouldCalculateAttackCorrectly()
        {
            _knight.AddItem(_axe);
            _knight.AddItem(_sword);
            _knight.AddItem(_bow);

            int totalAttack = _axe.Attack + _sword.Attack + _bow.Attack;
            Assert.That(_knight.GetAttack(), Is.EqualTo(totalAttack));
        }

        [Test]
        public void Knight_ShouldCalculateArmorCorrectly()
        {
            _knight.AddItem(_armor);
            _knight.AddItem(_helmet);
            _knight.AddItem(_shield);

            int totalArmor = _armor.Armor + _helmet.Armor + _shield.Armor;
            Assert.That(_knight.GetArmor(), Is.EqualTo(totalArmor));
        }

        [Test]
        public void Knight_ShouldTakeDamageCorrectly()
        {
            _knight.AddItem(_shield);
            int initialHealth = _knight.Health;

            _knight.Damage(80);

            int expectedHealth = initialHealth - (80 - _knight.GetArmor());
            Assert.That(_knight.Health, Is.EqualTo(expectedHealth));
        }

        [Test]
        public void Knight_ShouldNotGoBelowZeroHealth()
        {
            _knight.Damage(9999);
            Assert.That(_knight.Health, Is.EqualTo(0));
        }

        [Test]
        public void Knight_ShouldHealBackToFullHealth()
        {
            _knight.AddItem(_axe);
            _knight.Damage(60);

            _knight.Heal();
            Assert.That(_knight.Health, Is.EqualTo(100));
        }

        [Test]
        public void Knight_ShouldRemoveItemsCorrectly()
        {
            _knight.AddItem(_axe);
            _knight.AddItem(_sword);
            _knight.RemoveItem(_axe);

            int expectedAttack = _sword.Attack;
            Assert.That(_knight.GetAttack(), Is.EqualTo(expectedAttack));
        }

        [Test]
        public void Knight_ShouldHandleNoItemsGracefully()
        {
            Assert.That(_knight.GetAttack(), Is.EqualTo(0));
            Assert.That(_knight.GetArmor(), Is.EqualTo(0));
        }

        [Test]
        public void Knight_ItemsToString_ShouldContainReadableInfo()
        {
            string result = _sword.ToString();
            Assert.That(result, Does.Contain("sword").IgnoreCase);
            Assert.That(result, Does.Contain("attack"));
        }
    }
}
