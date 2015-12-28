using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ezytask.infrastructure.Data;
using ezytask.infrastructure;

namespace ezytask.TaskManagementModule.Views.TasksView
{
    public interface ITasksView : ICanDisplaySavePopup
    {
        List<Project> ProjectList
        {
            set;
        }
        List<TaskDataView> TaskList
        {
            set;
        }

        int? IdProject
        {
            get;
        }

        string TaskName
        {
            get;
            set;
        }
        string TaskDescription
        {
            get;
            set;
        }
        DateTime? TaskStartDate
        {
            get;
            set;
        }
        DateTime? TaskEndDate
        {
            get;
            set;
        }


    }
}
