namespace WindowsFormsApplication1.View
{
    using System.Windows.Forms;
    using System.Drawing;

    internal class ConfirmationButton : Button
    {
        internal ConfirmationButton(string formLocation, string buttonText, int buttonLocationX, int buttonLocationY)
        {
            BackColor = Color.FromArgb(5, 113, 176);
            FlatAppearance.BorderSize = 0;
            FlatStyle = FlatStyle.Flat;
            Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            Text = buttonText;
            Location = new Point(buttonLocationX, buttonLocationY);
            Size = new Size(75, 23);

            if (formLocation.Equals("menuForm"))
            {
                BackColor = Color.DarkGray;
                Font = new Font("Century Gothic", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
                Size = new Size(120, 34);
            }
        }

        internal ConfirmationButton(string buttonText, int buttonLocationX, int buttonLocationY, int buttonSizeWidth, int buttonSizeHeight)
        {
            BackColor = Color.FromArgb(5, 113, 176);
            FlatAppearance.BorderSize = 0;
            FlatStyle = FlatStyle.Flat;
            Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            Text = buttonText;
            Location = new Point(buttonLocationX, buttonLocationY);
            Size = new Size(buttonSizeWidth, buttonSizeHeight);
        }
    }
}
