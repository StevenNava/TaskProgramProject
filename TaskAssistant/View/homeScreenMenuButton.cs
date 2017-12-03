namespace WindowsFormsApplication1.View
{
    using System.Windows.Forms;
    using System.Drawing;

    class homeScreenMenuButton : Button
    {
        internal homeScreenMenuButton(string buttonName, Point buttonLocation, int buttonSizeWidth, int buttonSizeHeight, string buttonText, string buttonImage) //have constructor take parameters for location, text, image
        {
            this.BackColor = Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(113)))), ((int)(((byte)(176)))));
            this.FlatAppearance.BorderColor = Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(80)))), ((int)(((byte)(161)))));
            this.FlatAppearance.BorderSize = 0;
            this.FlatStyle = FlatStyle.Flat;
            this.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.ForeColor = Color.White;
            this.ImageAlign = ContentAlignment.TopLeft;
            this.Margin = new Padding(0, 0, 0, 0);
            this.Padding = new Padding(0, 0, 20, 0);
            this.Size = new Size(buttonSizeWidth, buttonSizeHeight);
            this.TextAlign = ContentAlignment.MiddleRight;
            this.Name = buttonName;
            this.Location = buttonLocation;
            this.Text = buttonText;
            this.Image = (Image)(ViewResource.ResourceManager.GetObject(buttonImage));

            if(this.Name.Equals("removeButton"))
            {
                this.Location = new Point(this.Location.X, this.Location.Y + this.Size.Height + 2);
            }
            if (this.Name.Equals("searchButton"))
            {
                this.Location = new Point(this.Location.X, this.Location.Y + (2 * (this.Size.Height + 2)));
            }
            if (this.Name.Equals("reportsButton"))
            {
                this.Location = new Point(this.Location.X, this.Location.Y + (3 * (this.Size.Height + 2)));
            }
            if (this.Name.Equals("settingsButton"))
            {
                this.Location = new Point(this.Location.X, this.Location.Y + (4 * (this.Size.Height + 2)));
            }
        }
    }
}
