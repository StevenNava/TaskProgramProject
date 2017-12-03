namespace WindowsFormsApplication1.View
{
    using System;
    using System.Windows.Forms;
    using System.Drawing;

    internal class programMainForm : Form
    {
        //object declaration
        homeScreenMenuButton addButton;
        homeScreenMenuButton removeButton;
        homeScreenMenuButton searchButton;
        homeScreenMenuButton reportsButton;
        homeScreenMenuButton settingsButton;
        titleBarPanel titleBar;
        verticalPanel menuBar;
        titleLabelFirstHalf firstHalfTitleLabel;
        titleLabelSecondHalf secondHalfTitleLabel;
        controlBarPanel controlBar;
        controlBarButton exit;
        controlBarButton minimize;

        //Add Task Menu Items
        homeScreenMenu addMenu;
        menuLabel addTaskTitle;
        menuLabel addTaskTaskName;
        menuLabel addTaskTaskDescription;
        menuLabel addTaskDueDate;
        menuLabel addTaskType;
        menuLabel addTaskPriority;
        informationTextbox addTaskNameTextbox;
        informationTextbox addTaskDescriptionTextbox;
        menuDateTimePicker addTaskDueDateTime;
        informationDropdown addTaskTypeDropDown;
        informationCheckbox addTaskPriority1;
        informationCheckbox addTaskPriority2;
        informationCheckbox addTaskPriority3;
        informationCheckbox addTaskPriority4;
        informationCheckbox addTaskPriority5;

        //Remove Task Menu Items
        homeScreenMenu removeMenu;
        menuLabel removeTaskTitle;

        //Search Task Menu Items
        homeScreenMenu searchMenu;
        menuLabel searchTasksTitle;

        //Reports Menu Items
        homeScreenMenu reportsMenu;
        menuLabel reportsTitle;

        //Settings Menu Items
        homeScreenMenu settingsMenu;
        menuLabel settingsTitle;

        bool menuShow;



        internal programMainForm(string formName) // accept name as a parameter
        {
            this.AllowDrop = true;
            this.BackColor = Color.FromArgb(195, 200, 205);
            this.ControlBox = false;
            this.Name = formName;
            this.Size = new Size(1030, 560);
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //add MouseDown event this.MouseDown += new MouseEventHandler(this.Form1_MouseDown_1);
            this.ResumeLayout(false);

            titleBar = new titleBarPanel("homeScreenTitleBar", this.Size.Width, this.Size.Height / 13);

            menuBar = new verticalPanel("menuBar", titleBar.Location.X, (titleBar.Location.Y + titleBar.Size.Height), this.Size.Width / 4, this.Size.Height - titleBar.Size.Height);

            addButton = new homeScreenMenuButton("addButton", new Point(0, 2), menuBar.Size.Width, (menuBar.Size.Height / 5) - 2, "Add Tasks", "add");
            removeButton = new homeScreenMenuButton("removeButton", new Point(0, 2), addButton.Size.Width, addButton.Size.Height, "Remove Tasks", "remove");
            searchButton = new homeScreenMenuButton("searchButton", new Point(0, 2), addButton.Size.Width, addButton.Size.Height, "Search Tasks", "search");
            reportsButton = new homeScreenMenuButton("reportsButton", new Point(0, 2), addButton.Size.Width, addButton.Size.Height, "Reports", "reports");
            settingsButton = new homeScreenMenuButton("settingsButton", new Point(0, 2), addButton.Size.Width, addButton.Size.Height, "Settings", "settings");

            //menuBar = new verticalPanel("menuBar", titleBar.Location.X, (titleBar.Location.Y + titleBar.Size.Height), addButton.Size.Width, (settingsButton.Location.Y + settingsButton.Size.Height));
            firstHalfTitleLabel = new titleLabelFirstHalf("titleLabelFirstHalf", "Task", titleBar.Size.Width / 25, titleBar.Size.Height / 6);
            secondHalfTitleLabel = new titleLabelSecondHalf("titleLabelSecondHalf", "Assistant", firstHalfTitleLabel.Location.X + 39, firstHalfTitleLabel.Location.Y + 1);


            controlBar = new controlBarPanel("homeScreenControlBar", titleBar.Size.Width, 30);
            exit = new controlBarButton("exit", controlBar.Size.Width - 20, 0, "X", ContentAlignment.BottomCenter);
            minimize = new controlBarButton("minimize", exit.Location.X - exit.Size.Width - 2, 0, "_");

            addMenu = new homeScreenMenu(addButton.Location.X + addButton.Size.Width, titleBar.Size.Height, this.Size.Width - addButton.Size.Width, menuBar.Size.Height);

            addTaskTitle = new menuLabel("addTaskTitle", "Add Task", 270, 18);
            addTaskTaskName = new menuLabel("addTaskTaskName", "Name", 40, 74);
            addTaskTaskDescription = new menuLabel("addTaskTaskDescription", "Description", addTaskTaskName.Location.X, addTaskTaskName.Location.Y + 80);
            addTaskDueDate = new menuLabel("addTaskDueDate", "Due Date/Time", addTaskTaskName.Location.X , addTaskTaskDescription.Location.Y + 80);
            addTaskType = new menuLabel("addTaskType", "Type", addTaskTaskName.Location.X, addTaskDueDate.Location.Y + 80);
            addTaskPriority = new menuLabel("addTaskPriority", "Priority", addTaskTaskName.Location.X, addTaskType.Location.Y + 80);

            addTaskNameTextbox = new informationTextbox("addTaskNameTextbox", 240, 71);
            addTaskDescriptionTextbox = new informationTextbox("addTaskDescriptionTextbox", addTaskNameTextbox.Location.X, addTaskNameTextbox.Location.Y + 80);
            addTaskDueDateTime = new menuDateTimePicker("addTaskDueDateTime", addTaskNameTextbox.Location.X, addTaskDescriptionTextbox.Location.Y + 80);
            addTaskTypeDropDown = new informationDropdown("addTaskTypeTextbox", addTaskNameTextbox.Location.X, addTaskDueDateTime.Location.Y + 80);
            addTaskPriority1 = new informationCheckbox("addTaskPriority1", "1", addTaskNameTextbox.Location.X, addTaskTypeDropDown.Location.Y + 80);
            addTaskPriority2 = new informationCheckbox("addTaskPriority2", "2", addTaskPriority1.Location.X + 66, addTaskPriority1.Location.Y);
            addTaskPriority3 = new informationCheckbox("addTaskPriority3", "3", addTaskPriority2.Location.X + 66, addTaskPriority1.Location.Y);
            addTaskPriority4 = new informationCheckbox("addTaskPriority4", "4", addTaskPriority3.Location.X + 66, addTaskPriority1.Location.Y);
            addTaskPriority5 = new informationCheckbox("addTaskPriority5", "5", addTaskPriority4.Location.X + 66, addTaskPriority1.Location.Y);

            removeMenu = new homeScreenMenu(addButton.Location.X + addButton.Size.Width, titleBar.Size.Height, titleBar.Size.Width - addButton.Size.Width, menuBar.Size.Height);

            removeTaskTitle = new menuLabel("removeTaskTitle", "Remove Task", 270, 18);

            searchMenu = new homeScreenMenu(addButton.Location.X + addButton.Size.Width, titleBar.Size.Height, titleBar.Size.Width - addButton.Size.Width, menuBar.Size.Height);

            searchTasksTitle = new menuLabel("searchTaskTitle", "Search Task", 270, 18);

            reportsMenu = new homeScreenMenu(addButton.Location.X + addButton.Size.Width, titleBar.Size.Height, titleBar.Size.Width - addButton.Size.Width, menuBar.Size.Height);

            reportsTitle = new menuLabel("reportsTitle", "Reports", 270, 18);

            settingsMenu = new homeScreenMenu(addButton.Location.X + addButton.Size.Width, titleBar.Size.Height, titleBar.Size.Width - addButton.Size.Width, menuBar.Size.Height);

            settingsTitle = new menuLabel("settingsTitle", "Settings", 270, 18);

            //create home screen objects
            addButton.MouseHover += addButton_Hover;
            removeButton.MouseHover += removeButton_Hover;
            searchButton.MouseHover += searchButton_Hover;
            reportsButton.MouseHover += reportsButton_Hover;
            settingsButton.MouseHover += settingsButton_Hover;

            addMenu.menuCancelButton.Click += menuCancelButton_Click;
            removeMenu.menuCancelButton.Click += menuCancelButton_Click;
            searchMenu.menuCancelButton.Click += menuCancelButton_Click;
            reportsMenu.menuCancelButton.Click += menuCancelButton_Click;
            settingsMenu.menuCancelButton.Click += menuCancelButton_Click;

            addTaskPriority1.CheckedChanged += AddTaskPriority1_CheckedChanged;
            addTaskPriority2.CheckedChanged += AddTaskPriority2_CheckedChanged;
            addTaskPriority3.CheckedChanged += AddTaskPriority3_CheckedChanged;
            addTaskPriority4.CheckedChanged += AddTaskPriority4_CheckedChanged;
            addTaskPriority5.CheckedChanged += AddTaskPriority5_CheckedChanged;

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
            addMenu.Hide();

            removeMenu.Controls.Add(removeTaskTitle);
            removeMenu.Hide();

            searchMenu.Controls.Add(searchTasksTitle);
            searchMenu.Hide();

            reportsMenu.Controls.Add(reportsTitle);
            reportsMenu.Hide();

            settingsMenu.Controls.Add(settingsTitle);
            settingsMenu.Hide();

            //create home screen for application
            this.Name = formName;
            //this.Size = new Size(titleBar.Size.Width, titleBar.Size.Height + menuBar.Size.Height);

            this.Controls.Add(menuBar);
            this.Controls.Add(titleBar);
            this.Controls.Add(addMenu);
            this.Controls.Add(removeMenu);
            this.Controls.Add(searchMenu);
            this.Controls.Add(reportsMenu);
            this.Controls.Add(settingsMenu);
        }

        private void AddTaskPriority5_CheckedChanged(object sender, EventArgs e)
        {
            if(addTaskPriority5.Checked == true)
            {
                addTaskPriority4.Checked = false;
                addTaskPriority3.Checked = false;
                addTaskPriority2.Checked = false;
                addTaskPriority1.Checked = false;
            }
        }

        private void AddTaskPriority4_CheckedChanged(object sender, EventArgs e)
        {
            if (addTaskPriority4.Checked == true)
            {
                addTaskPriority5.Checked = false;
                addTaskPriority3.Checked = false;
                addTaskPriority2.Checked = false;
                addTaskPriority1.Checked = false;
            }
        }

        private void AddTaskPriority3_CheckedChanged(object sender, EventArgs e)
        {
            if (addTaskPriority3.Checked == true)
            {
                addTaskPriority5.Checked = false;
                addTaskPriority4.Checked = false;
                addTaskPriority2.Checked = false;
                addTaskPriority1.Checked = false;
            }
        }

        private void AddTaskPriority2_CheckedChanged(object sender, EventArgs e)
        {
            if (addTaskPriority2.Checked == true)
            {
                addTaskPriority5.Checked = false;
                addTaskPriority4.Checked = false;
                addTaskPriority3.Checked = false;
                addTaskPriority1.Checked = false;
            }
        }

        private void AddTaskPriority1_CheckedChanged(object sender, EventArgs e)
        {
            if (addTaskPriority1.Checked == true)
            {
                addTaskPriority5.Checked = false;
                addTaskPriority4.Checked = false;
                addTaskPriority3.Checked = false;
                addTaskPriority2.Checked = false;
            }
        }

        private void clearAllMenus()
        {
            addMenu.Hide();
            removeMenu.Hide();
            searchMenu.Hide();
            reportsMenu.Hide();
            settingsMenu.Hide();
        }

        private void addButton_Hover(object sender, EventArgs e)
        {
            if(menuShow == true)
            {
                clearAllMenus();
                menuShow = false;
            }
            addMenu.Show();
            menuShow = true;
        }

        private void removeButton_Hover(object sender, EventArgs e)
        {
            if (menuShow == true)
            {
                clearAllMenus();
                menuShow = false;
            }
            removeMenu.Show();
            menuShow = true;
        }

        private void searchButton_Hover(object sender, EventArgs e)
        {
            if (menuShow == true)
            {
                clearAllMenus();
                menuShow = false;
            }
            searchMenu.Show();
            menuShow = true;
        }

        private void reportsButton_Hover(object sender, EventArgs e)
        {
            if (menuShow == true)
            {
                clearAllMenus();
                menuShow = false;
            }
            reportsMenu.Show();
            menuShow = true;
        }

        private void settingsButton_Hover(object sender, EventArgs e)
        {
            if (menuShow == true)
            {
                clearAllMenus();
                menuShow = false;
            }
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
            this.WindowState = FormWindowState.Minimized;
        }

        private static void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
