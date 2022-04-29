using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Weapon : Item
    {
        public int MinDMG { get; set; }
        public int MaxDMG { get; set; }

        public Weapon(int id, string name, string namePlural, int minDMG,int maxDMG, int price) : base(id, name, namePlural, price)
        {
            MinDMG = minDMG;
            MaxDMG = maxDMG;
        }
    }
}
