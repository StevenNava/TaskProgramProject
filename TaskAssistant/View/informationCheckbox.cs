namespace WindowsFormsApplication1.View
{
    using System.Windows.Forms;
    using System.Drawing;

    internal class informationCheckbox : CheckBox
    {
        internal informationCheckbox(string checkboxName, string checkboxText, int checkboxLocationX, int checkboxLocationY)
        {
            this.AutoSize = true;
            this.CheckAlign = ContentAlignment.TopCenter;
            this.ForeColor = Color.White;
            this.Location = new Point(checkboxLocationX, checkboxLocationY);
            this.Text = checkboxText;
            this.Name = checkboxName;
            this.Size = new Size(25, 40);
        }
    }
}
