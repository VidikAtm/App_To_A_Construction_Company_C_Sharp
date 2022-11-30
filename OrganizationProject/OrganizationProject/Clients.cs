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
    public partial class Clients : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Resources/BD.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();
        private bool delcheck = true;

        public Clients()
        {
            InitializeComponent();

            searchBox.Text = "";
            databaseRefresh("SELECT * FROM [Clients] WHERE [fioClient] LIKE '%" + searchBox.Text + "%'");
        }
        public void databaseRefresh(string stringBD) // обновление отображаемой информации в таблице
        {
            dataGridClient.Rows.Clear();
            con.Open();
            cmd = new OleDbCommand(stringBD, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (dr.Read())
            {
                int countColum = dataGridClient.ColumnCount;
                data.Add(new string[countColum]);
                data[data.Count - 1][0] = dr[0].ToString();
                data[data.Count - 1][1] = dr[1].ToString();
                data[data.Count - 1][2] = dr[2].ToString();
                data[data.Count - 1][3] = dr[3].ToString();
                data[data.Count - 1][4] = dr[4].ToString();
          //      data[data.Count - 1][5] = dr[5].ToString();
            }
            dr.Close();
            con.Close();
            foreach (string[] s in data)
                dataGridClient.Rows.Add(s);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите завершить работу с программой?", "Закрыть программу?", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            databaseRefresh("SELECT * FROM [Clients] WHERE [fioClient] LIKE '%" + searchBox.Text + "%'");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddClients clients = new AddClients();
            clients.windowMode = "Добавить";
            clients.ShowDialog();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            AddClients clients = new AddClients();
            clients.windowMode = "Изменить";
            clients.userID = Convert.ToInt32(dataGridClient[0, dataGridClient.CurrentRow.Index].Value);
            clients.fioBox.Text = Convert.ToString(dataGridClient[1, dataGridClient.CurrentRow.Index].Value);
            clients.telBox.Text = Convert.ToString(dataGridClient[2, dataGridClient.CurrentRow.Index].Value);
            clients.cityBox.Text = Convert.ToString(dataGridClient[3, dataGridClient.CurrentRow.Index].Value);
            clients.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            delcheck = false;
            DialogResult result;
            result = MessageBox.Show("Вы действительно хотите безвозвратно удалить данные о клиенте?", "Удалить данные о клиенте?", MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                delcheck = false;
                con.Open();
                String strings = "DELETE FROM [Clients] WHERE [idClient] = " + Convert.ToString(dataGridClient[0, dataGridClient.CurrentRow.Index].Value);
                cmd = new OleDbCommand(strings, con);
                OleDbDataReader dr = cmd.ExecuteReader();
                dr.Close();
                con.Close();
                databaseRefresh("SELECT * FROM [Clients] WHERE [idClient] LIKE '%" + searchBox.Text + "%'");
                MessageBox.Show("Данные клиента успешно удалены из базы!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            delcheck = true;
        }

        private void dataGridClient_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DocumentsWork documentsWork = new DocumentsWork();
            documentsWork.clientID = dataGridClient[0, dataGridClient.CurrentRow.Index].Value.ToString();
            documentsWork.ShowDialog();
        }

        private void Clients_Load(object sender, EventArgs e)
        {
        }
    }
}
