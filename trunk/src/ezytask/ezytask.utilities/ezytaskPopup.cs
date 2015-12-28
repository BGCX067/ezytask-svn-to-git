using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls.Primitives;
using System.Windows;
using System.Windows.Media.Effects;
using System.Windows.Controls;
using System.Windows.Media;
using System.Timers;
using System.Diagnostics;
using System.Configuration;


namespace ezytask.utilities
{
    public class ezytaskPopup : Popup
    {
        Timer timer;

        private ezytaskPopup() : base()
        {

            this.BeginInit();

            //POPUP properties
            this.Placement = PlacementMode.Center;
            this.AllowsTransparency = true;
            this.PopupAnimation = PopupAnimation.Fade;

            ////THE BORDER
            //Border border = new Border();
            //border.BorderBrush = Brushes.Black;
            //border.Padding = new Thickness(30);
            //border.CornerRadius = new CornerRadius(10);

            ////BORDER's BACKGROUND
            //LinearGradientBrush lgb = new LinearGradientBrush();
            //System.Drawing.Color c1 = System.Drawing.ColorTranslator.FromHtml("#FFFFFFF");
            //System.Drawing.Color c2 = System.Drawing.ColorTranslator.FromHtml("#FCFFF5F");
            //System.Drawing.Color c3 = System.Drawing.ColorTranslator.FromHtml("#3E606FF");

            //lgb.GradientStops.Add(new GradientStop(Color.FromArgb(c1.A, c1.R, c1.G, c1.B), 0));
            //lgb.GradientStops.Add(new GradientStop(Color.FromArgb(c2.A, c2.R, c2.G, c2.B), 0.992));
            //lgb.GradientStops.Add(new GradientStop(Color.FromArgb(c3.A, c3.R, c3.G, c3.B), 0.185));

            //lgb.StartPoint = new Point(0.5, 0);
            //lgb.EndPoint = new Point(0.5, 1);

            //border.Background = lgb;
            //border.BorderBrush = Brushes.Black;
            //border.BorderThickness = new Thickness(2);


            //TextBlock tb = new TextBlock();
            //tb.Text = "Saved!";

            //border.Child = tb;

            this.Child = (Border)Application.Current.Resources["SavePopup"];

            this.EndInit();

            this.Opened += new EventHandler(ezytaskPopup_Opened);

            double delay = Double.Parse(ConfigurationManager.AppSettings["PopupDelay"]);

            timer = new Timer(delay);
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
        }

        void ezytaskPopup_Opened(object sender, EventArgs e)
        {
            Trace.WriteLine("Popup opened");
            timer.Enabled = true;
            timer.Start();
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke((Action)delegate()
            {
                this.IsOpen = false;
                Trace.WriteLine("Popup closed");
            });
            
            this.timer.Stop();
            this.timer.Enabled = false;
        }

        private static ezytaskPopup m_Instance;

        public static ezytaskPopup Instance
        {
            get 
            {
                if (m_Instance == null)
                    m_Instance = new ezytaskPopup();

                return m_Instance;
            }
        }

    }
}
