using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.UnityExtensions;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Presentation.Regions;
using Infragistics.Windows.Ribbon;
using ezytask.infrastructure.CustomRegionAdapters;
using ezytask.infrastructure;
using ezytask.shell.NoUserForm;
using ezytask.shell.Login;
using System.Windows;

namespace ezytask.shell
{
    class Bootstrapper : UnityBootstrapper
    {
        Shell m_Shell;

        public Shell Shell
        {
            get { return m_Shell; }
        }

        protected override System.Windows.DependencyObject CreateShell()
        {
            m_Shell = new Shell();
            return m_Shell;
        }

        protected override IModuleCatalog GetModuleCatalog()
        {
            ModuleCatalog moduleCatalog = new ModuleCatalog();
            moduleCatalog.AddModule(typeof(ezytask.UsersManagementModule.UsersManagementModule));
            moduleCatalog.AddModule(typeof(ezytask.TaskInputModule.TaskInputModule));
            moduleCatalog.AddModule(typeof(ezytask.RightsManagementModule.RightsManagementModule));
            moduleCatalog.AddModule(typeof(ezytask.TaskManagementModule.TaskManagementModule));
            ///todo: add modules.

            return moduleCatalog;
        }

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            RegionAdapterMappings mappings = base.ConfigureRegionAdapterMappings();
            
            mappings.RegisterMapping(typeof(ApplicationMenu), 
                new ApplicationMenuRegionAdapter(
                    this.Container.Resolve<IRegionBehaviorFactory>()
                    ) 
                );

            mappings.RegisterMapping(typeof(XamRibbon),
                new RibbonBarRegionAdapter(
                    this.Container.Resolve<IRegionBehaviorFactory>()
                    )
                );

            mappings.RegisterMapping(typeof(RibbonTabItem),
                new RibbonTabItemRegionAdapter(
                    this.Container.Resolve<IRegionBehaviorFactory>()
                    )
                );

            mappings.RegisterMapping(typeof(TabGroupPaneRegionAdapter),
                new TabGroupPaneRegionAdapter(
                    this.Container.Resolve<IRegionBehaviorFactory>()
                    )
                );

            return mappings;
        }

        internal void ApplySecurity()
        {
            ezytaskModule.LoadedModules.ForEach(p => p.ApplySecurity());

        }
    }
}
