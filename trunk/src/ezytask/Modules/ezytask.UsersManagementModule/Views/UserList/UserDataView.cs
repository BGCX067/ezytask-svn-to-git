using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ezytask.infrastructure.Data;

namespace ezytask.UsersManagementModule.Views.UserList
{
    public class UserDataView
    {
        private User m_User;

        public int IdUser { get { return m_User.IdUser; } }
        public string FirstName { get { return m_User.FirstName; } }
        public string LastName { get { return m_User.LastName; } }
        public string Email { get { return m_User.Email; } }
        public string Role { get { return m_User.Role.Name; } }

        public UserDataView(User u)
        {
            m_User = u;
        }
    }
}
