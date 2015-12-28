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
using System.Configuration;

namespace ezytask.shell.Login
{
    /// <summary>
    /// Interaction logic for LoginFormView.xaml
    /// </summary>
    public partial class LoginFormView : Window, ILoginFormView
    {
        private LoginFormPresenter _presenter;

        public LoginFormView()
        {
            InitializeComponent();

            _presenter = new LoginFormPresenter(this);

#if DEBUG
            this.txtEmail.Text = "teomati@gmail.com";
#endif
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (!_presenter.Login())
            {
                MessageBox.Show("Login failed, please try again!", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                txtEmail.Clear();
                txtEmail.Focus();
            }
            else
            {
                this.Close();
            }
        }

        #region ILoginFormView Members

        public string Email
        {
            get { return txtEmail.Text.Trim(); }
        }

        #endregion
    }
}
