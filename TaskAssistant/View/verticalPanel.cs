namespace WindowsFormsApplication1.View
{
    using System.Windows.Forms;
    using System.Drawing;

    class verticalPanel : Panel
    {
        internal verticalPanel(string panelName, int panelXLocation, int panelYLocation, int panelSizeX, int panelSizeY) 
        {
            this.BackColor = Color.FromArgb(10, 80, 161);
            this.Location = new Point(panelXLocation, panelYLocation);
            this.Name = panelName;
            this.Size = new Size(panelSizeX, panelSizeY);
        }
    }
}
