using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ezytask.infrastructure.Data;
using Infragistics.Windows.DataPresenter;

namespace ezytask.TaskManagementModule.Views.TasksView
{
    /// <summary>
    /// Interaction logic for TasksView.xaml
    /// </summary>
    public partial class TasksView : UserControl, ITasksView
    {
        TasksPresenter _presenter;
        List<Project> m_ProjectList;
        List<TaskDataView> m_TaskList;

        private TaskManagementModule tmm;

        public TasksView(TaskManagementModule tmm)
        {
            InitializeComponent();
            this.tmm = tmm;
            _presenter = new TasksPresenter(this);
        }

        private void gridTasks_RecordActivated(object sender, Infragistics.Windows.DataPresenter.Events.RecordActivatedEventArgs e)
        {
            if (e.Record == null)
                _presenter.SetCurrentTask(null);
            else
                _presenter.SetCurrentTask(
                    (((DataRecord)e.Record).DataItem as TaskDataView).IdTask
                    );
                    
        }

        private void btnNewTask_Click(object sender, RoutedEventArgs e)
        {
            _presenter.SetCurrentTask(null);
            gridTasks.ActiveRecord = null;
        }

        private void btnSaveTask_Click(object sender, RoutedEventArgs e)
        {
            _presenter.SaveTask();
            
        }

        #region ITasksView Members

        public string TaskName
        {
            get
            {
                return txtTaskName.Text.Trim();
            }
            set
            {
                txtTaskName.Text = value;
            }
        }

        public string TaskDescription
        {
            get
            {
                return txtTaskDescription.Text.Trim();
            }
            set
            {
                txtTaskDescription.Text = value;
            }
        }

        public DateTime? TaskStartDate
        {
            get
            {
                return dtpStartDate.SelectedDate;
            }
            set
            {
                dtpStartDate.SelectedDate= value;
            }
        }

        public DateTime? TaskEndDate
        {
            get
            {
                return dtpEndDate.SelectedDate;
            }
            set
            {

                dtpEndDate.SelectedDate = value;
            }
        }

        public int? IdProject
        {
            get
            {
                if (cmbProject.SelectedIndex == -1)
                    return null;
                else
                    return (int)cmbProject.SelectedValue;

            }
        }

        public List<ezytask.infrastructure.Data.Project> ProjectList
        {
            set { 
                m_ProjectList = value;
                cmbProject.ItemsSource = m_ProjectList;
            }
            get { return m_ProjectList; }
        }

        public List<TaskDataView> TaskList
        {
            set 
            { 
                m_TaskList = value;
                gridTasks.DataSource = m_TaskList;
            }
        }

        #endregion

        private void cmbProject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            m_TaskList = new List<TaskDataView>();
            if (cmbProject.SelectedValue != null)
                TaskList = _presenter.GetTasksForProject((int)cmbProject.SelectedValue);
        }

        private void gridAssignments_RecordActivated(object sender, Infragistics.Windows.DataPresenter.Events.RecordActivatedEventArgs e)
        {
            
        }


        #region ICanDisplaySavePopup Members

        public Panel PopupHolder
        {
            get
            {
                return mainStack;
            }
        }

        #endregion
    }
}
