using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ezytask.infrastructure.Data;

namespace ezytask.UsersManagementModule.Views.EditUser
{
    interface IEditUserView
    {
        string FirstName { get; set;}
        string LastName { get; set; }
        string Email { get; set; }
        int? IdRole { get; set; }

        List<Role> Roles { get; set; }
    }
}
