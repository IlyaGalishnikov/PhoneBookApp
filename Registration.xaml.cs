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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    
    {
        private int reg = 0;
        private Authorization _currentUser = new Authorization();
        public Registration(Authorization SelectUser)
        {
            InitializeComponent();
          
            DataContext = _currentUser;
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            var TestLogin = KPGalishnikovEntities.GetContext().Authorization.Where(p => p.Login == LoginText.Text).FirstOrDefault();
            _currentUser.Password = PasswordText.Password;
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentUser.Login)) errors.AppendLine("Введите логин");
            if (string.IsNullOrWhiteSpace(_currentUser.Password)) errors.AppendLine("Введите пароль");
            if (TestLogin != null) errors.AppendLine("Такое имя пользователя уже сущетсвует!");
            //проверка пороля:
            string str2; int i = 0; bool boo; int yes = 0;
            if (_currentUser.Password.Length < 8) errors.AppendLine("Пароль должен быть длиннее 8 символов");
            str2 = _currentUser.Password.ToLower();
            if (_currentUser.Password == str2) errors.AppendLine("В пароле должны быть минимум одна заглавная буква");
            char[] array = _currentUser.Password.ToCharArray();
            while (_currentUser.Password.Length > i)
            {
                boo = Char.IsDigit(array[i]);
                if (boo == true) yes = yes + 1;
                i = i + 1;
            }
            if (_currentUser.Password.Length <= yes) errors.AppendLine("Пароль должен включать в себя буквы, Заглавные и строчные");
            if (yes == 0) errors.AppendLine("Пароль должен включать в себя цифры");
            //проверки длины
            if (_currentUser.Login != null)
            {
                if (_currentUser.Login.Length > 50) errors.AppendLine("Логин должен быть короче 50 символов");
            }
            if (_currentUser.Password != null)
            {
                if (_currentUser.Password.Length > 50) errors.AppendLine("Пароль должен быть короче 50 символов");
            }
            if (errors.Length > 0) { MessageBox.Show(errors.ToString()); return; }

            if (reg == 0) KPGalishnikovEntities.GetContext().Authorization.Add(_currentUser);
            else
            {
                var clnts = KPGalishnikovEntities.GetContext().Authorization.FirstOrDefault();
                clnts.Login = _currentUser.Login;
                clnts.Password = _currentUser.Password;
            }
            try
            {
                KPGalishnikovEntities.GetContext().SaveChanges();
                if (reg == 0) MessageBox.Show("Вы зарегистрированы!");
                else MessageBox.Show("Данные изменены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
    }

