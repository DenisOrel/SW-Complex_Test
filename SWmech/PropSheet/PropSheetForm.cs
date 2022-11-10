using System;
using System.Windows.Forms;

namespace SWmech.PropSheet
{
    public partial class PropSheetForm : Form
    {
        private Format format = new Format();

        public PropSheetForm()
        {
            InitializeComponent();

            //FormatsComboBox.DataSource = format.FormatsList().Select(x => x.Name).ToList();
            FormatsComboBox.DataSource = format.FormatsList();
            FormatsComboBox.DisplayMember = "FormatName";

            MultiplicityComboBox.DataSource = format.Multiplicity;

            HorizontalRadioButton.Checked = true;
            //HeightTextBox.ReadOnly = true;
            //WidthTextBox.ReadOnly = true;
        }

        private void FormatsComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            format = (Format)FormatsComboBox.SelectedItem;
            MultiplicityComboBox.DataSource = format.Multiplicity;

            if (HorizontalRadioButton.Checked)
            {
                HeightTextBox.Text = (format.Width * 1000).ToString() + " мм";
                WidthTextBox.Text = (format.Height * 1000).ToString() + " мм";
            }
            else
            {
                HeightTextBox.Text = (format.Height * 1000).ToString() + " мм";
                WidthTextBox.Text = (format.Width * 1000).ToString() + " мм";
            }

            if (format.FormatName == "Інший")
            {
                HeightTextBox.ReadOnly = false;
                WidthTextBox.ReadOnly = false;
            }
            else
            {
                HeightTextBox.ReadOnly = true;
                WidthTextBox.ReadOnly = true;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            PropSheetBuilder builder = new PropSheetBuilder();
            format.Orientation = HorizontalRadioButton.Checked;

            builder.Build(format);
        }
    }
}