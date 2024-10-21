using SportInventory.Classes;
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

namespace SportInventory.Pages
{
    /// <summary>
    /// Логика взаимодействия для ViewPage.xaml
    /// </summary>
    public partial class ViewPage : Page
    {
        public ViewPage()
        {
            InitializeComponent();
            Listing.ItemsSource = Data.SportsEntities.GetContext().User.ToList();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new LoginPage());
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage());
        }
    }
}
