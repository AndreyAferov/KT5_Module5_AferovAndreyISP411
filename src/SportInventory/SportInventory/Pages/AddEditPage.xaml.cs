using SportInventory.Classes;
using SportInventory.Data;
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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        public Data.User _currentUser = new Data.User();
        public AddEditPage(Data.User user)
        {
            InitializeComponent();


                IdTextBox.Text = Data.SportsEntities.GetContext().User.Max(g => g.Id + 1).ToString();
                _currentUser.Id = Data.SportsEntities.GetContext().User.Max(g => g.Id) + 1;

            DataContext = _currentUser;
            Init();
        }
        private void Init()
        {
            RoleCombo.ItemsSource = Data.SportsEntities.GetContext().Role.ToList();
            GenderComboBox.ItemsSource = Data.SportsEntities.GetContext().FemaleMale.ToList();
        }

            private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ViewPage());
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

                StringBuilder errors = new StringBuilder();

                if (string.IsNullOrEmpty(Surname.Text))
                {
                    errors.AppendLine("Введите фамилию");
                }
                if (string.IsNullOrEmpty(Name.Text))
                {
                    errors.AppendLine("Введите имя");
                }
                if (string.IsNullOrEmpty(Patronymic.Text))
                {
                    errors.AppendLine("Введите отчество");
                }
                if (RoleCombo.SelectedItem == null)
                {
                    errors.AppendLine("Выберите должность");
                }
                if (string.IsNullOrEmpty(BirthDate.Text))
                {
                    errors.AppendLine("Введите дату рождения");
                }
                if (string.IsNullOrEmpty(Phone.Text))
                {
                    errors.AppendLine("Введите номер телефона");
                }
                if (string.IsNullOrEmpty(Email.Text))
                {
                    errors.AppendLine("Введите Email");
                }
                if (Data.SportsEntities.GetContext().User.Any(g => g.Email == Email.Text))
                {
                    errors.AppendLine("Email должен быть уникальным");
                }
                if (string.IsNullOrEmpty(Login.Text))
                {
                    errors.AppendLine("Введите логин");
                }
                if (Data.SportsEntities.GetContext().User.Any(g => g.Login == Login.Text))
                {
                    errors.AppendLine("Логин должен быть уникальным");
                }
                if (string.IsNullOrEmpty(Password.Password))
                {
                    errors.AppendLine("Введите пароль");
                }
                if (Password.Password.Length < 8)
                {
                    errors.AppendLine("Пароль должен содержать минимум 8 символов");
                }
                if (!Password.Password.Any(char.IsDigit))
                {
                errors.AppendLine("Пароль должен содержать цифры");
                }
                if (!Password.Password.Any(char.IsUpper))
                {
                errors.AppendLine("Пароль должен содержать заглавные буквы");
                }
                if (!Password.Password.Any(char.IsLower))
                {
                errors.AppendLine("Пароль должен содержать строчные буквы");
                }
                if (String.IsNullOrEmpty(ConfirmPassword.Password))
                {
                     errors.AppendLine("Подтвердите пароль");
                }

               if (Password.Password != ConfirmPassword.Password)
               {
                  errors.AppendLine("Пароли не совпадают");
               }
                
                
                
                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            
            _currentUser.Surname = Surname.Text;
            _currentUser.Name = Name.Text;
            _currentUser.Patronomyc = Patronymic.Text;
            _currentUser.Role = (RoleCombo.SelectedItem as Role).Id;
            _currentUser.DateBirth = BirthDate.SelectedDate.Value;
            _currentUser.PhoneNumber = Phone.Text;
            _currentUser.FemaleMale = GenderComboBox.SelectedItem as FemaleMale;
            _currentUser.Email = Email.Text;
            _currentUser.Login = Login.Text;
            _currentUser.Password = Password.Password;

            Data.SportsEntities.GetContext().User.Add(_currentUser);

            Data.SportsEntities.GetContext().SaveChanges();
            MessageBox.Show("Успех!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
            Manager.MainFrame.Navigate(new ViewPage());
        }
    }
}
