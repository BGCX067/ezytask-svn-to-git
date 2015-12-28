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
using Infragistics.Windows.DataPresenter;

namespace ezytask.TaskManagementModule.Views.ProjectsView
{
    /// <summary>
    /// Interaction logic for ProjectsView.xaml
    /// </summary>
    public partial class ProjectsView : UserControl, IProjectsView
    {
        private ProjectsPresenter _presenter;
        private TaskManagementModule tmm;
        private List<ProjectDataView> m_ProjectList;

        public ProjectsView(TaskManagementModule tmm)
        {
            InitializeComponent();

            this.tmm = tmm;
            _presenter = new ProjectsPresenter(this);
        }

        #region IProjectsView Members

        public string ProjectName
        {
            get { return txtName.Text.Trim(); }
            set { txtName.Text = value; }
        }

        public string Description
        {
            get { return txtDescription.Text.Trim(); }
            set { txtDescription.Text = value; }
        }

        public List<ProjectDataView> ProjectList
        {
            get { return m_ProjectList; }
            set 
            { 
                m_ProjectList = value;
                gridProjects.DataSource = m_ProjectList;

                if (m_ProjectList == null ||
                    m_ProjectList.Count == 0)
                {
                    gridProjects.Visibility = Visibility.Collapsed;
                    lblNoProjectDefined.Visibility = Visibility.Visible;
                }
                else
                {
                    gridProjects.Visibility = Visibility.Visible;
                    lblNoProjectDefined.Visibility = Visibility.Collapsed;
                }

                
            }
        }

        #endregion

        private void gridProjects_RecordActivated(object sender, Infragistics.Windows.DataPresenter.Events.RecordActivatedEventArgs e)
        {
            if (e.Record != null)
            {
                ProjectDataView pdv = (e.Record as DataRecord).DataItem as ProjectDataView;
                if (pdv == null)
                    _presenter.SetCurrentProject(null);
                else
                    _presenter.SetCurrentProject(pdv.IdProject);
            }
            else
            {
                _presenter.SetCurrentProject(null);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            _presenter.Save();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            _presenter.SetCurrentProject(null);
            gridProjects.ActiveRecord = null;
        }
    }
}
