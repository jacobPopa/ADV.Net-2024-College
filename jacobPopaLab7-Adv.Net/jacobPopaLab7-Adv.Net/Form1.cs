using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Configuration;
using System.Security.AccessControl;
using System.Drawing.Text;

namespace jacobPopaLab7_Adv.Net
{
    
    public partial class Form1 : Form 
    {
        public string getConnStr()
        {
            return Properties.Settings.Default.connStr;
        }

        private myDataLayer dl = new myDataLayer();

        public Form1()
        {
           
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'peopleDs.people' table. You can move, or remove it, as needed.
            this.peopleTableAdapter.Fill(this.peopleDs.people);

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = dl.getPeople();
            dataGridView1.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn;
                SqlCommand cmd;
                conn = new SqlConnection(getConnStr());
                conn.Open();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlParameter rFirstname = new SqlParameter("@Firstname", SqlDbType.VarChar);
                rFirstname.Direction = ParameterDirection.Input;
                SqlParameter rLastname = new SqlParameter("@Lastname", SqlDbType.VarChar);
                rLastname.Direction = ParameterDirection.Input;
                rFirstname.Value = txtFirstName.Text;
                rLastname.Value = txtLastName.Text;
                cmd.Parameters.Add(rFirstname);
                cmd.Parameters.Add(rLastname);
                cmd.CommandText = "insert into people (firstname,lastname) values (@Firstname, @Lastname)";
                int result = cmd.ExecuteNonQuery();
                conn.Close();
                txtFirstName.Clear();
                txtLastName.Clear();
                MessageBox.Show("Data added. Please click Update");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " +  ex.Message);
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string sql;
                SqlConnection conn;
                SqlCommand cmd;
                sql = "delete from people where people_id=@People_id";
                conn = new SqlConnection(getConnStr());
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@People_id", Convert.ToInt32(txtPeople_id.Text));
                int result = cmd.ExecuteNonQuery();
                conn.Close();
                txtPeople_id.Clear();
                MessageBox.Show("Data deleted from People. Please click Update");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }


        }

        
    }
}
