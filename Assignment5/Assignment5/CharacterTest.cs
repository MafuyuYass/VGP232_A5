using NUnit.Framework;

namespace Assignment5
{
    [TestFixture]
    public class CharacterTest
    {
        private Character _character = null;

        [SetUp]
        public void SetUp()
        {
            _character = new Character("Joe", RaceCategory.Human, 100);
        }

        [TearDown]
        public void CleanUp()
        {

        }

        [Test]
        public void TakeDamageCorrectHealth()
        {
            _character.Health = 100;
            _character.TakeDamage(10);
            Assert.AreEqual(_character.Health, 90);
        }

        [Test]
        public void TakeDamageIsAliveFalse()
        {
            _character.Health = 100;
            _character.TakeDamage(100);
            Assert.IsTrue(_character.IsAlive == false);
        }

        [Test]
        public void RestoreHealthCorrectHealth()
        {
            _character.Health = 80;
            _character.MaxHealth = 100;
            _character.RestoreHealth(10);
            Assert.AreEqual(_character.Health, 90);
        }

        [Test]
        public void RestoreHealthIsAliveTrue()
        {
            _character.Health = 100;
            _character.MaxHealth = 100;
            _character.TakeDamage(100);
            Assert.IsTrue(_character.IsAlive == false);
            _character.RestoreHealth(15);
            Assert.IsTrue(_character.IsAlive == true);
        }
    }
}