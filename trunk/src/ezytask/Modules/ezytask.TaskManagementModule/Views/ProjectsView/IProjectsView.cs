using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ezytask.infrastructure.Data;

namespace ezytask.TaskManagementModule.Views.ProjectsView
{
    public interface IProjectsView
    {
        string ProjectName { get; set; }
        string Description { get; set; }
        List<ProjectDataView> ProjectList {set;}
    }
}
