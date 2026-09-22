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
        public Classes.PersonInfo Player = new Classes.PersonInfo("Student", 100, 10, 1, 0, 0, 5);

        public MainWindow()

        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            InitializeComponent();

            UserInfoPlayer();
            Enemys.Add(new Classes.PersonInfo("Название врага №1", 100, 20, 1, 15, 5, 20));
            Enemys.Add(new Classes.PersonInfo("Название врага №2", 20, 5, 1, 5, 2, 5));
            Enemys.Add(new Classes.PersonInfo("Название врага №3", 50, 3, 1, 10, 10, 15));
            dispatcherTimer.Tick += AttackPlayer;
            dispatcherTimer.Interval = new System.TimeSpan(0, 0, 10);
        }
        public void AttackPlayer(object sender, System.EventArgs e)
        {

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
            playerArmor.Content = "Броня: " + playerArmor;
            playerLevel.Content = "Уровень: " + playerLevel;
            playerGlasses.Content = "Опыт: " + playerGlasses;
            playerMoney.Content = "Монеты: " + playerMoney;
        }
    }
}
