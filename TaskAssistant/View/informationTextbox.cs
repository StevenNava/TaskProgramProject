using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1.View
{
    internal class InformationTextbox : RichTextBox
    {
        internal InformationTextbox(string textboxName, int textboxLocationX, int textboxLocationY)
        {
            BorderStyle = BorderStyle.FixedSingle;
            BackColor = Color.White;
            Location = new Point(textboxLocationX, textboxLocationY);
            Name = textboxName;
            Size = new Size(332, 31);
        }

        internal InformationTextbox(string textboxName, int textboxLocationX, int textboxLocationY,
            int dropDownSizeWidth, int dropDownSizeHeight)
        {
            BorderStyle = BorderStyle.FixedSingle;
            BackColor = Color.White;
            Location = new Point(textboxLocationX, textboxLocationY);
            Name = textboxName;
            Size = new Size(dropDownSizeWidth, dropDownSizeHeight);
        }
    }
}