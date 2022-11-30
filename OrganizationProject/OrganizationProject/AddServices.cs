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
    public partial class AddServices : Form
    {
        public string windowMode;
        public int servicesID;
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Resources/BD.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();
        
        public AddServices()
        {
            InitializeComponent();
        }

        /*
         -------------------------ИНТЕРФЕЙС. CОБЫТИЯ-------------------------
         */

        private void btnClickCencel(object sender, EventArgs e) // отменить добавление
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите отменить добавление услуги?", "Отменить добавление?", MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnClickSave(object sender, EventArgs e) // Сохранить-Изменить запись
        {
            Clients Clients = new Clients();
            if ((nameBox.Text != "") && (timeBox.Text != "") && (priceBox.Text != ""))
            {
                switch (windowMode)
                {
                    case "Добавить":
                        addInfoServices();
                        Clients.databaseRefresh("SELECT * FROM [Clients]");
                        Clients.searchBox.Text = "";
                        this.Close();
                        break;
                    case "Изменить":
                        editInfoServices();
                        Clients.databaseRefresh("SELECT * FROM [Clients]");
                        Clients.searchBox.Text = "";
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

        /*
         -------------------------Работа с данными-------------------------
         */

        private void addInfoServices() // Добавить запись в БД
        {
            con.Open();
            string commands = "INSERT INTO [Services]([ServicesName], [ServicesTime], [ServicesPrice], [ServicesTimeUp]) VALUES('" + nameBox.Text + "', '" + timeBox.Text + "', '" + priceBox.Text + "', '" + DateTime.Now + "')";
            cmd = new OleDbCommand(commands, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            dr.Close();
            con.Close();
        }

        private void editInfoServices()
        {
            con.Open();
            string datetime = DateTime.Now.ToString();
            string commands = "UPDATE [Services] SET [ServicesName] = '" + nameBox.Text + "', [ServicesTime] = '" + timeBox.Text + "', [ServicesPrice] = '" + priceBox.Text + "', [ServicesTimeUp] = '" + datetime + "' WHERE [ServicesId] = " + servicesID;
            cmd = new OleDbCommand(commands, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            dr.Close();
            con.Close();
        }

        private void timeBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && (e.KeyChar != 8))
                e.Handled = true;
        }

        private void Services_Load(object sender, EventArgs e)
        {
            label4.Text = "Заказ: ";
        }
    }
}
