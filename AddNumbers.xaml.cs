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
    /// Логика взаимодействия для AddNumbers.xaml
    /// </summary>
    public partial class AddNumbers : Page
    {
        public AddNumbers()
        {
            InitializeComponent();
            DGridPhoneBook.ItemsSource = KPGalishnikovEntities.GetContext().Number_Phone.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            manager.MainFrame.Navigate(new AddNumbers2((sender as Button).DataContext as Number_Phone));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            manager.MainFrame.Navigate(new AddNumbers2(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var Number_phoneForRemoving = DGridPhoneBook.SelectedItems;

            if (MessageBox.Show($"Подтвердите удаление выбранных элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try

                {

                    foreach (var c in Number_phoneForRemoving)
                    {
                        Number_Phone p = c as Number_Phone;
                        KPGalishnikovEntities.GetContext().Number_Users.Remove(p.Number_Users);
                        KPGalishnikovEntities.GetContext().Number_Phone.Remove(p);
                    }
                    KPGalishnikovEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");


                    DGridPhoneBook.ItemsSource = KPGalishnikovEntities.GetContext().Number_Phone.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
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

