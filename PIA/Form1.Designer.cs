
namespace PIA
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.groupBoxpuerto = new System.Windows.Forms.GroupBox();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxBaud = new System.Windows.Forms.ComboBox();
            this.buttonrefresh = new System.Windows.Forms.Button();
            this.comboBoxPort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxpuerto.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxpuerto
            // 
            this.groupBoxpuerto.BackColor = System.Drawing.SystemColors.Menu;
            this.groupBoxpuerto.Controls.Add(this.buttonOpen);
            this.groupBoxpuerto.Controls.Add(this.label2);
            this.groupBoxpuerto.Controls.Add(this.comboBoxBaud);
            this.groupBoxpuerto.Controls.Add(this.buttonrefresh);
            this.groupBoxpuerto.Controls.Add(this.comboBoxPort);
            this.groupBoxpuerto.Controls.Add(this.label1);
            this.groupBoxpuerto.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxpuerto.Location = new System.Drawing.Point(12, 12);
            this.groupBoxpuerto.Name = "groupBoxpuerto";
            this.groupBoxpuerto.Size = new System.Drawing.Size(388, 238);
            this.groupBoxpuerto.TabIndex = 3;
            this.groupBoxpuerto.TabStop = false;
            this.groupBoxpuerto.Text = "Configuración del Puerto";
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(25, 173);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(305, 37);
            this.buttonOpen.TabIndex = 4;
            this.buttonOpen.Text = "Conectar";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Baud Rate:";
            // 
            // comboBoxBaud
            // 
            this.comboBoxBaud.FormattingEnabled = true;
            this.comboBoxBaud.Location = new System.Drawing.Point(171, 117);
            this.comboBoxBaud.Name = "comboBoxBaud";
            this.comboBoxBaud.Size = new System.Drawing.Size(159, 32);
            this.comboBoxBaud.TabIndex = 3;
            // 
            // buttonrefresh
            // 
            this.buttonrefresh.Image = global::PIA.Properties.Resources.refresh;
            this.buttonrefresh.Location = new System.Drawing.Point(342, 60);
            this.buttonrefresh.Name = "buttonrefresh";
            this.buttonrefresh.Size = new System.Drawing.Size(32, 32);
            this.buttonrefresh.TabIndex = 6;
            this.buttonrefresh.UseVisualStyleBackColor = true;
            this.buttonrefresh.Click += new System.EventHandler(this.buttonrefresh_Click);
            // 
            // comboBoxPort
            // 
            this.comboBoxPort.FormattingEnabled = true;
            this.comboBoxPort.Location = new System.Drawing.Point(171, 61);
            this.comboBoxPort.Name = "comboBoxPort";
            this.comboBoxPort.Size = new System.Drawing.Size(159, 32);
            this.comboBoxPort.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Puerto de \r\ncomunicación:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(412, 262);
            this.Controls.Add(this.groupBoxpuerto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Examen Ordinario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxpuerto.ResumeLayout(false);
            this.groupBoxpuerto.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.GroupBox groupBoxpuerto;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.ComboBox comboBoxBaud;
        private System.Windows.Forms.ComboBox comboBoxPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonrefresh;
    }
}

