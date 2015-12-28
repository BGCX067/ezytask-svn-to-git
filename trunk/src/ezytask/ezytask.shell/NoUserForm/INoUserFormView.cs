using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ezytask.shell.NoUserForm
{
    interface INoUserFormView
    {
        string FirstName { get; }
        string LastName { get; }
        string Email { get; }

    }
}
