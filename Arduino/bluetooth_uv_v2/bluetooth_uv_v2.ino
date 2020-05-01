const int echoPin = 10;

// defines variables
long duration;
int distance;

void setup() {
  Serial.begin(9600);
  }


void loop() {
if (pulseIn(echoPin, HIGH)*0.034/2 > 15) Serial.write(B1000001);
else Serial.write(B1000000);
}
