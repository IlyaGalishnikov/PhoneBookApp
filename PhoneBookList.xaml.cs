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
    /// Логика взаимодействия для PhoneBookList.xaml
    /// </summary>
    public partial class PhoneBookList : Page
    {
        public PhoneBookList()
        {
            InitializeComponent();

            

            var currentNumber_Phone = KPGalishnikovEntities.GetContext().Number_Phone.ToList();
            LViewPhoneBook.ItemsSource = currentNumber_Phone;


        }

        private void UpdateNumber_Phone()
        {
            string str = TBoxSearch.Text.ToLower();
            var currentNumber_Phone = KPGalishnikovEntities.GetContext().Number_Phone.Where(p => p.Number_Users.Surname.ToLower().StartsWith(str)).ToList();
            LViewPhoneBook.ItemsSource = currentNumber_Phone.OrderBy(p => p.Number_User).ToList();


        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateNumber_Phone();
        }

        private void TBoxSearch2_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateNumber_Phone();
        }

        private void ComboNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
