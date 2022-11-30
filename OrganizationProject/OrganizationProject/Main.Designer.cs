namespace OrganizationProject
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panel1 = new System.Windows.Forms.Panel();
            this.regBut = new System.Windows.Forms.Button();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.btnInformation = new System.Windows.Forms.Button();
            this.btnClients = new System.Windows.Forms.Button();
            this.btnServices = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PanelManagement = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.regBut);
            this.panel1.Controls.Add(this.pnlNav);
            this.panel1.Controls.Add(this.btnInformation);
            this.panel1.Controls.Add(this.btnClients);
            this.panel1.Controls.Add(this.btnServices);
            this.panel1.Controls.Add(this.btnOrders);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 548);
            this.panel1.TabIndex = 1;
            // 
            // regBut
            // 
            this.regBut.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.regBut.FlatAppearance.BorderSize = 0;
            this.regBut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.regBut.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regBut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.regBut.Image = global::OrganizationProject.Properties.Resources.Conact;
            this.regBut.Location = new System.Drawing.Point(0, 464);
            this.regBut.Name = "regBut";
            this.regBut.Size = new System.Drawing.Size(186, 42);
            this.regBut.TabIndex = 3;
            this.regBut.Text = "Добавить сотрудника";
            this.regBut.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.regBut.UseVisualStyleBackColor = true;
            this.regBut.Click += new System.EventHandler(this.regBut_Click);
            // 
            // pnlNav
            // 
            this.pnlNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.pnlNav.Location = new System.Drawing.Point(0, 193);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(3, 100);
            this.pnlNav.TabIndex = 2;
            // 
            // btnInformation
            // 
            this.btnInformation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnInformation.FlatAppearance.BorderSize = 0;
            this.btnInformation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInformation.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInformation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnInformation.Image = global::OrganizationProject.Properties.Resources.inform;
            this.btnInformation.Location = new System.Drawing.Point(0, 506);
            this.btnInformation.Name = "btnInformation";
            this.btnInformation.Size = new System.Drawing.Size(186, 42);
            this.btnInformation.TabIndex = 1;
            this.btnInformation.Text = "Справка";
            this.btnInformation.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnInformation.UseVisualStyleBackColor = true;
            this.btnInformation.Click += new System.EventHandler(this.btnClickInformation);
            this.btnInformation.Leave += new System.EventHandler(this.buttonLeave);
            // 
            // btnClients
            // 
            this.btnClients.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClients.FlatAppearance.BorderSize = 0;
            this.btnClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClients.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClients.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnClients.Image = global::OrganizationProject.Properties.Resources.Conact;
            this.btnClients.Location = new System.Drawing.Point(0, 238);
            this.btnClients.Name = "btnClients";
            this.btnClients.Size = new System.Drawing.Size(186, 42);
            this.btnClients.TabIndex = 1;
            this.btnClients.Text = "Клиенты";
            this.btnClients.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnClients.UseVisualStyleBackColor = true;
            this.btnClients.Click += new System.EventHandler(this.btnClientsCkick);
            this.btnClients.Leave += new System.EventHandler(this.buttonLeave);
            // 
            // btnServices
            // 
            this.btnServices.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnServices.FlatAppearance.BorderSize = 0;
            this.btnServices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServices.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnServices.Image = global::OrganizationProject.Properties.Resources.service;
            this.btnServices.Location = new System.Drawing.Point(0, 196);
            this.btnServices.Name = "btnServices";
            this.btnServices.Size = new System.Drawing.Size(186, 42);
            this.btnServices.TabIndex = 1;
            this.btnServices.Text = "Услуги";
            this.btnServices.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnServices.UseVisualStyleBackColor = true;
            this.btnServices.Click += new System.EventHandler(this.btnServicesClick);
            this.btnServices.Leave += new System.EventHandler(this.buttonLeave);
            // 
            // btnOrders
            // 
            this.btnOrders.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOrders.FlatAppearance.BorderSize = 0;
            this.btnOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrders.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnOrders.Image = global::OrganizationProject.Properties.Resources.orders1;
            this.btnOrders.Location = new System.Drawing.Point(0, 154);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(186, 42);
            this.btnOrders.TabIndex = 1;
            this.btnOrders.Text = "Заказы";
            this.btnOrders.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnOrders.UseVisualStyleBackColor = true;
            this.btnOrders.Click += new System.EventHandler(this.btnOrdersClick);
            this.btnOrders.Leave += new System.EventHandler(this.buttonLeave);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(186, 154);
            this.panel2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label2.Location = new System.Drawing.Point(22, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "ИП Артем Серебров";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label1.Location = new System.Drawing.Point(22, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "ЭлитРем";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::OrganizationProject.Properties.Resources.avatar;
            this.pictureBox1.Image = global::OrganizationProject.Properties.Resources.avatar;
            this.pictureBox1.Location = new System.Drawing.Point(22, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // PanelManagement
            // 
            this.PanelManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.PanelManagement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelManagement.Location = new System.Drawing.Point(186, 0);
            this.PanelManagement.Margin = new System.Windows.Forms.Padding(3, 23, 3, 3);
            this.PanelManagement.Name = "PanelManagement";
            this.PanelManagement.Size = new System.Drawing.Size(733, 548);
            this.PanelManagement.TabIndex = 39;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(919, 548);
            this.Controls.Add(this.PanelManagement);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Opacity = 0.97D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главное окно";
            this.Activated += new System.EventHandler(this.Main_Activated);
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlNav;
        private System.Windows.Forms.Button btnInformation;
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Button btnServices;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel PanelManagement;
        private System.Windows.Forms.Button regBut;
    }
}

