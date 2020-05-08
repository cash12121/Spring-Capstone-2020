using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace WPFPresentationLayer.VolunteerPages
{
    /// <summary>
    /// Interaction logic for TaskControls.xaml
    /// </summary>
    public partial class TaskControls : Page
    {
        private IVolunteerTaskManager _volunteerTaskManager;

        public TaskControls()
        {
            InitializeComponent();
            _volunteerTaskManager = new VolunteerTaskManager();

            comboTaskType.Items.Add("TaskType1");
            comboTaskType.Items.Add("TaskType2");
            comboTaskType.Items.Add("TaskType3");
            comboTaskType.Items.Add("TaskType4");
            comboTaskType.Items.Add("TaskType5");
            comboTaskType.Items.Add("TaskType6");

            comboAssignmentGroup.Items.Add("Group1");
            comboAssignmentGroup.Items.Add("Group2");
            comboAssignmentGroup.Items.Add("Group3");
            comboAssignmentGroup.Items.Add("Group4");
            comboAssignmentGroup.Items.Add("Group5");
            comboAssignmentGroup.Items.Add("Group6");
        }

        /// <summary>
        /// NAME: Ethan Holmes
        /// DATE: 2/6/2020
        /// 
        /// This Method assigns column headers to the
        /// datagrid that displays the VolunteerTaskVM list.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATE DATE: N/A
        /// CHANGE DESCRIPTION: N/A
        /// </remarks>
        private void dgVolTaskList_ColumnHeaders(object sender, EventArgs e)
        {
            dgVolTaskList.Columns[0].Header = "Task Name";
            dgVolTaskList.Columns[1].Header = "Task Type";
            dgVolTaskList.Columns[2].Header = "Assignment Group";
            dgVolTaskList.Columns[3].Header = "Due Date";
            dgVolTaskList.Columns[4].Header = "Description";

        }

        private void DgVolTaskList_Loaded(object sender, RoutedEventArgs e)
        {
            //Not needed yet.
        }

        /// <summary>
        /// NAME: Ethan Holmes
        /// DATE: 2/6/2020
        /// 
        /// This Window loaded event will populate the data table with the 
        /// VolunteerTaskVM list that is retrieved via the GetAllVolunteerTasks() method
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATE DATE: N/A
        /// CHANGE DESCRIPTION: N/A
        /// </remarks>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();

            List<VolunteerTaskVM> volTasks = _volunteerTaskManager.GetAllVolunteerTasks();
            try
            {
                if (volTasks.Count != 0)
                {

                    foreach (VolunteerTaskVM volTask in volTasks)
                    {
                        dgVolTaskList.ItemsSource = _volunteerTaskManager.GetAllVolunteerTasks();
                    }
                }
                else
                {

                    System.Windows.MessageBox.Show("No data retrieved", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    //MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                return;
            }

        }

        /// <summary>
        /// NAME: Ethan Holmes
        /// DATE: 2/6/2020
        /// 
        /// this is the edit button which will bring up create task form 
        /// with editable properties for selected task.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditVolunteerTask_Click(object sender, RoutedEventArgs e)
        {

            VolunteerTaskVM selectedTaskVM = (VolunteerTaskVM)dgVolTaskList.SelectedItem;
            VolunteerTask selectedTask = _volunteerTaskManager.GetVolunteerTaskByName(selectedTaskVM.TaskName.ToString());
            //frmCreateVolunteerTask editTask = new frmCreateVolunteerTask();

            txtTaskName.Text = selectedTask.TaskName.ToString();
            comboAssignmentGroup.Text = selectedTask.AssignmentGroup.ToString();
            comboTaskType.Text = selectedTask.TaskType.ToString();
            txtVolunteerTaskDate.Text = selectedTask.DueDate.ToString();
            txtVolunteerTaskDescription.Text = selectedTask.TaskDescription.ToString();

            txtTaskName.IsReadOnly = true;

            canCreateTask.Visibility = Visibility.Visible;
            canViewTasks.Visibility = Visibility.Hidden;

            //editTask.Show();



            btnSave.Visibility = Visibility.Visible;
            btnCreateVolunteerTask.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// NAME: Ethan Holmes
        /// DATE: 2/6/2020
        /// 
        /// This Click event will open the form to create
        /// a new VolunteerTask() object.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATE DATE: N/A
        /// CHANGE DESCRIPTION: N/A
        /// </remarks>
        private void btnCreateVolunteerTask_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //string taskName = txtTaskName.Text.ToString();
                //string taskType = comboTaskType.Text.ToString();
                //string assignmentGroup = comboAssignmentGroup.Text.ToString();
                string taskDescription = txtVolunteerTaskDescription.Text.ToString();

                //Check if taskName is empty, if it is throw an error, otherwise assign the value.
                string taskName;
                if (txtTaskName.Text.ToString() != "")
                {
                    taskName = txtTaskName.Text.ToString();
                }
                else
                {
                    System.Windows.MessageBox.Show("TaskName must not be empty.");
                    return;
                }

                //Check if the TaskType is empty, if it is throw an error otherwise assign the value.
                string taskType;
                if (comboTaskType.Text.ToString() != "")
                {
                    taskType = comboTaskType.Text.ToString();
                }
                else
                {
                    System.Windows.MessageBox.Show("TaskType must not be empty.");
                    return;
                }

                //Check if the assignmentGroup is empty, if it is throw an error otherwise assign the value.
                string assignmentGroup;
                if (comboAssignmentGroup.Text.ToString() != "")
                {
                    assignmentGroup = comboAssignmentGroup.Text.ToString();
                }
                else
                {
                    System.Windows.MessageBox.Show("Assignment Group must not be empty.");
                    return;
                }

                //Check if the date is able to be parsed, if it fails, ask for a valid date otherwise assign the date value.
                DateTime dueDate;
                if (DateTime.TryParse(txtVolunteerTaskDate.Text.ToString(), out dueDate))
                {
                    dueDate = DateTime.Parse(txtVolunteerTaskDate.Text.ToString());
                }
                else
                {
                    System.Windows.MessageBox.Show("Please enter a valid date..");
                    return;
                }


                int create = _volunteerTaskManager.CreateVolunteerTask(taskName, taskType, assignmentGroup, taskDescription, dueDate);

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                //this.DialogResult = false;
            }
            txtTaskName.Text = "";
            txtVolunteerTaskDate.Text = "";
            txtVolunteerTaskDescription.Text = "";
            comboAssignmentGroup.Text = "";
            comboTaskType.Text = "";
            dgVolTaskList.ItemsSource = null;
            dgVolTaskList.ItemsSource = _volunteerTaskManager.GetAllVolunteerTasks();
            canCreateTask.Visibility = Visibility.Hidden;
            canViewTasks.Visibility = Visibility.Visible;

            //this.Close();
        }

        /// <summary>
        /// save button calls the update task method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string taskName = txtTaskName.Text.ToString();
            string taskType = comboTaskType.Text.ToString();
            string assignmentGroup = comboAssignmentGroup.Text.ToString();
            DateTime dueDate = DateTime.Parse(txtVolunteerTaskDate.Text.ToString());
            string taskDescription = txtVolunteerTaskDescription.Text.ToString();

            int update = _volunteerTaskManager.UpdateVolunteerTask(taskName, taskType, assignmentGroup, dueDate, taskDescription);

            //this.Close();

            canCreateTask.Visibility = Visibility.Hidden;
            dgVolTaskList.ItemsSource = null;
            dgVolTaskList.ItemsSource = _volunteerTaskManager.GetAllVolunteerTasks();
            canViewTasks.Visibility = Visibility.Visible;



        }

        private void btnDeleteVolunteerTask_Click(object sender, RoutedEventArgs e)
        {
            VolunteerTaskVM selectedTaskVM = (VolunteerTaskVM)dgVolTaskList.SelectedItem;
            VolunteerTask selectedTask = _volunteerTaskManager.GetVolunteerTaskByName(selectedTaskVM.TaskName.ToString());


            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Deleting this record is permenant, are you sure?", "WARNING", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int result = _volunteerTaskManager.DeleteVolunteerTask(selectedTask.TaskName.ToString());
                dgVolTaskList.ItemsSource = null;
                dgVolTaskList.ItemsSource = _volunteerTaskManager.GetAllVolunteerTasks();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }

            dgVolTaskList.ItemsSource = null;
            dgVolTaskList.ItemsSource = _volunteerTaskManager.GetAllVolunteerTasks();
        }

        private void BtnAddTask_Click(object sender, RoutedEventArgs e)
        {
            canViewTasks.Visibility = Visibility.Hidden;

            canCreateTask.Visibility = Visibility.Visible;
        }
    }
}

