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
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Resources/BD.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((loginUser.Text != "") && (password.Text != ""))
            {
                con.Open();
                string login = "SELECT * FROM [user] WHERE [login]='" + loginUser.Text + "' and [password]='" + password.Text + "'";
                cmd = new OleDbCommand(login, con);
                OleDbDataReader dr = cmd.ExecuteReader();

                if (dr.Read() == true)
                {
                    Main main = new Main();
                    main.label1.Text = Convert.ToString(dr["position"]);
                    main.label2.Text = Convert.ToString(dr["surname"]) + " " + Convert.ToString(dr["nameuser"]);
                    main.Show();
                    Hide();

                }
                else
                {
                    password.Text = "";
                    MessageBox.Show("Такого пользователя не существует или были не правильно заполнены поля ФИО и/или пароль!", "Ошибка в авторизации!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Вы забыли заполнить поле для ввода ФИО и/или пароль!", "Вы забыли ввести данные!", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void btnCencel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите завершить работу с программой?", "Закрыть программу?", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
