namespace WindowsFormsApplication1.View
{
    using System.Drawing;
    using System.Windows.Forms;

    internal class informationTextbox : RichTextBox
    {
        internal informationTextbox(string textboxName, int textboxLocationX, int textboxLocationY)
        {
            BorderStyle = BorderStyle.FixedSingle;
            BackColor = Color.White;
            Location = new Point(textboxLocationX, textboxLocationY);
            Name = textboxName;
            Size = new Size(332, 31);
        }

        internal informationTextbox(string textboxName, int textboxLocationX, int textboxLocationY, int dropDownSizeWidth, int dropDownSizeHeight)
        {
            BorderStyle = BorderStyle.FixedSingle;
            BackColor = Color.White;
            Location = new Point(textboxLocationX, textboxLocationY);
            Name = textboxName;
            Size = new Size(dropDownSizeWidth, dropDownSizeHeight);
        }
    }
}
