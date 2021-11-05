using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    //desconcectar();
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


        /*private void buttonClose_Click_1(object sender, EventArgs e)
        {
            desconcectar();
            groupBoxpuerto.Visible = true;
            groupBoxled.Visible = false;
            groupBoxdesconectar.Visible = false;
            groupBoxLCD.Visible = false;
            groupBoxServo.Visible = false;
            groupBoxPot.Visible = false;
            groupBoxTemp.Visible = false;
            serialPort1.Close();
            //429, 304
            Width = 325;
            Height = 250;
            

        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxled1.Checked)
                {
                    serialPort1.WriteLine("&1ON");
                    pictureBoxLed1.Image = Properties.Resources.ledencendido;
                }
                else
                {
                    serialPort1.WriteLine("&1OFF");
                    pictureBoxLed1.Image = Properties.Resources.ledapagado;
                }
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void checkBoxled2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxled2.Checked)
                {
                    serialPort1.WriteLine("&2ON");
                    pictureBoxLed2.Image = Properties.Resources.ledencendido;
                }
                else
                {
                    serialPort1.WriteLine("&2OFF");
                    pictureBoxLed2.Image = Properties.Resources.ledapagado;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void checkBoxled3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxled3.Checked)
                {
                    serialPort1.WriteLine("&3ON");
                    pictureBoxLed3.Image = Properties.Resources.ledencendido;
                }
                else
                {
                    serialPort1.WriteLine("&3OFF");
                    pictureBoxLed3.Image = Properties.Resources.ledapagado;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void checkBoxled4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxled4.Checked)
                {
                    serialPort1.WriteLine("&4ON");
                    pictureBoxLed4.Image = Properties.Resources.ledencendido;
                }
                else
                {
                    serialPort1.WriteLine("&4OFF");
                    pictureBoxLed4.Image = Properties.Resources.ledapagado;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }


        

        

        private void desconcectar()
        {
            try
            {
                serialPort1.WriteLine("&1OFF");
                pictureBoxLed1.Image = Properties.Resources.ledapagado;
                checkBoxled1.Checked = false;
                serialPort1.WriteLine("&2OFF");
                pictureBoxLed2.Image = Properties.Resources.ledapagado;
                checkBoxled2.Checked = false;
                serialPort1.WriteLine("&3OFF");
                pictureBoxLed3.Image = Properties.Resources.ledapagado;
                checkBoxled3.Checked = false;
                serialPort1.WriteLine("&4OFF");
                pictureBoxLed4.Image = Properties.Resources.ledapagado;
                checkBoxled4.Checked = false;
                borrarLCD();
                reiniciarservo();
                circularProgressBarPot.Value = 0;
                circularProgressBarPot.Text = "0%";
                trackBarTemp.Value = 0;
                labelTemp.Text = "0°";
                trackBarHum.Value = 0;
                labelHum.Text = "0%";



            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
            

        }

        private void buttonLCDImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                string L1 = textBoxLCD1.Text;
                string L2 = textBoxLCD2.Text;

                int n = L1.Length;
                if (n < 16)
                {
                    for (int i = 0; i < (16 - n); i++)
                    {
                        L1 += " ";
                    }
                }

                serialPort1.WriteLine($"&L{L1}{L2}");
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
            
        }

        private void buttonLCDBorrar_Click(object sender, EventArgs e)
        {
            borrarLCD();
        }

        private void borrarLCD()
        {
            try
            {
                textBoxLCD1.Text = "";
                textBoxLCD2.Text = "";

                serialPort1.WriteLine("&L");
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
            
        }

        private void esconder()
        {
            groupBoxpuerto.Visible = true;
            groupBoxled.Visible = false;
            groupBoxdesconectar.Visible = false;
            groupBoxLCD.Visible = false;
            groupBoxServo.Visible = false;
            circularProgressBarPot.Value = 0;
            circularProgressBarPot.Text = "0%";
            groupBoxPot.Visible = false;
            groupBoxTemp.Visible = false;
        }

        private void mostrar()
        {
            groupBoxpuerto.Visible = false;
            groupBoxled.Visible = true;
            groupBoxdesconectar.Visible = true;
            groupBoxLCD.Visible = true;
            groupBoxServo.Visible = true;
            groupBoxPot.Visible = true;
            groupBoxTemp.Visible = true;
        }

        private void trackBarServo1_Scroll(object sender, EventArgs e)
        {
            try
            {
 
                textBoxposicion.Text= trackBarServo1.Value + "°";
                serialPort1.WriteLine($"&S{textBoxposicion.Text}");
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
            
        }

        private void reiniciarservo()
        {
            serialPort1.WriteLine("&S0");
            textBoxposicion.Text = "0°";
            trackBarServo1.Value = 0;
        }

        private void buttonposicionar_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.WriteLine($"&S{textBoxposicion.Text}");
                trackBarServo1.Value = Convert.ToInt32(textBoxposicion.Text);
                textBoxposicion.Text += "°";
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            while (serialPort1.IsOpen && serialPort1.BytesToRead > 0)
            {
                string serialData = serialPort1.ReadLine();
                if (serialData.StartsWith("&P"))
                {
                    string[] val = serialData.Split('P');
                    int value = Convert.ToInt32(val[1]);
                    if (value >= circularProgressBarPot.Minimum && value <= circularProgressBarPot.Maximum)
                    {
                        circularProgressBarPot.Invoke((MethodInvoker)(() =>
                        {
                            circularProgressBarPot.Text = val[1]+'%';
                            circularProgressBarPot.Value = value;
                        }));
                    }
                }
                else if(serialData.StartsWith("&T"))
                {
                    string[] val = serialData.Split('T');
                    int value = Convert.ToInt32(val[1]);
                    if (value >= trackBarTemp.Minimum && value <= trackBarTemp.Maximum)
                    {
                        trackBarTemp.Invoke((MethodInvoker)(() =>
                        {
                            trackBarTemp.Value = value;
                            labelTemp.Text = val[1] + "°";
                        }));
                    }

                }
                else if (serialData.StartsWith("&H"))
                {
                    string[] val = serialData.Split('H');
                    int value = Convert.ToInt32(val[1]);
                    if (value >= trackBarHum.Minimum && value <= trackBarHum.Maximum)
                    {
                        trackBarHum.Invoke((MethodInvoker)(() =>
                        {
                            trackBarHum.Value = value;
                            labelHum.Text = val[1] + "%";
                        }));
                    }

                }
            }
        }

        private void buttoninicial_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.WriteLine("&S0");
                trackBarServo1.Value = 0;
                textBoxposicion.Text = "0°";
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }*/







        /*private void serialPort1_DataReceived_1(object sender, SerialDataReceivedEventArgs e)
        {
            while (serialPort1.IsOpen && serialPort1.BytesToRead > 0)
            {
                string serialData = serialPort1.ReadLine();
                int value = Convert.ToInt32(serialData);

                if (value >= circularProgressBarpwm.Minimum && value <= circularProgressBarpwm.Maximum)
                {
                    circularProgressBarpwm.Invoke((MethodInvoker)(() =>
                    {
                        circularProgressBarpwm.Text = serialData;
                        circularProgressBarpwm.Value = value;
                    }));

                    //charttemp.Invoke((MethodInvoker)(() => charttemp.Series["Temperatura"].Points.AddY(value)));
                    

                }
                else
                {
                    desconcectar();
                }

            }
        }*/
    }
}
