using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using ezytask.infrastructure.Data;
using DataStore = ezytask.infrastructure.Data.ezytaskDataStore;
using ezytask.infrastructure;

namespace ezytask.shell.NoUserForm
{
    class NoUserFormPresenter : PresenterBase<INoUserFormView>
    {
        public NoUserFormPresenter(INoUserFormView view) : base(view) { } 

        internal void CreateUser()
        {
            #region Validations
            if (m_View.FirstName.Trim().Length == 0)
            {
                MessageBox.Show("First name is required!", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (m_View.LastName.Trim().Length == 0)
            {
                MessageBox.Show("Last name is required!", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (m_View.Email.Trim().Length == 0)
            {
                MessageBox.Show("Email is required", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            } 
            #endregion

            #region Create Administrator role

            Role adminRole = new Role();
            adminRole.Name = "Administrator";
            DataStore.DataContext.Roles.InsertOnSubmit(adminRole);

            User adminUser = new User();
            adminUser.FirstName = m_View.FirstName;
            adminUser.LastName = m_View.LastName;
            adminUser.Email = m_View.Email;
            adminUser.Role = adminRole;
            DataStore.DataContext.Users.InsertOnSubmit(adminUser);

            DataStore.DataContext.SubmitChanges();

            #endregion
        }
    }
}
