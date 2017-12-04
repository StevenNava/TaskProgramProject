using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1.View
{
    internal class titleLabelSecondHalf : Label
    {
        internal titleLabelSecondHalf(string labelName, string labelText, int labelLocationX,
            int labelLocationY) //accept name, text, location as parameter (needed location ~ (31,33)
        {
            AutoSize = true;
            Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = SystemColors.ControlLightLight;
            Name = labelName;
            Text = labelText;
            Location = new Point(labelLocationX, labelLocationY);
        }
    }
}