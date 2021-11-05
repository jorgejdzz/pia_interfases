using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace PIA
{
    public partial class Form2 : Form
    {
        public static Form2 instance2;
        Thread th2;
        public string port;
        public string baud;
        
        public Form2()
        {
            InitializeComponent();
            instance2 = this;
            this.toolTipled.SetToolTip(this.pictureBoxledayuda, "Dar clic en las imagenes o texto para encender o apagar las luces LED.");
            this.toolTipled.SetToolTip(this.pictureBoxlcdayuda, @"Puedes escribir hasta un máximo de 16 caracteres por línea (incluyendo espacios) 
y mostrarlo en la pantalla LCD. También, puedes borrar el mensaje.");
            this.toolTipled.SetToolTip(this.pictureBoxbrilloayuda, @"Muestra el porcentaje de brillo de la pantalla LCD.
A mayor porcentaje, mayor brillo.");
            this.toolTipled.SetToolTip(this.pictureBoxtempayuda, @"Muestra la temperatura actual de tu habitación en grados Celsius (°C).
¿Qué significan los colores?
 --AZUL: Frio
 --VERDE: Agradable
 --ROJO: Calor
Se recomienda mantener la temperatura dentro del zona verde.");
            this.toolTipled.SetToolTip(this.pictureBoxhumayuda, @"Muestra la humedad actual de tu habitación en porcentaje (%).
¿Qué significan los colores?
 --AZUL: Seco
 --VERDE: Recomendado
 --ROJO: Muy húmedo
Se recomienda mantener la humedad dentro de la zona verde.");
            this.toolTipled.SetToolTip(this.pictureBoxbaseayuda, @"Es posible posicionar la base del robot en un rango de 0 y 180 grados. Los grados se 
pueden cambiar con la barra deslizadora o introduciendo el ángulo manualmente.
CUIDADO: Despejar la zona antes de mover el robot.");
            this.toolTipled.SetToolTip(this.pictureBoxbrazoayuda, @"Es posible posicionar el brazo del robot en un rango de 0 y 180 grados. Los grados se 
pueden cambiar con la barra deslizadora o introduciendo el ángulo manualmente.
CUIDADO: Despejar la zona antes de mover el robot. ");

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                
                serialPort1.PortName = port;
                serialPort1.BaudRate = Convert.ToInt32(baud);
                serialPort1.Open();
                desconcectar();

                
                
                labelpuerto.Text = port;
                labelbaud.Text = baud;

               

                serialPort1.WriteLine("&I");


            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                try
                {
                    desconcectar();
                    serialPort1.Close();
                    this.Close();
                    th2 = new Thread(opennewform);
                    th2.SetApartmentState(ApartmentState.STA);
                    th2.Start();

                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            desconcectar();

            serialPort1.Close();

            this.Close();

            th2 = new Thread(opennewform);
            th2.SetApartmentState(ApartmentState.STA);
            th2.Start();
            

        }

        private void opennewform()
        {
            Application.Run(new Form1());
        }

        /*private void checkBoxled1_CheckedChanged(object sender, EventArgs e)
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
            catch (Exception error)
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
        }*/

        private void desconcectar()
        {
            try
            {
                /*reiniciarservo();
                serialPort1.WriteLine("&1OFF");
                serialPort1.WriteLine("&2OFF");
                serialPort1.WriteLine("&3OFF");
                borrarLCD();*/
                serialPort1.WriteLine("&R");
                pictureBoxLed1.Image = Properties.Resources.ledapagado;
                checkBoxled1.Checked = false;
                
                pictureBoxLed2.Image = Properties.Resources.ledapagado;
                checkBoxled2.Checked = false;
                
                pictureBoxLed3.Image = Properties.Resources.ledapagado;
                checkBoxled3.Checked = false;
                
                circularProgressBarPot.Value = 0;
                circularProgressBarPot.Text = "0%";

            }
            catch (Exception error)
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
            catch (Exception error)
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
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

        }

        private void trackBarServo1_Scroll(object sender, EventArgs e)
        {
            try
            {

                textBoxposicion1.Text = trackBarServo1.Value + "°";
                serialPort1.WriteLine($"&S1{textBoxposicion1.Text}");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void reiniciarservo()
        {
            serialPort1.WriteLine("&S1S20");
            textBoxposicion1.Text = "0°";
            trackBarServo1.Value = 0;
            textBoxposicion2.Text = "0°";
            trackBarServo2.Value = 0;
        }

        private void buttonposicionar_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.WriteLine($"&S1{textBoxposicion1.Text}");
                trackBarServo1.Value = Convert.ToInt32(textBoxposicion1.Text);
                textBoxposicion1.Text += "°";
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
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
                            circularProgressBarPot.Text = val[1] + '%';
                            circularProgressBarPot.Value = value;
                            if (value == 10)
                            {
                                circularProgressBarPot.ProgressColor = Color.DarkGreen;

                            }
                            else if (value == 20)
                            {
                                circularProgressBarPot.ProgressColor = Color.Green;
                            }
                            else if (value == 30)
                            {
                                circularProgressBarPot.ProgressColor = Color.ForestGreen;
                            }
                            else if (value == 40)
                            {
                                circularProgressBarPot.ProgressColor = Color.SeaGreen;
                            }
                            else if (value == 50)
                            {
                                circularProgressBarPot.ProgressColor = Color.MediumSeaGreen;
                            }
                            else if (value == 60)
                            {
                                circularProgressBarPot.ProgressColor = Color.LimeGreen;
                            }
                            else if (value == 70)
                            {
                                circularProgressBarPot.ProgressColor = Color.Lime;
                            }
                            else if (value == 80)
                            {
                                circularProgressBarPot.ProgressColor = Color.LawnGreen;
                            }
                            else if (value == 90)
                            {
                                circularProgressBarPot.ProgressColor = Color.Chartreuse;
                            }
                            else if (value == 100)
                            {
                                circularProgressBarPot.ProgressColor = Color.GreenYellow;
                            }
                        }));
                    }
                }
                else if (serialData.StartsWith("&T"))
                {
                    string[] val = serialData.Split('T');
                    int value = Convert.ToInt32(val[1]);
                    /*if (value >= trackBarTemp.Minimum && value <= trackBarTemp.Maximum)
                    {
                        trackBarTemp.Invoke((MethodInvoker)(() =>
                        {
                            trackBarTemp.Value = value;
                            labelTemp.Text = val[1] + "°";
                        }));
                    }*/
                    if (value >= radialGaugetemp.MinimumValue && value <= radialGaugetemp.MaximumValue)
                    {
                        radialGaugetemp.Invoke((MethodInvoker)(() =>
                        {
                            radialGaugetemp.Value = value;
                        }));
                        digitalGaugetemp.Invoke((MethodInvoker)(() =>
                        {
                            if (value < 10)
                            {
                                digitalGaugetemp.Value = "0" + val[2];
                            }
                            else
                            {
                                digitalGaugetemp.Value = val[1];
                            }
                        }));
                    }

                }
                else if (serialData.StartsWith("&H"))
                {
                    string[] val = serialData.Split('H');
                    int value = Convert.ToInt32(val[1]);
                    /*if (value >= trackBarHum.Minimum && value <= trackBarHum.Maximum)
                    {
                        trackBarHum.Invoke((MethodInvoker)(() =>
                        {
                            trackBarHum.Value = value;
                            labelHum.Text = val[1] + "%";
                        }));
                    }*/
                    if (value >= radialGaugehum.MinimumValue && value <= radialGaugehum.MaximumValue)
                    {
                        radialGaugehum.Invoke((MethodInvoker)(() =>
                        {
                            radialGaugehum.Value = value;
                        }));
                        digitalGaugehum.Invoke((MethodInvoker)(() =>
                        {
                            digitalGaugehum.Value = val[1];
                        }));
                    }

                }
                else if (serialData.StartsWith("&I"))
                {
                    string[] val = serialData.Split('I','T','H');
                    int value = Convert.ToInt32(val[1]);
                    if (value >= circularProgressBarPot.Minimum && value <= circularProgressBarPot.Maximum)
                    {
                        circularProgressBarPot.Invoke((MethodInvoker)(() =>
                        {
                            circularProgressBarPot.Text = val[1] + '%';
                            circularProgressBarPot.Value = value;
                        }));
                    }
                    value = Convert.ToInt32(val[2]);
                    /*if (value >= trackBarTemp.Minimum && value <= trackBarTemp.Maximum)
                    {
                        trackBarTemp.Invoke((MethodInvoker)(() =>
                        {
                            trackBarTemp.Value = value;
                            labelTemp.Text = val[2] + "°";
                        }));
                    }*/

                    if (value >= radialGaugetemp.MinimumValue && value <= radialGaugetemp.MaximumValue)
                    {
                        radialGaugetemp.Invoke((MethodInvoker)(() =>
                        {
                            radialGaugetemp.Value = value;
                        }));
                        digitalGaugetemp.Invoke((MethodInvoker)(() =>
                        {
                            if (value < 10)
                            {
                                digitalGaugetemp.Value = "0" + val[2];
                            }
                            else
                            {
                                digitalGaugetemp.Value = val[2];
                            }
                        }));
                    }

                    value = Convert.ToInt32(val[3]);
                    /*if (value >= trackBarHum.Minimum && value <= trackBarHum.Maximum)
                    {
                        trackBarHum.Invoke((MethodInvoker)(() =>
                        {
                            trackBarHum.Value = value;
                            labelHum.Text = val[3] + "%";
                        }));
                    }*/

                    if (value >= radialGaugehum.MinimumValue && value <= radialGaugehum.MaximumValue)
                    {
                        radialGaugehum.Invoke((MethodInvoker)(() =>
                        {
                            radialGaugehum.Value = value;
                        }));
                        digitalGaugehum.Invoke((MethodInvoker)(() =>
                        {
                            digitalGaugehum.Value = val[3];
                        }));
                    }

                }
            }
        }

        private void buttoninicial_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.WriteLine("&S10");
                trackBarServo1.Value = 0;
                textBoxposicion1.Text = "0°";
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }



        private void buttonposicionar2_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.WriteLine($"&S2{textBoxposicion2.Text}");
                trackBarServo2.Value = Convert.ToInt32(textBoxposicion2.Text);
                textBoxposicion2.Text += "°";
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void buttoninicial2_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.WriteLine("&S20");
                trackBarServo2.Value = 0;
                textBoxposicion2.Text = "0°";
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void trackBarServo2_Scroll(object sender, EventArgs e)
        {
            try
            {
                textBoxposicion2.Text = trackBarServo2.Value + "°";
                serialPort1.WriteLine($"&S2{textBoxposicion2.Text}");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void pictureBoxLed1_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxled1.Checked)
                {
                    serialPort1.WriteLine("&1OFF");
                    pictureBoxLed1.Image = Properties.Resources.ledapagado;
                    checkBoxled1.Checked = false;
                }
                else
                {
                    serialPort1.WriteLine("&1ON");
                    pictureBoxLed1.Image = Properties.Resources.ledencendido;
                    checkBoxled1.Checked = true;

                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxled1.Checked)
                {
                    serialPort1.WriteLine("&1OFF");
                    pictureBoxLed1.Image = Properties.Resources.ledapagado;
                    checkBoxled1.Checked = false;
                }
                else
                {
                    serialPort1.WriteLine("&1ON");
                    pictureBoxLed1.Image = Properties.Resources.ledencendido;
                    checkBoxled1.Checked = true;

                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void pictureBoxLed2_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxled2.Checked)
                {
                    serialPort1.WriteLine("&2OFF");
                    pictureBoxLed2.Image = Properties.Resources.ledapagado;
                    checkBoxled2.Checked = false;
                }
                else
                {
                    serialPort1.WriteLine("&2ON");
                    pictureBoxLed2.Image = Properties.Resources.ledencendido;
                    checkBoxled2.Checked = true;

                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void labelled2_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxled2.Checked)
                {
                    serialPort1.WriteLine("&2OFF");
                    pictureBoxLed2.Image = Properties.Resources.ledapagado;
                    checkBoxled2.Checked = false;
                }
                else
                {
                    serialPort1.WriteLine("&2ON");
                    pictureBoxLed2.Image = Properties.Resources.ledencendido;
                    checkBoxled2.Checked = true;

                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void pictureBoxLed3_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxled3.Checked)
                {
                    serialPort1.WriteLine("&3OFF");
                    pictureBoxLed3.Image = Properties.Resources.ledapagado;
                    checkBoxled3.Checked = false;
                }
                else
                {
                    serialPort1.WriteLine("&3ON");
                    pictureBoxLed3.Image = Properties.Resources.ledencendido;
                    checkBoxled3.Checked = true;

                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void label8_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxled3.Checked)
                {
                    serialPort1.WriteLine("&3OFF");
                    pictureBoxLed3.Image = Properties.Resources.ledapagado;
                    checkBoxled3.Checked = false;
                }
                else
                {
                    serialPort1.WriteLine("&3ON");
                    pictureBoxLed3.Image = Properties.Resources.ledencendido;
                    checkBoxled3.Checked = true;

                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void pictureBoxled4_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxled4.Checked)
                {
                    //serialPort1.WriteLine("&3OFF");
                    pictureBoxLed4.Image = Properties.Resources.ledapagado;
                    checkBoxled4.Checked = false;
                }
                else
                {
                    //serialPort1.WriteLine("&3ON");
                    pictureBoxLed4.Image = Properties.Resources.ledencendido;
                    checkBoxled4.Checked = true;

                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void labelled4_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxled4.Checked)
                {
                    //serialPort1.WriteLine("&1OFF");
                    pictureBoxLed4.Image = Properties.Resources.ledapagado;
                    checkBoxled4.Checked = false;
                }
                else
                {
                    //serialPort1.WriteLine("&1ON");
                    pictureBoxLed4.Image = Properties.Resources.ledencendido;
                    checkBoxled4.Checked = true;

                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxled5.Checked)
                {
                    //serialPort1.WriteLine("&3OFF");
                    pictureBoxLed5.Image = Properties.Resources.ledapagado;
                    checkBoxled5.Checked = false;
                }
                else
                {
                    //serialPort1.WriteLine("&3ON");
                    pictureBoxLed5.Image = Properties.Resources.ledencendido;
                    checkBoxled5.Checked = true;

                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void labelled5_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxled5.Checked)
                {
                    //serialPort1.WriteLine("&3OFF");
                    pictureBoxLed5.Image = Properties.Resources.ledapagado;
                    checkBoxled5.Checked = false;
                }
                else
                {
                    //serialPort1.WriteLine("&3ON");
                    pictureBoxLed5.Image = Properties.Resources.ledencendido;
                    checkBoxled5.Checked = true;

                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
