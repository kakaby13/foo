using System.Device.Gpio;
using System.Diagnostics;

namespace Goose;

public class ServoSg90
{
    private readonly GpioPin _motorPin;
    
    public ServoSg90(RaspberryPiGpioPin pin)
    {
        try
        {
            var controller = new GpioController();
            _motorPin = controller.OpenPin(Convert.ToInt32(pin));
            _motorPin.SetPinMode(PinMode.Output);
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: GpioInit failed - " + ex);
        }
    }
    
    public void Rotate(To to)
    {
        var servoPulseTime = ServoPulseTime(to);   
        
        const double totalPulseTime = 20;
        var timeToWait = totalPulseTime - servoPulseTime;

        _motorPin.Write(PinValue.High);
        WaitMilliseconds(servoPulseTime);
        _motorPin.Write(PinValue.Low);
        WaitMilliseconds(timeToWait);
    }
    
    public void RotateContinuously(To to, int durationInMilliseconds)
    {
        var stopwatch = Stopwatch.StartNew();

        while (stopwatch.ElapsedMilliseconds < durationInMilliseconds)
        {
            Rotate(to);
        }
    }

    private static void WaitMilliseconds(double millisecondsToWait)
    {
        Thread.Sleep(Convert.ToInt32(millisecondsToWait));
    }
    
    private static double ServoPulseTime(To to)
    {
        return to switch
        {
            To.Left => 1.8,
            To.Middle => 1.2,
            To.Right => 0.4,
            _ => -1
        };
    }
}
