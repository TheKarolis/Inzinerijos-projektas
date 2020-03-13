    #define O0 11
    #define O1 10
    #define O2 9
    #define O3 6
    #define O4 5
    #define O5 3
    #define I0 A0
    #define I1 A1
    #define I2 A2
    #define I3 A3
    #define I4 A4
    #define I5 A5
    
    const int tiltPin = I0;
    int tiltState = 0;
    int state = 0;
    
    void setup() {
      pinMode(tiltPin, INPUT); 
      Serial.begin(9600);
    }
    
    void loop() {
      Serial.println(digitalRead(tiltPin)); 
     }
