using System.Runtime.InteropServices.ComTypes;

namespace WindowsFormsApplication1.View
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Data.SqlClient;
    internal class statisticPanel : Panel
    {
        private int totalTasks;
        private int completedTasks;
        private int tasksDueInThreeDays;
        private SqlConnection taskDatabaseConnection;
        private string ConnectionString =
        ("Data Source=localhost; " +
         "Initial Catalog=TaskAssistant; " +
         "user id=test; " +
         "password=test; " +
         "connection timeout=30");

        tasksDueIn3DaysProgressBar tasksDueIn3Days;
        tasksCompletedProgressBar tasksCompleted;
        internal statisticPanel(Color panelBackground, int panelXLocation, int panelYLocation, int panelSizeX, int panelSizeY)
        {
            Name = "statisticPanel";
            BackColor = panelBackground;
            Location = new Point(panelXLocation, panelYLocation);
            Size = new Size(panelSizeX, panelSizeY);
            createStatisticPanelProgressBars();
            Controls.Add(tasksDueIn3Days);
            Controls.Add(tasksCompleted);
        }

        internal void createStatisticPanelProgressBars()
        {
            string fetchTotalTasks =
                "SELECT COUNT(*) FROM dbo.Tasks";

            String fetchTotalCompletedTasks =
                "SELECT COUNT(*) FROM dbo.Tasks WHERE Completed = @completedTasks";

            String fetchTasksDueIn3Days =
                "SELECT COUNT(*) FROM dbo.Tasks WHERE Task_Due_Date <= @dueDate";

            using (taskDatabaseConnection = new SqlConnection(ConnectionString))
            using (SqlCommand GetTotalTasks = new SqlCommand(fetchTotalTasks, taskDatabaseConnection))
            using (SqlCommand GetNumberCompletedTasks = new SqlCommand(fetchTotalCompletedTasks, taskDatabaseConnection))
            using (SqlCommand GetTasksDueIn3Days = new SqlCommand(fetchTasksDueIn3Days, taskDatabaseConnection))
            {
                try
                {
                    taskDatabaseConnection.Open();
                }
                catch
                {
                    Console.WriteLine("Failed to open.");
                }

                GetNumberCompletedTasks.Parameters.AddWithValue("@completedTasks", 1);
                GetTasksDueIn3Days.Parameters.AddWithValue("@dueDate", DateTime.Now.AddDays(3));

                totalTasks = Convert.ToInt32(GetTotalTasks.ExecuteScalar());
                completedTasks = Convert.ToInt32(GetNumberCompletedTasks.ExecuteScalar());
                Console.WriteLine(completedTasks);
                tasksDueInThreeDays = Convert.ToInt32(GetTasksDueIn3Days.ExecuteScalar());
            }

            tasksDueIn3Days = new tasksDueIn3DaysProgressBar(totalTasks, tasksDueInThreeDays, this.Size.Width - 192, 50, this.Size.Width - 39);
            tasksCompleted = new tasksCompletedProgressBar(totalTasks, completedTasks, tasksDueIn3Days.Location.X, tasksDueIn3Days.Location.Y + 200, this.Size.Width - 39);
        }
    }
}
