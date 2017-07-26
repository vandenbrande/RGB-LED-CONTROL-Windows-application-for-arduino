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
