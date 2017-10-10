using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;


namespace MY_DATA_BASE_PROGRAM
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection(connectionString: @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\DataBae\Testdatabase.mdf;Integrated Security=True;Connect Timeout=30");
        
        public Form1()
        {
            
            InitializeComponent();
            DisplayData();
            this.dataGridView1.Columns[0].Visible = false;
            //DataGridViewButtonColumn uninstallButtoncolumn = new DataGridViewButtonColumn();
            //uninstallButtoncolumn.Name = "Button";
            //uninstallButtoncolumn.Text = "Clear";

            //int columnIndex = 2;
            //dataGridView1.Columns.Insert(columnIndex, uninstallButtoncolumn);


        }
        private void DisplayData()
        {
           
            connection.Open();
            SqlCommand command = new SqlCommand("SELECt*FROM TestDB1", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            command.ExecuteNonQuery();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }     
        private void clear()
        {
            Name_text.Text = "";
            Loc_text.Text = "";
            ID_textBox.Text = "";
        }
        

        private void btn_save_Click(object sender, EventArgs e)
        {
            int i;
            i = dataGridView1.SelectedCells[0].RowIndex;
            connection.Open();
            SqlCommand command = new SqlCommand("update testdb1 set ID=@ID,Name=@Name,Location=@Location where ID=@ID", connection);
            command.Parameters.AddWithValue("Name", Name_text.Text);
            command.Parameters.AddWithValue("Location", Loc_text.Text);
            command.Parameters.AddWithValue("ID",ID_textBox.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Succesufully Saved");
            DisplayData();
            clear();
        }       

        private void btn_insert_Click(object sender, EventArgs e)
        {
            int i;
            i = (dataGridView1.SelectedCells[0].RowIndex);
            connection.Open();
            SqlCommand command = new SqlCommand("insert into TestDB1 (SlNo,ID,Name,Location)Values(@SlNo,@ID,@Name,@Location)", connection);
            command.Parameters.AddWithValue("ID",ID_textBox.Text);
            command.Parameters.AddWithValue("SlNo", i+1);
            command.Parameters.AddWithValue("Name", Name_text.Text);
            command.Parameters.AddWithValue("Location", Loc_text.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Inserted Succesufully");
            DisplayData();
            clear();

        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do You Want To Delete Record", "Yes Or No", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {               
                connection.Open();
                SqlCommand command = new SqlCommand("Delete From TestDB1 Where ID=@ID", connection);
                command.Parameters.AddWithValue("ID",ID_textBox.Text);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Deleted Record Successfully");
                DisplayData();
              }
            if(dr==DialogResult.No)
            {
            }
            clear();
        }

        private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i = dataGridView1.SelectedCells[0].RowIndex;
            ID_textBox.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            Name_text.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            Loc_text.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridView1.SelectedCells[0].RowIndex;
            MessageBox.Show(rowindex.ToString());

        } 
        
}
}

