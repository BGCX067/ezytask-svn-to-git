using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ezytask.infrastructure.Data;

namespace ezytask.TaskManagementModule.Views.ProjectsView
{
    public class ProjectDataView
    {
        private Project m_Project;

        public ProjectDataView(Project project)
        {
            m_Project = project;
        }

        public int IdProject
        {
            get { return m_Project.IdProject; }
        }

        public string Name
        {
            get { return m_Project.Name; }
        }

        //first 10 characters of the description
        public string Description
        {
            get
            {
                if (String.IsNullOrEmpty(m_Project.Description))
                {
                    return string.Empty;
                }
                else
                {
                    if (m_Project.Description.Trim().Length > 10)
                    {
                        return m_Project.Description.Trim().Substring(0, 10) + "...";
                    }
                    else
                        return m_Project.Description;
                }
            }
        }
    }
}
