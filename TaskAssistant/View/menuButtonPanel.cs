using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.View
{
    class menuButtonPanel : Panel
    {
        private menuButtonPanel(string panelName) //accept name as parameter
        {
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(80)))), ((int)(((byte)(161)))));
            this.Location = new System.Drawing.Point(223, 103);
            this.Name = panelName;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Size = new System.Drawing.Size(800, 511);
            this.TabIndex = 12;
        }
    }
}
