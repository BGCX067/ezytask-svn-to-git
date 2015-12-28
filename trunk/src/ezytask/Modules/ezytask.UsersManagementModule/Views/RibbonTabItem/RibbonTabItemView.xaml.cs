using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ezytask.UsersManagementModule.Views.RibbonTabItem
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UsersRibbonTabItemView : UserControl
    {
        UsersManagementModule umm;

        public UsersRibbonTabItemView(UsersManagementModule umm)
        {
            this.umm = umm;

            InitializeComponent();
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            umm.ShowAddEditUserView();
        }

        private void btnEditUser_Click(object sender, RoutedEventArgs e)
        {
            umm.EditUser();
        }

        private void btnUserList_Click(object sender, RoutedEventArgs e)
        {
            umm.ShowUserList();        
        }
    }
}
