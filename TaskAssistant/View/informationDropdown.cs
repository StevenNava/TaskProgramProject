using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1.View
{
    internal class informationDropdown : ComboBox
    {
        internal informationDropdown(string dropDownName, int dropDownLocationX, int dropDownLocationY)
        {
            Items.AddRange(new object[]
            {
                "Work",
                "School",
                "Personal",
                "Family"
            });
            Name = dropDownName;
            Location = new Point(dropDownLocationX, dropDownLocationY);
            SelectedItem = Items[0];
            Size = new Size(332, 31);
        }
    }
}