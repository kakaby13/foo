using System.Device.Gpio;
using System.Diagnostics;

namespace Goose;

public class ServoSg90
{
    private readonly GpioController _controller;
    private readonly GpioPin _motorPin;
    private readonly ulong _ticksPerMilliSecond = (ulong)(Stopwatch.Frequency) / 1000;
    
    public ServoSg90(RaspberryPiGpioPin pin)
    {
        try
        {
            _controller = new GpioController();
            _motorPin = _controller.OpenPin(Convert.ToInt32(pin));
            _motorPin.SetPinMode(PinMode.Output);
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: GpioInit failed - " + ex);
        }
    }
    
    public void Rotate(To to)
    {
        Rotate(ServoPulseTime(to));
    }

    private void MillisecondToWait(double millisecondsToWait)
    {
        var sw = new Stopwatch();
        var durationTicks = _ticksPerMilliSecond * millisecondsToWait;
        sw.Start();
        while (sw.ElapsedTicks < durationTicks) { }
    }

    private void Rotate(double motorPulse)
    {
        const double totalPulseTime = 20;
        var timeToWait = totalPulseTime - motorPulse;

        _motorPin.Write(PinValue.High);
        MillisecondToWait(motorPulse);
        _motorPin.Write(PinValue.Low);
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