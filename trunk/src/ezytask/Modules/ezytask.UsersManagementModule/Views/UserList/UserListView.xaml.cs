using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ezytask.infrastructure.Data;

namespace ezytask.UsersManagementModule.Views.UserList
{
    /// <summary>
    /// Interaction logic for UserListView.xaml
    /// </summary>
    public partial class UserListView : UserControl, IUserListView
    {
        private UserListPresenter _presenter;
        private List<UserDataView> m_UserList;

        private UserDataView m_SelectedUser;

        public int? SelectedIdUser
        {
            get
            {
                if (m_SelectedUser != null)
                    return m_SelectedUser.IdUser;
                else
                    return null;
            }
        }

        public UserListView()
        {
            InitializeComponent();

            _presenter = new UserListPresenter(this);
        }

        #region IUserListView Members

        public List<UserDataView> UserList
        {
            set
            {
                m_UserList = value;
                this.gridUsers.DataSource = this.m_UserList;
            }
        }

        #endregion

        private void gridUsers_RecordActivated(object sender, Infragistics.Windows.DataPresenter.Events.RecordActivatedEventArgs e)
        {
            if (e.Record != null)
                m_SelectedUser = (UserDataView)(e.Record as Infragistics.Windows.DataPresenter.DataRecord).DataItem;
            else
                m_SelectedUser = null;

        }
    }
}
