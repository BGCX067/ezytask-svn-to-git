using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Composite.Events;
using ezytask.infrastructure.Constants;
using System.Diagnostics;

namespace ezytask.infrastructure
{
    public abstract class ezytaskModule : IModule
    {
        #region REGIONS
        private IRegion m_ApplicationMenuRegion;
        protected IRegion ApplicationMenuRegion
        {
            get { return m_ApplicationMenuRegion; }
        }

        private IRegion m_RibbonBarRegion;
        protected IRegion RibbonBarRegion
        {
            get { return m_RibbonBarRegion; }
        }

        private IRegion m_RibbonTabItemRegion;
        protected IRegion RibbonTabItemRegion
        {
            get { return m_RibbonTabItemRegion; }
        }

        private IRegion m_DocumentRegion;
        protected IRegion DocumentRegion
        {
            get { return m_DocumentRegion; }
        }

        #endregion


        protected IRegionManager m_RegionManager;
        protected IModuleManager m_ModuleManager;
        protected IEventAggregator m_EventAggregator;

        public ezytaskModule(IRegionManager regionManager, IModuleManager moduleManager, IEventAggregator eventAggregator)
        {
            Trace.WriteLine(String.Format(".ctor of module {0}", this.GetType().Name));

            m_RegionManager = regionManager;
            m_ModuleManager = moduleManager;
            m_EventAggregator = eventAggregator;

            m_ApplicationMenuRegion = regionManager.Regions[RegionNames.ApplicationMenuRegion];
            m_RibbonBarRegion = regionManager.Regions[RegionNames.RibbonBarRegion];
            m_RibbonTabItemRegion = regionManager.Regions[RegionNames.RibbonTabItemRegion];
            m_DocumentRegion = regionManager.Regions[RegionNames.DocumentRegion];
        }

        #region IModule Members

        public virtual void Initialize()
        {
            Trace.WriteLine(String.Format("Initializing module {0}", this.GetType().Name));

            InitializeInChildModules();

            m_LoadedModules.Add(this);
        }

        #endregion

        protected abstract void InitializeInChildModules();

        public abstract void ApplySecurity();

        private static List<ezytaskModule> m_LoadedModules;
        public static List<ezytaskModule> LoadedModules
        {
            get { return m_LoadedModules; }
        }

        static ezytaskModule()
        {
            m_LoadedModules = new List<ezytaskModule>();
        }
    }
}
