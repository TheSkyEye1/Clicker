﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoClicker
{
    public class CEnemyTemplate
    {
        string name;
        string iconName;

        int baseLife;
        double lifeModifier;
        
        int baseGold;
        double goldModifier;

        double spawnChance;

        public string Name
        { 
            get { return name; }
            set { if (value.Length > 0) name = value; else name = "unknown"; }
        }

        public string IconName
        { 
            get { return iconName; } 
            set { if (value.Length > 0) iconName = value; else iconName = "unknown"; } 
        }
        public int BaseLife
        { 
            get { return baseLife; } 
            set { if (value > 0) baseLife = value; else baseLife = 10; } 
        }

        public double LifeModifier
        { 
            get { return lifeModifier; } 
            set { if (value > 0) lifeModifier = value; else lifeModifier = 1.1; } 
        }
        
        public int BaseGold
        { 
            get { return baseGold; } 
            set { if (value > 0) baseGold = value; else baseGold = 10; } 
        }
        
        public double GoldModifier
        { 
            get { return goldModifier; } 
            set { if (value > 0) goldModifier = value; else goldModifier = 1.1; } 
        }
        
        public double SpawnChance
        { 
            get { return spawnChance; } 
            set { if (value > 0) spawnChance = value; else spawnChance = 50; } 
        }
    }
}
