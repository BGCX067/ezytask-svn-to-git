using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ezytask.infrastructure.Data;

namespace ezytask.RightsManagementModule.Views.RightsManagement
{
    interface IRightsManagementView
    {
        Role[] Roles { set; }
        Role SelectedRole { set; }
        Right[] Rights { set; }
        Right[] RightsOfCurrentRole { set; }

    }
}
