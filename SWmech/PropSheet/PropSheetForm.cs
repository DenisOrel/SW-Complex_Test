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
            FormatsComboBox.DisplayMember = "Name";
            HorizontalRadioButton.Checked = true;
        }

        private void FormatsComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            format = (Format)FormatsComboBox.SelectedItem;

            HeightTextBox.Text = format.Height.ToString();
            WidthTextBox.Text = format.Width.ToString();
            format.Orientation = true;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            PropSheetBuilder builder = new PropSheetBuilder();
            builder.Build(format);
        }
    }
}