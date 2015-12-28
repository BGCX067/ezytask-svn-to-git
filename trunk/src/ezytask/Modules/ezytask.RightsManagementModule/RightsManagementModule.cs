using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ezytask.infrastructure;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Events;
using ezytask.RightsManagementModule.Views.RMTabGroup;
using ezytask.RightsManagementModule.Views.RightsManagement;
using Infragistics.Windows.DockManager;
using System.Diagnostics;
using ezytask.infrastructure.Constants;


namespace ezytask.RightsManagementModule
{
    public class RightsManagementModule : ezytaskModule
    {
        private RMTabGroupView m_RMTabGroupView;
        private RightsManagementView m_RMView;

        public RightsManagementModule(IRegionManager regionManager, IModuleManager moduleManager, IEventAggregator eventAggregator)
            : base(regionManager, moduleManager, eventAggregator) { }

        protected override void InitializeInChildModules()
        {
            m_RMTabGroupView = new RMTabGroupView(this);
            m_RMView = new RightsManagementView();

            m_RMTabGroupView.RightsManagementRibbon.RibbonGroups.Clear();
            base.RibbonTabItemRegion.Add(m_RMTabGroupView.RightsManagementRibbonGroup);
        }

        internal void EditRoles()
        {
            object objRightsManagement = base.DocumentRegion.GetView(m_RMView.GetType().Name);

            if (objRightsManagement == null)
            {
                m_RMView.Content = null;
                base.DocumentRegion.Add(m_RMView.ContentPane, m_RMView.GetType().Name);
                m_RMView.ContentPane.Activate();
            }
            else
            {
                (objRightsManagement as ContentPane).Visibility = System.Windows.Visibility.Visible;
                (objRightsManagement as ContentPane).Activate();
            }
        }

        public override void ApplySecurity()
        {
            if (!UserInstance.CurrentUser.HasRightTo(Rights.RIGHT_MGR))
            {
                m_RMTabGroupView.RightsManagementRibbonGroup.Visibility = System.Windows.Visibility.Collapsed;
            }

            Trace.WriteLine("RightsManagementModule : ApplySecurity()...");
        }
    }
}
