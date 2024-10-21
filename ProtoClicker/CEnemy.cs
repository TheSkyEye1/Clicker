using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace ProtoClicker
{
    public class CEnemy //класс, описывающий конкретного противника
    {
        string name;

        int hitPoints;
        int gold;

        Rectangle icon;

        public string Name
        {
            get { return name; }
        }

        public int HitPoints
        { 
            get { return hitPoints; } 
            set { hitPoints = value; }
        }

        public int Gold
        {
            get { return gold; }
        }

        public CEnemy(string name, int hitPoints, int gold, Rectangle icon) 
        { 
            this.name = name;
            this.hitPoints = hitPoints;
            this.gold = gold;

            this.icon = icon;
        }

        public Rectangle getIcon()
        {
            return icon;
        }
    }
}
