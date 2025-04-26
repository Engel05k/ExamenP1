using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Item
    {
        public string Name { get; private set; }
        public bool IsLifeItem { get; private set; }
        public int Amount { get; private set; }

        public Item(string name, bool isLifeItem, int amount)
        {
            Name = name;
            IsLifeItem = isLifeItem;
            Amount = amount;
        }
    }
}
