namespace WindowsFormsApplication1.View
{
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    internal class tasksCompletedProgressBar : UserControl
    {
        int progress;
        menuLabel tasksCompletedLabel;

        internal tasksCompletedProgressBar(double totalTasksNotCurrent, double totalTasksCompeleted, int progressBarLocationX, int progressBarLocationY, int progressBarSizeDiameter)
        {
            progress = (int)(100 * (totalTasksCompeleted / totalTasksNotCurrent));
            this.Name = "tasksCompletedProgressBar";
            this.Size = new Size(progressBarSizeDiameter, progressBarSizeDiameter);
            this.Location = new Point(progressBarLocationX, progressBarLocationY);
            this.Paint += new PaintEventHandler(tasksCompletedProgressBar_Load);
            tasksCompletedLabel = new menuLabel("tasksCompletedLabel", "Tasks Completed", 12, 15, progressBarSizeDiameter - 30);
            this.Controls.Add(tasksCompletedLabel);
        }

        private void tasksCompletedProgressBar_Load(object sender, PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(this.Width / 2, this.Height / 2);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.RotateTransform(-90);
            Pen pen = new Pen(SystemColors.ControlDarkDark);
            Rectangle firstRectangle = new Rectangle(0 - (this.Width - 30) / 2 + 20, 0 - (this.Height - 30) / 2 + 20, this.Width - 70, this.Height - 70);
            e.Graphics.DrawPie(pen, firstRectangle, 0, 360);
            e.Graphics.FillPie(new SolidBrush(SystemColors.ControlDarkDark), firstRectangle, 0, 360);

            pen = new Pen(Color.FromArgb(5, 113, 176));
            e.Graphics.DrawPie(pen, firstRectangle, 0, (int)(progress * 3.6));
            e.Graphics.FillPie(new SolidBrush(Color.FromArgb(5, 113, 176)), firstRectangle, 0, (int)(progress * 3.6));

            pen = new Pen(Color.DarkGray);
            firstRectangle = new Rectangle(0 - (this.Width - 30) / 2 + 30, 0 - (this.Height - 30) / 2 + 30, this.Width - 90, this.Height - 90);
            e.Graphics.DrawPie(pen, firstRectangle, 0, 360);
            e.Graphics.FillPie(new SolidBrush(Color.DarkGray), firstRectangle, 0, 360);

            e.Graphics.RotateTransform(90);
            StringFormat fontFormat = new StringFormat();
            fontFormat.LineAlignment = StringAlignment.Center;
            fontFormat.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(progress.ToString() + "%", new Font("Century Gothic", 16F, FontStyle.Regular), new SolidBrush(Color.White), firstRectangle, fontFormat);
        }
    }
}
