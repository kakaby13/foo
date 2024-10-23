using Goose;

public class Program
{
    static void Main(string[] args)
    {
        var servo = new ServoSg90(RaspberryPiGpioPin.GPIO05);

        for (var i = 0; i < 5; i++)
        {
            var command = Console.ReadLine();
            if (!string.IsNullOrEmpty(command))
            {
                Run(command, servo);
            }
        }
        
    }

    private static void Run(string argument, ServoSg90 servo)
    {
        switch (argument)
        {
            case "R":
                servo.RotateContinuously(To.Right, 2000);
                return;
            case "r":
                servo.Rotate(To.Right);
                return;
            case "L":
                servo.RotateContinuously(To.Left, 2000);
                return;
            case "l":
                servo.Rotate(To.Left);
                return;
            case "M":
                servo.RotateContinuously(To.Middle, 2000);
                return;
            case "m":
                servo.Rotate(To.Middle);
                return;
        }
        
    }
}