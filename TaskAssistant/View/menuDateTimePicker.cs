namespace WindowsFormsApplication1.View
{
    using System.Windows.Forms;
    using System.Drawing;

    internal class menuDateTimePicker : DateTimePicker
    {
        internal menuDateTimePicker(string dateTimePickerName, int dateTimePickerLocationX, int dateTimePickerLocationY)
        {
            this.Format = DateTimePickerFormat.Custom;
            this.CustomFormat = "ddd, MM/dd/yyyy hh:mm:ss tt";
            this.Location = new Point(dateTimePickerLocationX, dateTimePickerLocationY);
            this.Name = dateTimePickerName;
            this.Size = new Size(332, 31);
        }
    }
}
