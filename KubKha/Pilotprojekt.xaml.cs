using KubKha.Models;
using KubKha.Services;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
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
using System.Windows.Media.Animation;
using KubKha.Views.Boss;
using System.Data.Entity.Migrations;
using System.Windows.Controls;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Wpf;

namespace KubKha
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public partial class Pilotprojekt : Window
    {
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
        int i = 0;
        public static Pilotprojekt window;
        ApplicationContext db = new ApplicationContext();


        public Pilotprojekt()
        {
            ApplicationContext db = new ApplicationContext();
            InitializeComponent();
            List<Team> teams = db.Teams.ToList();
            ListProject.ItemsSource = teams;
           
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {


            i++;
            if (i % 2 != 0)
            {
                ResizeMode = ResizeMode.NoResize;
                WindowStyle = WindowStyle.None;
                WindowState = WindowState.Maximized;
                ScaleTransform scale = new ScaleTransform();
                scale.ScaleX = 1;
                scale.ScaleY = 0.8;
                BossPage.RenderTransform = scale;
                ChangeBossborder.RenderTransform = scale;
                MainMenuAnalytic.RenderTransform = scale;


            }
            else
            {
                ResizeMode = ResizeMode.NoResize;
                WindowStyle = WindowStyle.None;
                WindowState = WindowState.Normal;
                ScaleTransform scale = new ScaleTransform();
                scale.ScaleX = 1;
                scale.ScaleY = 1;
                BossPage.RenderTransform = scale;
                ChangeBossborder.RenderTransform = scale;
                MainMenuAnalytic.RenderTransform = scale;
            }


        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void MovingWin(object sender, MouseButtonEventArgs e) => DragMove();

        private void authorization(object sender, RoutedEventArgs e)
        {
            string login_text = login.Text;
            string password_text = password.Password;
            if (login_text == "")
            {
                MessageBox.Show("Введите логин!");
            }
            if (password_text == "")
            {
                MessageBox.Show("Введите пароль!");
            }
            Boss validation = null;
            Boss boss = new Boss(login_text, password_text, null, null, null);
            List<Boss> bosses = db.Bosses.ToList();
            List<int> bossid = bosses.Select(b => b.ID).ToList();
            validation = db.Bosses.Where(b => b.login == login_text && b.password == password_text).FirstOrDefault();
            User user = null;
            user = db.Users.Where(b => b.login == login_text && b.password == password_text).FirstOrDefault();
            if (bossid.Count < 1)
            {
                var message = MessageBox.Show("В случай, если вы забудете свой логин или пароль, ваши данные будут потеряны. Хотите продолжить ?", "Предупреждение", MessageBoxButton.YesNo);
                if (message == MessageBoxResult.Yes)
                {
                    db.Bosses.Add(boss);
                    db.SaveChanges();
                    ThicknessAnimationUsingKeyFrames leftback = new ThicknessAnimationUsingKeyFrames();
                    leftback.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 0, 720, 500), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0))));
                    leftback.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 0, 1840, 500), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(200))));
                    back.BeginAnimation(FrameworkElement.MarginProperty, leftback);
                    Storyboard leftbackstoryboard = new Storyboard();
                    DoubleAnimation leftbackopacity = new DoubleAnimation();
                    leftbackopacity.From = 1;
                    leftbackopacity.To = 0;
                    leftbackopacity.Duration = new Duration(TimeSpan.FromMilliseconds(100));
                    Storyboard.SetTargetProperty(leftbackopacity, new PropertyPath(Button.OpacityProperty));
                    Storyboard.SetTarget(leftbackopacity, back);
                    leftbackstoryboard.Children.Add(leftbackopacity);
                    leftbackstoryboard.Begin();

                    ThicknessAnimationUsingKeyFrames continu = new ThicknessAnimationUsingKeyFrames();
                    continu.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 300, 0, 0), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0))));
                    continu.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 300, 1840, 0), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(200))));
                    begin1.BeginAnimation(FrameworkElement.MarginProperty, continu);
                    Storyboard continustoryboad = new Storyboard();
                    DoubleAnimation continuopacity = new DoubleAnimation();
                    continuopacity.From = 1;
                    continuopacity.To = 0;
                    continuopacity.Duration = new Duration(TimeSpan.FromMilliseconds(200));
                    Storyboard.SetTargetProperty(continuopacity, new PropertyPath(Button.OpacityProperty));
                    Storyboard.SetTarget(continuopacity, begin1);
                    continustoryboad.Children.Add(continuopacity);
                    continustoryboad.Begin();

                    ThicknessAnimationUsingKeyFrames l4margin = new ThicknessAnimationUsingKeyFrames();
                    l4margin.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 0, 0, 350), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0))));
                    l4margin.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 0, 1840, 350), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(200))));
                    l4.BeginAnimation(FrameworkElement.MarginProperty, l4margin);
                    Storyboard l4storyboad = new Storyboard();
                    DoubleAnimation l4opacity = new DoubleAnimation();
                    l4opacity.From = 1;
                    l4opacity.To = 0;
                    l4opacity.Duration = new Duration(TimeSpan.FromMilliseconds(200));
                    Storyboard.SetTargetProperty(l4opacity, new PropertyPath(Button.OpacityProperty));
                    Storyboard.SetTarget(l4opacity, l4);
                    l4storyboad.Children.Add(l4opacity);
                    l4storyboad.Begin();

                    ThicknessAnimationUsingKeyFrames l5margin = new ThicknessAnimationUsingKeyFrames();
                    l5margin.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 0, 0, 200), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0))));
                    l5margin.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 0, 1840, 200), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(200))));
                    l5.BeginAnimation(FrameworkElement.MarginProperty, l5margin);
                    Storyboard l5storyboad = new Storyboard();
                    DoubleAnimation l5opacity = new DoubleAnimation();
                    l5opacity.From = 1;
                    l5opacity.To = 0;
                    l5opacity.Duration = new Duration(TimeSpan.FromMilliseconds(200));
                    Storyboard.SetTargetProperty(l5opacity, new PropertyPath(Button.OpacityProperty));
                    Storyboard.SetTarget(l5opacity, l5);
                    l5storyboad.Children.Add(l5opacity);
                    l5storyboad.Begin();

                    ThicknessAnimationUsingKeyFrames l6margin = new ThicknessAnimationUsingKeyFrames();
                    l6margin.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 0, 0, 150), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0))));
                    l6margin.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 0, 1840, 150), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(200))));
                    l6.BeginAnimation(FrameworkElement.MarginProperty, l6margin);
                    Storyboard l6storyboad = new Storyboard();
                    DoubleAnimation l6opacity = new DoubleAnimation();
                    l6opacity.From = 1;
                    l6opacity.To = 0;
                    l6opacity.Duration = new Duration(TimeSpan.FromMilliseconds(200));
                    Storyboard.SetTargetProperty(l6opacity, new PropertyPath(Button.OpacityProperty));
                    Storyboard.SetTarget(l6opacity, l6);
                    l6storyboad.Children.Add(l6opacity);
                    l6storyboad.Begin();

                    ThicknessAnimationUsingKeyFrames passwordmargin = new ThicknessAnimationUsingKeyFrames();
                    passwordmargin.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 100, 0, 0), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0))));
                    passwordmargin.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 100, 1840, 0), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(200))));
                    password.BeginAnimation(FrameworkElement.MarginProperty, passwordmargin);
                    Storyboard passwordstoryboad = new Storyboard();
                    DoubleAnimation passwordopacity = new DoubleAnimation();
                    passwordopacity.From = 1;
                    passwordopacity.To = 0;
                    passwordopacity.Duration = new Duration(TimeSpan.FromMilliseconds(200));
                    Storyboard.SetTargetProperty(passwordopacity, new PropertyPath(PasswordBox.OpacityProperty));
                    Storyboard.SetTarget(passwordopacity, password);
                    passwordstoryboad.Children.Add(passwordopacity);
                    passwordstoryboad.Begin();

                    ThicknessAnimationUsingKeyFrames loginmargin = new ThicknessAnimationUsingKeyFrames();
                    loginmargin.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 0, 0, 0), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0))));
                    loginmargin.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 0, 1840, 0), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(200))));
                    login.BeginAnimation(FrameworkElement.MarginProperty, loginmargin);
                    Storyboard loginstoryboad = new Storyboard();
                    DoubleAnimation loginopacity = new DoubleAnimation();
                    loginopacity.From = 1;
                    loginopacity.To = 0;
                    loginopacity.Duration = new Duration(TimeSpan.FromMilliseconds(200));
                    Storyboard.SetTargetProperty(loginopacity, new PropertyPath(TextBox.OpacityProperty));
                    Storyboard.SetTarget(loginopacity, password);
                    loginstoryboad.Children.Add(loginopacity);
                    loginstoryboad.Begin();

                    ThicknessAnimationUsingKeyFrames bossbox = new ThicknessAnimationUsingKeyFrames();
                    bossbox.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(2000, 0, 0, 0), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0))));
                    bossbox.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 0, 0, 0), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(200))));
                    Bossviewbox.BeginAnimation(FrameworkElement.MarginProperty, bossbox);
                    Bossviewbox.Opacity = 1;
                    AuthBoss.Content = login_text;
                    AuthBoss.Opacity = 1;
                    

                }
                else if (message == MessageBoxResult.No)
                {

                }


            }
            else if (bossid.Count == 1 && validation != null)
            {


                ThicknessAnimationUsingKeyFrames leftback = new ThicknessAnimationUsingKeyFrames();
                leftback.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 0, 720, 500), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0))));
                leftback.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 0, 1840, 500), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(200))));
                back.BeginAnimation(FrameworkElement.MarginProperty, leftback);
                Storyboard leftbackstoryboard = new Storyboard();
                DoubleAnimation leftbackopacity = new DoubleAnimation();
                leftbackopacity.From = 1;
                leftbackopacity.To = 0;
                leftbackopacity.Duration = new Duration(TimeSpan.FromMilliseconds(100));
                Storyboard.SetTargetProperty(leftbackopacity, new PropertyPath(Button.OpacityProperty));
                Storyboard.SetTarget(leftbackopacity, back);
                leftbackstoryboard.Children.Add(leftbackopacity);
                leftbackstoryboard.Begin();

                ThicknessAnimationUsingKeyFrames continu = new ThicknessAnimationUsingKeyFrames();
                continu.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 300, 0, 0), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0))));
                continu.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 300, 1840, 0), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(200))));
                begin1.BeginAnimation(FrameworkElement.MarginProperty, continu);
                Storyboard continustoryboad = new Storyboard();
                DoubleAnimation continuopacity = new DoubleAnimation();
                continuopacity.From = 1;
                continuopacity.To = 0;
                continuopacity.Duration = new Duration(TimeSpan.FromMilliseconds(200));
                Storyboard.SetTargetProperty(continuopacity, new PropertyPath(Button.OpacityProperty));
                Storyboard.SetTarget(continuopacity, begin1);
                continustoryboad.Children.Add(continuopacity);
                continustoryboad.Begin();

                ThicknessAnimationUsingKeyFrames l4margin = new ThicknessAnimationUsingKeyFrames();
                l4margin.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 0, 0, 350), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0))));
                l4margin.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 0, 1840, 350), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(200))));
                l4.BeginAnimation(FrameworkElement.MarginProperty, l4margin);
                Storyboard l4storyboad = new Storyboard();
                DoubleAnimation l4opacity = new DoubleAnimation();
                l4opacity.From = 1;
                l4opacity.To = 0;
                l4opacity.Duration = new Duration(TimeSpan.FromMilliseconds(200));
                Storyboard.SetTargetProperty(l4opacity, new PropertyPath(Button.OpacityProperty));
                Storyboard.SetTarget(l4opacity, l4);
                l4storyboad.Children.Add(l4opacity);
                l4storyboad.Begin();

                ThicknessAnimationUsingKeyFrames l5margin = new ThicknessAnimationUsingKeyFrames();
                l5margin.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 0, 0, 200), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0))));
                l5margin.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 0, 1840, 200), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(200))));
                l5.BeginAnimation(FrameworkElement.MarginProperty, l5margin);
                Storyboard l5storyboad = new Storyboard();
                DoubleAnimation l5opacity = new DoubleAnimation();
                l5opacity.From = 1;
                l5opacity.To = 0;
                l5opacity.Duration = new Duration(TimeSpan.FromMilliseconds(200));
                Storyboard.SetTargetProperty(l5opacity, new PropertyPath(Button.OpacityProperty));
                Storyboard.SetTarget(l5opacity, l5);
                l5storyboad.Children.Add(l5opacity);
                l5storyboad.Begin();

                ThicknessAnimationUsingKeyFrames l6margin = new ThicknessAnimationUsingKeyFrames();
                l6margin.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 0, 0, 150), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0))));
                l6margin.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 0, 1840, 150), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(200))));
                l6.BeginAnimation(FrameworkElement.MarginProperty, l6margin);
                Storyboard l6storyboad = new Storyboard();
                DoubleAnimation l6opacity = new DoubleAnimation();
                l6opacity.From = 1;
                l6opacity.To = 0;
                l6opacity.Duration = new Duration(TimeSpan.FromMilliseconds(200));
                Storyboard.SetTargetProperty(l6opacity, new PropertyPath(Button.OpacityProperty));
                Storyboard.SetTarget(l6opacity, l6);
                l6storyboad.Children.Add(l6opacity);
                l6storyboad.Begin();

                ThicknessAnimationUsingKeyFrames passwordmargin = new ThicknessAnimationUsingKeyFrames();
                passwordmargin.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 100, 0, 0), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0))));
                passwordmargin.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 100, 1840, 0), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(200))));
                password.BeginAnimation(FrameworkElement.MarginProperty, passwordmargin);
                Storyboard passwordstoryboad = new Storyboard();
                DoubleAnimation passwordopacity = new DoubleAnimation();
                passwordopacity.From = 1;
                passwordopacity.To = 0;
                passwordopacity.Duration = new Duration(TimeSpan.FromMilliseconds(200));
                Storyboard.SetTargetProperty(passwordopacity, new PropertyPath(PasswordBox.OpacityProperty));
                Storyboard.SetTarget(passwordopacity, password);
                passwordstoryboad.Children.Add(passwordopacity);
                passwordstoryboad.Begin();

                ThicknessAnimationUsingKeyFrames loginmargin = new ThicknessAnimationUsingKeyFrames();
                loginmargin.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 0, 0, 0), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0))));
                loginmargin.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 0, 1840, 0), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(200))));
                login.BeginAnimation(FrameworkElement.MarginProperty, loginmargin);
                Storyboard loginstoryboad = new Storyboard();
                DoubleAnimation loginopacity = new DoubleAnimation();
                loginopacity.From = 1;
                loginopacity.To = 0;
                loginopacity.Duration = new Duration(TimeSpan.FromMilliseconds(200));
                Storyboard.SetTargetProperty(loginopacity, new PropertyPath(TextBox.OpacityProperty));
                Storyboard.SetTarget(loginopacity, password);
                loginstoryboad.Children.Add(loginopacity);
                loginstoryboad.Begin();

                ThicknessAnimationUsingKeyFrames bossbox = new ThicknessAnimationUsingKeyFrames();
                bossbox.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(2000, 0, 0, 0), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0))));
                bossbox.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 0, 0, 0), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(200))));
                Bossviewbox.BeginAnimation(FrameworkElement.MarginProperty, bossbox);
                Bossviewbox.Opacity = 1;
                AuthBoss.Content = validation.firstname;
                AuthBoss.Opacity = 1;
                if(AuthBoss.Content == null)
                {
                    AuthBoss.Content = login_text;
                    AuthBoss.Opacity = 1;
                }

            }
            if(user != null)
            {


                ThicknessAnimationUsingKeyFrames leftback = new ThicknessAnimationUsingKeyFrames();
                leftback.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 0, 720, 500), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0))));
                leftback.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 0, 2840, 500), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(200))));
                back.BeginAnimation(FrameworkElement.MarginProperty, leftback);
                Storyboard leftbackstoryboard = new Storyboard();
                DoubleAnimation leftbackopacity = new DoubleAnimation();
                leftbackopacity.From = 1;
                leftbackopacity.To = 0;
                leftbackopacity.Duration = new Duration(TimeSpan.FromMilliseconds(100));
                Storyboard.SetTargetProperty(leftbackopacity, new PropertyPath(Button.OpacityProperty));
                Storyboard.SetTarget(leftbackopacity, back);
                leftbackstoryboard.Children.Add(leftbackopacity);
                leftbackstoryboard.Begin();

                ThicknessAnimationUsingKeyFrames continu = new ThicknessAnimationUsingKeyFrames();
                continu.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 300, 0, 0), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0))));
                continu.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 300, 2840, 0), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(200))));
                begin1.BeginAnimation(FrameworkElement.MarginProperty, continu);
                Storyboard continustoryboad = new Storyboard();
                DoubleAnimation continuopacity = new DoubleAnimation();
                continuopacity.From = 1;
                continuopacity.To = 0;
                continuopacity.Duration = new Duration(TimeSpan.FromMilliseconds(200));
                Storyboard.SetTargetProperty(continuopacity, new PropertyPath(Button.OpacityProperty));
                Storyboard.SetTarget(continuopacity, begin1);
                continustoryboad.Children.Add(continuopacity);
                continustoryboad.Begin();

                ThicknessAnimationUsingKeyFrames l4margin = new ThicknessAnimationUsingKeyFrames();
                l4margin.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 0, 0, 350), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0))));
                l4margin.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 0, 2840, 350), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(200))));
                l4.BeginAnimation(FrameworkElement.MarginProperty, l4margin);
                Storyboard l4storyboad = new Storyboard();
                DoubleAnimation l4opacity = new DoubleAnimation();
                l4opacity.From = 1;
                l4opacity.To = 0;
                l4opacity.Duration = new Duration(TimeSpan.FromMilliseconds(200));
                Storyboard.SetTargetProperty(l4opacity, new PropertyPath(Button.OpacityProperty));
                Storyboard.SetTarget(l4opacity, l4);
                l4storyboad.Children.Add(l4opacity);
                l4storyboad.Begin();

                ThicknessAnimationUsingKeyFrames l5margin = new ThicknessAnimationUsingKeyFrames();
                l5margin.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 0, 0, 200), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0))));
                l5margin.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 0, 2840, 200), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(200))));
                l5.BeginAnimation(FrameworkElement.MarginProperty, l5margin);
                Storyboard l5storyboad = new Storyboard();
                DoubleAnimation l5opacity = new DoubleAnimation();
                l5opacity.From = 1;
                l5opacity.To = 0;
                l5opacity.Duration = new Duration(TimeSpan.FromMilliseconds(200));
                Storyboard.SetTargetProperty(l5opacity, new PropertyPath(Button.OpacityProperty));
                Storyboard.SetTarget(l5opacity, l5);
                l5storyboad.Children.Add(l5opacity);
                l5storyboad.Begin();

                ThicknessAnimationUsingKeyFrames l6margin = new ThicknessAnimationUsingKeyFrames();
                l6margin.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 0, 0, 150), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0))));
                l6margin.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 0, 2840, 150), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(200))));
                l6.BeginAnimation(FrameworkElement.MarginProperty, l6margin);
                Storyboard l6storyboad = new Storyboard();
                DoubleAnimation l6opacity = new DoubleAnimation();
                l6opacity.From = 1;
                l6opacity.To = 0;
                l6opacity.Duration = new Duration(TimeSpan.FromMilliseconds(200));
                Storyboard.SetTargetProperty(l6opacity, new PropertyPath(Button.OpacityProperty));
                Storyboard.SetTarget(l6opacity, l6);
                l6storyboad.Children.Add(l6opacity);
                l6storyboad.Begin();

                ThicknessAnimationUsingKeyFrames passwordmargin = new ThicknessAnimationUsingKeyFrames();
                passwordmargin.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 100, 0, 0), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0))));
                passwordmargin.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 100, 2840, 0), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(200))));
                password.BeginAnimation(FrameworkElement.MarginProperty, passwordmargin);
                Storyboard passwordstoryboad = new Storyboard();
                DoubleAnimation passwordopacity = new DoubleAnimation();
                passwordopacity.From = 1;
                passwordopacity.To = 0;
                passwordopacity.Duration = new Duration(TimeSpan.FromMilliseconds(200));
                Storyboard.SetTargetProperty(passwordopacity, new PropertyPath(PasswordBox.OpacityProperty));
                Storyboard.SetTarget(passwordopacity, password);
                passwordstoryboad.Children.Add(passwordopacity);
                passwordstoryboad.Begin();

                ThicknessAnimationUsingKeyFrames loginmargin = new ThicknessAnimationUsingKeyFrames();
                loginmargin.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 0, 0, 0), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0))));
                loginmargin.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 0, 2840, 0), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(200))));
                login.BeginAnimation(FrameworkElement.MarginProperty, loginmargin);
                Storyboard loginstoryboad = new Storyboard();
                DoubleAnimation loginopacity = new DoubleAnimation();
                loginopacity.From = 1;
                loginopacity.To = 0;
                loginopacity.Duration = new Duration(TimeSpan.FromMilliseconds(200));
                Storyboard.SetTargetProperty(loginopacity, new PropertyPath(TextBox.OpacityProperty));
                Storyboard.SetTarget(loginopacity, password);
                loginstoryboad.Children.Add(loginopacity);
                loginstoryboad.Begin();

                ThicknessAnimationUsingKeyFrames bossbox = new ThicknessAnimationUsingKeyFrames();
                bossbox.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(2000, 0, 0, 0), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0))));
                bossbox.KeyFrames.Add(new SplineThicknessKeyFrame(new Thickness(0, 0, 0, 0), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(200))));
                MainMenuAnalytic.BeginAnimation(FrameworkElement.MarginProperty, bossbox);
                MainMenuAnalytic.Opacity = 1;
                ShadowBorderAnalytic.Opacity = 0;
                ShadowBorderAnalytic.SetValue(Grid.ZIndexProperty, 0);
                ShadowBorderAnalytic.Width = 0;
                Loginanalytic.Content = user.firstname;
                if (Loginanalytic.Content == null)
                {
                    Loginanalytic.Content = login_text;
                    ChangeInfoAnalytic.Width = 840;
                    TeamView team = db.TeamViews.Where(b => b.login == login_text).FirstOrDefault();
                    int mon = Convert.ToInt32(team.money);
                    SeriesCollection = new SeriesCollection
                {
                new LineSeries
                {
                    Title = "Выручка",
                    Values = new ChartValues<double> { 4, 6, 5, 2 ,4 }
                },
                new LineSeries
                {
                    Title = "Затраты",
                    Values = new ChartValues<double> { 6, 7, 3, 4 ,6 },
                    PointGeometry = null
                },
                new LineSeries
                {
                    Title = "Стартап",
                    Values = new ChartValues<double>{ mon, mon, mon, mon, mon }
                },
            };
                    Labels = new[] { "1", "3", "6", "9", "12" };
                    YFormatter = value => value.ToString("C");


                    DataContext = this;
                }
                else
                {
                    ChangeInfoAnalytic.Width = 0;
                    TeamView team = new TeamView();
                    team = db.TeamViews.Where(b => b.login == (string)user.login).FirstOrDefault();
                    string teamon = team.money;
                    int mon = Convert.ToInt32(teamon);
                    SeriesCollection = new SeriesCollection
                {
                new LineSeries
                {
                    Title = "Выручка",
                    Values = new ChartValues<double> { 4, 6, 5, 2 ,4 }
                },
                new LineSeries
                {
                    Title = "Затраты",
                    Values = new ChartValues<double> { 6, 7, 3, 4 ,6 },
                    PointGeometry = null
                },
                new LineSeries
                {
                    Title = "Стартап",
                    Values = new ChartValues<double>{ mon, mon, mon, mon, mon},
                    
                },
            };
                    Labels = new[] { "1", "3", "6", "9", "12" };
                    YFormatter = value => value.ToString("C");


                    DataContext = this;
                }
                Graphics.Margin = new Thickness(220, 25, 0, 0);
                Graphics.Width = 600;
            }
            else if(bossid.Count != 1 && validation == null && user == null && boss == null)
            {

                MessageBox.Show("Вы неправильно ввели логин или пароль! Обратитесь к своему работаделю");

            }
        }
        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = searcher.Text;
            ApplicationContext db = new ApplicationContext();
            // Очищаем текущее содержимое ListBox
            List<Team> teams = db.Teams.ToList();
            ListProject.ItemsSource = teams;
            var list = teams;
            var matchingItems = new List<Team>();

            // Проходим по всем элементам в ListBox
            foreach (var item in list)
            {
                // Проверяем, содержит ли элемент введенный текст
                if (item.ToString().Contains(searchText))
                {
                    // Если содержит, добавляем его в новую коллекцию
                    matchingItems.Add(item);
                }
            }
            ListProject.ItemsSource = matchingItems;
        }
        //}
        //    private void ListProject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //    {
        //        if (ListProject.SelectedItem != null)
        //        {

        //            infoborder.Opacity = 1;
        //            infoborder.SetValue(Grid.ZIndexProperty, 1);
        //            Infogrid.Opacity = 1;
        //            Storyboard infostoryboard = new Storyboard();
        //            DoubleAnimation infoanimatiom = new DoubleAnimation();
        //            infoanimatiom.From = 0;
        //            infoanimatiom.To = 520;
        //            infoanimatiom.Duration = new Duration(TimeSpan.FromMilliseconds(0.1));
        //            Storyboard.SetTargetProperty(infoanimatiom, new PropertyPath(Frame.WidthProperty));
        //            Storyboard.SetTarget(infoanimatiom, Infogrid);
        //            infostoryboard.Children.Add(infoanimatiom);
        //            infostoryboard.Begin();
        //            Storyboard infohstoryboard = new Storyboard();
        //            DoubleAnimation infohanimatiom = new DoubleAnimation();
        //            infohanimatiom.From = 0;
        //            infohanimatiom.To = 640;
        //            infohanimatiom.Duration = new Duration(TimeSpan.FromMilliseconds(0.1));
        //            Storyboard.SetTargetProperty(infohanimatiom, new PropertyPath(Frame.HeightProperty));
        //            Storyboard.SetTarget(infohanimatiom, Infogrid);
        //            infohstoryboard.Children.Add(infohanimatiom);
        //            infohstoryboard.Begin();
        //        }

        //    }
        private void MenuBoss(object sender, RoutedEventArgs e)
        {
            Shadow.SetValue(Grid.ZIndexProperty, 1);
            Menu.SetValue(Grid.ZIndexProperty, 1);
            mainborder.SetValue(Grid.ZIndexProperty, 0);
            BossPage.SetValue(Grid.ZIndexProperty, 0);
            infoborder.SetValue(Grid.ZIndexProperty, 0);
            ChangeBossborder.Opacity = 0.5;
            ChangeBossborder.SetValue(Grid.ZIndexProperty, 0);
            AuthBoss.Opacity = 1;

        }

        private void Shadow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int n = 1;
            Shadow.SetValue(Grid.ZIndexProperty, n);
            if (n == 1)
            {
                Shadow.Opacity = Math.Abs(Shadow.Opacity - 0.5);
                Shadow.SetValue(Grid.ZIndexProperty, 0);
                Storyboard menustoryboard = new Storyboard();
                DoubleAnimation menuanimatiom = new DoubleAnimation();
                menuanimatiom.From = 270;
                menuanimatiom.To = 0;
                menuanimatiom.Duration = new Duration(TimeSpan.FromMilliseconds(200));
                Storyboard.SetTargetProperty(menuanimatiom, new PropertyPath(Frame.WidthProperty));
                Storyboard.SetTarget(menuanimatiom, Menu);
                menustoryboard.Children.Add(menuanimatiom);
                menustoryboard.Begin();
                Storyboard Shadowstoryboard = new Storyboard();
                DoubleAnimation Shadowanimatiom = new DoubleAnimation();
                Shadowanimatiom.From = 820;
                Shadowanimatiom.To = 0;
                Shadowanimatiom.Duration = new Duration(TimeSpan.FromMilliseconds(10));
                Storyboard.SetTargetProperty(Shadowanimatiom, new PropertyPath(Frame.WidthProperty));
                Storyboard.SetTarget(Shadowanimatiom, Shadow);
                Shadowstoryboard.Children.Add(Shadowanimatiom);
                Shadowstoryboard.Begin();
                Storyboard Shadowgrid = new Storyboard();
                DoubleAnimation gridanimatiom = new DoubleAnimation();
                gridanimatiom.From = 0.5;
                gridanimatiom.To = 1;
                gridanimatiom.Duration = new Duration(TimeSpan.FromMilliseconds(10));
                Storyboard.SetTargetProperty(gridanimatiom, new PropertyPath(Frame.OpacityProperty));
                Storyboard.SetTarget(gridanimatiom, maingrid);
                Shadowgrid.Children.Add(gridanimatiom);
                Shadowgrid.Begin();
                Storyboard Shadowlist = new Storyboard();
                DoubleAnimation listanimatiom = new DoubleAnimation();
                listanimatiom.From = 0.5;
                listanimatiom.To = 1;
                listanimatiom.Duration = new Duration(TimeSpan.FromMilliseconds(10));
                Storyboard.SetTargetProperty(listanimatiom, new PropertyPath(Frame.OpacityProperty));
                Storyboard.SetTarget(listanimatiom, ListProject);
                Shadowlist.Children.Add(listanimatiom);
                Shadowlist.Begin();
                ChangeBossborder.Opacity = 1;
                ChangeBossborder.SetValue(Grid.ZIndexProperty, 1);
                mainborder.SetValue(Grid.ZIndexProperty, 1);
            }
        }

        private void Buttonmenuinpage_Click(object sender, RoutedEventArgs e)
        {
            int n = 1;
            Test test = new Test();
            test.Shadow.SetValue(Grid.ZIndexProperty, n);
            if (n == 1)
            {
                ListProject.SetValue(Grid.ZIndexProperty, 0);
                Shadow.SetValue(Grid.ZIndexProperty, 1);
                Menu.SetValue(Grid.ZIndexProperty, 1);
                mainborder.SetValue(Grid.ZIndexProperty, 0);
                AuthBoss.Opacity = 1;


            }
        }

        private void ButtonAddTeam_Click(object sender, RoutedEventArgs e)
        {
            BossPage.SetValue(Grid.ZIndexProperty, 1);
            ButtonAddTeam.SetValue(Grid.ZIndexProperty, 1);
            int n = 1;
            Shadow.SetValue(Grid.ZIndexProperty, n);
            if (n == 1)
            {
                BossPage.Width = 520;
                Shadow.Opacity = Math.Abs(Shadow.Opacity - 0.5);
                Shadow.SetValue(Grid.ZIndexProperty, 0);
                Storyboard menustoryboard = new Storyboard();
                DoubleAnimation menuanimatiom = new DoubleAnimation();
                menuanimatiom.From = 270;
                menuanimatiom.To = 0;
                menuanimatiom.Duration = new Duration(TimeSpan.FromMilliseconds(200));
                Storyboard.SetTargetProperty(menuanimatiom, new PropertyPath(Frame.WidthProperty));
                Storyboard.SetTarget(menuanimatiom, Menu);
                menustoryboard.Children.Add(menuanimatiom);
                menustoryboard.Begin();
                Storyboard Shadowstoryboard = new Storyboard();
                DoubleAnimation Shadowanimatiom = new DoubleAnimation();
                Shadowanimatiom.From = 820;
                Shadowanimatiom.To = 0;
                Shadowanimatiom.Duration = new Duration(TimeSpan.FromMilliseconds(10));
                Storyboard.SetTargetProperty(Shadowanimatiom, new PropertyPath(Frame.WidthProperty));
                Storyboard.SetTarget(Shadowanimatiom, Shadow);
                Shadowstoryboard.Children.Add(Shadowanimatiom);
                Shadowstoryboard.Begin();
                Storyboard Shadowlist = new Storyboard();
                DoubleAnimation listanimatiom = new DoubleAnimation();
                listanimatiom.From = 0.5;
                listanimatiom.To = 1;
                listanimatiom.Duration = new Duration(TimeSpan.FromMilliseconds(10));
                Storyboard.SetTargetProperty(listanimatiom, new PropertyPath(Frame.OpacityProperty));
                Storyboard.SetTarget(listanimatiom, ListProject);
                Shadowlist.Children.Add(listanimatiom);
                Shadowlist.Begin();
                ApplicationContext db = new ApplicationContext();
                BossPage.Content = new StartPageBoss();
                List<Team> teams = db.Teams.ToList();
                ListProject.ItemsSource = teams;
                Infogrid.Opacity = 0;
                infoborder.SetValue(Grid.ZIndexProperty, 0);
                Storyboard ChangeBossborderstoryboard = new Storyboard();
                DoubleAnimation ChangeBossborderanimatiom = new DoubleAnimation();
                ChangeBossborderanimatiom.From = 520;
                ChangeBossborderanimatiom.To = 0;
                ChangeBossborderanimatiom.Duration = new Duration(TimeSpan.FromMilliseconds(10));
                Storyboard.SetTargetProperty(ChangeBossborderanimatiom, new PropertyPath(Frame.WidthProperty));
                Storyboard.SetTarget(ChangeBossborderanimatiom, ChangeBossborder);
                ChangeBossborderstoryboard.Children.Add(ChangeBossborderanimatiom);
                ChangeBossborderstoryboard.Begin();
                ChangeBossborder.Opacity = 0;
                ChangeBossborder.SetValue(Grid.ZIndexProperty, 0);
            }

        }
        private void ButtonAddAnalytics_Click(object sender, RoutedEventArgs e)
        {
            BossPage.SetValue(Grid.ZIndexProperty, 1);
            ButtonAddTeam.SetValue(Grid.ZIndexProperty, 1);
            int n = 1;
            Shadow.SetValue(Grid.ZIndexProperty, n);
            if (n == 1)
            {
                BossPage.Width = 520;
                Shadow.Opacity = Math.Abs(Shadow.Opacity - 0.5);
                Shadow.SetValue(Grid.ZIndexProperty, 0);
                Storyboard menustoryboard = new Storyboard();
                DoubleAnimation menuanimatiom = new DoubleAnimation();
                menuanimatiom.From = 270;
                menuanimatiom.To = 0;
                menuanimatiom.Duration = new Duration(TimeSpan.FromMilliseconds(200));
                Storyboard.SetTargetProperty(menuanimatiom, new PropertyPath(Frame.WidthProperty));
                Storyboard.SetTarget(menuanimatiom, Menu);
                menustoryboard.Children.Add(menuanimatiom);
                menustoryboard.Begin();
                Storyboard Shadowstoryboard = new Storyboard();
                DoubleAnimation Shadowanimatiom = new DoubleAnimation();
                Shadowanimatiom.From = 820;
                Shadowanimatiom.To = 0;
                Shadowanimatiom.Duration = new Duration(TimeSpan.FromMilliseconds(10));
                Storyboard.SetTargetProperty(Shadowanimatiom, new PropertyPath(Frame.WidthProperty));
                Storyboard.SetTarget(Shadowanimatiom, Shadow);
                Shadowstoryboard.Children.Add(Shadowanimatiom);
                Shadowstoryboard.Begin();
                Storyboard Shadowlist = new Storyboard();
                DoubleAnimation listanimatiom = new DoubleAnimation();
                listanimatiom.From = 0.5;
                listanimatiom.To = 1;
                listanimatiom.Duration = new Duration(TimeSpan.FromMilliseconds(10));
                Storyboard.SetTargetProperty(listanimatiom, new PropertyPath(Frame.OpacityProperty));
                Storyboard.SetTarget(listanimatiom, ListProject);
                Shadowlist.Children.Add(listanimatiom);
                Shadowlist.Begin();
                ApplicationContext db = new ApplicationContext();
                BossPage.Content = new AddUsersPage();
                List<Team> teams = db.Teams.ToList();
                ListProject.ItemsSource = teams;
                Infogrid.Opacity = 0;
                infoborder.SetValue(Grid.ZIndexProperty, 0);
                Storyboard ChangeBossborderstoryboard = new Storyboard();
                DoubleAnimation ChangeBossborderanimatiom = new DoubleAnimation();
                ChangeBossborderanimatiom.From = 520;
                ChangeBossborderanimatiom.To = 0;
                ChangeBossborderanimatiom.Duration = new Duration(TimeSpan.FromMilliseconds(10));
                Storyboard.SetTargetProperty(ChangeBossborderanimatiom, new PropertyPath(Frame.WidthProperty));
                Storyboard.SetTarget(ChangeBossborderanimatiom, ChangeBossborder);
                ChangeBossborderstoryboard.Children.Add(ChangeBossborderanimatiom);
                ChangeBossborderstoryboard.Begin();
                ChangeBossborder.Opacity = 0;
                ChangeBossborder.SetValue(Grid.ZIndexProperty, 0);
            }
        }

        private void DataBossClick(object sender, RoutedEventArgs e)
        {
            infoborder.Opacity = 1;
            infoborder.SetValue(Grid.ZIndexProperty, 1);
            Infogrid.Opacity = 1;
            Storyboard infostoryboard = new Storyboard();
            DoubleAnimation infoanimatiom = new DoubleAnimation();
            infoanimatiom.From = 0;
            infoanimatiom.To = 520;
            infoanimatiom.Duration = new Duration(TimeSpan.FromMilliseconds(0.1));
            Storyboard.SetTargetProperty(infoanimatiom, new PropertyPath(Frame.WidthProperty));
            Storyboard.SetTarget(infoanimatiom, Infogrid);
            infostoryboard.Children.Add(infoanimatiom);
            infostoryboard.Begin();
            Storyboard infohstoryboard = new Storyboard();
            DoubleAnimation infohanimatiom = new DoubleAnimation();
            infohanimatiom.From = 0;
            infohanimatiom.To = 640;
            infohanimatiom.Duration = new Duration(TimeSpan.FromMilliseconds(0.1));
            Storyboard.SetTargetProperty(infohanimatiom, new PropertyPath(Frame.HeightProperty));
            Storyboard.SetTarget(infohanimatiom, Infogrid);
            infohstoryboard.Children.Add(infohanimatiom);
            infohstoryboard.Begin();
            ChangeBossborder.Opacity = 0;
            ChangeBossborder.SetValue(Grid.ZIndexProperty, 0);
            Button button = (Button)sender;
            // Получаем текущий элемент данных, который отображается в кнопке
            Team team = null;
            ApplicationContext db = new ApplicationContext();
            var dataItem = button.Content;
            string data = (string)dataItem;
            team = db.Teams.Where(b => b.name == data).FirstOrDefault();
            if (team != null)
            {
                List<Team> teams = db.Teams.Where(b => b.name == team.name).ToList();
                Listofteams.ItemsSource = teams;
            }
            List<User> views = db.Users.Where(b => b.idt == team.idteam).ToList();
            Listofusers.ItemsSource = views;

        }
        private void ButtonChangeBoss_Click(object sender, RoutedEventArgs e)
        {
            int n = 1;
            Shadow.SetValue(Grid.ZIndexProperty, n);
            if (n == 1)
            {
                BossPage.Width = 0;
                Shadow.Opacity = Math.Abs(Shadow.Opacity - 0.5);
                Shadow.SetValue(Grid.ZIndexProperty, 0);
                Storyboard menustoryboard = new Storyboard();
                DoubleAnimation menuanimatiom = new DoubleAnimation();
                menuanimatiom.From = 300;
                menuanimatiom.To = 0;
                menuanimatiom.Duration = new Duration(TimeSpan.FromMilliseconds(200));
                Storyboard.SetTargetProperty(menuanimatiom, new PropertyPath(Frame.WidthProperty));
                Storyboard.SetTarget(menuanimatiom, Menu);
                menustoryboard.Children.Add(menuanimatiom);
                menustoryboard.Begin();
                Storyboard Shadowstoryboard = new Storyboard();
                DoubleAnimation Shadowanimatiom = new DoubleAnimation();
                Shadowanimatiom.From = 820;
                Shadowanimatiom.To = 0;
                Shadowanimatiom.Duration = new Duration(TimeSpan.FromMilliseconds(10));
                Storyboard.SetTargetProperty(Shadowanimatiom, new PropertyPath(Frame.WidthProperty));
                Storyboard.SetTarget(Shadowanimatiom, Shadow);
                Shadowstoryboard.Children.Add(Shadowanimatiom);
                Shadowstoryboard.Begin();
                Storyboard Shadowlist = new Storyboard();
                DoubleAnimation listanimatiom = new DoubleAnimation();
                listanimatiom.From = 0.5;
                listanimatiom.To = 1;
                listanimatiom.Duration = new Duration(TimeSpan.FromMilliseconds(10));
                Storyboard.SetTargetProperty(listanimatiom, new PropertyPath(Frame.OpacityProperty));
                Storyboard.SetTarget(listanimatiom, ListProject);
                Shadowlist.Children.Add(listanimatiom);
                Shadowlist.Begin();
                ApplicationContext db = new ApplicationContext();
                Storyboard ChangeBossborderstoryboard = new Storyboard();
                DoubleAnimation ChangeBossborderanimatiom = new DoubleAnimation();
                ChangeBossborderanimatiom.From = 0;
                ChangeBossborderanimatiom.To = 520;
                ChangeBossborderanimatiom.Duration = new Duration(TimeSpan.FromMilliseconds(10));
                Storyboard.SetTargetProperty(ChangeBossborderanimatiom, new PropertyPath(Frame.WidthProperty));
                Storyboard.SetTarget(ChangeBossborderanimatiom, ChangeBossborder);
                ChangeBossborderstoryboard.Children.Add(ChangeBossborderanimatiom);
                ChangeBossborderstoryboard.Begin();
                ChangeBossborder.Opacity = 1;
                ChangeBossborder.SetValue(Grid.ZIndexProperty, 1);
                List<Team> teams = db.Teams.ToList();
                ListProject.ItemsSource = teams;
                Infogrid.Opacity = 0;
                infoborder.SetValue(Grid.ZIndexProperty, 0);
                Boss boss = new Boss();
                boss = db.Bosses.Where(b => b.login == (string)AuthBoss.Content || b.firstname == (string)AuthBoss.Content).FirstOrDefault();
                LoginBoss.Text = boss.login;
                passwordboss.Password = boss.password;
                LastnameBoss.Text = boss.lastname;
                FirstnameBoss.Text = boss.firstname;
                PatronymicBoss.Text = boss.patronymic;
            }

        }
        private void ChangeBoss_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginBoss.Text;
            string password = passwordboss.Password;
            string lastname = LastnameBoss.Text;
            string firstname = FirstnameBoss.Text;
            string patronymic = PatronymicBoss.Text;
            Boss boss = new Boss(login, password, lastname, firstname, patronymic);
            boss.ID = 1;
            db.Bosses.AddOrUpdate(boss);
            db.SaveChanges();
            MessageBox.Show("Сохранение прошло успешно!");
            AuthBoss.Content = firstname;
            

        }
        private void MenuAnalytic_click(object sender, RoutedEventArgs e)
        {
            ShadowBorderAnalytic.SetValue(Grid.ZIndexProperty, 1);
            MenuBorderAnanlytc.SetValue(Grid.ZIndexProperty, 1);
            Graphics.Margin = new Thickness(0, 25, 0, 0);

        }
        private void Shadow_MouseDown_analytic(object sender, MouseButtonEventArgs e)
        {
            int n = 1;
            ShadowBorderAnalytic.SetValue(Grid.ZIndexProperty, n);
            if (n == 1)
            {

                ShadowBorderAnalytic.Opacity = Math.Abs(ShadowBorderAnalytic.Opacity - 0.5);
                ShadowBorderAnalytic.SetValue(Grid.ZIndexProperty, 0);
                Storyboard menustoryboard = new Storyboard();
                DoubleAnimation menuanimatiom = new DoubleAnimation();
                menuanimatiom.From = 270;
                menuanimatiom.To = 0;
                menuanimatiom.Duration = new Duration(TimeSpan.FromMilliseconds(200));
                Storyboard.SetTargetProperty(menuanimatiom, new PropertyPath(Frame.WidthProperty));
                Storyboard.SetTarget(menuanimatiom, MenuBorderAnanlytc);
                menustoryboard.Children.Add(menuanimatiom);
                menustoryboard.Begin();
                Storyboard Shadowstoryboard = new Storyboard();
                DoubleAnimation Shadowanimatiom = new DoubleAnimation();
                Shadowanimatiom.From = 820;
                Shadowanimatiom.To = 0;
                Shadowanimatiom.Duration = new Duration(TimeSpan.FromMilliseconds(10));
                Storyboard.SetTargetProperty(Shadowanimatiom, new PropertyPath(Frame.WidthProperty));
                Storyboard.SetTarget(Shadowanimatiom, ShadowBorderAnalytic);
                Shadowstoryboard.Children.Add(Shadowanimatiom);
                Shadowstoryboard.Begin();
                Storyboard Shadowgrid = new Storyboard();
                DoubleAnimation gridanimatiom = new DoubleAnimation();
                gridanimatiom.From = 0.5;
                gridanimatiom.To = 1;
                gridanimatiom.Duration = new Duration(TimeSpan.FromMilliseconds(10));
                Storyboard.SetTargetProperty(gridanimatiom, new PropertyPath(Frame.OpacityProperty));
                Storyboard.SetTarget(gridanimatiom, MainMenuAnalytic);
                Shadowgrid.Children.Add(gridanimatiom);
                Shadowgrid.Begin();
                Graphics.Margin = new Thickness(220, 25, 0, 0);
                Graphics.Width = 600;
            }
        }
        private void ChangeAnanlytic_Click(object sender, RoutedEventArgs e)
        {
            string lastnameanalytic = Lastnameanalytic.Text;
            string firstnameanalytic = Firstnameanalytic.Text;
            string patronymicanalytic = Patronymicanalytic.Text;
            User user = new User();
            user = db.Users.Where(b => b.login == (string)Loginanalytic.Content).FirstOrDefault();
            if (user != null) 
            {
                user.lastname = lastnameanalytic;
                user.firstname = firstnameanalytic;
                user.patronymic = patronymicanalytic;
                db.Users.AddOrUpdate(user);
                db.SaveChanges();
                MessageBox.Show("Сохранение прошло успешно!");
                Loginanalytic.Content = firstnameanalytic;
                ChangeInfoAnalytic.Width = 0;
            }
        }

    }
}
