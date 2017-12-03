namespace WindowsFormsApplication1.View
{
    using System.Windows.Forms;

    class titleBarPanel : Panel
    {
        internal titleBarPanel(string panelName, int panelSizeWidth, int panelSizeHeight) //accept name as parameter
        {
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new Padding(0);
            this.Name = panelName;
            this.Size = new System.Drawing.Size(panelSizeWidth, panelSizeHeight);
        }
    }
}
