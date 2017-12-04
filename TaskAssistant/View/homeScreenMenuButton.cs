using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1.View
{
    internal class homeScreenMenuButton : Button
    {
        internal homeScreenMenuButton(string buttonName, Point buttonLocation, int buttonSizeWidth,
            int buttonSizeHeight, string buttonText,
            string buttonImage) //have constructor take parameters for location, text, image
        {
            BackColor = Color.FromArgb(5, 113, 176);
            FlatAppearance.BorderColor = Color.FromArgb(10, 80, 161);
            FlatAppearance.BorderSize = 0;
            FlatStyle = FlatStyle.Flat;
            Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            ImageAlign = ContentAlignment.TopLeft;
            Margin = new Padding(0, 0, 0, 0);
            Padding = new Padding(0, 0, 20, 0);
            Size = new Size(buttonSizeWidth, buttonSizeHeight);
            TextAlign = ContentAlignment.MiddleRight;
            Name = buttonName;
            Location = buttonLocation;
            Text = buttonText;
            Image = (Image) ViewResource.ResourceManager.GetObject(buttonImage);

            if (Name.Equals("removeButton"))
                Location = new Point(Location.X, Location.Y + Size.Height + 2);
            if (Name.Equals("searchButton"))
                Location = new Point(Location.X, Location.Y + 2 * (Size.Height + 2));
            if (Name.Equals("reportsButton"))
                Location = new Point(Location.X, Location.Y + 3 * (Size.Height + 2));
            if (Name.Equals("settingsButton"))
                Location = new Point(Location.X, Location.Y + 4 * (Size.Height + 2));
        }
    }
}