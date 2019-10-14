#include<IRremote.h>
int recvPin = 7;  // CONNECT THE OUTPUT PIN OF THE IR RECIEVER TO THIS PIN
int c = 0;
IRrecv irrecv(recvPin);
decode_results results;
void setup() {
  Serial.begin(9600);
irrecv.enableIRIn();
//pinMode(LED_BUILTIN,OUTPUT);
}


void loop() {
if(irrecv.decode(&results))
{
  Serial.println(results.value,HEX);
  irrecv.resume();
  digitalWrite(LED_BUILTIN,HIGH);
  delay(500);
}
  digitalWrite(LED_BUILTIN,LOW);
  delay(1000);
}
