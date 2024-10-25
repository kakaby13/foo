using System.Device.Pwm;
using Iot.Device.ServoMotor;

ServoMotor servoMotor = new ServoMotor(PwmChannel.Create(0, 0, 50));
servoMotor.Start();  // Enable control signal.

// Move position.  Pulse width argument is in microseconds.
servoMotor.WritePulseWidth(1000); // 1ms; Approximately 0 degrees.
Console.ReadKey();
servoMotor.WritePulseWidth(1500); // 1.5ms; Approximately 90 degrees.
Console.ReadKey();

servoMotor.WritePulseWidth(2000); // 2ms; Approximately 180 degrees.

servoMotor.Stop(); // Disable control signal.