using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Windows.Ribbon;
using Microsoft.Practices.Composite.Presentation.Regions;
using Microsoft.Practices.Composite.Regions;

namespace ezytask.infrastructure.CustomRegionAdapters
{
    public class RibbonTabItemRegionAdapter : RegionAdapterBase<RibbonTabItem>
    {

        #region CTOR
        public RibbonTabItemRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory) { } 
        #endregion

        #region RegionAdapterBase Implementation
        protected override void Adapt(IRegion region, RibbonTabItem regionTarget)
        {
            region.ActiveViews.CollectionChanged += delegate
            {
                regionTarget.RibbonGroups.Add(region.ActiveViews.Last() as RibbonGroup);
            };

            region.Views.CollectionChanged += (sender, e) =>
            {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    region.Activate(e.NewItems[0]);
                }
            };
        }
        protected override IRegion CreateRegion()
        {
            return new Region();
        } 
        #endregion
    }
}
