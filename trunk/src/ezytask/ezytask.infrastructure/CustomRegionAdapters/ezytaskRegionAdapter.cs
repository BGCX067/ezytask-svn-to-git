using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Presentation.Regions;
using System.Windows.Controls;

namespace ezytask.infrastructure.CustomRegionAdapters
{
    public class ezytaskRegionAdapter<TRegion, TView> : RegionAdapterBase<TRegion> 
        where TRegion : ItemsControl
        where TView : class
    {

        public ezytaskRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) 
            : base(regionBehaviorFactory) { }

        /// <summary>
        /// Default implementation is for TRegion being a ItemsControl.
        /// </summary>
        /// <param name="region"></param>
        /// <param name="regionTarget"></param>
        protected override void Adapt(Microsoft.Practices.Composite.Regions.IRegion region, TRegion regionTarget)
        {
            region.ActiveViews.CollectionChanged += delegate
            {
                regionTarget.Items.Insert(0, region.ActiveViews.FirstOrDefault() as TView);
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
