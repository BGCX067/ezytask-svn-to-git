using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Windows.Ribbon;
using Microsoft.Practices.Composite.Presentation.Regions;
using Microsoft.Practices.Composite.Regions;
using System.Collections.Specialized;

namespace ezytask.infrastructure.CustomRegionAdapters
{
    public class ApplicationMenuRegionAdapter : RegionAdapterBase<ApplicationMenu>
    {
        public ApplicationMenuRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory) {}

        protected override void Adapt(IRegion region, ApplicationMenu regionTarget)
        {
            region.ActiveViews.CollectionChanged += delegate
            {
                regionTarget.Items.Insert(0, region.ActiveViews.FirstOrDefault() as ButtonTool);
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
