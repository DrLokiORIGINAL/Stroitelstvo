using Stroitelstvo.ClassFolder;
using Stroitelstvo.DataFolder;
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
using System.Windows.Shapes;

namespace Stroitelstvo.WindowFolder.ManagerFolder
{
    /// <summary>
    /// Логика взаимодействия для AddManagerClientWindow.xaml
    /// </summary>
    public partial class AddManagerClientWindow : Window
    {
        public AddManagerClientWindow()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (FirstName.Text == String.Empty)
            {
                MBClass.ErrorMB("Введите Имя");
            }
            else if (LastName.Text == String.Empty)
            {
                MBClass.ErrorMB("Введите Фамилия");
            }
            else if (MiddleName.Text == String.Empty)
            {
                MBClass.ErrorMB("Введите Отчество");
            }
            else if (PhoneNumber.Text == String.Empty)
            {
                MBClass.ErrorMB("Введите Номер телефона");
            }
            else if (Email.Text == String.Empty)
            {
                MBClass.ErrorMB("Введите Эл. Почту");
            }
            else
            {
                AddUser();
                MBClass.InformationMB("Пользователь зарегистрирован");
                this.Close();
            }
        }
        private void AddUser()
        {
            DBEntities.Getcontext().Clients.Add(new Client()
            {
                LastName = LastName.Text,
                FirstName = FirstName.Text,
                MiddleName = MiddleName.Text,
                PhoneNumber = PhoneNumber.Text,
                Email = Email.Text
            });
            DBEntities.Getcontext().SaveChanges();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
