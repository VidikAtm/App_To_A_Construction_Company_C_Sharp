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
    public partial class AddClients : Form
    {
        public string windowMode;
        public int userID;

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Resources/BD.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        public AddClients()
        {
            InitializeComponent();
        }


        /*
         -------------------------ИНТЕРФЕЙС. CОБЫТИЯ-------------------------
         */

        private void Clients_Load(object sender, EventArgs e) // загрузка окна
        {
            switch (windowMode)
            {
                case "Добавить":

                    break;
                case "Изменить":

                    break;
            }
        }

        private void btnClickCancel(object sender, EventArgs e) // отменить добавление
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите отменить добавление клиента?", "Отменить добавление?", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnClickSave(object sender, EventArgs e) // Сохранить-Изменить запись
        {
            if ((fioBox.Text != "") && (telBox.Text != "") && (cityBox.Text != "") && (dateTime.Value != null))
            {
                switch (windowMode)
                {
                    case "Добавить":
                        addInfoClients();
                        addWorksDoc();
                        this.Close();
                        break;
                    case "Изменить":
                        editInfoClients();
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

        private void addWorksDoc() 
        {
            int clientID;
            con.Open();
            string commands = "SELECT * FROM [Clients] ORDER BY [idClient] DESC";
            cmd = new OleDbCommand(commands, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            dr.Read();
            clientID =  Convert.ToInt32(dr["idClient"].ToString());

            commands = "INSERT INTO [WorkDocuments]([id_documents], [id_Clients], [name_docements], [status]) VALUES ('1', '" + clientID + "', 'Свидетельство', " + false + ")";
            cmd = new OleDbCommand(commands, con);
            dr = cmd.ExecuteReader();
            commands = "INSERT INTO [WorkDocuments]([id_documents], [id_Clients], [name_docements], [status]) VALUES ('2', '" + clientID + "', 'Проект помещения', " + false + ")";
            cmd = new OleDbCommand(commands, con);
            dr = cmd.ExecuteReader();
            commands = "INSERT INTO [WorkDocuments]([id_documents], [id_Clients], [name_docements], [status]) VALUES ('3', '" + clientID + "', 'Тех. паспорт объекта', " + false + ")";
            cmd = new OleDbCommand(commands, con);
            dr = cmd.ExecuteReader();
            commands = "INSERT INTO [WorkDocuments]([id_documents], [id_Clients], [name_docements], [status]) VALUES ('4', '" + clientID + "', 'План объекта', " + false + ")";
            cmd = new OleDbCommand(commands, con);
            dr = cmd.ExecuteReader();
            commands = "INSERT INTO [WorkDocuments]([id_documents], [id_Clients], [name_docements], [status]) VALUES ('5', '" + clientID + "', 'Согласие собственников', " + false + ")";
            cmd = new OleDbCommand(commands, con);
            dr = cmd.ExecuteReader();
            commands = "INSERT INTO [WorkDocuments]([id_documents], [id_Clients], [name_docements], [status]) VALUES ('6', '" + clientID + "', 'Кадастровый паспорт', " + false + ");";
            cmd = new OleDbCommand(commands, con);
            dr = cmd.ExecuteReader();
            commands = "INSERT INTO [WorkDocuments]([id_documents], [id_Clients], [name_docements], [status]) VALUES ('7', '" + clientID + "', 'Разрешение администрации', " + false + ");";
            cmd = new OleDbCommand(commands, con);
            dr = cmd.ExecuteReader();
            dr.Close();
            con.Close();
        }

        private void addInfoClients() // Добавить запись в БД
        {
            con.Open();
            string commands = "INSERT INTO [Clients]([fioClient], [phoneNumber], [address], [dateApplication]) VALUES('" + fioBox.Text + "', '" + telBox.Text + "', '" + cityBox.Text + "', '" + dateTime.Value + "')";
            cmd = new OleDbCommand(commands, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            dr.Close();
            con.Close();
        }

        private void editInfoClients()
        {
            con.Open();
            string commands = "UPDATE [Clients] SET [fioClient] = '" + fioBox.Text + "', [phoneNumber] = '" + telBox.Text + "', [address] = '" + cityBox.Text + "', [dateApplication] = '" + dateTime.Value + "' WHERE [idClient] = " + userID;
            cmd = new OleDbCommand(commands, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            dr.Close();
            con.Close();
        }

        private void Clients_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
