using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication1.View
{
    class titleLabelSecondHalf : Label
    {
        internal titleLabelSecondHalf(string labelName, string labelText, int labelLocationX, int labelLocationY) //accept name, text, location as parameter (needed location ~ (31,33)
        {
            this.AutoSize = true;
            this.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = SystemColors.ControlLightLight;
            this.Name = labelName;
            this.Text = labelText;
            this.Location = new Point(labelLocationX, labelLocationY);
        }
    }
}
