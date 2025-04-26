using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Player
    {
        public string Name { get; private set; }
        public int Life { get; private set; }
        public int Mana { get; private set; }

        private int damage;
        private List<Item> items = new List<Item>();
        private List<Power> powers = new List<Power>();

        public Player(string name)
        {
            Name = name;
            Life = 100;
            Mana = 50;
            damage = 10;
        }

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public void AddPower(Power power)
        {
            powers.Add(power);
        }

        public void UseItem()
        {
            if (items.Count > 0)
            {
                Item item = items[0];
                if (item.IsLifeItem)
                {
                    Life += item.Amount;
                    Console.WriteLine("Usaste " + item.Name + ". Vida ahora: " + Life);
                }
                else
                {
                    Mana += item.Amount;
                    Console.WriteLine("Usaste " + item.Name + ". Maná ahora: " + Mana);
                }
                items.RemoveAt(0);
            }
            else
            {
                Console.WriteLine("No tienes items!");
            }
        }

        public void Attack(Enemy enemy)
        {
            enemy.ReceiveDamage(damage);
        }

        public void UsePower(Enemy enemy)
        {
            if (powers.Count > 0)
            {
                Power power = powers[0];
                if (Mana >= power.ManaCost)
                {
                    Mana -= power.ManaCost;
                    enemy.ReceiveDamage(power.Damage);
                    Console.WriteLine("Usaste " + power.Name + ". Vida del enemigo: " + enemy.Life);
                }
                else
                {
                    Console.WriteLine("No tienes suficiente maná!");
                }
            }
        }

        public void ReceiveDamage(int amount)
        {
            Life -= amount;
        }

        public List<Item> GetItems()
        {
            return items;
        }
    }
}
