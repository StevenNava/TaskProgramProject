namespace WindowsFormsApplication1.View
{
    using System.Windows.Forms;
    using System.Drawing;

    class controlBarButton : Button
    {
        internal controlBarButton(string buttonName, int buttonLocationX, int buttonLocationY, string buttonText) //have constructor take parameters for location, text, image
        {
            this.BackColor = SystemColors.ControlDarkDark;
            this.FlatAppearance.BorderSize = 0;
            this.FlatStyle = FlatStyle.Flat;
            this.Font = new Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = Color.DarkGray;
            this.Size = new Size(20, 30);
            this.TextAlign = ContentAlignment.BottomCenter;
            this.Name = buttonName;
            this.Location = new Point(buttonLocationX, buttonLocationY);
            this.Text = buttonText;
            this.Padding = new Padding(0, 0, 0, 3);
        }

        internal controlBarButton(string buttonName, int buttonLocationX, int buttonLocationY, string buttonText, ContentAlignment align) //have constructor take parameters for location, text, image
        {
            this.BackColor = SystemColors.ControlDarkDark;
            this.FlatAppearance.BorderSize = 0;
            this.FlatStyle = FlatStyle.Flat;
            this.Font = new Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = Color.DarkGray;
            this.Size = new Size(20, 30);
            this.TextAlign = align;
            this.Name = buttonName;
            this.Location = new Point(buttonLocationX, buttonLocationY);
            this.Text = buttonText;
        }
    }
}
