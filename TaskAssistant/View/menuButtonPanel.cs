using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1.View
{
    internal class menuButtonPanel : Panel
    {
        private menuButtonPanel(string panelName) //accept name as parameter
        {
            BackColor = Color.White;
            Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(10, 80, 161);
            Location = new Point(223, 103);
            Name = panelName;
            Margin = new Padding(0);
            Size = new Size(800, 511);
            TabIndex = 12;
        }
    }
}