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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder errors = new StringBuilder();
                if (String.IsNullOrEmpty(LoginBox.Text))
                {
                    errors.AppendLine("Введите логин");
                }
                if (String.IsNullOrEmpty(PasswordBox.Password))
                {
                    errors.AppendLine("Введите пароль");
                }
                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
               if(Data.SportsEntities.GetContext().User.Any(d=> d.Login == LoginBox.Text && d.Password == PasswordBox.Password))
                {
                    Manager.MainFrame.Navigate(new ViewPage());
                    MessageBox.Show("Успех!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch { }
        }
    }
}
