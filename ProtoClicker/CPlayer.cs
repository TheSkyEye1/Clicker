using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoClicker
{
    public class CPlayer    //класс, описывающий игрока
    {
        //уровень улучшения
        int lvl;
        //количество золота у игрока
        int gold;
        //урон и модификатор урона
        int damage;
        double damageModifier;
        //цена и модификатор цены улучшения
        int upgradeCost;
        double upgradeModifier;

        public int Gold
        {  
            get { return gold; } 
        }

        public int UpgradeCost
        {
            get { return upgradeCost; }
        }

        public int Damage
        { 
            get { return damage; } 
        }

        public double DamageModifier
        {
            get { return damageModifier; }
        }

        public CPlayer(int gold, int damage, double damageModifier, int upgradeCost, double upgradeModifier)
        {
            lvl = 1;
            this.gold = gold;
            this.damage = damage;
            this.damageModifier = damageModifier;
            this.upgradeCost = upgradeCost;
            this.upgradeModifier = upgradeModifier;
        }

        public bool gainGold(int gold)   //возвращает true если после увеличения золота доступен апгрейд
        {
            this.gold += gold;

            if (this.gold >= upgradeCost)
                return true;

            return false;
        }

        public bool upgrade()   //возвращает true если после апгрейда всё ещё доступен апгрейд
        {
            gold -= upgradeCost;
            upgradeCost = (int)(upgradeCost * (upgradeModifier * lvl));
            damage = (int)(damage * (damageModifier))+1;
            lvl += 1;

            if (gold < upgradeCost)
                return false;

            return true;
        }
    }
}
