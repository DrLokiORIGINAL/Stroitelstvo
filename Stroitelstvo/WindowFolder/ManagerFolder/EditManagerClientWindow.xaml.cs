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
    /// Логика взаимодействия для EditManagerClientWindow.xaml
    /// </summary>
    public partial class EditManagerClientWindow : Window
    {
        public EditManagerClientWindow(Client client)
        {
            InitializeComponent();
            DataContext = client;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Client client = DBEntities.Getcontext().Clients.
               FirstOrDefault(s => s.IdClient == VariableClass.IdClient);
            client.FirstName = FirstName.Text;
            client.LastName = LastName.Text;
            client.MiddleName = MiddleName.Text;
            client.PhoneNumber = NumberPhone.Text;
            client.Email = Email.Text;
            DBEntities.Getcontext().SaveChanges();
            MBClass.InformationMB("Сотрудник успешно отредактирован");
            new AdminFolder.MenuAdminWindow();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
