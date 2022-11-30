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
    public partial class Services : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Resources/BD.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();
        private bool delcheck = true;

        public Services()
        {
            InitializeComponent();

            searchBox.Text = "";
            databaseRefresh("SELECT * FROM [Services] WHERE [ServicesName] LIKE '%" + searchBox.Text + "%'");
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
        public void databaseRefresh(string stringBD) // обновление отображаемой информации в таблице
        {
            dataGridServices.Rows.Clear();
            con.Open();
            cmd = new OleDbCommand(stringBD, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (dr.Read())
            {
                int countColum = dataGridServices.ColumnCount;
                data.Add(new string[countColum]);
                data[data.Count - 1][0] = dr[0].ToString();
                data[data.Count - 1][1] = dr[1].ToString();
                data[data.Count - 1][2] = dr[2].ToString();
                data[data.Count - 1][3] = dr[3].ToString();
                data[data.Count - 1][4] = dr[4].ToString();
           //     data[data.Count - 1][5] = dr[5].ToString();
            }
            dr.Close();
            con.Close();
            foreach (string[] s in data)
                dataGridServices.Rows.Add(s);

        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            databaseRefresh("SELECT * FROM [Services] WHERE [ServicesName] LIKE '%" + searchBox.Text + "%'");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddServices services = new AddServices();
            services.windowMode = "Добавить";
            services.ShowDialog();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            AddServices services = new AddServices();
            services.windowMode = "Изменить";
            services.servicesID = Convert.ToInt32(dataGridServices[0, dataGridServices.CurrentRow.Index].Value);
            services.nameBox.Text = Convert.ToString(dataGridServices[1, dataGridServices.CurrentRow.Index].Value);
            services.timeBox.Text = Convert.ToString(dataGridServices[2, dataGridServices.CurrentRow.Index].Value);
            services.priceBox.Text = Convert.ToString(dataGridServices[3, dataGridServices.CurrentRow.Index].Value);
            services.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            delcheck = false;
            DialogResult result;
            result = MessageBox.Show("Вы действительно хотите безвозвратно удалить данную услугу?", "Удалить данные об услуге?", MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                delcheck = false;
                con.Open();
                String strings = "DELETE FROM [Services] WHERE [ServicesId] = " + dataGridServices[0, dataGridServices.CurrentRow.Index].Value;

                cmd = new OleDbCommand(strings, con);
                OleDbDataReader dr = cmd.ExecuteReader();
                dr.Close();
                con.Close();
                databaseRefresh("SELECT * FROM [Services] WHERE [ServicesID] LIKE '%" + searchBox.Text + "%'");
                MessageBox.Show("Данная услуга успешно удалена из базы!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            delcheck = true;
        }
    }
}
