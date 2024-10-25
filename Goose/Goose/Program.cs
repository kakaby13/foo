using System.Device.Pwm;

class Program
{
    static void Main(string[] args)
    {
        int servoPin = 12; // Пин для подключения сервопривода
        int frequency = 50; // Частота для SG90 сервопривода

        using (var pwmChannel = PwmChannel.Create(0, servoPin, frequency))
        {
            pwmChannel.Start();
            while (true)
            {
                // Позиция 0 градусов
                pwmChannel.DutyCycle = 0.05;
                Thread.Sleep(1000);

                // Позиция 90 градусов
                pwmChannel.DutyCycle = 0.075;
                Thread.Sleep(1000);

                // Позиция 180 градусов
                pwmChannel.DutyCycle = 0.1;
                Thread.Sleep(1000);
            }
        }
    }
}