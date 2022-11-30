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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Resources/BD.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void btnCencel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите отменить добавление Нового сотрудника?", "Отменить добавление?", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String nameuser = nameBox.Text;
            String Surname = surname.Text;
            String Telef = telef.Text;
            String Email = email.Text;
            String loginUser = login.Text;
            String Password = password.Text;
            String Password2 = password2.Text;

            if ((nameuser != "") && (Surname != "") && (Position.SelectedIndex != -1) && (Telef != "") && (loginUser != "") && (Password != "") && (Password2 != ""))
            {
                if (Password == Password2)
                {
                    con.Open();
                    string login = "SELECT * FROM [user] WHERE [surname]='" + loginUser + "'";
                    cmd = new OleDbCommand(login, con);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    if (dr.Read() == false)
                    {
                        string register = "INSERT INTO [user]([nameuser], [surname], [position], [telef], [email], [login], [password]) VALUES('" + nameuser + "', '" + Surname + "', '" + Position.Items[Position.SelectedIndex] + "', '" + Telef + "', '" + Email + "', '" + loginUser + "', '" + Password + "')";
                        cmd = new OleDbCommand(register, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Регистрация прошла успешно!", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        string save = "SELECT * FROM [user] WHERE [login]='" + loginUser + "' and [password]='" + Password + "'";
                        cmd = new OleDbCommand(save, con);
                        OleDbDataReader sv = cmd.ExecuteReader();

                        sv.Read();
                        Main main = new Main();
                        main.Show();
                        main.label1.Text = Convert.ToString(Position.Items[Position.SelectedIndex]);
                        main.label2.Text = Surname + " " + nameuser;
                        con.Close();
                        main.Show();
                        Hide();
                    }
                    else
                    {
                        con.Close();
                        MessageBox.Show("Такой логин уже существует!", "Логин занят!", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Пароли не совпадают! Попробуйте ввести пароль еще раз!", "Пароли не совпадают!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    password2.Text = "";
                }
            }
            else 
            {
                MessageBox.Show("Вы заполнили не все поля!", "Вы забыли ввести данные!", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
    }
}
