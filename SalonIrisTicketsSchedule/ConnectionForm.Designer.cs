

namespace SalonIrisTicketsSchedule
{
    partial class ConnectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionForm));
            this.SaveAndConnectButton = new System.Windows.Forms.Button();
            this.ServerNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DatabaseTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CompanyTextBox = new System.Windows.Forms.TextBox();
            this.CycleTimer = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.DBUserTextBox = new System.Windows.Forms.TextBox();
            this.DBPasswordTextBox = new System.Windows.Forms.TextBox();
            this.SSPICheckBox = new System.Windows.Forms.CheckBox();
            this.AppointmentPerHourComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // SaveAndConnectButton
            // 
            this.SaveAndConnectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveAndConnectButton.Location = new System.Drawing.Point(23, 441);
            this.SaveAndConnectButton.Name = "SaveAndConnectButton";
            this.SaveAndConnectButton.Size = new System.Drawing.Size(360, 51);
            this.SaveAndConnectButton.TabIndex = 6;
            this.SaveAndConnectButton.Text = "Save and Connect to Database";
            this.SaveAndConnectButton.UseVisualStyleBackColor = true;
            this.SaveAndConnectButton.Click += new System.EventHandler(this.SaveAndConnectButton_Click);
            // 
            // ServerNameTextBox
            // 
            this.ServerNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerNameTextBox.Location = new System.Drawing.Point(140, 209);
            this.ServerNameTextBox.Name = "ServerNameTextBox";
            this.ServerNameTextBox.Size = new System.Drawing.Size(233, 23);
            this.ServerNameTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Server Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Database Name:";
            // 
            // DatabaseTextBox
            // 
            this.DatabaseTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatabaseTextBox.Location = new System.Drawing.Point(140, 247);
            this.DatabaseTextBox.Name = "DatabaseTextBox";
            this.DatabaseTextBox.Size = new System.Drawing.Size(233, 23);
            this.DatabaseTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(333, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "You can find this information in Salon Iris -> File -> Database Controls.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(38, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(331, 79);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Company Name:";
            // 
            // CompanyTextBox
            // 
            this.CompanyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompanyTextBox.Location = new System.Drawing.Point(140, 173);
            this.CompanyTextBox.Name = "CompanyTextBox";
            this.CompanyTextBox.Size = new System.Drawing.Size(233, 23);
            this.CompanyTextBox.TabIndex = 1;
            // 
            // CycleTimer
            // 
            this.CycleTimer.Interval = 1000;
            this.CycleTimer.Tick += new System.EventHandler(this.CycleTimer_Tick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(46, 287);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Server User:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 324);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Server Password:";
            // 
            // DBUserTextBox
            // 
            this.DBUserTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DBUserTextBox.Location = new System.Drawing.Point(140, 285);
            this.DBUserTextBox.Name = "DBUserTextBox";
            this.DBUserTextBox.Size = new System.Drawing.Size(233, 23);
            this.DBUserTextBox.TabIndex = 4;
            this.DBUserTextBox.Text = "PC4";
            // 
            // DBPasswordTextBox
            // 
            this.DBPasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DBPasswordTextBox.Location = new System.Drawing.Point(140, 320);
            this.DBPasswordTextBox.Name = "DBPasswordTextBox";
            this.DBPasswordTextBox.PasswordChar = '-';
            this.DBPasswordTextBox.Size = new System.Drawing.Size(233, 23);
            this.DBPasswordTextBox.TabIndex = 5;
            this.DBPasswordTextBox.Text = "test";
            // 
            // SSPICheckBox
            // 
            this.SSPICheckBox.AutoSize = true;
            this.SSPICheckBox.Location = new System.Drawing.Point(170, 357);
            this.SSPICheckBox.Name = "SSPICheckBox";
            this.SSPICheckBox.Size = new System.Drawing.Size(213, 17);
            this.SSPICheckBox.TabIndex = 12;
            this.SSPICheckBox.Text = "Windows Based(No Password Needed)";
            this.SSPICheckBox.UseVisualStyleBackColor = true;
            // 
            // AppointmentPerHourComboBox
            // 
            this.AppointmentPerHourComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AppointmentPerHourComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppointmentPerHourComboBox.FormattingEnabled = true;
            this.AppointmentPerHourComboBox.Items.AddRange(new object[] {
            "3",
            "4"});
            this.AppointmentPerHourComboBox.Location = new System.Drawing.Point(140, 391);
            this.AppointmentPerHourComboBox.Name = "AppointmentPerHourComboBox";
            this.AppointmentPerHourComboBox.Size = new System.Drawing.Size(233, 24);
            this.AppointmentPerHourComboBox.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 391);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "#Appts per Hour:";
            // 
            // ConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 504);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.AppointmentPerHourComboBox);
            this.Controls.Add(this.SSPICheckBox);
            this.Controls.Add(this.DBPasswordTextBox);
            this.Controls.Add(this.DBUserTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CompanyTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DatabaseTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ServerNameTextBox);
            this.Controls.Add(this.SaveAndConnectButton);
            this.Name = "ConnectionForm";
            this.Text = "Salon Iris Tickets Configuration";
            this.Load += new System.EventHandler(this.ConnectionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveAndConnectButton;
        private System.Windows.Forms.TextBox ServerNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DatabaseTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox CompanyTextBox;
        private System.Windows.Forms.Timer CycleTimer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox DBUserTextBox;
        private System.Windows.Forms.TextBox DBPasswordTextBox;
        private System.Windows.Forms.CheckBox SSPICheckBox;
        private System.Windows.Forms.ComboBox AppointmentPerHourComboBox;
        private System.Windows.Forms.Label label8;
    }
}

