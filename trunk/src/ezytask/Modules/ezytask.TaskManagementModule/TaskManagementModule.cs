using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ezytask.infrastructure;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Events;
using ezytask.TaskManagementModule.Views.RibbonTabItem;
using ezytask.infrastructure.Constants;
using ezytask.TaskManagementModule.Views.ProjectsView;
using Infragistics.Windows.DockManager;
using ezytask.TaskManagementModule.Views.TasksView;

namespace ezytask.TaskManagementModule
{
    public class TaskManagementModule : ezytaskModule
    {
        private RibbonTabItemView m_TabItemView;
        private ProjectsView m_ProjectsView;
        private TasksView m_TasksView;

        public TaskManagementModule(IRegionManager regionManager, IModuleManager moduleManager, IEventAggregator eventAggregator)
            : base(regionManager, moduleManager, eventAggregator) 
        {
            m_TabItemView = new RibbonTabItemView(this);
            m_ProjectsView = new ProjectsView(this);
            m_TasksView = new TasksView(this);
        }

        protected override void InitializeInChildModules()
        {
            m_TabItemView.ContainerRibbon.Tabs.Clear();
            m_RegionManager.Regions[RegionNames.RibbonBarRegion].Add(m_TabItemView.TaskManagementRibbon);

            
        }

        public override void ApplySecurity()
        {
            
        }

        public void ManageProjects()
        {
            object objProjectsView = m_RegionManager.Regions[RegionNames.DocumentRegion].GetView(m_ProjectsView.GetType().Name);

            if (objProjectsView == null)
            {
                m_ProjectsView.Content = null;
                m_RegionManager.Regions[RegionNames.DocumentRegion].Add(m_ProjectsView.ContentPane, m_ProjectsView.GetType().Name);
                m_ProjectsView.ContentPane.Activate();
            }
            else
            {
                (objProjectsView as ContentPane).Visibility = System.Windows.Visibility.Visible;
                (objProjectsView as ContentPane).Activate();
            }
        }

        public void ManageTasks()
        {
            object objTasksView = m_RegionManager.Regions[RegionNames.DocumentRegion].GetView(m_TasksView.GetType().Name);

            if (objTasksView == null)
            {
                m_TasksView.Content = null;
                m_RegionManager.Regions[RegionNames.DocumentRegion].Add(m_TasksView.ContentPane, m_TasksView.GetType().Name);
                m_TasksView.ContentPane.Activate();
            }
            else
            {
                (objTasksView as ContentPane).Visibility = System.Windows.Visibility.Visible;
                (objTasksView as ContentPane).Activate();
            }
        }
    }
}
