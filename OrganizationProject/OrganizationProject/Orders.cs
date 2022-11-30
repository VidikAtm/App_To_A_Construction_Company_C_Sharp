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
    public partial class Orders : Form
    {

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Resources/BD.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();
        public string ordersID;
        private bool delcheck = true;
        private int editsStatus;

        public Orders()
        {
            InitializeComponent();

            searchBox.Text = "";
            databaseRefresh("SELECT * FROM [Orders] WHERE [OrdersID] LIKE '%" + searchBox.Text + "%'");
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            databaseRefresh("SELECT * FROM [Orders] WHERE [OrdersID] LIKE '%" + searchBox.Text + "%'");
        }

        public void databaseRefresh(string stringBD) // обновление отображаемой информации в таблице
        {
            dataGridOrders.Rows.Clear();
            con.Open();
            cmd = new OleDbCommand(stringBD, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (dr.Read())
            {
                int countColum = dataGridOrders.ColumnCount;
                data.Add(new string[countColum]);
                data[data.Count - 1][0] = dr[0].ToString();
                data[data.Count - 1][1] = dr[1].ToString();
                data[data.Count - 1][2] = dr[2].ToString();
                data[data.Count - 1][3] = dr[3].ToString();
                data[data.Count - 1][4] = dr[4].ToString();
                data[data.Count - 1][5] = dr[5].ToString();
                data[data.Count - 1][6] = dr[6].ToString();
            }
            dr.Close();
            con.Close();
            foreach (string[] s in data)
            dataGridOrders.Rows.Add(s);
        }

        private int CalcID()
        {
            con.Open();
            string stringBD = "SELECT * FROM [Orders]";
            cmd = new OleDbCommand(stringBD, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            int calckID = 0;
            while (dr.Read())
            {
                calckID++;
            }
            dr.Close();
            con.Close();
            return calckID;
        }

        private string defineLastLine()
        {
            con.Open();
            string stringBD = "";
            OleDbDataReader dr = null;
            stringBD = "SELECT * FROM Orders where OrdersID = (select max(OrdersID) from Orders)";
            cmd = new OleDbCommand(stringBD, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            ordersID = Convert.ToString(Convert.ToInt32(dr[0]) + 1);
            dr.Close();
            con.Close();
            return ordersID;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddOrders order = new AddOrders();
            order.windowMode = "Добавить";
            order.orderID = defineLastLine(); // узнаем максимальный id в таблице Orders
            order.ShowDialog();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            AddOrders orders = new AddOrders();
            orders.windowMode = "Изменить";
            orders.orderID = Convert.ToString(dataGridOrders[0, dataGridOrders.CurrentRow.Index].Value);
            orders.numOrders.Text = "Номер заказа: " + Convert.ToString(dataGridOrders[1, dataGridOrders.CurrentRow.Index].Value);
            orders.sum.Text = Convert.ToString(dataGridOrders[3, dataGridOrders.CurrentRow.Index].Value) + " Руб.";
            orders.locate.Text = Convert.ToString(dataGridOrders[5, dataGridOrders.CurrentRow.Index].Value);
            orders.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            delcheck = false;
            DialogResult result;
            result = MessageBox.Show("Вы действительно хотите безвозвратно удалить данные о заказе?", "Удалить данные о заказе?", MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                con.Open();
                String strings = "DELETE FROM [Orders] WHERE [OrdersID] = " + dataGridOrders[0, dataGridOrders.CurrentRow.Index].Value.ToString();
                cmd = new OleDbCommand(strings, con);
                OleDbDataReader dr = cmd.ExecuteReader();
                dr.Close();
                con.Close();
                databaseRefresh("SELECT * FROM [Orders] WHERE [OrdersID] LIKE '%" + searchBox.Text + "%'");
                MessageBox.Show("Данные заказа успешно удалены из базы!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            delcheck = true;
        }

        private void dataGridOrders_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            updateStatus();
        }

        public void updateStatus()
        {
            if (editsStatus == 1)
            {
                con.Open();
                string commands = "UPDATE [Orders] SET [OrdersStatus] = '" + dataGridOrders[6, dataGridOrders.CurrentRow.Index].Value + "' WHERE [OrdersID] = " + dataGridOrders[0, dataGridOrders.CurrentRow.Index].Value;
                cmd = new OleDbCommand(commands, con);
                OleDbDataReader dr = cmd.ExecuteReader();
                dr.Close();
                con.Close();
                editsStatus = 0;
            }
        }

        private void dataGridOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            editsStatus = 1;
        }

        private void Orders_Load(object sender, EventArgs e)
        {
        }
    }
}
