using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1.View
{
    internal class menuLabel : Label
    {
        internal menuLabel(string labelName, string labelText, int labelLocationX, int labelLocationY)
        {
            AutoSize = true;
            Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            Location = new Point(labelLocationX, labelLocationY);
            Name = labelName;
            Text = labelText;
        }

        internal menuLabel(string labelName, string labelText, float font, int labelLocationX, int labelLocationY)
        {
            AutoSize = true;
            Font = new Font("Century Gothic", font, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            Location = new Point(labelLocationX, labelLocationY);
            Name = labelName;
            Text = labelText;
        }
    }
}