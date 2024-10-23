using Goose;

public class Program
{
    static void Main(string[] args)
    {
        var servo = new ServoSg90(RaspberryPiGpioPin.GPIO05);
        
        Console.WriteLine("left");
        servo.RotateContinuously(To.Left, 2000);
        Console.WriteLine("Middle");
        servo.RotateContinuously(To.Middle, 2000);
        Console.WriteLine("Right");
        servo.RotateContinuously(To.Right, 2000);
    }

    private static void Run(string argument)
    {
        var servo = new ServoSg90(RaspberryPiGpioPin.GPIO05);
        
        switch (argument)
        {
            case "R":
            case "r":
                servo.Rotate(To.Right);
                return;
            case "L":
            case "l":
                servo.Rotate(To.Left);
                return;
            case "M":
            case "m":
                servo.Rotate(To.Middle);
                return;
        }
    }
}