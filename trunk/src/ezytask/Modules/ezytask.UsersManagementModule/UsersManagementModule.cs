using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Composite.Events;
using ezytask.infrastructure;
using ezytask.UsersManagementModule.Views.ApplicationMenuButton;
using ezytask.UsersManagementModule.Views.RibbonTabItem;
using ezytask.UsersManagementModule.Views.EditUser;
using Infragistics.Windows.DockManager;
using System.Diagnostics;
using ezytask.infrastructure.Constants;
using ezytask.UsersManagementModule.Views.UserList;

namespace ezytask.UsersManagementModule
{
    public class UsersManagementModule : ezytaskModule
    {
        ApplicationMenuButtonView m_UsersButton;
        UsersRibbonTabItemView m_RibbonTabItem;
        EditUserView m_EditUser;
        UserListView m_UserList;

        public UsersManagementModule(IRegionManager regionManager, IModuleManager moduleManager, IEventAggregator eventAggregator)
            : base(regionManager, moduleManager, eventAggregator)
        {
            m_UsersButton = new ApplicationMenuButtonView(this);
            m_RibbonTabItem = new UsersRibbonTabItemView(this);
            m_EditUser = new EditUserView(this);
            m_UserList = new UserListView();
        }

        protected override void InitializeInChildModules()
        {
            base.ApplicationMenuRegion.Add(m_UsersButton);

            m_RibbonTabItem.ContainerRibbon.Tabs.Clear();
            base.RibbonBarRegion.Add(m_RibbonTabItem.UserManagementRibbon);


        }


        internal void ShowAddEditUserView()
        {
            //IS THE VIEW ALREADLY LOADED?

            object objEditUser = base.DocumentRegion.GetView(m_EditUser.GetType().Name);

            if ( objEditUser == null)
            {
                //NO

                try
                {
                    m_EditUser.Content = null;
                    base.DocumentRegion.Add(m_EditUser.ContentPane, m_EditUser.GetType().Name);
                    m_EditUser.ContentPane.Activate();
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                //YES

                (objEditUser as ContentPane).Visibility = System.Windows.Visibility.Visible;
                (objEditUser as ContentPane).Activate();
            }
        }

        internal void EditUser()
        {
            object objUserList = base.DocumentRegion.GetView(m_UserList.GetType().Name);
            if (objUserList != null)
            {
                int? id = m_UserList.SelectedIdUser;
                m_EditUser.IdUser = id;
                ShowAddEditUserView();
            }
        }


        public override void ApplySecurity()
        {
            Trace.WriteLine("UsersManagementModule : ApplySecurity()...");
            if (!UserInstance.CurrentUser.HasRightTo(Rights.USR_MGR))
            {
                m_UsersButton.Visibility = System.Windows.Visibility.Collapsed;
                m_RibbonTabItem.UserManagementRibbon.Visibility = System.Windows.Visibility.Collapsed;
            }

        }

        internal void ShowUserList()
        {
            object objUserList = base.DocumentRegion.GetView(m_UserList.GetType().Name);
            if (objUserList == null)
            {
                try
                {
                    m_UserList.Content = null;
                    base.DocumentRegion.Add(m_UserList.ContentPane, m_UserList.GetType().Name);
                    m_UserList.ContentPane.Activate();
                }
                catch (Exception) { }
            }
            else
            {
                (objUserList as ContentPane).Visibility = System.Windows.Visibility.Visible;
                (objUserList as ContentPane).Activate();
            }
        }
    }
}
