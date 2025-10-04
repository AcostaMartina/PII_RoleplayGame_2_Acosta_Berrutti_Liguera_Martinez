using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace LibraryTests
{
    [TestFixture]
    public class WizardTest
    {
        private Wizard _wizard;
        private Staff _staff;
        private Spell _spellFire;
        private Spell _spellIce;
        private SpellsBook _spellBook;
        private Axe _axe;
        private Sword _sword;
        private Shield _shield;
        private Helmet _helmet;

        [SetUp]
        public void Setup()
        {
            _wizard = new Wizard("Gandalf");

            _staff = new Staff("Staff", 100, 100, true);
            _spellFire = new Spell("Fire", 70, 70, true);
            _spellIce = new Spell("Ice", 60, 80, true);
            _spellBook = new SpellsBook();
            _spellBook.AddSpell(_spellFire);
            _spellBook.AddSpell(_spellIce);

            _axe = new Axe("Axe", 25, false);
            _sword = new Sword("Sword", 20, false);
            _shield = new Shield("Shield", 14, false);
            _helmet = new Helmet("Helmet", 18, false);
        }

        [Test]
        public void Wizard_ShouldAddMagicalItemsCorrectly()
        {
            _wizard.AddItem(_staff);
            _wizard.AddItem(_spellFire);
            _wizard.AddItem(_spellBook);

            int expectedAttack = _staff.Attack + _spellFire.Attack + _spellBook.Attack;
            int expectedArmor = _staff.Armor + _spellFire.Armor + _spellBook.Armor;

            Assert.That(_wizard.GetAttack(), Is.EqualTo(expectedAttack));
            Assert.That(_wizard.GetArmor(), Is.EqualTo(expectedArmor));
        }

        [Test]
        public void Wizard_ShouldNotAddNonMagicalItems()
        {
            _wizard.AddItem(_axe);
            _wizard.AddItem(_sword);
            _wizard.AddItem(_shield);
            _wizard.AddItem(_helmet);

            Assert.That(_wizard.GetAttack(), Is.EqualTo(0));
            Assert.That(_wizard.GetArmor(), Is.EqualTo(0));
        }

        [Test]
        public void Wizard_ShouldCalculateTotalAttackIncludingSpells()
        {
            _wizard.AddItem(_staff);
            _wizard.AddItem(_spellBook);

            int expectedAttack = _staff.Attack + _spellBook.Attack;
            Assert.That(_wizard.GetAttack(), Is.EqualTo(expectedAttack));
        }

        [Test]
        public void Wizard_ShouldCalculateTotalArmorIncludingSpells()
        {
            _wizard.AddItem(_staff);
            _wizard.AddItem(_spellBook);

            int expectedArmor = _staff.Armor + _spellBook.Armor;
            Assert.That(_wizard.GetArmor(), Is.EqualTo(expectedArmor));
        }

        [Test]
        public void Wizard_ShouldTakeDamageCorrectly()
        {
            _wizard.AddItem(_staff);
            int initialHealth = _wizard.Health;

            _wizard.Damage(250);

            int expectedHealth = initialHealth - (250 - _wizard.GetArmor());
            if (expectedHealth < 0) expectedHealth = 0;

            Assert.That(_wizard.Health, Is.EqualTo(expectedHealth));
        }


        [Test]
        public void Wizard_ShouldNotGoBelowZeroHealth()
        {
            _wizard.AddItem(_staff);
            _wizard.Damage(9999);
            Assert.That(_wizard.Health, Is.EqualTo(0));
        }

        [Test]
        public void Wizard_ShouldHealBackToFullHealth()
        {
            _wizard.AddItem(_staff);
            _wizard.Damage(200);

            _wizard.Heal();
            Assert.That(_wizard.Health, Is.EqualTo(100));
        }

        [Test]
        public void Wizard_ShouldRemoveItemsCorrectly()
        {
            _wizard.AddItem(_staff);
            _wizard.AddItem(_spellBook);
            _wizard.RemoveItem(_staff);

            int expectedAttack = _spellBook.Attack;
            Assert.That(_wizard.GetAttack(), Is.EqualTo(expectedAttack));
        }

        [Test]
        public void Wizard_ShouldHandleNoItemsGracefully()
        {
            Assert.That(_wizard.GetAttack(), Is.EqualTo(0));
            Assert.That(_wizard.GetArmor(), Is.EqualTo(0));
        }
    }
}
