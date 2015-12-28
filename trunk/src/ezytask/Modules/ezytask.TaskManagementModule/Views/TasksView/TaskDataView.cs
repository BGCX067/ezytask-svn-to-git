using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ezytask.infrastructure.Data;

namespace ezytask.TaskManagementModule.Views.TasksView
{
    public class TaskDataView
    {
        private Task m_Task;
        public TaskDataView(Task task)
        {
            m_Task = task;
        }

        public int IdTask
        {
            get { return m_Task.IdTask; }
        }

        public string Name
        {
            get { return m_Task.Name; }
        }

        public DateTime StartDate
        {
            get { return m_Task.StartDate; }
        }
        public DateTime EndDate
        {
            get { return m_Task.EndDate; }
        }
    }
}
