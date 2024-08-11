using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using KubKha.Models;
using KubKha.Services;

namespace KubKha.Views.Boss
{
    /// <summary>
    /// Логика взаимодействия для StartPageBoss.xaml
    /// </summary>
    public partial class StartPageBoss : Page
    {
        public StartPageBoss()
        {
            InitializeComponent();
            
        }
        private void NumberTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Проверяем, является ли вводимый символ цифрой
            if (!char.IsDigit(e.Text[0]))
            {
                e.Handled = true; // Предотвращаем ввод нецифровых символов
            }
        }

        private void NumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Очищаем текстовое поле, если в нем есть нецифровые символы
            string text = ((TextBox)sender).Text;
            if (!text.All(char.IsDigit))
            {
                ((TextBox)sender).Text = string.Empty;
            }
            
        }

        private void Buttonmenuinpage_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ButtonAddTeam_Click(object sender, RoutedEventArgs e)
        {
            ApplicationContext db = new ApplicationContext();
            string teamname = TeamName.Text;
            if(teamname != "")
            {
                string ID = IDTeam.Text;
                long id = 0;
                if (ID == "")
                {
                    ID = "0";
                    id = (long)Convert.ToDouble(ID);
                }
                id = (long)Convert.ToDouble(ID);
                if (ID != null && id > 2000000000)
                {
                    MessageBox.Show("ID команды не должно превышать 2 млрд");
                    id = 2000000000;
                }
                string teammoney = TeamMoney.Text;
                long money = 0;
                if (teammoney == "")
                {
                    teammoney = "0";
                    money = (long)Convert.ToDouble(teammoney);
                }
                money = (long)Convert.ToDouble(teammoney);
                if (teammoney != "0" && money < 100000)
                {
                    MessageBox.Show("Сумма стартапа должно начинаться свыше 100000 рублей");
                    money = 100000;
                }
                if (teammoney != "0" && money > 2000000000)
                {
                    MessageBox.Show("Сумма стартапа не должно превышать 2 млрд рублей ");
                    money = 2000000000;
                }
                int Id = (int)id;
                string Money = Convert.ToString(money);
                string teamdescription = TeamDescription.Text;
                Team team = new Team(teamname, Id, Money, teamdescription);
                Team team1 = null;
                team1 = db.Teams.Where(b => b.idteam == Id).FirstOrDefault();
                if (team1 != null)
                {
                    MessageBox.Show("ID команды уже занят");
                }
                if (team1 == null)
                {
                    db.Teams.Add(team);
                    db.SaveChanges();
                    MessageBox.Show("Сохранение прошло успешно");
                    MessageBox.Show("Сейчас программа перезапуститься, чтобы внести измение");
                    Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    Application.Current.Shutdown();
                }
            }
            if(teamname == "")
            {
                MessageBox.Show("Введите название команды");
            }
              
        }
    }
}
