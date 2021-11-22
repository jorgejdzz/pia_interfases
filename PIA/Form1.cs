using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;


namespace PIA
{
    public partial class Form1 : Form
    {
        public static Form1 instance;
        Thread th1;
        public Form1()
        {
            InitializeComponent();
            instance = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                comboBoxBaud.Text = "9600";
                string[] portList = SerialPort.GetPortNames();
                comboBoxPort.DataSource = portList;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.Close();

                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = comboBoxPort.Text;
                serialPort1.BaudRate = Convert.ToInt32(comboBoxBaud.Text);
                serialPort1.Open();
                serialPort1.Close();
                using (Form2 form2=new Form2())
                {
                    form2.port = comboBoxPort.Text;
                    form2.baud = comboBoxBaud.Text;
                    form2.ShowDialog();
                }
                this.Close();
                Form1.instance.Close();
                th1 = new Thread(opennewform);
                th1.SetApartmentState(ApartmentState.STA);
                th1.Start();
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void opennewform()
        {
            Application.Run(new Form2());
        }

        private void buttonrefresh_Click(object sender, EventArgs e)
        {
            string[] portList = SerialPort.GetPortNames();
            comboBoxPort.DataSource = portList;
        }
      }
}
