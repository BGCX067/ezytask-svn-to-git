using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Windows.Ribbon;
using System.Windows.Media.Imaging;

namespace ezytask.UsersManagementModule.Views.RibbonTabItem
{
    class RibbonTabItemView : Infragistics.Windows.Ribbon.RibbonTabItem
    {
        public RibbonTabItemView()
        {
            this.Header = "User Management";

            BitmapImage imageAddUsers = new BitmapImage();
            imageAddUsers.BeginInit();
            imageAddUsers.UriSource = new Uri(@"/ezytask.UsersManagementModule;component/Resources/add_user.png", UriKind.RelativeOrAbsolute);
            imageAddUsers.EndInit();

            ButtonTool btnAddUsers = new ButtonTool();
            btnAddUsers.LargeImage = imageAddUsers;
            btnAddUsers.SmallImage = imageAddUsers;
            btnAddUsers.Caption= "Add User";
            


            
            BitmapImage imageEditUsers = new BitmapImage();
            imageEditUsers.BeginInit();
            imageEditUsers.UriSource = new Uri(@"/ezytask.UsersManagementModule;component/Resources/edit_user.png", UriKind.RelativeOrAbsolute);
            imageEditUsers.EndInit();

            ButtonTool btnEditUsers = new ButtonTool();
            btnEditUsers.LargeImage = imageEditUsers;
            btnEditUsers.Caption = "Edit User";




            RibbonGroup groupActions = new RibbonGroup();
            RibbonGroup.SetMaximumSize(groupActions, RibbonToolSizingMode.ImageAndTextLarge);
            RibbonGroup.SetMinimumSize(groupActions, RibbonToolSizingMode.ImageAndTextLarge);

            ToolVerticalWrapPanel panelVertical = new ToolVerticalWrapPanel();
            ToolHorizontalWrapPanel panel = new ToolHorizontalWrapPanel();
            panel.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            panel.Children.Add(btnAddUsers);
            panel.Children.Add(btnEditUsers);

            panelVertical.Children.Add(panel);

            groupActions.Items.Add(panelVertical);

            //RibbonGroup.SetMaximumSize(groupActions, RibbonToolSizingMode.ImageAndTextLarge);
            //RibbonGroup.SetMinimumSize(groupActions, RibbonToolSizingMode.ImageAndTextLarge);

            this.RibbonGroups.Add(groupActions);
            
        }
    }
}
