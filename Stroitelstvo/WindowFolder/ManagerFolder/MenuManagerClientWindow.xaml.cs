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
    /// Логика взаимодействия для MenuManagerWindow2.xaml
    /// </summary>
    public partial class MenuManagerClientWindow : Window
    {
        public MenuManagerClientWindow()
        {
            InitializeComponent();
            UserDG.ItemsSource = DBEntities.Getcontext().Clients.ToList()
               .OrderBy(c => c.IdClient);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            new AddManagerClientWindow().ShowDialog();
        }

        private void EditClient_Click(object sender, RoutedEventArgs e)
        {
            Client client = UserDG.SelectedItem as Client;
            VariableClass.IdClient = client.IdClient;
            new EditManagerClientWindow(client).ShowDialog();
        }

        private void UserDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Client client = UserDG.SelectedItem as Client;
            VariableClass.IdClient = client.IdClient;
            new EditManagerClientWindow(client).ShowDialog();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                UserDG.ItemsSource = DBEntities.Getcontext().Clients.Where
                (u => u.LastName.StartsWith(SearchTb.Text)).ToList();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
