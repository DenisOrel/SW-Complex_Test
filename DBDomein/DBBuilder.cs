using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBDomein
{
    public class DBBuilder
    {
        /// <summary>
        /// Component for build connection string to data base
        /// </summary>
        private ConnectionSettings form;

        public DBBuilder()
        {
            form = new ConnectionSettings();
        }

        public void SettingsForm()
        {
            form.Show();
        }
    }
}