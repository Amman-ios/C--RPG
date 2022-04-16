using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Player : LivingCreature
    {
        public int Gold { get; set; }
        public int XP { get; set; }
        public int LVL { get; set; }
        public Location CurrentLocation { get; set; }
        public List<InventoryItem> Inventory { get; set; }
        public List<PlayerQuest> Quest { get; set; }

        public Player(int currentHP, int maxHP, int gold, int xp,int lvl) : base(currentHP, maxHP)
        {
            Gold = gold;
            XP = xp;
            LVL = lvl;
            Inventory = new List<InventoryItem>();
            Quest = new List<PlayerQuest>();
        }
    }
}