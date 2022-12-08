using NUnit.Framework;
using System.Collections.Generic;

namespace Assignment5
{
    [TestFixture]
    public class InventoryTest
    {
        private Inventory _inventory = new Inventory(_maxSlot);
        private const int _maxSlot = 8;
        private Item _bronzeSword = null;
        private Item _smallHealthPotion = null;
        private Item _fragileKey = null;

        [SetUp]
        public void SetUp()
        {
            _bronzeSword = new Item("Bronze Sword", 5, ItemGroup.Equipment);
            _smallHealthPotion = new Item("Small Health Potion", amount: 10, ItemGroup.Consumable);
            _fragileKey = new Item("Fragile Key", 1, ItemGroup.Key);
        }

        [TearDown]
        public void CleanUp()
        {
            _inventory.Reset();
        }

        [Test]
        public void AddItemTrueAndSlotDecreases()
        {
            Assert.IsTrue(_inventory.AddItem(_bronzeSword));
            Assert.AreEqual(_inventory.AvailableSlots, _maxSlot - 1);
        }

        [Test]
        public void RemoveItemTrueAndSlotIncrease()
        {
            Assert.IsTrue(_inventory.AddItem(_bronzeSword));
            Assert.AreEqual(_inventory.AvailableSlots, _maxSlot - 1);
            Assert.IsTrue(_inventory.TakeItem(_bronzeSword));
            Assert.AreEqual(_inventory.AvailableSlots, _maxSlot);
        }

        [Test]
        public void RemoveItemFalseAndSlotRemainsSame()
        {
            Assert.IsFalse(_inventory.TakeItem(_bronzeSword));
            Assert.AreEqual(_inventory.AvailableSlots, _maxSlot);
        }

        [Test]
        public void Reset()
        {
            Assert.IsTrue(_inventory.AddItem(_bronzeSword));
            Assert.IsTrue(_inventory.AddItem(_fragileKey));
            Assert.IsTrue(_inventory.AddItem(_smallHealthPotion));
            Assert.AreEqual(_inventory.AvailableSlots, _maxSlot - 3);
            _inventory.Reset();
            Assert.AreEqual(_inventory.AvailableSlots, _maxSlot);
        }

        [Test]
        public void ValidateStackAndList()
        {
            List<Item> threeBronzeSwordTestList = new List<Item>();
            for (int i = 0; i < 3; ++i)
            {
                Assert.IsTrue(_inventory.AddItem(_bronzeSword));
                threeBronzeSwordTestList.Add(_bronzeSword);
            }
            Assert.AreEqual(_inventory.AvailableSlots, _maxSlot - 1);
            Assert.AreEqual(threeBronzeSwordTestList.Count, 3);
            Assert.AreEqual(threeBronzeSwordTestList, _inventory.ListAllItems());
        }
    }
}