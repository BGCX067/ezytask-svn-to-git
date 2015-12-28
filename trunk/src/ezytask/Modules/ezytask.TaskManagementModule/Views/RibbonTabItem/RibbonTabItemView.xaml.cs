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

namespace ezytask.TaskManagementModule.Views.RibbonTabItem
{
    /// <summary>
    /// Interaction logic for RibbonTabItemContainer.xaml
    /// </summary>
    public partial class RibbonTabItemView : UserControl
    {
        private TaskManagementModule tmm;

        public RibbonTabItemView(TaskManagementModule tmm)
        {
            this.tmm = tmm;
            InitializeComponent();
        }

        private void btnProjects_Click(object sender, RoutedEventArgs e)
        {
            tmm.ManageProjects();
        }

        private void btnTasks_Click(object sender, RoutedEventArgs e)
        {
            tmm.ManageTasks();
        }
    }
}
