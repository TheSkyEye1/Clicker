using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace ProtoClicker
{
    public class CRandomList    //класс, для выбора объектов из списка по их вероятностям
    {
        Random rng;

        List<CEnemyTemplate> enemies;

        public CRandomList() 
        { 
            rng = new Random();
            enemies = new List<CEnemyTemplate>();
        }

        void insertEnemyTemplate(CEnemyTemplate enemyTemplate)  //объекты отсортированы по возрастанию вероятности их появления
        {
            for (int i = 0; i < enemies.Count; i++)
                if (enemies[i].SpawnChance > enemyTemplate.SpawnChance)
                {
                    enemies.Insert(i, enemyTemplate);
                    return;
                }

            enemies.Add(enemyTemplate);
        }

        void normalizeChances() //нормализация шансов выбора объектов, сумма шансов должна быть равна 1
        {
            double sum = 0;
            //enemies - List<CEnemyTemplate>
            for (int i = 0; i < enemies.Count; i++)
                sum += enemies[i].SpawnChance;

            for (int i = 0; i < enemies.Count; i++)
                enemies[i].SpawnChance /= sum;
        }

        public void addEnemyTemplates(List<CEnemyTemplate> enemyTemplates)
        {
            foreach (CEnemyTemplate et in enemyTemplates)
                insertEnemyTemplate(et);

            normalizeChances();
        }

        CEnemyTemplate findByChance(double chance)  //поиск объекта по выповшей вероятности
        {
            double sum = 0;

            for(int i = 0; i < enemies.Count; i++)
            {
                sum += enemies[i].SpawnChance;

                if (sum >= chance) return enemies[i];
            }

            return null;
        }

        public CEnemy getEnemy(int lvl, CIconList icons)    //создание экземпляра противника из выбранного случайно шаблона
        {
            double chance = rng.Next(1, 100) / 100.0;

            CEnemyTemplate et = findByChance(chance);

            string name = et.Name;
            int hp = (int)(et.BaseLife * (lvl * et.LifeModifier));
            int gold =(int)(et.BaseGold * (lvl * et.GoldModifier));

            Rectangle icon = icons.findByName(et.IconName).CloneIcon();

            CEnemy newEnemy = new CEnemy(name, hp, gold, icon);

            return newEnemy;
        }

    }
}
