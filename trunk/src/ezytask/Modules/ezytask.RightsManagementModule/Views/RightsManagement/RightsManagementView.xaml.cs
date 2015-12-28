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
using ezytask.utilities;

namespace ezytask.RightsManagementModule.Views.RightsManagement
{
    /// <summary>
    /// Interaction logic for RightsManagementView.xaml
    /// </summary>
    public partial class RightsManagementView : UserControl, IRightsManagementView
    {
        private RightsManagementPresenter _presenter;
        private RightCollectionDataView RightCollection;

        public Role[] Roles
        {
            set
            {
                lbRoles.Items.Clear();

                foreach (Role role in value)
                {
                    TextBlock tb = new TextBlock();
                    tb.Tag = role;
                    tb.Text = role.Name;
                    tb.ContextMenu = lbRoles.ContextMenu;

                    lbRoles.Items.Add(tb);
                }
            }
        }

        public Role SelectedRole
        {
            set
            {
                foreach (TextBlock tb in lbRoles.Items)
                {
                    if ((tb.Tag as Role).IdRole == value.IdRole)
                    {
                        lbRoles.SelectedItem = tb;
                        break;
                    }
                }
            }
        }

        public Right[] Rights
        {
            set
            {
                this.RightCollection = new RightCollectionDataView(
                    (from r in value
                     select new RightDataView(r)).ToList());

                this.gridRights.DataContext = RightCollection;

                this.RightCollection.InternalCollection.ForEach(
                    r => r.PropertyChanged += (sender, e) =>
                    {
                        RightDataView rdv = sender as RightDataView;
                        if (rdv.IsChecked)
                            _presenter.AssignRightToRole(rdv.IdRight);
                        else
                            _presenter.RemoveRightFromRole(rdv.IdRight);
                    });
            }
        }

        public Right[] RightsOfCurrentRole
        {
            set
            {
                foreach (RightDataView rdv in this.RightCollection.InternalCollection)
                {
                    if (value.Where(p => p.IdRight == rdv.IdRight).Count() == 1)
                        rdv.IsChecked = true;
                    else
                        rdv.IsChecked = false;
                }
            }
        }

        public RightsManagementView()
        {
            InitializeComponent();
            _presenter = new RightsManagementPresenter(this);
        }

        private void mnuEditRole_Click(object sender, RoutedEventArgs e)
        {
            txtRoleName.Text = _presenter.SelectedRole.Name;
            gridCreateRole.Visibility = Visibility.Visible;
            gridOKButton.Visibility = Visibility.Collapsed;
            btnCreateRole.Content = "Edit Role";
        }

        private void mnuAddRole_Click(object sender, RoutedEventArgs e)
        {
            gridCreateRole.Visibility = Visibility.Visible;
            gridOKButton.Visibility = Visibility.Collapsed;
        }

        private void btnCreateRole_Click(object sender, RoutedEventArgs e)
        {

            if (btnCreateRole.Content as string == "Create Role")
            {
                _presenter.CreateRole(txtRoleName.Text);
            }
            else if (btnCreateRole.Content as string == "Edit Role")
            {
                _presenter.UpdateRoleName(txtRoleName.Text);
            }
            txtRoleName.Text = String.Empty;
            gridCreateRole.Visibility = Visibility.Collapsed;
            gridOKButton.Visibility = Visibility.Visible;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ContextMenu_Opened(object sender, RoutedEventArgs e)
        {
            if (lbRoles.SelectedItems.Count == 0)
            {
                mnuEditRole.IsEnabled = false;
            }
            else
            {
                mnuEditRole.IsEnabled = true;
            }
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            _presenter.SaveChanges();
        }

        private void lbRoles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (_presenter.IsDirty)
            //{
            //    //if (MessageBox.Show("You have unsaved changes. Are you sure you want to proceed?", "Unsaved changes", MessageBoxButton.YesNo, MessageBoxImage.Question)
            //    //    == MessageBoxResult.No)
            //    //{
            //    //    lbRoles.SelectedItem = e.RemovedItems[0];
            //    //    return;
            //    //}
            //}

            if (lbRoles.SelectedItem != null)
            {
                _presenter.SelectedRole = (Role)((TextBlock)lbRoles.SelectedItem).Tag;
            }
            else
            {
                _presenter.SelectedRole = null;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.txtRoleName.Clear();
            gridCreateRole.Visibility = Visibility.Collapsed;
            gridOKButton.Visibility = Visibility.Visible;

        }

        private void lbRoles_MouseDown(object sender, MouseButtonEventArgs e)
        {
            object item = null;
            item = ezytask.utilities.Utilities.GetElementFromPoint(lbRoles, e.GetPosition(lbRoles));
            if (item != null)
                lbRoles.SelectedItem = item;
        }
    }
}
