using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ezytask.infrastructure;
using ezytask.infrastructure.Data;
using DataStore = ezytask.infrastructure.Data.ezytaskDataStore;

namespace ezytask.UsersManagementModule.Views.UserList
{
    class UserListPresenter : PresenterBase<IUserListView>
    {
        public UserListPresenter(IUserListView view)
            : base(view)
        {
            m_View.UserList = (from u in DataStore.DataContext.Users
                               select new UserDataView(u)).ToList();
        }
    }
}
