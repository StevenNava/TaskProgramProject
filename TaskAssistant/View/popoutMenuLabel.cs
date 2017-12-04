using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1.View
{
    internal class popoutMenuLabel : Label
    {
        internal popoutMenuLabel(int labelSizeWidth, int labelSizeHeight, string labelName, string labelText)
        {
            AutoSize = false;
            Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            Location = new Point(0, 0);
            Size = new Size(labelSizeWidth, labelSizeHeight);
            Name = labelName;
            Text = labelText;
            TextAlign = ContentAlignment.MiddleCenter;
        }
    }
}