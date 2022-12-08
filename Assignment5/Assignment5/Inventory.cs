using System;
using System.Collections.Generic;

namespace Assignment5
{
    public class Inventory
    {
        private Dictionary<Item, int> items = new Dictionary<Item, int>();
        private int availableSlots;
        public int AvailableSlots { get => availableSlots; }
        private int maxSlots;
        public int MaxSlots { get => maxSlots; }

        public Inventory(int slots)
        {
            maxSlots = slots;
            availableSlots = maxSlots;
        }
        /// <summary>
        /// Removes all the items, and restore the original number of slots.
        /// </summary>
        public void Reset()
        {
            items.Clear();
            availableSlots = maxSlots;
        }
        /// <summary>
        /// Removes the item from the items dictionary if the count is 1 otherwise decrease the quantity.
        /// </summary>
        /// <param name="name">The item name</param>
        /// <param name="found">The item if found</param>
        /// <returns>True if you find the item, and false if it does not exist.</returns>
        public bool TakeItem(Item item) 
        {
            if (items.ContainsKey(item))
            {
                --items[item];

                if (items[item] == 0) // Empty
                {
                    items.Remove(item);
                    ++availableSlots;
                }

                return true;
            }

            return false;
        }
        /// <summary>
        /// Checks if there is space for a unique item
        /// </summary>
        /// <param name="newItem"></param>
        /// <returns></returns>
        public bool AddItem(Item newItem)
        {
            if (items.ContainsKey(newItem) == true)
            {
                ++items[newItem];
                return true;
            }
            else
            {
                if (availableSlots == 0)
                {
                    Console.WriteLine($"CANNOT ADD - No slots avaialable.");
                    return false;
                }

                items.Add(newItem, 1);
                --availableSlots;
                return true;
            }
        }

        /// <summary>
        /// Iterates through the dictionary and create a list of all the items.
        /// </summary>
        /// <returns></returns>
        public List<Item> ListAllItems()
        {
            List<Item> newList = new List<Item>();

            foreach (var item in items)
            {
                for (int i = 0; i < item.Value; ++i)
                {
                    newList.Add(item.Key);
                }
            }

            return newList;
        }
    }
}