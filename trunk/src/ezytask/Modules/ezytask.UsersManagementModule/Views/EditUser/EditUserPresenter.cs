using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ezytask.infrastructure.Data;
using DataStore = ezytask.infrastructure.Data.ezytaskDataStore;

namespace ezytask.UsersManagementModule.Views.EditUser
{
    class EditUserPresenter : ezytask.infrastructure.PresenterBase<IEditUserView>
    {
        private User m_User;

        public EditUserPresenter(IEditUserView view)
            : base(view) 
        {
            m_View.Roles = DataStore.DataContext.Roles.ToList();
        }

        public void LoadUser(int? idUser)
        {
            if (idUser != null)
            {
                m_User = DataStore.DataContext.Users.Where(u => u.IdUser == idUser).FirstOrDefault();

                m_View.FirstName = m_User.FirstName;
                m_View.LastName = m_User.LastName;
                m_View.Email = m_User.Email;
                m_View.IdRole = m_User.IdRole;
            }
            else
            {
                m_View.FirstName = string.Empty;
                m_View.LastName = string.Empty;
                m_View.Email = string.Empty;
                m_View.IdRole = null;
            }
        }

        internal void Save()
        {
            #region Validations
            //TODO: validations
            #endregion

            if (m_User == null)
            {
                // NEW USER
                m_User = new User();
                m_User.FirstName = m_View.FirstName;
                m_User.LastName = m_View.LastName;
                m_User.Email = m_View.Email;
                m_User.Role = DataStore.DataContext.Roles.Where(r => r.IdRole == m_View.IdRole).FirstOrDefault();

                DataStore.DataContext.Users.InsertOnSubmit(m_User);
                DataStore.DataContext.SubmitChanges();
            }
        }
    }
}
