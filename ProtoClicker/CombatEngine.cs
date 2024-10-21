using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoClicker
{
    public static class CombatEngine    //класс для вычисления повреждений наносимых игроком противнику
    {
        public static bool ResolveAttack(CPlayer player, CEnemy enemy)  //возвращает true если противник умирает
        {
            enemy.HitPoints -= player.Damage;   //формулу можно усложнять, добавляя параметры брони, клонения и т.д.
                                                //поэтому она в отдельном классе
            if (enemy.HitPoints <= 0)
                return true;

            return false; 
        }
    }
}
