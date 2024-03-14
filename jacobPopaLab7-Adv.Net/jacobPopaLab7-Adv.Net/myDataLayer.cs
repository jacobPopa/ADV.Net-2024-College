using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace jacobPopaLab7_Adv.Net
{
    internal class myDataLayer
    {
        public string getConnectionString()
        {
            return Properties.Settings.Default.connStr;
        }
        public DataTable getPeople()
        {

            
            string sql;
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataAdapter da;
            DataTable dt = new DataTable();
            sql = "Select people_id, firstname, lastname from people";
            conn = new SqlConnection(getConnectionString());
            cmd = new SqlCommand(sql, conn);
            da = new SqlDataAdapter(cmd);
            conn.Open();
            da.Fill(dt);
            conn.Close();
            return dt;

        }
    }
}
