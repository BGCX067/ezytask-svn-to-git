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
using System.Windows.Shapes;

namespace ezytask.shell.NoUserForm
{
    /// <summary>
    /// Interaction logic for NoUserForm.xaml
    /// </summary>
    public partial class NoUserFormView : Window, INoUserFormView
    {
        private NoUserFormPresenter _presenter;

        public NoUserFormView()
        {
            InitializeComponent();

            _presenter = new NoUserFormPresenter(this);
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            _presenter.CreateUser();   
        }

        #region INoUserFormView Members

        public string FirstName
        {
            get { return txtFirstName.Text; }
        }

        public string LastName
        {
            get { return txtLastName.Text; }
        }

        public string Email
        {
            get { return txtEmail.Text; }
        }

        #endregion
    }
}
