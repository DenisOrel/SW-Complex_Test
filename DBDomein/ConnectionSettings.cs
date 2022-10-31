using System;
using System.Windows.Forms;

namespace DBDomein
{
    public partial class ConnectionSettings : Form
    {
        private string dbName;
        private string sqlserverName;
        private string User;
        private string Pass;

        public string DBName
        {
            get { return dbName; }
            set { dbName = value; }
        }

        public string SqlServerName
        {
            get { return sqlserverName; }
            set { sqlserverName = value; }
        }

        public string SQLUser
        {
            get { return User; }
            set { User = value; }
        }

        public string SQLPassword
        {
            get { return Pass; }
            set { Pass = value; }
        }

        public ConnectionSettings()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            dbName = DBNameTextBox.Text;

            Close();
        }
    }
}