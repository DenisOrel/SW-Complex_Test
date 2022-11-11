using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBDomein;
using SWmech.PropSheet;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace TestWF
{
    public partial class Form1 : Form
    {
        private DBBuilder re = new DBBuilder();
        private PropSheetForm PropSheetForm = new PropSheetForm();

        public Form1()
        {
            InitializeComponent();
            PropSheetForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            CommonOpenFileDialog dialog = new CommonOpenFileDialog();

            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string folder = dialog.FileName;
                MessageBox.Show(folder);
            }
        }
    }
}