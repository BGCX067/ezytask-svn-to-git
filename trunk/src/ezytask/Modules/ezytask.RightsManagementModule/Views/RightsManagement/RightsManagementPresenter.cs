using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using ezytask.infrastructure.Data;
using DataStore = ezytask.infrastructure.Data.ezytaskDataStore;
using System.Windows;
using ezytask.infrastructure;

namespace ezytask.RightsManagementModule.Views.RightsManagement
{
    class RightsManagementPresenter : PresenterBase<IRightsManagementView>
    {
        private bool m_IsDirty;

        public bool IsDirty
        {
            get { return m_IsDirty; }
            set { m_IsDirty = value; }
        }

        private Role m_SelectedRole;
        public Role SelectedRole
        {
            get { return m_SelectedRole; }
            set 
            { 
                m_SelectedRole = value;
                if (m_SelectedRole != null)
                {
                    m_View.RightsOfCurrentRole = this.GetRightsForSelectedRole();
                    m_IsDirty = false;
                }
            }
        }

        public RightsManagementPresenter(IRightsManagementView view)
            : base(view)
        {
            m_View.Roles = this.Roles;
            m_View.Rights = this.AllRights;
        }

        private Role[] Roles
        {
            get
            {
                var expr = from roles in DataStore.DataContext.Roles
                           select roles;
                return expr.ToArray<Role>();
            }
        }

        public Right[] GetRightsForSelectedRole()
        {
            if (m_SelectedRole != null)
            {

                var expr = from rights in DataStore.DataContext.Rights
                           join rr in DataStore.DataContext.Roles_Rights
                           on rights.IdRight equals rr.IdRight
                           where rr.IdRole == m_SelectedRole.IdRole
                           select rights;

                //var expr = from rights in DataStore.DataContext.Rights
                //           join rr in DataStore.DataContext.Roles_Rights
                //           on rights.IdRight equals rr.IdRight into rolesrights
                //           from items in rolesrights.DefaultIfEmpty()
                //           select new Right
                //           {
                //               IdRight = rights.IdRight,
                //               Name = rights.Name,
                //               HasRight = items.IdRight == null ? false : true
                //           };

                return expr.ToArray();
            }
            else
            {
                return null;
            }

        }

        public Right[] AllRights
        {
            get
            {
                return DataStore.DataContext.Rights.ToArray();
            }
        }

        internal void CreateRole(string roleName)
        {
            if (roleName.Trim().Length == 0)
            {
                MessageBox.Show("Please input a name for the role!");
                return;
            }
            if (this.Roles.Where(p => p.Name.Equals(roleName.Trim())).Count() > 0)
            {
                MessageBox.Show("This role already exist!");
                return;
            }

            Role newRole = new Role();
            newRole.Name = roleName;

            DataStore.DataContext.Roles.InsertOnSubmit(newRole);
            DataStore.DataContext.SubmitChanges();

            m_View.Roles = this.Roles;
            m_View.SelectedRole = newRole;
        }

        internal void AssignRightToRole(string idRight)
        {
            if (m_SelectedRole != null)
            {
                Roles_Right newEntity = new Roles_Right();
                newEntity.IdRight = idRight;
                newEntity.IdRole = m_SelectedRole.IdRole;

                if (DataStore.DataContext.Roles_Rights
                    .Where(p => p.IdRight == idRight && p.IdRole == m_SelectedRole.IdRole)
                    .Count() == 0)
                {
                    DataStore.DataContext.Roles_Rights.InsertOnSubmit(newEntity);
                    m_IsDirty = true;
                }
            }
        }

        internal void RemoveRightFromRole(string idRight)
        {
            if (m_SelectedRole != null)
            {
                Roles_Right toRemove = DataStore.DataContext.Roles_Rights
                        .Where(p => p.IdRole == m_SelectedRole.IdRole && p.IdRight == idRight).FirstOrDefault();

                if (toRemove != null)
                {
                    m_SelectedRole.Roles_Rights.Remove(toRemove);
                    m_IsDirty = true;
                }
            }
        }

        internal void SaveChanges()
        {
            if (m_IsDirty)
            {
                DataStore.DataContext.SubmitChanges();
                m_IsDirty = false;
            }
        }

        internal void UpdateRoleName(string roleName)
        {
            if (roleName.Trim().Length == 0)
            {
                MessageBox.Show("Please input a name for the role!");
                return;
            }
            if (this.Roles.Where(p => p.Name.Equals(roleName.Trim()) && p.IdRole != m_SelectedRole.IdRole).Count() > 0)
            {
                MessageBox.Show("This role already exist!");
                return;
            }

            m_SelectedRole.Name = roleName;
            DataStore.DataContext.SubmitChanges();

            m_View.Roles = this.Roles;
            m_View.SelectedRole = m_SelectedRole;
        }
    }
}
