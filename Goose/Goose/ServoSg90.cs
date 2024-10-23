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
        var motorPulse = ServoPulseTime(to);   
        
        const double totalPulseTime = 20;
        var timeToWait = totalPulseTime - motorPulse;

        _motorPin.Write(PinValue.High);
        WaitMilliseconds(motorPulse);
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
            To.Left => 2,
            To.Middle => 1.5,
            To.Right => 1,
            _ => -1
        };
    }
}