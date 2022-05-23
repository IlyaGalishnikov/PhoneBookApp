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
    /// Логика взаимодействия для Go2.xaml
    /// </summary>
    public partial class Go2 : Page
    {
        public Go2()
        {
            InitializeComponent();
            DGridPhoneBook.ItemsSource = KPGalishnikovEntities.GetContext().Number_Phone.ToList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

       

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                //KPGalishnikovEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridPhoneBook.ItemsSource = KPGalishnikovEntities.GetContext().Number_Phone.ToList();
            }
        }
    }
}
