using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using ezytask.utilities;
using ezytask.infrastructure.Data;

namespace ezytask.RightsManagementModule.Views.RightsManagement
{
    class RightDataView : PropertyNotifier
    {
        private Right m_Right;

        private bool m_IsChecked;

        public bool IsChecked
        {
            get { return m_IsChecked; }
            set 
            {
                if (m_IsChecked == value)
                    return;

                m_IsChecked = value;
                base.OnPropertyChanged("IsChecked");
            }
        }

        public string IdRight
        {
            get
            {
                return m_Right.IdRight;
            }
        }

        public string Name
        {
            get
            {
                return m_Right.Name;
            }
        }


        public RightDataView(Right Right)
        {
            this.m_Right = Right;
        }
    }

    class RightCollectionDataView : PropertyNotifier
    {
        public List<RightDataView> InternalCollection
        {
            get;
            private set;
        }

        public bool? AllMembersAreChecked
        {
            get
            {
                bool? value = null;
                for (int i = 0; i < this.InternalCollection.Count; i++)
                {
                    if (i == 0)
                        value = this.InternalCollection[i].IsChecked;
                    else
                    {
                        if (value != this.InternalCollection[i].IsChecked)
                        {
                            value = null;
                            break;
                        }
                    }
                }

                return value;
            }
            set
            {
                if (value == null)
                    return;
                foreach (RightDataView member in this.InternalCollection)
                    member.IsChecked = value.Value;
            }
        }

        public RightCollectionDataView(List<RightDataView> collection)
        {
            this.InternalCollection = collection;

            this.InternalCollection.ForEach(
                p => p.PropertyChanged +=
                    (sender, e) =>
                    {
                        if (e.PropertyName == "IsChecked")
                            this.OnPropertyChanged("AllMembersAreChecked");
                    });
        }
    }
}
