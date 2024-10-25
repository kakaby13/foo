using System;
using System.Device.Gpio;
using System.Device.Pwm;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        int servoPin = 12; // Новый пин для подключения сервопривода
        int frequency = 50; // Частота для SG90 сервопривода

        using (var pwmChannel = PwmChannel.Create(1, servoPin, frequency))
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