namespace WindowsFormsApplication1.View
{
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    internal class tasksDueIn3DaysProgressBar : UserControl
    {
        int progress, totalTasksDue, tasksDueIn3Days;
        menuLabel tasksDueIn3DaysLabel;

        internal tasksDueIn3DaysProgressBar(double totalTasksDue, double tasksDueIn3Days, int progressBarLocationX, int progressBarLocationY, int progressBarSizeDiameter)
        {
            this.Name = "tasksDueIn3DaysProgressBar";
            this.totalTasksDue = (int)totalTasksDue;
            this.tasksDueIn3Days = (int)tasksDueIn3Days;
            progress = (int)(100 * (tasksDueIn3Days / totalTasksDue));
            this.Size = new Size(progressBarSizeDiameter, progressBarSizeDiameter);
            this.Location = new Point(progressBarLocationX, progressBarLocationY);
            this.Paint += new PaintEventHandler(tasksDueIn3DaysProgressBar_Load);
            tasksDueIn3DaysLabel = new menuLabel("tasksDueIn3Days", "Tasks Due In 3 Days", 12, 10, progressBarSizeDiameter - 30);
            this.Controls.Add(tasksDueIn3DaysLabel);
        }

        private void tasksDueIn3DaysProgressBar_Load(object sender, PaintEventArgs e)
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
            e.Graphics.DrawString(tasksDueIn3Days.ToString() + "/" + totalTasksDue.ToString(), new Font("Century Gothic", 16F, FontStyle.Regular), new SolidBrush(Color.White), firstRectangle, fontFormat);
        }
    }
}
