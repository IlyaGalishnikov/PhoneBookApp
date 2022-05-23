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
    /// Логика взаимодействия для AddNumbers2.xaml
    /// </summary>
    public partial class AddNumbers2 : Page
    {
        private Number_Phone _currentNumber_Phone = new Number_Phone();

        public AddNumbers2(Number_Phone SelectedNumber_Phone)
        {
            InitializeComponent();

            if (SelectedNumber_Phone != null)
                _currentNumber_Phone = SelectedNumber_Phone;
            else
                _currentNumber_Phone.Number_Users = new Number_Users() { Number_User = KPGalishnikovEntities.GetContext().Number_Users.Max(x => x.Number_User) + 1 };




            DataContext = _currentNumber_Phone;


            ComboTypes.ItemsSource = KPGalishnikovEntities.GetContext().Type_Phone.ToList();
            ComboUser.ItemsSource = KPGalishnikovEntities.GetContext().Number_Users.ToList();


        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (_currentNumber_Phone.Number_Phone1 == null)
                errors.AppendLine("Укажите номер телефона");
            if (_currentNumber_Phone.Type_Phone.Name_Type == null)
                errors.AppendLine("Выберите тип телефона");
            if (_currentNumber_Phone.Number_User == null)
                errors.AppendLine("Выберите код пользователя");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentNumber_Phone.Number_Zapisi == 0)
            {
                _currentNumber_Phone.Number_Zapisi = KPGalishnikovEntities.GetContext().Number_Phone.Select(x => x.Number_Zapisi).Max() + 1;
                KPGalishnikovEntities.GetContext().Number_Phone.Add(_currentNumber_Phone);
            }

            try
            {
                KPGalishnikovEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
