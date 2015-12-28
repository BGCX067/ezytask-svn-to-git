using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace ezytask.utilities
{
    public class Utilities
    {
        public static Visual GetDescendantByType(Visual element, Type type, string name)
        {
            if (element == null) return null;
            if (element.GetType() == type)
            {
                FrameworkElement fe = element as FrameworkElement;
                if (fe != null)
                {
                    if (fe.Name == name)
                    {
                        return fe;
                    }
                }
            }
            Visual foundElement = null;
            if (element is FrameworkElement)
                (element as FrameworkElement).ApplyTemplate();
            for (int i = 0;
                i < VisualTreeHelper.GetChildrenCount(element); i++)
            {
                Visual visual = VisualTreeHelper.GetChild(element, i) as Visual;
                foundElement = GetDescendantByType(visual, type, name);
                if (foundElement != null)
                    break;
            }
            return foundElement;
        }

        /// <summary>
        /// hit-test
        /// </summary>
        /// <param name="box"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public static object GetElementFromPoint(ListBox box, Point point)
        {

            UIElement element = (UIElement)box.InputHitTest(point);

            while (true)
            {

                if (element == box)
                {

                    return null;

                }

                object item = box.ItemContainerGenerator.ItemFromContainer(element);

                bool itemFound = !(item.Equals(DependencyProperty.UnsetValue));

                if (itemFound)
                {

                    return item;

                }

                element = (UIElement)VisualTreeHelper.GetParent(element);

            }

        }


        public static void ShowPopup(Panel mainStack)
        {
            if (ezytaskPopup.Instance.Parent != null)
            {
                if (mainStack != ezytaskPopup.Instance.Parent)
                {
                    ((Panel)ezytaskPopup.Instance.Parent).Children.Remove(ezytaskPopup.Instance);
                }
            }

            if (!mainStack.Children.Contains(ezytaskPopup.Instance))
                mainStack.Children.Add(ezytaskPopup.Instance);

            ezytaskPopup.Instance.IsOpen = true;
                
        }
    }
}
