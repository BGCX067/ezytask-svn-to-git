using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ezytask.infrastructure;

namespace ezytask.shell.Login
{
    class LoginFormPresenter : PresenterBase<ILoginFormView>
    {
        public LoginFormPresenter(ILoginFormView view) : base(view) { }

        public bool Login()
        {
            return UserInstance.Login(m_View.Email);
        }

    }
}
