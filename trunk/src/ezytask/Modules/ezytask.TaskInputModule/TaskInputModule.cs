using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ezytask.infrastructure;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Events;
using ezytask.TaskInputModule.Views.RibbonTabItem;
using System.Diagnostics;

namespace ezytask.TaskInputModule
{
    public class TaskInputModule : ezytaskModule
    {
        private RibbonTabItemView m_RibbonTabItemView;

        #region CTOR
        public TaskInputModule(IRegionManager regionManager, IModuleManager moduleManager, IEventAggregator eventAggregator)
            : base(regionManager, moduleManager, eventAggregator) { } 
        #endregion

        protected override void InitializeInChildModules()
        {
            this.m_RibbonTabItemView = new RibbonTabItemView();
            base.RibbonBarRegion.Add(m_RibbonTabItemView);
        }

        public override void ApplySecurity()
        {
            Trace.WriteLine("TaskInputModule : ApplySecurity");
        }
    }
}
