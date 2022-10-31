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

namespace TestWF
{
    public partial class Form1 : Form
    {
        private DBBuilder re = new DBBuilder();

        public Form1()
        {
            InitializeComponent();

            re.SettingsForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}