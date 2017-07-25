using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;

namespace RGBLedColorPicker
{
	public partial class Form1 : Form
	{
		bool isConnected = false;
		String[] ports;
		SerialPort port;

		// Initialize the default color to black
		private Color defaultColor = Color.FromArgb(0, 0, 0);
		//you can add more colors here to use for the buttons.
		//you can also add them with the method explained at the buttons.
		private Color RedColor1 = Color.FromArgb(255, 0, 0);
		private Color GreenColor1 = Color.FromArgb(0, 255, 0);
		private Color BlueColor1 = Color.FromArgb(0, 0, 255);
		private Color WhiteColor1 = Color.FromArgb(255, 255, 255);
		private Color BlackColor1 = Color.FromArgb(0, 0, 0);
		//dimmer 3
		private Color DIM3 = Color.FromArgb(64, 64, 64);

		public Form1()
		{
			InitializeComponent();
			disableControls();
			getAvailableComPorts();

			foreach (string port in ports)
			{
				comboBox1.Items.Add(port);
				Console.WriteLine(port);
				if (ports[0] != null)
				{
					comboBox1.SelectedItem = ports[0];
				}
			}
		}

		
		void getAvailableComPorts()
		{
			ports = SerialPort.GetPortNames(); 
		}

		private void connectToArduino()
		{
			isConnected = true;
			string selectedPort = comboBox1.GetItemText(comboBox1.SelectedItem);
			port = new SerialPort(selectedPort, 9600, Parity.None, 8, StopBits.One);
			port.Open();
			this.SetColor(defaultColor);
			button19.Text = "DISCONNECT FROM SERIAL PORT";
			enableControls();

		}

		private void disconnectFromArduino()
		{
			isConnected = false;
			this.SetColor(defaultColor); 
			port.Close();
			button19.Text = "CONNECT TO SERIAL PORT"; 
			disableControls();

		}

		private void enableControls()
		{
			button1.Enabled = true;
			button2.Enabled = true;
			button3.Enabled = true;
			button4.Enabled = true;
			button5.Enabled = true;
			button6.Enabled = true;
			button7.Enabled = true;
			button8.Enabled = true;
			button9.Enabled = true;
			button10.Enabled = true;
			button11.Enabled = true;
			button12.Enabled = true;
			button13.Enabled = true;
			button14.Enabled = true;
			button15.Enabled = true;
			button16.Enabled = true;
			button17.Enabled = true;
			button18.Enabled = true;
			pictureBox1.Enabled = true;

		}

		private void disableControls()
		{
			button1.Enabled = false;
			button2.Enabled = false;
			button3.Enabled = false;
			button4.Enabled = false;
			button5.Enabled = false;
			button6.Enabled = false;
			button7.Enabled = false;
			button8.Enabled = false;
			button9.Enabled = false;
			button10.Enabled = false;
			button11.Enabled = false;
			button12.Enabled = false;
			button13.Enabled = false;
			button14.Enabled = false;
			button15.Enabled = false;
			button16.Enabled = false;
			button17.Enabled = false;
			button18.Enabled = false;
			pictureBox1.Enabled = false;


		}


		private void SetColor(Color color)
		{
			// Update color in the panel
			panel1.BackColor = color;

			// Write color to Arduino
			port.Write(new[] { color.R, color.G, color.B }, 0, 3);
		}
		

		private void button1_Click_1(object sender, EventArgs e)
		{
			ColorDialog colorDialog1 = new ColorDialog();
			colorDialog1.AllowFullOpen = true;
			colorDialog1.AnyColor = true;
			colorDialog1.SolidColorOnly = true;
			colorDialog1.Color = Color.BlueViolet; 
			if (colorDialog1.ShowDialog() == DialogResult.OK)
			{
				SetColor(colorDialog1.Color);
			}
		}

		private void button2_Click_1(object sender, EventArgs e)
		{
			//SetColor(Color.Red);
			//You can also use the method SetColor(Color.Red); and just fill in the color
			this.SetColor(RedColor1); 
		}

		private void button3_Click_1(object sender, EventArgs e)
		{
			//SetColor(Color.Green);
			this.SetColor(GreenColor1); 
		}

		private void button4_Click_1(object sender, EventArgs e)
		{
			//SetColor(Color.Blue);
			this.SetColor(BlueColor1); 
		}

		private void button5_Click_1(object sender, EventArgs e)
		{
			//SetColor(Color.White);
			this.SetColor(WhiteColor1);
		}

		private void button6_Click_1(object sender, EventArgs e)
		{
			//SetColor(Color.Black); // turns off RGB Led
		    this.SetColor(BlackColor1);
		}

		private void button7_Click(object sender, EventArgs e)
		{
			SetColor(Color.DarkRed);
		}

		private void button8_Click(object sender, EventArgs e)
		{
			SetColor(Color.DarkGreen);
		}

		private void button9_Click(object sender, EventArgs e)
		{
			SetColor(Color.DarkBlue);
		}

		private void button10_Click(object sender, EventArgs e)
		{
			SetColor(Color.DeepPink);
		}

		private void button11_Click(object sender, EventArgs e)
		{
			SetColor(Color.Turquoise);
		}

		private void button12_Click(object sender, EventArgs e)
		{
			SetColor(Color.Magenta);
		}

		private void button13_Click(object sender, EventArgs e)
		{
			SetColor(Color.DarkOrange);
		}

		private void button14_Click(object sender, EventArgs e)
		{
			SetColor(Color.Yellow);
		}

		private void button15_Click(object sender, EventArgs e)
		{
			SetColor(Color.Purple);
		}

		private void button16_Click(object sender, EventArgs e) //dimmer button 1
		{
			SetColor(Color.Gray);
		}

		private void button17_Click(object sender, EventArgs e) //dimmer button 2
		{
			SetColor(Color.DimGray);
		}

		private void button18_Click(object sender, EventArgs e) //Dimmer button 3
		{
			this.SetColor(DIM3);
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RGBLedCONTROLpcARDUINO.AboutBox1 box = new RGBLedCONTROLpcARDUINO.AboutBox1();
			box.ShowDialog();
		}

		private void instructablesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://www.instructables.com/member/vandenbrande/instructables/");
		}

		private void fBToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://www.facebook.com/ArduinoProjects101/");
		}

		private void youtubeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCzk_SWD_SASF8UE2FPk9LOA");
		}

		private void githubToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/vandenbrande?utf8=%E2%9C%93&tab=repositories&q=&type=source&language=");
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://www.facebook.com/ArduinoProjects101/");
		}

		private void button19_Click_1(object sender, EventArgs e)
		{
			if (!isConnected)
			{
				connectToArduino();
			}
			else
			{
				disconnectFromArduino();
			}
		}

		private void Exit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}
