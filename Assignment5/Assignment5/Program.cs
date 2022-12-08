using System;
using System.Collections.Generic;

namespace Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Adventure of Assignment 5!");

            Character hero = new Character("Bob", RaceCategory.Human, 100);
            Inventory inventory = new Inventory(8);
            Item bronzeSword = new Item("Bronze Sword", 5, ItemGroup.Equipment);
            Item smallHealthPotion = new Item("Small Health Potion", 10, ItemGroup.Consumable);
            Item fragileKey = new Item("Fragile Key", 1, ItemGroup.Key);

            inventory.AddItem(bronzeSword);
            Console.WriteLine($"{hero.Name} has found a {bronzeSword.Name}");

            Console.WriteLine($"{hero.Name} has entered the forest");

            string monster = "goblin";
            int damage = 10;

            Console.WriteLine($"A {monster} appeared and attacks {hero.Name}");
            Console.WriteLine($"{hero.Name} takes {damage} damage");

            hero.TakeDamage(damage);
            Console.WriteLine(hero);

            Console.WriteLine($"{hero.Name} flees from the enemy");

            Console.WriteLine($"{hero.Name} finds a {smallHealthPotion.Name}");
            inventory.AddItem(smallHealthPotion);

            if (inventory.TakeItem(smallHealthPotion))
            {
                hero.RestoreHealth(smallHealthPotion.Amount);
                Console.WriteLine($"{hero.Name} drinks {smallHealthPotion.Name} and restores {smallHealthPotion.Amount} health.");
            }
            Console.WriteLine(hero);

            Console.WriteLine($"{hero.Name} finds a {smallHealthPotion.Name} and {fragileKey.Name}.");
            inventory.AddItem(smallHealthPotion);
            inventory.AddItem(fragileKey);

            if (hero.IsAlive)
            {
                Console.WriteLine($"Congratulations! {hero.Name} survived.");

                string loot = "";

                List<Item> inventoryList = inventory.ListAllItems();
                for (int i = 0; i < inventoryList.Count; ++i)
                {
                    if (i == 0)
                    {
                        loot += $"{inventoryList[i].Name}";
                    }
                    else if (i == inventoryList.Count - 1)
                    {
                        loot += $", and {inventoryList[i].Name}";
                    }
                    else
                    {
                        loot += $", {inventoryList[i].Name}";
                    }
                }

                Console.WriteLine($"Your total loot was {loot}.");
            }
            else
            {
                Console.WriteLine($"{hero.Name} has died.");
            }
        }
    }
}