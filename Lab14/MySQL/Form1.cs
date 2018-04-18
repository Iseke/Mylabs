using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySQL
{
    public partial class Form1 : Form
    {
        MySqlConnection mySqlConnection;
        MySqlDataAdapter mySqlDataAdapter;
        MySqlCommandBuilder mySqlCommandBuilder;
        DataTable dataTable;
        BindingSource bindingSource;
        DataSet ds = new DataSet();
        
        int start ;
        int viewnow = 10;
        int swipeon = 10;
        public Form1()
        {
            InitializeComponent();
            Load();
            start = 0;
            
        }
        public void Load()
        {
            mySqlConnection = new MySqlConnection(
              "SERVER=localhost;" +
              "DATABASE=ISA;" +
              "UID=root;" +
              "PASSWORD=;");
            mySqlConnection.Open();

            string query = "SELECT *  FROM contacts ";

            mySqlDataAdapter = new MySqlDataAdapter(query, mySqlConnection);
            mySqlCommandBuilder = new MySqlCommandBuilder(mySqlDataAdapter);

            mySqlDataAdapter.UpdateCommand = mySqlCommandBuilder.GetUpdateCommand();
            mySqlDataAdapter.DeleteCommand = mySqlCommandBuilder.GetDeleteCommand();
            mySqlDataAdapter.InsertCommand = mySqlCommandBuilder.GetInsertCommand();

            dataTable = new DataTable();
            mySqlDataAdapter.Fill(dataTable);
            mySqlDataAdapter.Fill(ds,start,viewnow, "contacts");
            PreviousBtn.Enabled = false;
            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;

            dataGridView1.DataSource = ds.Tables[0];
            bindingNavigator1.BindingSource = bindingSource;
        }
       

      

        private void nextpage_Click(object sender, EventArgs e)
        {
            PreviousBtn.Enabled = true;
            start += swipeon;
            if (start > 15)
            {
                start = 0;
            }
            ds.Clear();
            mySqlDataAdapter.Fill(ds, start, viewnow, "contacts");
        }

        private void Previouspage_click(object sender, EventArgs e)
        {
            start -= swipeon;
            if (start < 0)
            {
                PreviousBtn.Enabled = false;

                start = 0;
            }
            ds.Clear();
            mySqlDataAdapter.Fill(ds, start, viewnow, "contacts");
        }

        private void save_Click(object sender, EventArgs e)
        {
            mySqlDataAdapter.Update(dataTable);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
