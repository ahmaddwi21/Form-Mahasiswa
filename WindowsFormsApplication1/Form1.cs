using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Dapper;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        OleDbConnection konn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:/Form Mahasiswa/Mahasiswa.mdb");
        public Form1()
        {
            InitializeComponent();
            load();

        }

        public void load()
        {
            OleDbCommand command = new OleDbCommand("select * from DataMhs", konn);
            konn.Open();

            OleDbDataReader reader = command.ExecuteReader();
            DataTable mytable = new DataTable();

            mytable.Load(reader);
            konn.Close();
            dataGrid.DataSource = mytable;
        }

        private void empty()
        {
            tbNIM.Text = string.Empty;
            tbNama.Text = string.Empty;
            tbAlamat.Text = string.Empty;

        }

        private void insertData()
        {
            try
            {
                konn.Execute("insert into DataMhs(NIM, nama, alamat) values('"+tbNIM.Text+"','"+tbNama.Text+"','"+tbAlamat.Text+"')");
                empty();

                load();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void updateData()
        {
            try
            {

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            insertData();
        }
    }
}
