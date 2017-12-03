namespace WindowsFormsApplication1.View
{
    using System.Windows.Forms;
    using System.Drawing;

    class popoutMenuLabel : Label
    {
        popoutMenuLabel(int labelLocationX, int labelLocationY, string labelName, string labelText)
        {
            this.AutoSize = true;
            this.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.ForeColor = Color.White;
            this.Location = new Point(labelLocationX, labelLocationY);
            this.Name = labelName;
            this.Text = labelText;
        }
    }
}
