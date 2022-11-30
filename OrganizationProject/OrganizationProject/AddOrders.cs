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

    public partial class AddOrders : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Resources/BD.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();
        List<string[]> saveLocale = new List<string[]>();
        public string windowMode;
        public string orderID;
        public int summa = 0;
        public int clientID;
        public bool delOn = true;

        /*
         -------------------------ИНТЕРФЕЙС. CОБЫТИЯ-------------------------
         */

        public AddOrders()
        {
            InitializeComponent();
        }

        private void Orders_Load(object sender, EventArgs e)
        {
            outputUsers();
            loadingInformation();
        }

        private void loadingInformation()
        {
            numOrders.Text = "Заказ № " + orderID;
            sum.Text = Convert.ToString(summa);
        }

        private void outputUsers()
        {
            CBClient.Items.Clear();
            con.Open();
            string stringBD = "";
            OleDbDataReader dr = null;
            stringBD = "SELECT * FROM Clients";
            cmd = new OleDbCommand(stringBD, con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
                CBClient.Items.Add(dr[1]);
            }
            comboBox1.SelectedIndex = 0;
            CBClient.SelectedIndex = 0;
            dr.Close();
            con.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (windowMode == "Добавить")
            {
                saveOrders();
                this.Close();
            }
            else 
            {
                updateOrders();
                this.Close();
            }
        }

        private void updateOrders()
        {
            con.Open();
            string stringBD = "";
            OleDbDataReader dr = null;
            DateTime thisDay = DateTime.Now;
            stringBD = "UPDATE [Orders] SET [ClientsID] = '" + comboBox1.Items[CBClient.SelectedIndex] + "', [ClientsName] = '" + CBClient.Items[CBClient.SelectedIndex] + "', [CheckAmount] = '" + sum.Text + "', [OrdersData] = '" + thisDay + "', [OrdersLocate] = '" + locate.Text + "' WHERE [OrdersID] = " + orderID;
            cmd = new OleDbCommand(stringBD, con);
            dr = cmd.ExecuteReader();
            dr.Close();
            con.Close();
        }

        private void saveOrders()
        {
            con.Open();
            string stringBD = "";
            OleDbDataReader dr = null;
            DateTime thisDay = DateTime.Now;
            stringBD = "INSERT INTO [Orders] ([ClientsID], [ClientsName], [CheckAmount], [OrdersData], [OrdersLocate]) VALUES('" + comboBox1.Items[CBClient.SelectedIndex] + "', '" + CBClient.Items[CBClient.SelectedIndex] + "', '" + sum.Text + "', '" + thisDay + "', '" + locate.Text + "')"; ;            cmd = new OleDbCommand(stringBD, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            dr.Close();
            con.Close();
        }
        private void CBClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Form.ActiveForm == this)
            {
                DialogResult result = MessageBox.Show("Вы хотите подставить адрес из базы данных?", "Добавить адрес?", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                con.Open();
                string stringBD = "SELECT * FROM [Clients] WHERE [fioClient] LIKE '%" + CBClient.Items[CBClient.SelectedIndex] + "%'";
                cmd = new OleDbCommand(stringBD, con);
                OleDbDataReader dr = cmd.ExecuteReader();
                saveLocale.Clear();
                while (dr.Read())
                {
                    if (result == DialogResult.Yes)
                    {
                        locate.Text = dr[3].ToString();
                    }
                    clientID = Convert.ToInt32(dr[0]);
                }
                dr.Close();
                con.Close();
            }
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            databaseRefresh("SELECT * FROM [ServicesList] WHERE [OrdersID] LIKE '%" + orderID + "%' and [Services] Like '%" + searchBox.Text + "%'");
        }

        private void Orders_Activated(object sender, EventArgs e)
        {
            if (delOn) updateDateTable();
            sum.Text = calcSumm();


        }

        private string calcSumm()
        {
            con.Open();
            String strings = "SELECT * FROM [ServicesList] WHERE [OrdersID] LIKE '%" + orderID + "%'";
            cmd = new OleDbCommand(strings, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            int calc = 0;
            while (dr.Read()) { calc += Convert.ToInt32(dr[5]); }
            dr.Close();
            con.Close();
            return Convert.ToString(calc);
        }

        private void updateDateTable()
        {
            databaseRefresh("SELECT * FROM [ServicesList] WHERE [OrdersID] LIKE '%" + orderID + "%'");
        }

        public void databaseRefresh(string stringBD) // обновление отображаемой информации в таблице
        {
            dataGridOrdersList.Rows.Clear();
            con.Open();
            cmd = new OleDbCommand(stringBD, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            List<string[]> data = new List<string[]>();
            summa = 0;
            while (dr.Read())
            {
                int countColum = dataGridOrdersList.ColumnCount;
                data.Add(new string[countColum]);
                data[data.Count - 1][0] = dr[0].ToString();
                data[data.Count - 1][1] = dr[1].ToString();
                data[data.Count - 1][2] = dr[2].ToString();
                data[data.Count - 1][3] = dr[3].ToString();
                data[data.Count - 1][4] = dr[4].ToString();
                data[data.Count - 1][5] = dr[5].ToString();
                summa = summa + Convert.ToInt32(dr[5]);
            }
            foreach (string[] s in data)
                dataGridOrdersList.Rows.Add(s);
            dr.Close();
            con.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            delOn = false;
            delIndataTable();
            databaseRefresh("SELECT * FROM [ServicesList] WHERE [OrdersID] LIKE '%" + orderID + "%' and [Services] Like '%" + searchBox.Text + "%'");
            delOn = true;
        }

        private void delIndataTable()
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите безвозвратно удалить данные об услуге в заказе?", "Удалить данные об услуге в  заказе?", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                if (sum.Text != "0")
                {
                    con.Open();
                    String strings = "DELETE FROM [ServicesList] WHERE [ServicesListID] = " + dataGridOrdersList[0, dataGridOrdersList.CurrentRow.Index].Value.ToString();
                    cmd = new OleDbCommand(strings, con);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    dr.Close();
                    con.Close();
                    MessageBox.Show("Данные об услуге успешно удалены из базы!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddServicesList servicesList = new AddServicesList();
            servicesList.windowMode = "Добавить";
            servicesList.ordersID = orderID;
            servicesList.ShowDialog();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                AddServicesList servicesList = new AddServicesList();
                servicesList.windowMode = "Изменить";
                servicesList.ordersID = orderID;
                servicesList.ServicesListID = Convert.ToInt32(dataGridOrdersList[0, dataGridOrdersList.CurrentRow.Index].Value);
                servicesList.BoxCount.Text = Convert.ToString(dataGridOrdersList[4, dataGridOrdersList.CurrentRow.Index].Value);
                servicesList.label3.Text = Convert.ToString(dataGridOrdersList[5, dataGridOrdersList.CurrentRow.Index].Value);
                servicesList.servicesName = Convert.ToString(dataGridOrdersList[3, dataGridOrdersList.CurrentRow.Index].Value);
                servicesList.servicesName = Convert.ToString(dataGridOrdersList[3, dataGridOrdersList.CurrentRow.Index].Value);
                servicesList.ShowDialog();
            }
            catch (Exception ex) { 

            }
        }
    }
}
