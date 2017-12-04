using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Reporting;

namespace WindowsFormsApplication1.View
{
    internal class programMainForm : Form
    {
        //object declaration
        private readonly Button addButton;

        private readonly PictureBox addDateTimeAlert;

        //Add Task Menu Items
        private readonly HomeScreenMenuPanel addMenu;

        private readonly PictureBox addTaskDescriptionAlert;
        private readonly RichTextBox addTaskDescriptionTextbox;
        private readonly Label addTaskDueDate;
        private readonly DateTimePicker addTaskDueDateTime;
        private readonly PictureBox addTaskNameAlert;
        private readonly RichTextBox addTaskNameTextbox;
        private readonly Label addTaskPriority;
        private readonly CheckBox addTaskPriority1;
        private readonly CheckBox addTaskPriority2;
        private readonly CheckBox addTaskPriority3;
        private readonly CheckBox addTaskPriority4;
        private readonly CheckBox addTaskPriority5;
        private readonly PictureBox addTaskPriorityAlert;
        private readonly Label addTaskTaskDescription;
        private readonly Label addTaskTaskName;
        private readonly Label addTaskTitle;
        private readonly Label addTaskType;
        private readonly ComboBox addTaskTypeDropDown;
        private readonly Form alertConfirmation;
        private readonly Label AtAGlance;
        private readonly Button completedTasksReportButton;

        private readonly string ConnectionString =
            "Data Source=localhost; " +
            "Initial Catalog=TaskAssistant; " +
            "user id=test; " +
            "password=test; " +
            "connection timeout=30";

        private readonly Panel controlBar;
        private readonly Form dateTimealertConfirmation;
        private readonly Button exit;
        private readonly Label firstHalfTitleLabel;
        private readonly Button fullReportButton;
        private readonly Panel menuBar;
        private readonly Button minimize;
        private readonly Button removeButton;

        //Remove Task Menu Items
        private readonly HomeScreenMenuPanel removeMenu;

        private readonly Button removeDeleteButton;
        private readonly Button removeSearchButton;
        private readonly Label removeTaskChooseTaskLabel;
        private readonly DateTimePicker removeTaskEndDateTime;
        private readonly Label removeTaskEndDateTimeLabel;
        private readonly Label removeTaskName;
        private readonly ComboBox removeTaskNameDropDown;
        private readonly RichTextBox removeTaskNameTextbox;
        private readonly DateTimePicker removeTaskStartDateTime;
        private readonly Label removeTaskStartDateTimeLabel;
        private readonly Label removeTaskTitle;
        private readonly Button reportsButton;

        //Reports Menu Items
        private readonly HomeScreenMenuPanel reportsMenu;

        private readonly Label reportsTitle;
        private readonly Button searchButton;
        private readonly ComboBox reportSelector;
        private readonly TextBox reportsTextbox;

        //Search Task Menu Items
        private readonly HomeScreenMenuPanel searchMenu;

        private readonly Label searchTaskChooseTaskLabel;
        private readonly menuLabel searchTaskDescription;
        private readonly RichTextBox searchTaskDescriptionBox;
        private readonly DateTimePicker searchTaskEndDateTime;
        private readonly menuLabel searchTaskEndDateTimeLabel;
        private readonly ComboBox searchTaskNameDropdown;
        private readonly Button searchTaskSearchButton;
        private readonly DateTimePicker searchTaskStartDateTime;
        private readonly menuLabel searchTaskStartDateTimeLabel;
        private readonly menuLabel searchTasksTitle;
        private readonly Label secondHalfTitleLabel;
        private readonly Button settingsButton;

        //Settings Menu Items
        private readonly HomeScreenMenuPanel settingsMenu;

        private readonly Label settingsTitle;
        private readonly Panel titleBar;
        private tasksDueProgressBar FrontPageTasksDueIn3DaysProgressBar;
        private tasksDueProgressBar FrontPageTasksDueIn7DaysProgressBar;
        private tasksDueProgressBar FrontPageOverdueTasksProgressBar;
        private Form FullReport;
        private Form CompletedTasksReport;
        private Form TasksDueIn3DaysReport;

        private bool menuShow;
        private int prioritySelection;

        private SqlConnection taskDatabaseConnection;


        internal programMainForm(string formName) // accept name as a parameter
        {
            AllowDrop = true;
            BackColor = Color.FromArgb(195, 200, 205);
            ControlBox = false;
            Name = formName;
            Size = new Size(1030, 560);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            //add MouseDown event this.MouseDown += new MouseEventHandler(this.Form1_MouseDown_1);
            ResumeLayout(false);

            titleBar = new titleBarPanel("homeScreenTitleBar", Size.Width, Size.Height / 13);

            menuBar = new verticalPanel("menuBar", titleBar.Location.X, titleBar.Location.Y + titleBar.Size.Height,
                Size.Width / 4, Size.Height - titleBar.Size.Height);

            addButton = new homeScreenMenuButton("addButton", new Point(0, 2), menuBar.Size.Width,
                menuBar.Size.Height / 5 - 2, "Add Tasks", "add");
            removeButton = new homeScreenMenuButton("removeButton", new Point(0, 2), addButton.Size.Width,
                addButton.Size.Height, "Remove Tasks", "remove");
            searchButton = new homeScreenMenuButton("searchButton", new Point(0, 2), addButton.Size.Width,
                addButton.Size.Height, "Search Tasks", "search");
            reportsButton = new homeScreenMenuButton("reportsButton", new Point(0, 2), addButton.Size.Width,
                addButton.Size.Height, "Reports", "reports");
            settingsButton = new homeScreenMenuButton("settingsButton", new Point(0, 2), addButton.Size.Width,
                addButton.Size.Height, "Settings", "settings");

            //menuBar = new verticalPanel("menuBar", titleBar.Location.X, (titleBar.Location.Y + titleBar.Size.Height), addButton.Size.Width, (settingsButton.Location.Y + settingsButton.Size.Height));
            firstHalfTitleLabel = new titleLabelFirstHalf("titleLabelFirstHalf", "Task", titleBar.Size.Width / 25,
                titleBar.Size.Height / 6);
            secondHalfTitleLabel = new titleLabelSecondHalf("titleLabelSecondHalf", "Assistant",
                firstHalfTitleLabel.Location.X + 39, firstHalfTitleLabel.Location.Y + 1);


            controlBar = new controlBarPanel("homeScreenControlBar", titleBar.Size.Width, 30);
            exit = new ControlBarButton("exit", controlBar.Size.Width - 20, 0, "X", ContentAlignment.BottomCenter);
            minimize = new ControlBarButton("minimize", exit.Location.X - exit.Size.Width - 2, 0, "_");

            createHomePageProgressBars();
            FrontPageTasksDueIn3DaysProgressBar.Click += TasksDueIn3DaysButton_Click;

            AtAGlance = new menuLabel("AtAGlanceLabel", "At A Glance", Size.Width / 14 * 8, Size.Height / 8);
            AtAGlance.ForeColor = SystemColors.ControlDarkDark;

            addMenu = new HomeScreenMenuPanel(addButton.Location.X + addButton.Size.Width, titleBar.Size.Height,
                Size.Width - addButton.Size.Width, menuBar.Size.Height);

            addTaskTitle = new menuLabel("addTaskTitle", "Add Task", 270, 18);
            addTaskTaskName = new menuLabel("addTaskTaskName", "Name", 40, 74);
            addTaskTaskDescription = new menuLabel("addTaskTaskDescription", "Description", addTaskTaskName.Location.X,
                addTaskTaskName.Location.Y + 80);
            addTaskDueDate = new menuLabel("addTaskDueDate", "Due Date/Time", addTaskTaskName.Location.X,
                addTaskTaskDescription.Location.Y + 80);
            addTaskType = new menuLabel("addTaskType", "Type", addTaskTaskName.Location.X,
                addTaskDueDate.Location.Y + 80);
            addTaskPriority = new menuLabel("addTaskPriority", "Priority", addTaskTaskName.Location.X,
                addTaskType.Location.Y + 80);

            addTaskNameTextbox = new informationTextbox("addTaskNameTextbox", 200, 71);
            addTaskDescriptionTextbox = new informationTextbox("addTaskDescriptionTextbox",
                addTaskNameTextbox.Location.X, addTaskNameTextbox.Location.Y + 80);
            addTaskDueDateTime = new menuDateTimePicker("addTaskDueDateTime", addTaskNameTextbox.Location.X,
                addTaskDescriptionTextbox.Location.Y + 80);
            addTaskTypeDropDown = new informationDropdown("addTaskTypeTextbox", addTaskNameTextbox.Location.X,
                addTaskDueDateTime.Location.Y + 80);
            addTaskPriority1 = new informationCheckbox("addTaskPriority1", "1", addTaskNameTextbox.Location.X,
                addTaskTypeDropDown.Location.Y + 80);
            addTaskPriority2 = new informationCheckbox("addTaskPriority2", "2", addTaskPriority1.Location.X + 66,
                addTaskPriority1.Location.Y);
            addTaskPriority3 = new informationCheckbox("addTaskPriority3", "3", addTaskPriority2.Location.X + 66,
                addTaskPriority1.Location.Y);
            addTaskPriority4 = new informationCheckbox("addTaskPriority4", "4", addTaskPriority3.Location.X + 66,
                addTaskPriority1.Location.Y);
            addTaskPriority5 = new informationCheckbox("addTaskPriority5", "5", addTaskPriority4.Location.X + 66,
                addTaskPriority1.Location.Y);
            addTaskDescriptionAlert = new AlertExclamationImage(
                addTaskDescriptionTextbox.Location.X + addTaskDescriptionTextbox.Size.Width + 8,
                addTaskDescriptionTextbox.Location.Y);
            addTaskNameAlert =
                new AlertExclamationImage(addTaskDescriptionAlert.Location.X, addTaskNameTextbox.Location.Y);
            addTaskPriorityAlert =
                new AlertExclamationImage(addTaskDescriptionAlert.Location.X, addTaskPriority1.Location.Y);
            addDateTimeAlert =
                new AlertExclamationImage(addTaskDescriptionAlert.Location.X, addTaskDueDateTime.Location.Y);
            alertConfirmation = new ConfirmationForm("addMenuAlertConfirmation");
            dateTimealertConfirmation = new ConfirmationForm("dateTimeConfirmation");

            removeMenu = new HomeScreenMenuPanel(addButton.Location.X + addButton.Size.Width, titleBar.Size.Height,
                titleBar.Size.Width - addButton.Size.Width, menuBar.Size.Height);

            removeTaskTitle = new menuLabel("removeTaskTitle", "Remove Task", 270, 18);
            removeTaskName = new menuLabel("removeTaskName", "Name", 40, 74);
            removeTaskStartDateTimeLabel = new menuLabel("removeStartDateTimeLabel", "Search Start",
                removeTaskName.Location.X,
                removeTaskName.Location.Y + 80);
            removeTaskEndDateTimeLabel = new menuLabel("removeEndDateTimeLabel", "Search End",
                removeTaskStartDateTimeLabel.Location.X,
                removeTaskStartDateTimeLabel.Location.Y + 80);
            removeTaskChooseTaskLabel = new menuLabel("removeChooseTaskLabel", "Choose Task",
                removeTaskEndDateTimeLabel.Location.X,
                removeTaskEndDateTimeLabel.Location.Y + 80);

            removeTaskNameTextbox = new informationTextbox("removeTaskNameTextbox", 200, 71);
            removeTaskStartDateTime = new menuDateTimePicker("removeTaskStartDateTime",
                removeTaskNameTextbox.Location.X,
                removeTaskNameTextbox.Location.Y + 80);
            removeTaskEndDateTime = new menuDateTimePicker("removeaskEndDateTime", removeTaskStartDateTime.Location.X,
                removeTaskStartDateTime.Location.Y + 80);
            removeTaskNameDropDown = new generalBlankDropdown("removeTaskDropdown", removeTaskEndDateTime.Location.X,
                removeTaskEndDateTime.Location.Y + 80);
            removeDeleteButton = new ConfirmationButton("menuForm", "Complete",
                removeTaskNameDropDown.Location.X,
                removeTaskNameDropDown.Location.Y + 60);
            removeSearchButton = new ConfirmationButton("menuForm", "Search",
                removeDeleteButton.Location.X + 210 ,
                removeDeleteButton.Location.Y);

            searchMenu = new HomeScreenMenuPanel(addButton.Location.X + addButton.Size.Width, titleBar.Size.Height,
                titleBar.Size.Width - addButton.Size.Width, menuBar.Size.Height);

            searchTasksTitle = new menuLabel("searchTaskTitle", "Search Task", 270, 18);
            searchTaskStartDateTimeLabel = new menuLabel("searchTaskStartDateTime", "Search Start", 40, 74);
            searchTaskEndDateTimeLabel = new menuLabel("searchTaskEndDateTime", "Search End",
                searchTaskStartDateTimeLabel.Location.X, searchTaskStartDateTimeLabel.Location.Y + 80);
            searchTaskChooseTaskLabel = new menuLabel("searchChooseTaskLabel", "Choose Task",
                searchTaskEndDateTimeLabel.Location.X,
                searchTaskEndDateTimeLabel.Location.Y + 80);
            searchTaskDescription = new menuLabel("searchTaskDescription", "Description",
                searchTaskChooseTaskLabel.Location.X, searchTaskChooseTaskLabel.Location.Y + 80);
            searchTaskStartDateTime = new menuDateTimePicker("searchTasksStartDateTime", 200, 71);
            searchTaskEndDateTime = new menuDateTimePicker("searchTasksEndDateTime", searchTaskStartDateTime.Location.X,
                searchTaskStartDateTime.Location.Y + 80);
            searchTaskNameDropdown = new generalBlankDropdown("searchTaskDropdown", searchTaskEndDateTime.Location.X,
                searchTaskEndDateTime.Location.Y + 80);
            searchTaskDescriptionBox = new informationTextbox("searchTaskDescriptionTextbox",
                searchTaskNameDropdown.Location.X, searchTaskNameDropdown.Location.Y + 80,
                searchTaskNameDropdown.Size.Width, searchTaskNameDropdown.Size.Height * 4);
            searchTaskSearchButton = new ConfirmationButton("menuForm", "Search",
                searchTaskDescriptionBox.Location.X + searchTaskDescriptionBox.Width / 3,
                searchTaskDescriptionBox.Location.Y + searchTaskNameDropdown.Size.Height * 2 + 60);

            reportsMenu = new HomeScreenMenuPanel(addButton.Location.X + addButton.Size.Width, titleBar.Size.Height,
                titleBar.Size.Width - addButton.Size.Width, menuBar.Size.Height);


            reportsTitle = new menuLabel("reportsTitle", "Reports", 290, 18);
            reportsTextbox = new InstructionalTextbox("reportsTextbox", 100, 71);
            reportsTextbox.Text =
                "Please choose a report from the dropdown menu.\r\n\r\nThe available reports are: full tasks report which gives information on all tasks, tasks due within 3 days,"
                 + " tasks due within 7 days, overdue tasks, or completed tasks. All reports can be saved or printed.";

            reportSelector = new generalBlankDropdown("reportSelector", 200, Size.Height / 11 * 5);
            reportSelector.Items.AddRange(new object[]
                {
                "Full Tasks Report",
                "Tasks Due In 3 Days",
                "Tasks Due In 7 Days",
                "Completed Tasks Report",
                "Overdue Tasks Report"
                });
            reportSelector.SelectedItem = reportSelector.Items[0];

            completedTasksReportButton = new ConfirmationButton("menuForm", "Run Report",
                Size.Width / 5 * 2, reportSelector.Location.Y + 80);

            completedTasksReportButton.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);

            settingsMenu = new HomeScreenMenuPanel(addButton.Location.X + addButton.Size.Width, titleBar.Size.Height,
                titleBar.Size.Width - addButton.Size.Width, menuBar.Size.Height);

            settingsTitle = new menuLabel("settingsTitle", "Settings", 270, 18);


            //create home screen objects
            addButton.MouseHover += HomeMenuButton_Hover;
            removeButton.MouseHover += HomeMenuButton_Hover;
            searchButton.MouseHover += HomeMenuButton_Hover;
            reportsButton.MouseHover += HomeMenuButton_Hover;
            settingsButton.MouseHover += HomeMenuButton_Hover;

            addMenu.menuCancelButton.Click += menuCancelButton_Click;
            removeMenu.menuCancelButton.Click += menuCancelButton_Click;
            searchMenu.menuCancelButton.Click += menuCancelButton_Click;
            reportsMenu.menuCancelButton.Click += menuCancelButton_Click;
            settingsMenu.menuCancelButton.Click += menuCancelButton_Click;

            addMenu.menuSubmitButton.Click += AddMenuSubmitButton_Click;
            reportsMenu.menuSubmitButton.Click += ReportMenuSubmitButton_Click;
            removeMenu.menuSubmitButton.Click += MenuSubmitButton_Click;

            completedTasksReportButton.Click += CompletedTasksReportButton_Click;

            addTaskPriority1.CheckedChanged += AddTaskPriority_CheckedChanged;
            addTaskPriority2.CheckedChanged += AddTaskPriority_CheckedChanged;
            addTaskPriority3.CheckedChanged += AddTaskPriority_CheckedChanged;
            addTaskPriority4.CheckedChanged += AddTaskPriority_CheckedChanged;
            addTaskPriority5.CheckedChanged += AddTaskPriority_CheckedChanged;

            removeSearchButton.Click += RemoveSearchButton_Click;
            removeDeleteButton.Click += RemoveDeleteButton_Click;
            searchTaskSearchButton.Click += SearchTaskSearchButton_Click;
            searchTaskNameDropdown.SelectedIndexChanged += SearchTaskNameDropdown_SelectedIndexChanged;

            exit.Click += Exit_Click;
            minimize.Click += Minimize_Click;

            controlBar.Controls.Add(exit);
            controlBar.Controls.Add(minimize);
            controlBar.MouseDown += Move_MouseDown;

            titleBar.Controls.Add(firstHalfTitleLabel);
            titleBar.Controls.Add(secondHalfTitleLabel);
            titleBar.Controls.Add(controlBar);

            menuBar.Controls.Add(addButton);
            menuBar.Controls.Add(removeButton);
            menuBar.Controls.Add(searchButton);
            menuBar.Controls.Add(reportsButton);
            menuBar.Controls.Add(settingsButton);


            addMenu.Controls.Add(addTaskTitle);
            addMenu.Controls.Add(addTaskTaskName);
            addMenu.Controls.Add(addTaskTaskDescription);
            addMenu.Controls.Add(addTaskDueDate);
            addMenu.Controls.Add(addTaskType);
            addMenu.Controls.Add(addTaskPriority);
            addMenu.Controls.Add(addTaskNameTextbox);
            addMenu.Controls.Add(addTaskDescriptionTextbox);
            addMenu.Controls.Add(addTaskDueDateTime);
            addMenu.Controls.Add(addTaskTypeDropDown);
            addMenu.Controls.Add(addTaskPriority1);
            addMenu.Controls.Add(addTaskPriority2);
            addMenu.Controls.Add(addTaskPriority3);
            addMenu.Controls.Add(addTaskPriority4);
            addMenu.Controls.Add(addTaskPriority5);
            addMenu.Controls.Add(addTaskDescriptionAlert);
            addMenu.Controls.Add(addTaskNameAlert);
            addMenu.Controls.Add(addTaskPriorityAlert);
            addMenu.Controls.Add(addDateTimeAlert);

            addMenu.Hide();

            removeMenu.Controls.Add(removeTaskTitle);
            removeMenu.Controls.Add(removeTaskName);
            removeMenu.Controls.Add(removeTaskStartDateTimeLabel);
            removeMenu.Controls.Add(removeTaskEndDateTimeLabel);
            removeMenu.Controls.Add(removeTaskNameTextbox);
            removeMenu.Controls.Add(removeTaskStartDateTime);
            removeMenu.Controls.Add(removeTaskEndDateTime);
            removeMenu.Controls.Add(removeDeleteButton);
            removeMenu.Controls.Add(removeSearchButton);
            removeMenu.Controls.Add(removeTaskNameDropDown);
            removeMenu.Controls.Add(removeTaskChooseTaskLabel);
            removeMenu.Hide();

            searchMenu.Controls.Add(searchTasksTitle);
            searchMenu.Controls.Add(searchTaskStartDateTimeLabel);
            searchMenu.Controls.Add(searchTaskEndDateTimeLabel);
            searchMenu.Controls.Add(searchTaskStartDateTime);
            searchMenu.Controls.Add(searchTaskEndDateTime);
            searchMenu.Controls.Add(searchTaskDescriptionBox);
            searchMenu.Controls.Add(searchTaskNameDropdown);
            searchMenu.Controls.Add(searchTaskSearchButton);
            searchMenu.Controls.Add(searchTaskChooseTaskLabel);
            searchMenu.Controls.Add(searchTaskDescription);
            searchMenu.Hide();

            reportsMenu.Controls.Add(reportsTitle);
            reportsMenu.Controls.Add(reportSelector);
            reportsMenu.Controls.Add(completedTasksReportButton);
            reportsMenu.Controls.Add(reportsTextbox);
            reportsMenu.Hide();

            settingsMenu.Controls.Add(settingsTitle);
            settingsMenu.Hide();

            //create home screen for application
            Name = formName;
            //this.Size = new Size(titleBar.Size.Width, titleBar.Size.Height + menuBar.Size.Height);

            Controls.Add(menuBar);
            Controls.Add(titleBar);
            Controls.Add(addMenu);
            Controls.Add(removeMenu);
            Controls.Add(searchMenu);
            Controls.Add(reportsMenu);
            Controls.Add(settingsMenu);
            Controls.Add(AtAGlance);
            Controls.Add(FrontPageTasksDueIn3DaysProgressBar);
            Controls.Add(FrontPageTasksDueIn7DaysProgressBar);
            Controls.Add(FrontPageOverdueTasksProgressBar);
        }

        private void RemoveDeleteButton_Click(object sender, EventArgs e)
        {

            if (removeTaskNameDropDown.SelectedItem == null)
            {
                return;
            }

            var deleteSelectedTask =
                "DELETE FROM dbo.Tasks WHERE Task_Name = @taskName";


            using (taskDatabaseConnection = new SqlConnection(ConnectionString))
            using (var DeleteSelectedTask = new SqlCommand(deleteSelectedTask, taskDatabaseConnection))
            {
                try
                {
                    taskDatabaseConnection.Open();
                }
                catch
                {
                    Console.WriteLine("Failed to open.");
                }

                DeleteSelectedTask.Parameters.AddWithValue("@taskName", removeTaskNameDropDown.SelectedItem);
                DeleteSelectedTask.ExecuteScalar();
                taskDatabaseConnection.Close();
            }
        }

        private void MenuSubmitButton_Click(object sender, EventArgs e)
        {
            
        }

        private void CompletedTasksReportButton_Click(object sender, EventArgs e)
        {
            if (reportSelector.SelectedItem == "Full Tasks Report")
            {
                FullReport = new FullReportForm();
                FullReport.Show();
            }
        }


        private void OverdueTasksButton_Click(object sender, EventArgs e)
        {
            FullReport = new FullReportForm();
            FullReport.Show();
        }

        private void TasksDueIn3DaysButton_Click(object sender, EventArgs e)
        {
            FullReport = new TasksDueIn3DaysReport();
            FullReport.Show();
        }

        private void TasksDueIn7DaysButton_Click(object sender, EventArgs e)
        {
            FullReport = new FullReportForm();
            FullReport.Show();
        }

        private void ReportMenuSubmitButton_Click(object sender, EventArgs e)
        {
        }

        private void createHomePageProgressBars()
        {
            var fetchTotalTasks =
                "SELECT COUNT(*) FROM dbo.Tasks";

            var fetchTotalTasksNotComplete =
                "SELECT COUNT(*) FROM dbo.Tasks WHERE Completed != @completedTasks";

            var fetchTotalCompletedTasks =
                "SELECT COUNT(*) FROM dbo.Tasks WHERE Completed = @completedTasks";

            var fetchTasksDueInXDays =
                "SELECT COUNT(*) FROM dbo.Tasks WHERE Task_Due_Date <= @dueDate";

            var fetchOverdueTasks =
                "SELECT COUNT(*) FROM dbo.Tasks WHERE Task_Due_Date <= @previousDueDate";

            using (taskDatabaseConnection = new SqlConnection(ConnectionString))
            using (var GetTotalTasks = new SqlCommand(fetchTotalTasks, taskDatabaseConnection))
            using (var GetTotalTasksNotCompleted = new SqlCommand(fetchTotalTasksNotComplete, taskDatabaseConnection))
            using (var GetNumberCompletedTasks = new SqlCommand(fetchTotalCompletedTasks, taskDatabaseConnection))
            using (var GetTasksDueIn3Days = new SqlCommand(fetchTasksDueInXDays, taskDatabaseConnection))
            using (var GetTasksDueIn7Days = new SqlCommand(fetchTasksDueInXDays, taskDatabaseConnection))
            using (var GetOverdueTasks = new SqlCommand(fetchOverdueTasks, taskDatabaseConnection))
            {
                try
                {
                    taskDatabaseConnection.Open();
                }
                catch
                {
                    Console.WriteLine("Failed to open.");
                }

                GetTotalTasksNotCompleted.Parameters.AddWithValue("@completedTasks", 1);
                GetNumberCompletedTasks.Parameters.AddWithValue("@completedTasks", 1);
                GetTasksDueIn3Days.Parameters.AddWithValue("@dueDate", DateTime.Now.AddDays(3));
                GetTasksDueIn7Days.Parameters.AddWithValue("@dueDate", DateTime.Now.AddDays(7));
                GetOverdueTasks.Parameters.AddWithValue("@previousDueDate", DateTime.Now);

                var totalTasks = Convert.ToInt32(GetTotalTasks.ExecuteScalar());
                var totalTasksNotCompleted = Convert.ToInt32(GetTotalTasksNotCompleted.ExecuteScalar());
                var completedTasks = Convert.ToInt32(GetNumberCompletedTasks.ExecuteScalar());
                Console.WriteLine(completedTasks);
                var tasksDueInThreeDays = Convert.ToInt32(GetTasksDueIn3Days.ExecuteScalar());
                var tasksDueInSevenDays = Convert.ToInt32(GetTasksDueIn7Days.ExecuteScalar());
                var overdueTasks = Convert.ToInt32(GetOverdueTasks.ExecuteScalar());

                FrontPageTasksDueIn3DaysProgressBar = new tasksDueProgressBar(totalTasks, tasksDueInThreeDays,
                    Size.Width / 4, Size.Height / 6, Size.Width / 5, SystemColors.ControlDarkDark, "Tasks Due In 3 Days", 25);
                FrontPageTasksDueIn7DaysProgressBar = new tasksDueProgressBar(totalTasks, tasksDueInSevenDays,
                    Size.Width / 2, Size.Height / 6, Size.Width / 5, SystemColors.ControlDarkDark, "Tasks Due In 7 Days", 16);
                FrontPageOverdueTasksProgressBar = new tasksDueProgressBar(totalTasks, overdueTasks,
                    FrontPageTasksDueIn7DaysProgressBar.Location.X + 270, Size.Height / 6, Size.Width / 5, SystemColors.ControlDarkDark, "Overdue Tasks", 6);

            }
        }

        private void SearchTaskNameDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fetchTaskDescription =
                "SELECT TASK_DESCRIPTION FROM dbo.Tasks WHERE TASK_NAME = @taskName";

            using (taskDatabaseConnection = new SqlConnection(ConnectionString))
            using (var GetTaskDescription = new SqlCommand(fetchTaskDescription, taskDatabaseConnection))
            {
                taskDatabaseConnection.Open();
                GetTaskDescription.Parameters.AddWithValue("@taskName", searchTaskNameDropdown.SelectedItem);
                searchTaskDescriptionBox.Text = Convert.ToString(GetTaskDescription.ExecuteScalar());
                taskDatabaseConnection.Close();
            }
        }

        private void SearchTaskSearchButton_Click(object sender, EventArgs e)
        {
            searchTaskNameDropdown.Items.Clear();

            var searchCommand =
                "SELECT TASK_NAME FROM dbo.Tasks WHERE TASK_DUE_DATE >= @dueDateStart AND TASK_DUE_DATE <= @dueDateEnd AND COMPLETED = @COMPLETED";

            using (taskDatabaseConnection = new SqlConnection(ConnectionString))
            using (var SearchTask = new SqlCommand(searchCommand, taskDatabaseConnection))
            {
                SearchTask.Parameters.AddWithValue("@dueDateStart", searchTaskStartDateTime.Value);
                SearchTask.Parameters.AddWithValue("@dueDateEnd", searchTaskEndDateTime.Value);
                SearchTask.Parameters.AddWithValue("@Completed", 0);

                taskDatabaseConnection.Open();

                using (var reader = SearchTask.ExecuteReader())
                {
                    var dropDownStrings = new List<string>();
                    while (reader.Read())
                        dropDownStrings.Add(reader.GetString(0));
                    var dropDownItems = dropDownStrings.ToArray();

                    for (var i = 0; i < dropDownItems.Length; ++i)
                        searchTaskNameDropdown.Items.Add(dropDownItems[i]);
                    taskDatabaseConnection.Close();
                    if (dropDownItems.Length > 0)
                        searchTaskNameDropdown.SelectedItem = dropDownItems[0];
                }
            }
        }

        private void RemoveSearchButton_Click(object sender, EventArgs e)
        {
            removeTaskNameDropDown.Items.Clear();

            var searchCommand =
                "SELECT TASK_NAME FROM dbo.Tasks";

            if (!string.IsNullOrWhiteSpace(removeTaskNameTextbox.Text))
                searchCommand += " WHERE TASK_NAME LIKE @taskName";

            if (removeTaskEndDateTime.Value > removeTaskStartDateTime.Value)
                if (!string.IsNullOrWhiteSpace(removeTaskNameTextbox.Text))
                    searchCommand += " AND TASK_DUE_DATE >= @dueDateStart AND TASK_DUE_DATE <= @dueDateEnd";
                else
                    searchCommand += " WHERE TASK_DUE_DATE >= @dueDateStart AND TASK_DUE_DATE <= @dueDateEnd";

            using (taskDatabaseConnection = new SqlConnection(ConnectionString))
            using (var RemoveTask = new SqlCommand(searchCommand, taskDatabaseConnection))
            {
                RemoveTask.Parameters.AddWithValue("@taskName", "%" + removeTaskNameTextbox.Text + "%");
                RemoveTask.Parameters.AddWithValue("@dueDateStart", removeTaskStartDateTime.Value);
                RemoveTask.Parameters.AddWithValue("@dueDateEnd", removeTaskEndDateTime.Value);

                taskDatabaseConnection.Open();
                using (var reader = RemoveTask.ExecuteReader())
                {
                    var dropDownStrings = new List<string>();
                    while (reader.Read())
                        dropDownStrings.Add(reader.GetString(0));
                    var dropDownItems = dropDownStrings.ToArray();

                    for (var i = 0; i < dropDownItems.Length; ++i)
                        removeTaskNameDropDown.Items.Add(dropDownItems[i]);

                    if (dropDownItems.Length > 0)
                        removeTaskNameDropDown.SelectedItem = dropDownItems[0];
                }
            }
        }

        private void AddMenuSubmitButton_Click(object sender, EventArgs e)
        {
            if (addTaskDueDateTime.Value <= DateTime.Now.AddHours(5) ||
                addTaskPriority1.Checked == false && addTaskPriority2.Checked == false &&
                addTaskPriority3.Checked == false && addTaskPriority4.Checked == false &&
                addTaskPriority5.Checked == false ||
                string.IsNullOrWhiteSpace(addTaskNameTextbox.Text) ||
                string.IsNullOrWhiteSpace(addTaskNameTextbox.Text))
            {
                if (string.IsNullOrWhiteSpace(addTaskDescriptionTextbox.Text))
                {
                    addTaskDescriptionAlert.Show();
                    alertConfirmation.Show();
                }

                if (string.IsNullOrWhiteSpace(addTaskNameTextbox.Text))
                {
                    addTaskNameAlert.Show();
                    alertConfirmation.Show();
                }

                if (addTaskPriority1.Checked == false && addTaskPriority2.Checked == false &&
                    addTaskPriority3.Checked == false && addTaskPriority4.Checked == false &&
                    addTaskPriority5.Checked == false)
                {
                    addTaskPriorityAlert.Show();
                    alertConfirmation.Show();
                }

                if (addTaskDueDateTime.Value <= DateTime.Now.AddHours(5) &&
                    (addTaskPriority1.Checked.Equals(true) || addTaskPriority2.Checked.Equals(true) ||
                     addTaskPriority3.Checked.Equals(true) || addTaskPriority4.Checked.Equals(true) ||
                     addTaskPriority5.Checked.Equals(true)) && !string.IsNullOrWhiteSpace(addTaskNameTextbox.Text) &&
                    !string.IsNullOrWhiteSpace(addTaskNameTextbox.Text))
                {
                    addDateTimeAlert.Show();
                    dateTimealertConfirmation.Show();
                }

                if (!string.IsNullOrWhiteSpace(addTaskDescriptionTextbox.Text))
                    addTaskDescriptionAlert.Hide();

                if (!string.IsNullOrWhiteSpace(addTaskNameTextbox.Text))
                    addTaskNameAlert.Hide();

                if (addTaskPriority1.Checked.Equals(true) || addTaskPriority2.Checked.Equals(true) ||
                    addTaskPriority3.Checked.Equals(true) || addTaskPriority4.Checked.Equals(true) ||
                    addTaskPriority5.Checked.Equals(true))
                    addTaskPriorityAlert.Hide();

                if (addTaskDueDateTime.Value > DateTime.Now.AddHours(5))
                {
                    addDateTimeAlert.Hide();
                    dateTimealertConfirmation.Hide();
                }
            }
            else
            {
                var insertCommand =
                    "INSERT INTO dbo.Tasks " +
                    "Values (@taskName, @taskDescription, @taskType, @priority, @dateTime, @completed)";
                using (taskDatabaseConnection = new SqlConnection(ConnectionString))
                using (var AddTask = new SqlCommand(insertCommand, taskDatabaseConnection))
                {
                    try
                    {
                        taskDatabaseConnection.Open();
                    }
                    catch
                    {
                        Console.WriteLine("Failed to open.");
                    }

                    AddTask.Parameters.AddWithValue("@taskName", addTaskNameTextbox.Text);
                    AddTask.Parameters.AddWithValue("@taskDescription", addTaskDescriptionTextbox.Text);
                    AddTask.Parameters.AddWithValue("@taskType", addTaskTypeDropDown.SelectedItem);
                    AddTask.Parameters.AddWithValue("@priority", prioritySelection);
                    AddTask.Parameters.AddWithValue("@dateTime", addTaskDueDateTime.Value);
                    AddTask.Parameters.AddWithValue("@completed", 0);

                    AddTask.ExecuteNonQuery();
                    clearAddMenuAlerts();
                }
            }
        }

        private void AddTaskPriority_CheckedChanged(object sender, EventArgs e)
        {
            var checkBoxName = sender as CheckBox;
            if (checkBoxName == addTaskPriority5 && addTaskPriority5.Checked)
            {
                addTaskPriority4.Checked = false;
                addTaskPriority3.Checked = false;
                addTaskPriority2.Checked = false;
                addTaskPriority1.Checked = false;
                prioritySelection = 5;
            }
            else if (checkBoxName == addTaskPriority4 && addTaskPriority4.Checked)
            {
                addTaskPriority5.Checked = false;
                addTaskPriority3.Checked = false;
                addTaskPriority2.Checked = false;
                addTaskPriority1.Checked = false;
                prioritySelection = 4;
            }
            else if (checkBoxName == addTaskPriority3 && addTaskPriority3.Checked)
            {
                addTaskPriority5.Checked = false;
                addTaskPriority4.Checked = false;
                addTaskPriority2.Checked = false;
                addTaskPriority1.Checked = false;
                prioritySelection = 3;
            }
            else if (checkBoxName == addTaskPriority2 && addTaskPriority2.Checked)
            {
                addTaskPriority5.Checked = false;
                addTaskPriority4.Checked = false;
                addTaskPriority3.Checked = false;
                addTaskPriority1.Checked = false;
                prioritySelection = 2;
            }
            else if (checkBoxName == addTaskPriority1 && addTaskPriority1.Checked)
            {
                addTaskPriority5.Checked = false;
                addTaskPriority4.Checked = false;
                addTaskPriority3.Checked = false;
                addTaskPriority2.Checked = false;
                prioritySelection = 1;
            }
        }

        private void clearAllMenus()
        {
            addMenu.Hide();
            removeMenu.Hide();
            searchMenu.Hide();
            reportsMenu.Hide();
            settingsMenu.Hide();
            clearAddMenuAlerts();
        }

        private void clearAddMenuAlerts()
        {
            addTaskPriorityAlert.Hide();
            addTaskNameAlert.Hide();
            addTaskDescriptionAlert.Hide();
            addDateTimeAlert.Hide();
            prioritySelection = 0;
            addTaskNameTextbox.Clear();
            addTaskDescriptionTextbox.Clear();
            addTaskDueDateTime.Value = DateTime.Now;
            addTaskTypeDropDown.SelectedItem = addTaskTypeDropDown.Items[0];
            addTaskPriority1.Checked = false;
            addTaskPriority2.Checked = false;
            addTaskPriority3.Checked = false;
            addTaskPriority4.Checked = false;
            addTaskPriority5.Checked = false;
        }

        private void HomeMenuButton_Hover(object sender, EventArgs e)
        {
            var buttonName = sender as Button;
            if (menuShow)
            {
                clearAllMenus();
                menuShow = false;
            }
            if (buttonName == removeButton)
                removeMenu.Show();
            else if (buttonName == addButton)
                addMenu.Show();
            else if (buttonName == searchButton)
                searchMenu.Show();
            else if (buttonName == reportsButton)
                reportsMenu.Show();
            else
                settingsMenu.Show();
            menuShow = true;
        }

        private void menuCancelButton_Click(object sender, EventArgs e)
        {
            clearAllMenus();
            menuShow = false;
        }

        private void Move_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Program.ReleaseCapture();
                Program.SendMessage(Handle, Program.WM_NCLBUTTONDOWN, Program.HT_CAPTION, 0);
            }
        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private static void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}