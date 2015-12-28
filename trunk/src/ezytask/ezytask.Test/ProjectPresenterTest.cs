using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ezytask.TaskManagementModule.Views.ProjectsView;

namespace ezytask.Test
{
    /// <summary>
    /// Summary description for ProjectPresenterTest
    /// </summary>
    [TestClass]
    public class ProjectPresenterTest
    {
        public ProjectPresenterTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Can_create_a_project()
        {
            MockIProjectView mockView = new MockIProjectView();
            ProjectsPresenter presenter = new ProjectsPresenter(mockView);

            mockView.ProjectName = "Test project name";
            mockView.Description = "Project description";

            //save a new project
            presenter.Save();
        }

        public class MockIProjectView : IProjectsView
        {
            #region IProjectsView Members

            public string ProjectName
            {
                get;
                set;
            }

            public string Description
            {
                get;
                set;
            }

            public List<ProjectDataView> ProjectList
            {
                get;
                set;
            }

            #endregion

        }
    }
}
