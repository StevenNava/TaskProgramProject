namespace WindowsFormsApplication1.View
{
    using System.Windows.Forms;
    using System.Drawing;

    class controlBarPanel : Panel
    {
        internal controlBarPanel(string panelName, int panelSizeX, int panelSizeY) //accept name as parameter
        {
            this.BackColor = SystemColors.ControlDarkDark;
            this.Location = new Point(0, 0);
            this.Name = panelName;
            this.Size = new Size(panelSizeX, panelSizeY);
        }
    }
}
