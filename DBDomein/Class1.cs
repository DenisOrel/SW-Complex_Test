using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBDomein
{
    public class Class1
    {
        /// <summary>
        /// Component for build connection string to data base
        /// </summary>
        private SqlConnectionStringBuilder SqlConnectionStringBuilder { get; set; }

        private ConnectionSettings form;

        public Class1()
        {
            form = new ConnectionSettings();
        }

        public void SettingsForm()
        {
            // SqlConnectionStringBuilder = new SqlConnectionStringBuilder();

            form.Show();
        }

        public string Text()
        {
            return form.DBName;
        }
    }
}