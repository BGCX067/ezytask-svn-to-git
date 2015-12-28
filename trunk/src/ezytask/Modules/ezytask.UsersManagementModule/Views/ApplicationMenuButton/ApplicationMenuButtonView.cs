using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Windows.Ribbon;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ezytask.UsersManagementModule.Views.ApplicationMenuButton
{
    public class ApplicationMenuButtonView : ButtonTool
    {
        private UsersManagementModule umm;

        public ApplicationMenuButtonView(UsersManagementModule umm)
            : base()
        {

            this.umm = umm;

            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(@"/ezytask.UsersManagementModule;component/Resources/users.png", UriKind.RelativeOrAbsolute);
            image.EndInit();

            this.SmallImage = image;
            this.Content = "Users";

            this.Click += (sender, e) => 
            {
                umm.ShowUserList();
            };
        }
    }
}
