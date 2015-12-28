using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Windows.DockManager;
using Microsoft.Practices.Composite.Presentation.Regions;

namespace ezytask.infrastructure.CustomRegionAdapters
{
    public class TabGroupPaneRegionAdapter : RegionAdapterBase<TabGroupPane>
    {
        public TabGroupPaneRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) 
            : base(regionBehaviorFactory) { }

        protected override void Adapt(Microsoft.Practices.Composite.Regions.IRegion region, TabGroupPane regionTarget)
        {
            region.ActiveViews.CollectionChanged += delegate
            {
                regionTarget.Items.Insert(0, region.ActiveViews.FirstOrDefault() as ContentPane);
            };

            region.Views.CollectionChanged += (sender, e) =>
            {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add &&
                    region.ActiveViews.Count() == 0)
                {
                    region.Activate(e.NewItems[0]);
                }
            };
        }

        protected override Microsoft.Practices.Composite.Regions.IRegion CreateRegion()
        {
            return new Region();
        }
    }
}
