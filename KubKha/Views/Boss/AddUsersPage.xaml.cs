using KubKha.Models;
using KubKha.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KubKha.Views.Boss
{
    /// <summary>
    /// Логика взаимодействия для AddUsersPage.xaml
    /// </summary>
    public partial class AddUsersPage : Page
    {
        public AddUsersPage()
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
        private void ButtonAddAnalytics_Click(object sender, RoutedEventArgs e)
        {
            ApplicationContext db = new ApplicationContext();
            string login = LoginAnalytics.Text;
            if (login != "")
            {
                string ID = idanalytics.Text;
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
                string password = passwordanalytics.Password;
                if(password != "")
                {
                    int Id = (int)id;
                    User analytic = new User(login, password, null, null, null, Id, 0);
                    User analytic1 = null;
                    analytic1 = db.Users.Where(b => b.login == login).FirstOrDefault();
                    if (analytic1 != null)
                    {
                        MessageBox.Show("Логин, с таким названием, уже занят.");
                    }
                    if(analytic1 == null)
                    {
                        db.Users.Add(analytic);
                        db.SaveChanges();
                        MessageBox.Show("Сохранение прошло успешно");
                        MessageBox.Show("Сейчас программа перезапуститься, чтобы внести измение");
                        Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                        Application.Current.Shutdown();
                    }
                }
                if(password == "")
                {
                    MessageBox.Show("Введите пароль!");
                }
            }
            if (login == "")
            {
                MessageBox.Show("Введите логин!");
            }
        }
    }
}
