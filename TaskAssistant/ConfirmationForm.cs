using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApplication1.View;

namespace WindowsFormsApplication1
{
    internal class ConfirmationForm : Form
    {
        private readonly PopoutMenuLabel confirmationButtonLabel;
        private readonly ConfirmationButton menuOKButton;

        internal ConfirmationForm(string formName)
        {
            BackColor = Color.FromArgb(5, 113, 176);
            Name = formName;
            Size = new Size(550, 150);
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            menuOKButton = new ConfirmationButton("OK", Size.Width / 5 * 2, Size.Height / 3 * 2, Size.Width / 5,
                Size.Height / 4);
            menuOKButton.Click += MenuOKButton_Click;
            Controls.Add(menuOKButton);
            confirmationButtonLabel = new PopoutMenuLabel(Size.Width, Size.Height - Size.Height / 5,
                "confirmationButtonLabel",
                "You must enter all the required information");

            if (Name == "dateTimeConfirmation")
                confirmationButtonLabel = new PopoutMenuLabel(Size.Width, Size.Height - Size.Height / 5,
                    "dateTimeConfirmationButtonLabel", "Tasks must be set further than 5 hours out");
            Controls.Add(confirmationButtonLabel);
        }

        private void MenuOKButton_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}