﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Monster : LivingCreature
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int MaxDMG { get; set; }
        public int RewardXP { get; set; }
        public int RewardGold { get; set; }
    }
}
