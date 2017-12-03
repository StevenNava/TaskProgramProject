namespace WindowsFormsApplication1.View
{
    using System.Windows.Forms;
    using System.Drawing;

    internal class ControlBarButton : Button
    {
        internal ControlBarButton(string buttonName, int buttonLocationX, int buttonLocationY, string buttonText) //have constructor take parameters for location, text, image
        {
            BackColor = SystemColors.ControlDarkDark;
            FlatAppearance.BorderSize = 0;
            FlatStyle = FlatStyle.Flat;
            Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.DarkGray;
            Size = new Size(20, 30);
            TextAlign = ContentAlignment.BottomCenter;
            Name = buttonName;
            Location = new Point(buttonLocationX, buttonLocationY);
            Text = buttonText;
            Padding = new Padding(0, 0, 0, 3);
        }

        internal ControlBarButton(string buttonName, int buttonLocationX, int buttonLocationY, string buttonText, ContentAlignment align) //have constructor take parameters for location, text, image
        {
            BackColor = SystemColors.ControlDarkDark;
            FlatAppearance.BorderSize = 0;
            FlatStyle = FlatStyle.Flat;
            Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.DarkGray;
            Size = new Size(20, 30);
            Name = buttonName;
            TextAlign = align;
            Location = new Point(buttonLocationX, buttonLocationY);
            Text = buttonText;
        }
    }
}
