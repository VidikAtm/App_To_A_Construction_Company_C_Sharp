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

namespace OrganizationProject
{ 
    public partial class DocumentsWork : Form
    {
        public bool statusDoc;
        public string numDoc;
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Resources/BD.mdb");
        OleDbCommand cmd = new OleDbCommand();
        public string clientID;
        public DocumentsWork()
        {
            InitializeComponent();
        }

        public void databaseRefresh(string stringBD) // обновление отображаемой информации в таблице
        {
            dataGridDoc.Rows.Clear();
            con.Open();
            cmd = new OleDbCommand(stringBD, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (dr.Read())
            {
                int countColum = dataGridDoc.ColumnCount;
                data.Add(new string[countColum]);
                data[data.Count - 1][0] = dr[0].ToString();
                data[data.Count - 1][1] = dr[3].ToString();
                data[data.Count - 1][2] = dr[4].ToString();
            }
            dr.Close();
            con.Close();
            foreach (string[] s in data)
                dataGridDoc.Rows.Add(s);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DocumentsWork_Load(object sender, EventArgs e)
        {
            string stringBD = "SELECT * FROM [WorkDocuments] WHERE [id_Clients] = '" + clientID + "'";
            databaseRefresh(stringBD);
            
        }

        private void dataGridDoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string stringBD;
            numDoc = dataGridDoc[0, dataGridDoc.CurrentRow.Index].Value.ToString();

            if (Convert.ToString(dataGridDoc[2, dataGridDoc.CurrentRow.Index].Value) == "False")
            {
                statusDoc = true;
                editWorksDoc();
                dataGridDoc[2, dataGridDoc.CurrentRow.Index].Value = true;
            }
            else
            {
                statusDoc = false;
                editWorksDoc();
                dataGridDoc[2, dataGridDoc.CurrentRow.Index].Value = false;
            }
        }

        private void editWorksDoc()
        {
            con.Open();
            string commands = "UPDATE [WorkDocuments] SET [status] = " + statusDoc + " WHERE [id_Clients] = '" + clientID + "' AND [id_workDocum] = " + numDoc;
            cmd = new OleDbCommand(commands, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            dr.Close();
            con.Close();
        }
    }
}
