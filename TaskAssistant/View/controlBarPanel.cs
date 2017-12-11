using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1.View
{
    internal class ControlBarPanel : Panel
    {
        internal ControlBarPanel(string panelName, int panelSizeX, int panelSizeY) //accept name as parameter
        {
            BackColor = SystemColors.ControlDarkDark;
            Location = new Point(0, 0);
            Name = panelName;
            Size = new Size(panelSizeX, panelSizeY);
        }
    }
}