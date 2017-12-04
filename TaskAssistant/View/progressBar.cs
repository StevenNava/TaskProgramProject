using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsApplication1.View
{
    internal class progressBar : UserControl
    {
        private readonly int dueIn3Days;
        private readonly int progress;
        private readonly int totalTasks;

        internal progressBar(string progressBarName, int progressPercentage, int progressBarLocationX,
            int progressBarLocationY)
        {
            progress = progressPercentage;
            Name = progressBarName;
            Size = new Size(181, 181);
            Location = new Point(progressBarLocationX, progressBarLocationY);
            Paint += progressBar_Load;
        }

        internal progressBar(string progressBarName, double dueIn3Days, double totalTasks, int progressBarLocationX,
            int progressBarLocationY)
        {
            this.dueIn3Days = (int) dueIn3Days;
            this.totalTasks = (int) totalTasks;
            progress = (int) (100 * (dueIn3Days / totalTasks));
            Name = progressBarName;
            Size = new Size(181, 181);
            Location = new Point(progressBarLocationX, progressBarLocationY);
            Paint += progressBarQty_Load;
        }

        private void progressBar_Load(object sender, PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(Width / 2, Height / 2);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.RotateTransform(-90);
            var pen = new Pen(SystemColors.ControlDarkDark);
            var firstRectangle = new Rectangle(0 - (Width - 30) / 2 + 20, 0 - (Height - 30) / 2 + 20, Width - 70,
                Height - 70);
            e.Graphics.DrawPie(pen, firstRectangle, 0, 360);
            e.Graphics.FillPie(new SolidBrush(SystemColors.ControlDarkDark), firstRectangle, 0, 360);

            pen = new Pen(Color.FromArgb(5, 113, 176));
            e.Graphics.DrawPie(pen, firstRectangle, 0, (int) (progress * 3.6));
            e.Graphics.FillPie(new SolidBrush(Color.FromArgb(5, 113, 176)), firstRectangle, 0, (int) (progress * 3.6));

            pen = new Pen(Color.DarkGray);
            firstRectangle = new Rectangle(0 - (Width - 30) / 2 + 30, 0 - (Height - 30) / 2 + 30, Width - 90,
                Height - 90);
            e.Graphics.DrawPie(pen, firstRectangle, 0, 360);
            e.Graphics.FillPie(new SolidBrush(Color.DarkGray), firstRectangle, 0, 360);

            e.Graphics.RotateTransform(90);
            var fontFormat = new StringFormat();
            fontFormat.LineAlignment = StringAlignment.Center;
            fontFormat.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(progress + "%", new Font("Century Gothic", 16F, FontStyle.Regular),
                new SolidBrush(Color.White), firstRectangle, fontFormat);
        }

        private void progressBarQty_Load(object sender, PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(Width / 2, Height / 2);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.RotateTransform(-90);
            var pen = new Pen(SystemColors.ControlDarkDark);
            var firstRectangle = new Rectangle(0 - (Width - 30) / 2 + 20, 0 - (Height - 30) / 2 + 20, Width - 70,
                Height - 70);
            e.Graphics.DrawPie(pen, firstRectangle, 0, 360);
            e.Graphics.FillPie(new SolidBrush(SystemColors.ControlDarkDark), firstRectangle, 0, 360);

            pen = new Pen(Color.FromArgb(5, 113, 176));
            e.Graphics.DrawPie(pen, firstRectangle, 0, (int) (progress * 3.6));
            e.Graphics.FillPie(new SolidBrush(Color.FromArgb(5, 113, 176)), firstRectangle, 0, (int) (progress * 3.6));

            pen = new Pen(Color.DarkGray);
            firstRectangle = new Rectangle(0 - (Width - 30) / 2 + 30, 0 - (Height - 30) / 2 + 30, Width - 90,
                Height - 90);
            e.Graphics.DrawPie(pen, firstRectangle, 0, 360);
            e.Graphics.FillPie(new SolidBrush(Color.DarkGray), firstRectangle, 0, 360);

            e.Graphics.RotateTransform(90);
            var fontFormat = new StringFormat();
            fontFormat.LineAlignment = StringAlignment.Center;
            fontFormat.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(dueIn3Days + "/" + totalTasks, new Font("Century Gothic", 16F, FontStyle.Regular),
                new SolidBrush(Color.White), firstRectangle, fontFormat);
        }
    }
}