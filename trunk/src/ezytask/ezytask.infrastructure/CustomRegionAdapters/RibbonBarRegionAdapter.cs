using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Windows.Ribbon;
using Microsoft.Practices.Composite.Presentation.Regions;
using Microsoft.Practices.Composite.Regions;

namespace ezytask.infrastructure.CustomRegionAdapters
{
    public class RibbonBarRegionAdapter : RegionAdapterBase<XamRibbon>
    {
        #region CTOR
        public RibbonBarRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory) { } 
        #endregion

        #region RegionAdapterBase Implementation
        protected override void Adapt(IRegion region, XamRibbon regionTarget)
        {
            region.ActiveViews.CollectionChanged += delegate
            {
                regionTarget.Tabs.Add(region.ActiveViews.Last() as RibbonTabItem);
            };

            region.Views.CollectionChanged += (sender, e) =>
                {
                    if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                    {
                        region.Activate(e.NewItems[0]);
                    }
                };
        }
        protected override Microsoft.Practices.Composite.Regions.IRegion CreateRegion()
        {
            return new Region();
        } 
        #endregion
    }
}
