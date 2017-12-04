using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1.View
{
    internal class menuDateTimePicker : DateTimePicker
    {
        internal menuDateTimePicker(string dateTimePickerName, int dateTimePickerLocationX, int dateTimePickerLocationY)
        {
            Format = DateTimePickerFormat.Custom;
            CustomFormat = "ddd, MM/dd/yyyy hh:mm:ss tt";
            Location = new Point(dateTimePickerLocationX, dateTimePickerLocationY);
            Name = dateTimePickerName;
            Size = new Size(332, 31);
        }
    }
}