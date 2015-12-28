using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ezytask.infrastructure;
using ezytask.infrastructure.Data;
using DataStore = ezytask.infrastructure.Data.ezytaskDataStore;

namespace ezytask.TaskManagementModule.Views.TasksView
{
    public class TasksPresenter : PresenterBase<ITasksView>
    {
        private Task m_CurrentTask;

        public void SetCurrentTask(int? idTask)
        {
            if (idTask == null)
                CurrentTask = null;
            else
                CurrentTask = DataStore.DataContext.Tasks.Where(t => t.IdTask == (int)idTask).First();
        }

        private Task CurrentTask
        {
            get { return m_CurrentTask; }
            set 
            { 
                m_CurrentTask = value;
                if (m_CurrentTask == null)
                {
                    m_View.TaskName = String.Empty;
                    m_View.TaskDescription = String.Empty;
                    m_View.TaskStartDate = null;
                    m_View.TaskEndDate = null;
                }
                else
                {
                    m_View.TaskName = m_CurrentTask.Name;
                    m_View.TaskDescription = m_CurrentTask.Description;
                    m_View.TaskStartDate = m_CurrentTask.StartDate;
                    m_View.TaskEndDate = m_CurrentTask.EndDate;
                }
            }
        }
        private Assignment m_CurrentAssignment;

        public TasksPresenter(ITasksView view)
            : base(view)
        {
            List<Project> projList = DataStore.DataContext.Projects.ToList();
            m_View.ProjectList = projList;
        }

        public List<TaskDataView> GetTasksForProject(int idProject)
        {
            //load the tasks for the current project
            List<TaskDataView> taskList = (from t in DataStore.DataContext.Tasks
                                           where t.IdProject == idProject
                                           select new TaskDataView(t)).ToList();
            return taskList;
        }

        public Task SaveTask()
        {
            if (m_CurrentTask == null)
            {
                m_CurrentTask = new Task();

                m_CurrentTask.IdProject = (int)m_View.IdProject;
                m_CurrentTask.Name = m_View.TaskName;
                m_CurrentTask.Description = m_View.TaskDescription;
                m_CurrentTask.StartDate = (DateTime)m_View.TaskStartDate;
                m_CurrentTask.EndDate = (DateTime)m_View.TaskEndDate;

                DataStore.DataContext.Tasks.InsertOnSubmit(m_CurrentTask);
                DataStore.DataContext.SubmitChanges();


            }
            else
            {
                m_CurrentTask.Name = m_View.TaskName;
                m_CurrentTask.Description = m_View.TaskDescription;
                m_CurrentTask.StartDate = (DateTime)m_View.TaskStartDate;
                m_CurrentTask.EndDate = (DateTime)m_View.TaskEndDate;

                DataStore.DataContext.SubmitChanges();
            }

                m_View.TaskList = GetTasksForProject((int)m_View.IdProject);
                base.DisplaySavePopup();
                return m_CurrentTask;
        }

    }
}
