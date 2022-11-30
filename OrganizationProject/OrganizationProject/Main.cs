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
    public partial class Main : Form
    {
        public string userPosition;
        public string windowMode;
        private Form currentChildForm;

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Resources/BD.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        /*
         -------------------------ИНТЕРФЕЙС. CОБЫТИЯ-------------------------
         */

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e) // загрузка окна
        {
            windowMode = "Заказы";
            Orders Orders = new Orders();
            OpenChildForm(Orders);

            
            if (label1.Text != "Администратор")
            {
                regBut.Visible = false;
            }
            pnlNav.Height = btnOrders.Height;
            pnlNav.Top = btnOrders.Top;
            pnlNav.Left = btnOrders.Left;
            btnOrders.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void buttonLeave(object sender, EventArgs e) // Убрать курсор с кнопки
        {
            switch (windowMode)
            {
                case "Заказы":
                    btnOrders.BackColor = Color.FromArgb(24, 30, 54);
                    break;
                case "Услуги":
                    btnServices.BackColor = Color.FromArgb(24, 30, 54);
                    break;
                case "Клиенты":
                    btnClients.BackColor = Color.FromArgb(24, 30, 54);
                    break;
            }
        }

        public void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            PanelManagement.Controls.Add(childForm);
            PanelManagement.Tag = childForm;
            PanelManagement.BringToFront();
            childForm.Show();
        }

        private void btnOrdersClick(object sender, EventArgs e) // клик по кнопке "Заказы"
        {
            windowMode = "Заказы";
            Orders Orders = new Orders();
            Orders.updateStatus();
            OpenChildForm(Orders);
            pnlNav.Height = btnOrders.Height;
            pnlNav.Top = btnOrders.Top;
            pnlNav.Left = btnOrders.Left;
            btnOrders.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnServicesClick(object sender, EventArgs e) // клик по кнопке "Услуги"
        {
            windowMode = "Услуги";
            Services Services = new Services();
            Orders Orders = new Orders();
            Orders.updateStatus();
            OpenChildForm(Services);

            pnlNav.Height = btnServices.Height;
            pnlNav.Top = btnServices.Top;
            pnlNav.Left = btnServices.Left;
            btnServices.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnClientsCkick(object sender, EventArgs e) // клик по кнопке "Клиенты"
        {
            windowMode = "Клиенты";
            Clients Clients = new Clients();
            Orders Orders = new Orders();
            Orders.updateStatus();
            OpenChildForm(Clients);

            pnlNav.Height = btnClients.Height;
            pnlNav.Top = btnClients.Top;
            pnlNav.Left = btnClients.Left;
            btnClients.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnClickInformation(object sender, EventArgs e) // открытие окна с информацией
        {
            System.Diagnostics.Process.Start(@"Resources\Help.chm");
        }

        private void Main_Activated(object sender, EventArgs e)
        {

        }

        private void regBut_Click(object sender, EventArgs e)
        {
            Registration reg = new Registration();
            reg.ShowDialog();
        }
    }
}