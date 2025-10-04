using NUnit.Framework;
using Ucu.Poo.RoleplayGame;
using System.Linq;

namespace LibraryTests
{
    [TestFixture]
    public class ArcherTest
    {
        private Archer _archer;
        private Axe _axe;
        private Sword _sword;
        private Bow _bow;
        private Armor _armor;
        private Helmet _helmet;
        private Shield _shield;
        private Staff _staff; 
        private Spell _spell;
        private SpellsBook _spellsBook; 

        [SetUp]
        public void Setup()
        {
            _archer = new Archer("Legolas");


            _axe = new Axe("Axe", 25, false);
            _sword = new Sword("Sword", 20, false);
            _bow = new Bow("Bow", 15, false);

            _armor = new Armor("Armor", 25, false);
            _helmet = new Helmet("Helmet", 18, false);
            _shield = new Shield("Shield", 14, false);
            
            _staff = new Staff("Staff", 100, 100, true);
            _spell = new Spell("Fire", 70, 70, true);
            _spellsBook = new SpellsBook();
            _spellsBook.AddSpell(_spell);
        }

        [Test]
        public void Archer_ShouldAddNonMagicalItemsCorrectly()
        {
            _archer.AddItem(_axe);
            _archer.AddItem(_sword);
            _archer.AddItem(_bow);
            _archer.AddItem(_armor);
            _archer.AddItem(_helmet);
            _archer.AddItem(_shield);

            int expectedAttack = _axe.Attack + _sword.Attack + _bow.Attack;
            int expectedArmor = _armor.Armor + _helmet.Armor + _shield.Armor;

            Assert.That(_archer.GetAttack(), Is.EqualTo(expectedAttack));
            Assert.That(_archer.GetArmor(), Is.EqualTo(expectedArmor));
        }

        [Test]
        public void Archer_ShouldNotAddMagicalItems()
        {
            _archer.AddItem(_staff);
            _archer.AddItem(_spell);
            _archer.AddItem(_spellsBook);

           
            Assert.That(_archer.GetAttack(), Is.EqualTo(0));
            Assert.That(_archer.GetArmor(), Is.EqualTo(0));
        }

        [Test]
        public void Archer_ShouldCalculateAttackCorrectly()
        {
            _archer.AddItem(_axe);
            _archer.AddItem(_sword);
            _archer.AddItem(_bow);

            int totalAttack = _axe.Attack + _sword.Attack + _bow.Attack;
            Assert.That(_archer.GetAttack(), Is.EqualTo(totalAttack));
        }

        [Test]
        public void Archer_ShouldCalculateArmorCorrectly()
        {
            _archer.AddItem(_armor);
            _archer.AddItem(_helmet);
            _archer.AddItem(_shield);

            int totalArmor = _armor.Armor + _helmet.Armor + _shield.Armor;
            Assert.That(_archer.GetArmor(), Is.EqualTo(totalArmor));
        }

        [Test]
        public void Archer_ShouldReduceHealthWhenTakingDamage()
        {
            _archer.AddItem(_shield); 
            int initialHealth = _archer.Health;

            _archer.Damage(50); 

            Assert.That(_archer.Health, Is.EqualTo(initialHealth - (50 - _shield.Armor)));
        }

        [Test]
        public void Archer_ShouldNotHaveNegativeHealth()
        {
            _archer.Damage(9999);
            Assert.That(_archer.Health, Is.EqualTo(0));
        }

        [Test]
        public void Archer_ShouldHealBackToFullHealth()
        {
            _archer.Damage(40);
            Assert.That(_archer.Health, Is.LessThan(100));

            _archer.Heal();
            Assert.That(_archer.Health, Is.EqualTo(100));
        }

        [Test]
        public void Archer_ShouldRemoveItemsCorrectly()
        {
            _archer.AddItem(_bow);
            _archer.AddItem(_axe);
            _archer.RemoveItem(_axe);

            int expectedAttack = _bow.Attack; 

            Assert.That(_archer.GetAttack(), Is.EqualTo(expectedAttack));
        }

        [Test]
        public void Archer_ShouldHandleNoItemsGracefully()
        {
            Assert.That(_archer.GetAttack(), Is.EqualTo(0));
            Assert.That(_archer.GetArmor(), Is.EqualTo(0));
        }

        [Test]
        public void Archer_ItemsToString_ShouldContainReadableInfo()
        {
            string result = _axe.ToString();
            Assert.That(result, Does.Contain("axe").IgnoreCase);
            Assert.That(result, Does.Contain("attack"));
        }
    }
}
