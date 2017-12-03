namespace WindowsFormsApplication1.View
{
    using System.Drawing;
    using System.Windows.Forms;
    internal class statisticPanel : Panel
    {
        tasksDueIn3DaysProgressBar tasksDueIn3Days;
        tasksCompletedProgressBar tasksCompleted;
        internal statisticPanel(Color panelBackground, int panelXLocation, int panelYLocation, int panelSizeX, int panelSizeY)
        {
            this.Name = "statisticPanel";
            this.BackColor = panelBackground;
            this.Location = new Point(panelXLocation, panelYLocation);
            this.Size = new Size(panelSizeX, panelSizeY);
            tasksDueIn3Days = new tasksDueIn3DaysProgressBar(12, 4, this.Size.Width - 192, 50, this.Size.Width - 39);
            tasksCompleted = new tasksCompletedProgressBar(12, 4, tasksDueIn3Days.Location.X, tasksDueIn3Days.Location.Y + 200, this.Size.Width - 39);
            this.Controls.Add(tasksDueIn3Days);
            this.Controls.Add(tasksCompleted);
        }
    }
}
