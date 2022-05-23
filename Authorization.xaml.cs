using System;
using System.Collections.Generic;
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

namespace PhoneBookApp
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    
    {

        string _login, _password;
        
        public Authorization()
        {
            InitializeComponent();
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Authorization User = null;

            _login = LoginText.Text;
            _password = PasswordText.Password;
            User = KPGalishnikovEntities.GetContext().Authorization.Where(p => p.Password == _password && p.Login == _login).FirstOrDefault();

            if (User == null) MessageBox.Show("Не найдено");
            else if (User.Login == "admin                         ")
            {
                MessageBox.Show("Успешно");
                 Login = User.Login;
                manager.MainFrame.Content = new UserMenu();
            }
            else
            {
                MessageBox.Show("Успешно");
                 Login = User.Login;
                manager.MainFrame.Content = new UserMenu2();
            }

        }
        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            manager.MainFrame.Content = new Registration(null);
        }
    }
}
