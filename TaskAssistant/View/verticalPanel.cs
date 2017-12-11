using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1.View
{
    internal class VerticalPanel : Panel
    {
        internal VerticalPanel(string panelName, int panelXLocation, int panelYLocation, int panelSizeX, int panelSizeY)
        {
            BackColor = Color.FromArgb(10, 80, 161);
            Location = new Point(panelXLocation, panelYLocation);
            Name = panelName;
            Size = new Size(panelSizeX, panelSizeY);
        }
    }
}