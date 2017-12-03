namespace WindowsFormsApplication1.View
{
    using System.Drawing;
    using System.Windows.Forms;

    internal class informationTextbox : RichTextBox

    {
        internal informationTextbox(string textboxName, int textboxLocationX, int textboxLocationY)
        {
            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackColor = Color.White;
            this.Location = new Point(textboxLocationX, textboxLocationY);
            this.Name = textboxName;
            this.Size = new Size(332, 31);
            this.Text = "";
        }
    }
}
