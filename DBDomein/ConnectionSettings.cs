using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

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

            ServerTextBox.Text = Properties.Settings.Default.sqlserverName;
            DBNameTextBox.Text = Properties.Settings.Default.dbName;
            UserTextBox.Text = Properties.Settings.Default.User;
            PassTextBox.Text = Properties.Settings.Default.Pass;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            sqlserverName = ServerTextBox.Text;
            dbName = DBNameTextBox.Text;
            User = UserTextBox.Text;
            Pass = PassTextBox.Text;

            Properties.Settings.Default["sqlserverName"] = sqlserverName;
            Properties.Settings.Default["dbName"] = dbName;
            Properties.Settings.Default["User"] = User;
            Properties.Settings.Default["Pass"] = Pass;

            Properties.Settings.Default.Save(); // Saves settings in application configuration file
        }

        private void TestConnButton_Click(object sender, EventArgs e)
        {
            Helper con = new Helper();
            try
            {
                initPros();

                con.DBName = dbName;
                con.SqlServerName = sqlserverName;
                con.SQLUser = User;
                con.SQLPassword = Pass;
                con.Open();
                con.Close();
                MessageBox.Show("Підключення встановленно.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void initPros()
        {
            sqlserverName = ServerTextBox.Text;
            dbName = DBNameTextBox.Text;
            User = UserTextBox.Text;
            Pass = PassTextBox.Text;
        }
    }
}