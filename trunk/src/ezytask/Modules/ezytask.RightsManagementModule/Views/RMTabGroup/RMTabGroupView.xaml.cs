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

namespace ezytask.RightsManagementModule.Views.RMTabGroup
{
    /// <summary>
    /// Interaction logic for RMTabGroupView.xaml
    /// </summary>
    public partial class RMTabGroupView : UserControl
    {
        private RightsManagementModule rmm;

        public RMTabGroupView(RightsManagementModule rmm)
        {
            this.rmm = rmm;

            InitializeComponent();
        }

        private void ButtonTool_Click(object sender, RoutedEventArgs e)
        {
            rmm.EditRoles();
        }
    }
}
