namespace WindowsFormsApplication1.View
{
    using System.Windows.Forms;
    using System.Drawing;

    internal class informationDropdown : ComboBox
    {
        internal informationDropdown(string dropDownName, int dropDownLocationX, int dropDownLocationY)
        {
            this.Items.AddRange(new object[]
            {
                "Work",
                "School",
                "Personal",
                "Family"
            });
            this.Name = dropDownName;
            this.Location = new Point(dropDownLocationX, dropDownLocationY);
            this.SelectedItem = this.Items[0];
            this.Size = new Size(332, 31);
        }
    }
}
