using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProtoClicker
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CIconList iconList = new CIconList(100, 100, 100, 100);
        CEnemyTemplateList enemyTemplates = new CEnemyTemplateList();

        CRandomList randomizer = new CRandomList();

        CPlayer player;
        CEnemy activeEnemy = null;

        int lvl = 1;

        public MainWindow()
        {
            InitializeComponent();

            iconList.Load(@"/Resources/MonsterIcons/");

            string folder = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            enemyTemplates.loadFromXML(folder + @"/Resources/MonsterTemplates/monsters.xml");

            randomizer.addEnemyTemplates(enemyTemplates.getTemplates());

            player = new CPlayer(1, 5, 1.1, 20, 1.1);

            lb_playersGold.Content = player.Gold;
            lb_playersDamage.Content = player.Damage;

            spawnNewEnemy();

            button_next.IsEnabled = false;
            upgrade_button.IsEnabled = false;

            lb_lvl.Content = lvl;
        }

        void spawnNewEnemy()
        {
            activeEnemy = randomizer.getEnemy(lvl, iconList);

            lb_enemyName.Content = activeEnemy.Name;
            lb_hp.Content = activeEnemy.HitPoints;
            lb_gold.Content = activeEnemy.Gold;

            enemy_canvas.Children.Clear();
            enemy_canvas.Children.Add(activeEnemy.getIcon());
        }

        private void button_next_Click(object sender, RoutedEventArgs e)
        {
            lvl += 1;

            spawnNewEnemy();

            button_next.IsEnabled = false;

            lb_lvl.Content = lvl;
        }

        private void button_repeat_Click(object sender, RoutedEventArgs e)
        {
            spawnNewEnemy();
        }

        private void upgrade_button_Click(object sender, RoutedEventArgs e)
        {
            upgrade_button.IsEnabled = player.upgrade();

            lb_playersGold.Content = player.Gold;
            lb_playersDamage.Content = player.Damage;
        }

        private void enemy_canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (activeEnemy.HitPoints > 0)
            {
                if (CombatEngine.ResolveAttack(player, activeEnemy))
                {
                    upgrade_button.IsEnabled = player.gainGold(activeEnemy.Gold);

                    lb_playersGold.Content = player.Gold;
                    button_next.IsEnabled = true;
                }

                lb_hp.Content = activeEnemy.HitPoints;
            }
        }
    }
}
