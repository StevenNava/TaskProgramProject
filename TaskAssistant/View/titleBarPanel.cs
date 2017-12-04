using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1.View
{
    internal class titleBarPanel : Panel
    {
        internal titleBarPanel(string panelName, int panelSizeWidth, int panelSizeHeight) //accept name as parameter
        {
            BackColor = SystemColors.ControlDarkDark;
            Location = new Point(0, 0);
            Margin = new Padding(0);
            Name = panelName;
            Size = new Size(panelSizeWidth, panelSizeHeight);
        }
    }
}