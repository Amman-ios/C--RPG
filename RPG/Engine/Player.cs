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
        public List<InventoryItem> Inventory { get; set; }
        public List<PlayerQuest> Questions { get; set; }
        Inventory = new List<InventoryItem>();
        Quest = new List<PlayerQuest>();
    }
}