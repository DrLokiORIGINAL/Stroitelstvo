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
    /// Логика взаимодействия для MenuManagerWindow.xaml
    /// </summary>
    public partial class MenuManagerWindow : Window
    {
        public MenuManagerWindow()
        {
            InitializeComponent();
            UserDG.ItemsSource = DBEntities.Getcontext().Staffs.ToList()
               .OrderBy(c => c.IdStaff);
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                UserDG.ItemsSource = DBEntities.Getcontext().Staffs.Where
                (u => u.LastName.StartsWith(SearchTb.Text)).ToList();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void AddStaff_Click(object sender, RoutedEventArgs e)
        {
            new AddManagerWindow().ShowDialog();
        }

        private void EditStaff_Click(object sender, RoutedEventArgs e)
        {
            Staff staff = UserDG.SelectedItem as Staff;
            VariableClass.IdStaff = staff.IdStaff;
            new EditManagerWindow(staff).ShowDialog();
        }

        private void UserDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Staff staff = UserDG.SelectedItem as Staff;
            VariableClass.IdStaff = staff.IdStaff;
            new EditManagerWindow(staff).ShowDialog();
        }

        private void Perehod_Click(object sender, RoutedEventArgs e)
        {
            new MenuManagerClientWindow().ShowDialog();
        }
    }
}
