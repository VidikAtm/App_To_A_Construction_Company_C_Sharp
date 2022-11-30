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
    public partial class AddServicesList : Form
    {
        public string windowMode;
        public string ordersID;
        public int ServicesListID;
        public string servicesName;
        public string servisId;

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Resources/BD.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        /*
         -------------------------ИНТЕРФЕЙС. CОБЫТИЯ-------------------------
         */

        public AddServicesList()
        {
            InitializeComponent();
        }

        private void ServicesList_Load(object sender, EventArgs e)
        {
            int vountServiceName = -1;
            int step = -1;
            dataGridServices.Rows.Clear();
            CBServicesList.Items.Clear();
            con.Open();
            cmd = new OleDbCommand("SELECT * FROM [Services] WHERE [ServicesName]", con);
            OleDbDataReader dr = cmd.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (dr.Read())
            {
                step++;
                int countColum = dataGridServices.ColumnCount;
                data.Add(new string[countColum]);
                data[data.Count - 1][0] = dr[0].ToString();
                data[data.Count - 1][1] = dr[1].ToString();
                data[data.Count - 1][2] = dr[2].ToString();
                data[data.Count - 1][3] = dr[3].ToString();
                data[data.Count - 1][4] = dr[4].ToString();
                CBServicesList.Items.Add(dr[1].ToString());
                if (servicesName == dr[1].ToString())
                {
                    vountServiceName = step;
                }
            }
            dr.Close();
            con.Close();
            foreach (string[] s in data)
                dataGridServices.Rows.Add(s);
            if (CBServicesList.SelectedIndex < 0) CBServicesList.SelectedIndex = 0;
            if (vountServiceName == -1) CBServicesList.SelectedIndex = 0; else CBServicesList.SelectedIndex = vountServiceName;
            refreshFieldValues();

        }

        private void btnClickCancel(object sender, EventArgs e) // Отменить добавление
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите отменить добавление услуги?", "Отменить добавление?", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnClickSave(object sender, EventArgs e) // Сохранить/Изменить
        {
            if ((BoxCount.Text != "") && (CBServicesList.SelectedIndex != -1))
            {
                switch (windowMode)
                {
                    case "Добавить":
                        addInfoServicesList();
                        this.Close();
                        break;
                    case "Изменить":
                        editInfoServicesList();
                        this.Close();
                        break;
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Вы заполнили не все поля, для сохранения/изменения данных, необходимо заполнить все поля!", "Внимание!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void BoxCount_KeyPress(object sender, KeyPressEventArgs e) // Запрет ввода букв
        {
            if (!Char.IsDigit(e.KeyChar) && (e.KeyChar != 8))
                e.Handled = true;
        }
        private void BoxCount_Leave(object sender, EventArgs e) // проверка чтобы в колличестве не было 0
        {
            if (BoxCount.Text == "") BoxCount.Text = "1";
        }

        private void BoxCountChanged(object sender, EventArgs e) // обработка изменений колличества
        {
            if ((Form.ActiveForm == this) && (BoxCount.Text != ""))
            {
                refreshFieldValues();
            }
        }

        /*
         -------------------------Работа с данными-------------------------
         */

        private void addInfoServicesList()
        {
            con.Open();
            string commands = "INSERT INTO [ServicesList]([OrdersID], [ServicesID], [Services], [Count],[sum]) VALUES('" + ordersID + "', '" +  Convert.ToString(dataGridServices[0, dataGridServices.CurrentRow.Index].Value) + "', '" + CBServicesList.Items[CBServicesList.SelectedIndex] + "', '" + BoxCount.Text + "', '" + label3.Text + "')";
            cmd = new OleDbCommand(commands, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            dr.Close();
            con.Close();
        }

        private void editInfoServicesList()
        {
            con.Open();
            string commands = "UPDATE [ServicesList] SET[OrdersID] = '" + ordersID + "', [ServicesID] = '" + servisId + "', [Services] = '" + CBServicesList.Items[CBServicesList.SelectedIndex] + "', [Count] = '" + BoxCount.Text + "', [sum] = '" + label3.Text + "' WHERE [ServicesListID] = " + ServicesListID;
            cmd = new OleDbCommand(commands, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            dr.Close();
            con.Close();
        }

        private void refreshFieldValues() // обновить поля в зависимотси от выбранной услуги
        {
            dataGridServices.Rows.Clear();
            con.Open();
            cmd = new OleDbCommand("SELECT * FROM [Services] WHERE [ServicesName]", con);
            OleDbDataReader dr = cmd.ExecuteReader();
            List<string[]> data = new List<string[]>();
            dr.Read();
            label3.Text = Convert.ToString(Convert.ToInt32(BoxCount.Text) * Convert.ToInt32(dr[3].ToString()));
            servisId = Convert.ToString(dr[0]);
            dr.Close();
            con.Close();

            dataGridServices.Rows.Clear();
            con.Open();
            cmd = new OleDbCommand("SELECT * FROM [Services] WHERE [ServicesName]", con);
            dr = cmd.ExecuteReader();
            data = new List<string[]>();
            while (dr.Read())
            {
                int countColum = dataGridServices.ColumnCount;
                data.Add(new string[countColum]);
                data[data.Count - 1][0] = dr[0].ToString();
                data[data.Count - 1][1] = dr[1].ToString();
                data[data.Count - 1][2] = dr[2].ToString();
                data[data.Count - 1][3] = dr[3].ToString();
                data[data.Count - 1][4] = dr[4].ToString();
            }
            dr.Close();
            con.Close();
            foreach (string[] s in data)
                dataGridServices.Rows.Add(s);
        }

        private void CBServicesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshFieldValues();
        }
    }
}
