using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private static readonly Random random = new Random();
        public Classes.PersonInfo Player = new Classes.PersonInfo("Student", 100, 10, 1, 0, 0, 5, 5, 0, "Image/knight.png");
        public List<Classes.PersonInfo> Enemys = new List<Classes.PersonInfo>();
        public Classes.PersonInfo Enemy;
        public MainWindow()

        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            InitializeComponent();

            UserInfoPlayer();
            Enemys.Add(new Classes.PersonInfo("Название врага №1", 30, 10, 1, 15, 5, 0, 5, 20, "Image/monstr.png"));
            Enemys.Add(new Classes.PersonInfo("Название врага №2", 20, 5, 1, 5, 2, 5, 5, 20, "Image/monser2.png"));
            Enemys.Add(new Classes.PersonInfo("Название врага №3", 25, 3, 1, 10, 10, 15, 5, 20, "Image/monster3.png"));
            dispatcherTimer.Tick += AttackPlayer;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 10);
            dispatcherTimer.Start();
            SelectEnemy();

        }
        public void SelectEnemy()
        {
            int Id = new Random().Next(0, Enemys.Count);
            Enemy = new Classes.PersonInfo(
                Enemys[Id].Name,
                Enemys[Id].Health,
                Enemys[Id].Armor,
                Enemys[Id].Level,
                Enemys[Id].Glasses,
                Enemys[Id].Money,
                Enemys[Id].Damage,
                Enemys[Id].Pierce,
                Enemys[Id].ContrAttack,
                Enemys[Id].Image);
            emptyImage.Source = new BitmapImage(new Uri(Enemy.Image, UriKind.Relative));
            emptyHealth.Content = "Жизненные показатели: " + Enemy.Health;
            emptyArmor.Content = "Броня: " + Enemy.Armor;
        }
        public void AttackPlayer(object sender, System.EventArgs e)
        {
            Player.Health -= Convert.ToInt32(Enemy.Damage * 100f / (100f - Player.Armor));
            UserInfoPlayer();
            if (Player.Health <= 0)
            {
                MessageBox.Show("Ты умер");
                SelectEnemy();
                Player = new Classes.PersonInfo("Student", 100, 10, 1, 0, 0, 5, 5, 0, "Image/knight.png");
            }
            UserInfoPlayer();
        }
        public void AttackEnemy(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (random.Next(1, 101) > Player.Pierce) { Enemy.Health -= Convert.ToInt32(Player.Damage / 100f * (100f - Enemy.Armor)); }
            else { Enemy.Health -= Convert.ToInt32(Player.Damage); }

            if (Enemy.Health <= 0)
            {
                Player.Glasses += Enemy.Glasses;
                Player.Money += Enemy.Money;

                UserInfoPlayer();

                SelectEnemy();
            }
            else
            {
                emptyHealth.Content = "Жизненные показатели: " + Enemy.Health;
                emptyArmor.Content = "Броня: " + Enemy.Armor;

                if (random.Next(1, 101) <= Enemy.ContrAttack) { AttackPlayer(this, EventArgs.Empty); }
            }
        }
        public void UserInfoPlayer()
        {

            if (Player.Glasses > 100 * Player.Level)
            {
                Player.Level++;
                Player.Glasses = 0;
                Player.Health += 100;
                Player.Damage++;
                Player.Armor++;
            }
            playerHealth.Content = "Жизенные показатели: " + Player.Health;
            playerArmor.Content = "Броня: " + Player.Armor;
            playerLevel.Content = "Уровень: " + Player.Level;
            playerGlasses.Content = "Опыт: " + Player.Glasses;
            playerMoney.Content = "Монеты: " + Player.Money;
        }
    }
}
