using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1.View
{
    internal class controlBarPanel : Panel
    {
        internal controlBarPanel(string panelName, int panelSizeX, int panelSizeY) //accept name as parameter
        {
            BackColor = SystemColors.ControlDarkDark;
            Location = new Point(0, 0);
            Name = panelName;
            Size = new Size(panelSizeX, panelSizeY);
        }
    }
}