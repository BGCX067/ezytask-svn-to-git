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
using ezytask.infrastructure.Data;

namespace ezytask.UsersManagementModule.Views.EditUser
{
    /// <summary>
    /// Interaction logic for EditUserView.xaml
    /// </summary>
    public partial class EditUserView : UserControl, IEditUserView
    {
        private UsersManagementModule umm;
        private EditUserPresenter _presenter;
        private List<Role> m_Roles;


        public EditUserView(UsersManagementModule umm)
        {
            this.umm = umm;
            InitializeComponent();

            _presenter = new EditUserPresenter(this);
        }

        public int? IdUser
        {
            set
            {
                _presenter.LoadUser(value);
            }
        }

        #region IEditUserView Members

        public string FirstName
        {
            get
            {
                return txtFirstName.Text.Trim();
            }
            set
            {
                txtFirstName.Text = value;
            }
        }

        public string LastName
        {
            get
            {
                return txtLastName.Text.Trim();
            }
            set
            {
                txtLastName.Text = value;
            }
        }

        public string Email
        {
            get
            {
                return txtEmail.Text.Trim();
            }
            set
            {
                txtEmail.Text = value;
            }
        }

        public int? IdRole
        {
            get
            {
                return (int?)cmbRole.SelectedValue;
            }
            set
            {
                cmbRole.SelectedValue = value;
            }
        }

        public List<Role> Roles
        {
            set { m_Roles = value; cmbRole.ItemsSource = this.Roles; }
            get { return m_Roles; }
        }

        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _presenter.Save();
        }
    }
}
