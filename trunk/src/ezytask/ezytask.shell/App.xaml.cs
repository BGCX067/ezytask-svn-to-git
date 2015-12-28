using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using ezytask.infrastructure;
using ezytask.shell.NoUserForm;
using ezytask.shell.Login;

namespace ezytask.shell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            

            Bootstrapper bootstrapper = new Bootstrapper();
            bootstrapper.Run();

            if (UserInstance.IsDatabaseEmpty)
            {
                NoUserFormView frmNoUser = new NoUserFormView();
                frmNoUser.ShowDialog();
            }
            else
            {
                LoginFormView frmLogin = new LoginFormView();
                frmLogin.ShowDialog();
                if (UserInstance.CurrentUser != null)
                {
                    base.OnStartup(e);
                    bootstrapper.ApplySecurity();
                    bootstrapper.Shell.Show();
                }
                else
                {
                    App.Current.MainWindow.Close();
                }
            }
        }
    }
}
