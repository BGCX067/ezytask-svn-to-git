using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace ezytask.utilities
{
    public static class ListViewHelper
    {
        public static FrameworkElement GetElementFromCellTemplate(ListView listView, Int32 column, Int32 row, String name)
        {
            if (row >= listView.Items.Count || row < 0)
            {
                throw new ArgumentOutOfRangeException("row");
            }

            GridView gridView = listView.View as GridView;
            if (gridView == null)
            {
                return null;
            }

            if (column >= gridView.Columns.Count || column < 0)
            {
                throw new ArgumentOutOfRangeException("column");
            }

            ListViewItem item = listView.ItemContainerGenerator.ContainerFromItem(listView.Items[row]) as ListViewItem;
            if (item != null)
            {
                GridViewRowPresenter rowPresenter = GetFrameworkElementByName<GridViewRowPresenter>(item);
                if (rowPresenter != null)
                {
                    ContentPresenter templatedParent = VisualTreeHelper.GetChild(rowPresenter, column) as ContentPresenter;
                    DataTemplate dataTemplate = gridView.Columns[column].CellTemplate;
                    if (dataTemplate != null && templatedParent != null)
                    {
                        return dataTemplate.FindName(name, templatedParent) as FrameworkElement;
                    }
                }
            }

            return null;
        }

        private static T GetFrameworkElementByName<T>(FrameworkElement referenceElement) where T : FrameworkElement
        {
            FrameworkElement child = null;
            for (Int32 i = 0; i < VisualTreeHelper.GetChildrenCount(referenceElement); i++)
            {
                child = VisualTreeHelper.GetChild(referenceElement, i) as FrameworkElement;
                System.Diagnostics.Debug.WriteLine(child);
                if (child != null && child.GetType() == typeof(T))
                {
                    break;
                }
                else if (child != null)
                {
                    child = GetFrameworkElementByName<T>(child);
                    if (child != null && child.GetType() == typeof(T))
                    {
                        break;
                    }
                }
            }
            return child as T;
        }
    }
}
