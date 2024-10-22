using Goose;

public class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Empty arguments");
        }
        else
        {
            Console.WriteLine("Arguments: " + string.Join(" ", args));
            Run(args[0]);
        }
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