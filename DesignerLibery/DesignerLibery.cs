using DBDomein;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignerLibery
{
    public partial class DesignerLibery : Form
    {
        public DesignerLibery()
        {
            InitializeComponent();

            string yourParentNode;

            yourParentNode = "Навігатор";
            treeView1.Nodes.Add(yourParentNode);
            treeView1.ExpandAll();
            treeView1.Nodes[0].Nodes.Add("Стандартні вироби");
            //treeView1.Nodes[1].Nodes.Add("Болти і гайки");
            treeView1.Nodes[0].Nodes.Add("Інші вироби");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBBuilder re = new DBBuilder();
            re.SettingsForm();
        }
    }
}