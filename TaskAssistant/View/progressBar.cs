using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace WindowsFormsApplication1.View
{
    internal class progressBar : UserControl
    {
        int progress, dueIn3Days, totalTasks;

        internal progressBar(string progressBarName, int progressPercentage, int progressBarLocationX, int progressBarLocationY)
        {
            progress = progressPercentage;
            this.Name = progressBarName;
            this.Size = new Size(181, 181);
            this.Location = new Point(progressBarLocationX, progressBarLocationY);
            this.Paint += new PaintEventHandler(progressBar_Load);
        }

        internal progressBar(string progressBarName, double dueIn3Days, double totalTasks, int progressBarLocationX, int progressBarLocationY)
        {
            this.dueIn3Days = (int)dueIn3Days;
            this.totalTasks = (int)totalTasks;
            progress = (int)(100 * (dueIn3Days / totalTasks));
            this.Name = progressBarName;
            this.Size = new Size(181, 181);
            this.Location = new Point(progressBarLocationX, progressBarLocationY);
            this.Paint += new PaintEventHandler(progressBarQty_Load);
        }

        private void progressBar_Load(object sender, PaintEventArgs e)
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

        private void progressBarQty_Load(object sender, PaintEventArgs e)
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
            e.Graphics.DrawString(dueIn3Days.ToString() + "/" + totalTasks.ToString(), new Font("Century Gothic", 16F, FontStyle.Regular), new SolidBrush(Color.White), firstRectangle, fontFormat);
        }
    }
}
