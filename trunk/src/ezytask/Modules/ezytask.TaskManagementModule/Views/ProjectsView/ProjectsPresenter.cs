using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ezytask.infrastructure.Data;
using DataStore = ezytask.infrastructure.Data.ezytaskDataStore;

namespace ezytask.TaskManagementModule.Views.ProjectsView
{
    public class ProjectsPresenter : ezytask.infrastructure.PresenterBase<IProjectsView>
    {
        private Project m_CurrentProject;
        private Project CurrentProject
        {
            set
            {
                m_CurrentProject = value;

                if (m_CurrentProject == null)
                {
                    m_View.Description = string.Empty;
                    m_View.ProjectName = string.Empty;
                }
                else
                {
                    m_View.ProjectName = m_CurrentProject.Name;
                    m_View.Description = m_CurrentProject.Description;
                }
            }
        }


        public ProjectsPresenter(IProjectsView view)
            : base(view)
        {
            LoadProjects();
        }

        public void SetCurrentProject(int? idProject)
        {
            if (idProject != null)
                CurrentProject = DataStore.DataContext.Projects.Where(p => p.IdProject == idProject).First();
            else
                CurrentProject = null;
        }

        public void Save()
        {
            if (string.IsNullOrEmpty(m_View.ProjectName))
            {
                //...todo: validation message
                return;
            }
            if (m_CurrentProject == null)
            {
                m_CurrentProject = new Project();
                m_CurrentProject.Name = m_View.ProjectName;
                m_CurrentProject.Description = m_View.Description;

                DataStore.DataContext.Projects.InsertOnSubmit(m_CurrentProject);
                DataStore.DataContext.SubmitChanges();
            }

            else
            {
                m_CurrentProject.Name = m_View.ProjectName;
                m_CurrentProject.Description = m_View.Description;
                DataStore.DataContext.SubmitChanges();
            }

            LoadProjects();
            CurrentProject = null;

        }

        private void LoadProjects()
        {
            m_View.ProjectList = (from p in DataStore.DataContext.Projects
                                  select new ProjectDataView(p)).ToList();
        }
    }
}
