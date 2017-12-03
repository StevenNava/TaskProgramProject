namespace WindowsFormsApplication1.View
{
    using System.Windows.Forms;
    using System.Drawing;

    internal class menuLabel : Label
    {
        internal menuLabel(string labelName, string labelText, int labelLocationX, int labelLocationY)
        {
            this.AutoSize = true;
            this.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.ForeColor = Color.White;
            this.Location = new Point(labelLocationX, labelLocationY);
            this.Name = labelName;
            this.Text = labelText;
        }

        internal menuLabel(string labelName, string labelText, float font, int labelLocationX, int labelLocationY)
        {
            this.AutoSize = true;
            this.Font = new Font("Century Gothic", font, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.ForeColor = Color.White;
            this.Location = new Point(labelLocationX, labelLocationY);
            this.Name = labelName;
            this.Text = labelText;
        }
    }
}
