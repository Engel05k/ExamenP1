using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Enemy
    {
        public string Name { get; private set; }
        public int Life { get; private set; }

        private int damage;
        private List<Item> items = new List<Item>();

        public Enemy(string name)
        {
            Name = name;
            Life = 50;
            damage = 5;
        }

        public void Attack(Player player)
        {
            player.ReceiveDamage(damage);
        }

        public void ReceiveDamage(int amount)
        {
            Life -= amount;
        }

        public bool IsDead()
        {
            return Life <= 0;
        }

        public List<Item> GetItems()
        {
            return items;
        }

        public void AddItem(Item item)
        {
            items.Add(item);
        }
    }
}
