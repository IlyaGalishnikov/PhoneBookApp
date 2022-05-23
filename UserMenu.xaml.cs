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
    /// Логика взаимодействия для UserMenu.xaml
    /// </summary>
    public partial class UserMenu : Page
    {
        public UserMenu()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            manager.MainFrame.Navigate(new PhoneBookList());
        }

        private void Abonent_Click(object sender, RoutedEventArgs e)
        {
            manager.MainFrame.Navigate(new Go());
        }

        private void AddAnotherPhone_Click(object sender, RoutedEventArgs e)
        {
            manager.MainFrame.Navigate(new AddNumbers());
        }

        
    }
}
