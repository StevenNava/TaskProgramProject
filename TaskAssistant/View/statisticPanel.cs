using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1.View
{
    internal class statisticPanel : Panel
    {
        private readonly string ConnectionString =
            "Data Source=localhost; " +
            "Initial Catalog=TaskAssistant; " +
            "user id=test; " +
            "password=test; " +
            "connection timeout=30";

        private int completedTasks;

        private SqlConnection taskDatabaseConnection;
        private tasksCompletedProgressBar tasksCompleted;

        private tasksDueProgressBar tasksDueIn3Days;
        private int tasksDueInThreeDays;
        private int totalTasks;
        private int totalTasksNotCompleted;

        internal statisticPanel(Color panelBackground, int panelXLocation, int panelYLocation, int panelSizeX,
            int panelSizeY)
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
            var fetchTotalTasks =
                "SELECT COUNT(*) FROM dbo.Tasks";

            var fetchTotalTasksNotComplete =
                "SELECT COUNT(*) FROM dbo.Tasks WHERE Completed != @completedTasks";

            var fetchTotalCompletedTasks =
                "SELECT COUNT(*) FROM dbo.Tasks WHERE Completed = @completedTasks";

            var fetchTasksDueIn3Days =
                "SELECT COUNT(*) FROM dbo.Tasks WHERE Task_Due_Date <= @dueDate";

            using (taskDatabaseConnection = new SqlConnection(ConnectionString))
            using (var GetTotalTasks = new SqlCommand(fetchTotalTasks, taskDatabaseConnection))
            using (var GetTotalTasksNotCompleted = new SqlCommand(fetchTotalTasksNotComplete, taskDatabaseConnection))
            using (var GetNumberCompletedTasks = new SqlCommand(fetchTotalCompletedTasks, taskDatabaseConnection))
            using (var GetTasksDueIn3Days = new SqlCommand(fetchTasksDueIn3Days, taskDatabaseConnection))
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
                GetTotalTasksNotCompleted.Parameters.AddWithValue("@completedTasks", 1);
                GetTasksDueIn3Days.Parameters.AddWithValue("@dueDate", DateTime.Now.AddDays(3));

                totalTasks = Convert.ToInt32(GetTotalTasks.ExecuteScalar());
                totalTasksNotCompleted = Convert.ToInt32(GetTotalTasksNotCompleted.ExecuteScalar());
                completedTasks = Convert.ToInt32(GetNumberCompletedTasks.ExecuteScalar());
                tasksDueInThreeDays = Convert.ToInt32(GetTasksDueIn3Days.ExecuteScalar());
            }

            tasksDueIn3Days = new tasksDueProgressBar(totalTasks, tasksDueInThreeDays, Size.Width - 192, 50,
                Size.Width - 39);
            tasksCompleted = new tasksCompletedProgressBar(totalTasksNotCompleted, completedTasks, tasksDueIn3Days.Location.X,
                tasksDueIn3Days.Location.Y + 200, Size.Width - 39);
        }
    }
}