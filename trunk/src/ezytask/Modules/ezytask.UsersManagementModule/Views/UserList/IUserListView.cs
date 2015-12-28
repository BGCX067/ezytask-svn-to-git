using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ezytask.infrastructure.Data;

namespace ezytask.UsersManagementModule.Views.UserList
{
    interface IUserListView
    {
        List<UserDataView> UserList { set; }
    }
}
