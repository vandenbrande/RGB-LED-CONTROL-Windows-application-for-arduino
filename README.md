# RGB-LED-CONTROL-Windows-application-for-arduino
C# Application to control RGB Leds, or LED Strips with arduino.

Hello world! Today i made a c# Application with visual studio to control RGB Leds/Led strips. The Arduino code is very simple.
The source is open to modify and included in this description.

In the C# Code you can use 2 options to send a color to the arduino from each button, examples are below.

1: Using RGB Values 
First open the Project file in Visual Studio.

Open the code Form1.cs 

go to:  
public partial class Form1 : Form
change and add new values and names like below: 

private Color RedColor1 = Color.FromArgb(255, 0, 0);

Next place this.SetColor(RedColor1); at a (NEW) button like the example below.

private void button1_Click(object sender, EventArgs e) 
  {
   this.SetColor(RedColor1);
  }

=====================================
2: Using color names (These are Web Colors)

Simply place the following at a button and choose a color:
SetColor(Color.Red);

example below: 

private void button1_Click_1(object sender, EventArgs e)
  {
   SetColor(Color.Red);
  }


The color panel: 
(Windows color dialog)
Press the Color Panel button to open the Color Dialog. 
Not all colors work form the Color Dialog because RGB Leds cannot generate any color from every value, 
But it gives you a wide choice of colors that can be used.

HOW to modify?:
Files you modify in the C# source are the following. Form1.cs & Form.1Designer.cs 
To modify the look of the Application you simply double click on Form1.cs and the Form1.cs [Design] should pop up. 
You can now drag and drop buttons and whatever you want from the toolbox, and change background in the properties etc. 
If adding a button for example, double click the button to give it a function, 
Double clicking it will bring you to the part of the code that belongs to the button.

You can also change the about box by double clicking on the about box AboutBox1.cs, 
You can change background, font, colors etc. To change company name, version etc. 
you can double click Properties in the [solution explorer]. And then at [application] click on [assembly information], 
you can also modify AssemblyInfo.cs directly.


Arduino code:
const int RED_LED_PIN = 5;
const int GREEN_LED_PIN = 9;
const int BLUE_LED_PIN = 11;

void setup() { 
  Serial.begin(9600);
  
}

void loop() {
  
  if (Serial.available() == 3)
  {
    analogWrite(RED_LED_PIN, Serial.read());
    analogWrite(GREEN_LED_PIN, Serial.read());
    analogWrite(BLUE_LED_PIN, Serial.read());
   
   
  }
}
