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
using Stroitelstvo.ClassFolder;
using Stroitelstvo.DataFolder;

namespace Stroitelstvo.WindowFolder.ManagerFolder
{
    /// <summary>
    /// Логика взаимодействия для EditManagerWindow.xaml
    /// </summary>
    public partial class EditManagerWindow : Window
    {
        public EditManagerWindow(Staff staff)
        {
            InitializeComponent();
            DataContext = staff;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Staff staff = DBEntities.Getcontext().Staffs.
               FirstOrDefault(s => s.IdStaff == VariableClass.IdStaff);
            staff.FirstName = FirstName.Text;
            staff.LastName = LastName.Text;
            staff.MiddleName = MiddleName.Text;
            staff.PhoneNumber = NumberPhone.Text;
            staff.Email = Email.Text;
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
