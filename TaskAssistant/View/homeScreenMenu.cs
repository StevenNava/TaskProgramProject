namespace WindowsFormsApplication1.View
{
    using System.Windows.Forms;
    using System.Drawing;

    internal class homeScreenMenu : Panel
    {
        statisticPanel menuStatisticPanel;
        internal ConfirmationButton menuCancelButton;
        internal ConfirmationButton menuSubmitButton;

        internal homeScreenMenu(int panelLocationX, int panelLocationY, int panelSizeWidth, int panelSizeHeight)
        {
            this.BackColor = Color.DarkGray;
            this.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.ForeColor = Color.White;
            this.Location = new Point(panelLocationX, panelLocationY);
            this.Size = new Size(panelSizeWidth, panelSizeHeight);
            menuStatisticPanel = new statisticPanel(this.BackColor, this.Size.Width - 200, 0, 200, this.Size.Height);
            menuCancelButton = new ConfirmationButton("menuForm", "Cancel", this.Size.Width - 500, this.Size.Height - 50);
            menuSubmitButton = new ConfirmationButton("menuForm", "Submit", menuCancelButton.Location.X + 150, menuCancelButton.Location.Y);
            this.Controls.Add(menuStatisticPanel);
            this.Controls.Add(menuCancelButton);
            this.Controls.Add(menuSubmitButton);
        }
    }
}
