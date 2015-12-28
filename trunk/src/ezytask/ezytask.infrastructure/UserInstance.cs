using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ezytask.infrastructure.Data;
using DataStore = ezytask.infrastructure.Data.ezytaskDataStore;
using ezytask.infrastructure.Constants;

namespace ezytask.infrastructure
{
    public class UserInstance
    {
        static UserInstance m_CurrentUser;
        public static UserInstance CurrentUser
        {
            get { return UserInstance.m_CurrentUser; }
            set { UserInstance.m_CurrentUser = value; }
        }

        private readonly User m_User;


        public UserInstance(User user)
        {
            m_User = user;
        }

        public static bool IsDatabaseEmpty
        {
            get
            {
                return DataStore.DataContext.Users.Count() == 0;
            }
        }

        public static bool Login(string email)
        {
            try
            {
                m_CurrentUser = null;

                User u = DataStore.DataContext.Users.Where(p => p.Email == email).FirstOrDefault();
                if (u == null)
                    return false;

                m_CurrentUser = new UserInstance(u);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool HasRightTo(string right)
        {

            var expr = from u in DataStore.DataContext.Users
                       join rr in DataStore.DataContext.Roles_Rights on u.IdRole equals rr.IdRole
                       where u.IdUser == CurrentUser.m_User.IdUser && rr.IdRight.Trim() == right
                       select rr;

            return expr.Count() != 0;

        }

    }
}
