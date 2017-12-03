

namespace WindowsFormsApplication1.View
{
    using System.Windows.Forms;
    using System.Drawing;

    internal class confirmationButton : Button
    {
        internal confirmationButton(string formLocation, string buttonText, int buttonLocationX, int buttonLocationY)
        {
            this.BackColor = Color.FromArgb(5, 113, 176);
            this.FlatAppearance.BorderSize = 0;
            this.FlatStyle = FlatStyle.Flat;
            this.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.ForeColor = Color.White;
            this.Text = buttonText;
            this.Location = new Point(buttonLocationX, buttonLocationY);
            this.Size = new Size(75, 23);

            if (formLocation.Equals("menuForm"))
            {
                this.BackColor = Color.DarkGray;
                this.Font = new Font("Century Gothic", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
                this.Size = new Size(120, 34);
            }
        }
    }
}
