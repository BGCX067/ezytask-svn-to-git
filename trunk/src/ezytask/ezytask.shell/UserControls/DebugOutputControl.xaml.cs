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
using ezytask.utilities;
using System.Diagnostics;

namespace ezytask.shell.UserControls
{
    /// <summary>
    /// Interaction logic for DebugOutputControl.xaml
    /// </summary>
    public partial class DebugOutputControl : UserControl
    {
        public DebugOutputControl()
        {
            InitializeComponent();
            this.txtOutput.Text += "ezytask debug output:\n";
            this.txtOutput.Text += "=====================\n";


            TextBoxTraceListener listener = new TextBoxTraceListener(txtOutput);
            Trace.Listeners.Add(listener);
            //Debug.Listeners.Add(listener);
        }

        private void fontIncrease_Click(object sender, RoutedEventArgs e)
        {
            if (txtOutput.FontSize < 30)
                txtOutput.FontSize++;
        }

        private void fontDecrease_Click(object sender, RoutedEventArgs e)
        {
            if (txtOutput.FontSize > 5)
                txtOutput.FontSize--;
        }

        private void clearLog_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
