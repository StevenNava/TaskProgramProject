using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1.View
{
    internal class InformationCheckbox : CheckBox
    {
        internal InformationCheckbox(string checkboxName, string checkboxText, int checkboxLocationX,
            int checkboxLocationY)
        {
            AutoSize = true;
            CheckAlign = ContentAlignment.TopCenter;
            ForeColor = Color.White;
            Location = new Point(checkboxLocationX, checkboxLocationY);
            Text = checkboxText;
            Name = checkboxName;
            Size = new Size(25, 40);
        }
    }
}