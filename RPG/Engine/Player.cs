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

        public Player(int currentHP, int maxHP, int gold, int xp,int lvl) : base(currentHP, maxHP)
        {
            Gold = gold;
            XP = xp;
            LVL = lvl;
        }
    }
}