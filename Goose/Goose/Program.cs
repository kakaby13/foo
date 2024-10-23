using Goose;

public class Program
{
    static void Main(string[] args)
    {
        var servo = new ServoSg90(RaspberryPiGpioPin.GPIO05);
        // Повернуть сервопривод влево на 5 секунд
        servo.RotateContinuously(To.Left, 5000);

        // Повернуть сервопривод в середину на 3 секунды
        servo.RotateContinuously(To.Middle, 3000);

        // Повернуть сервопривод вправо на 2 секунды
        servo.RotateContinuously(To.Right, 2000);
    }

    private static void Run(string argument)
    {
        var servo = new ServoSg90(RaspberryPiGpioPin.GPIO05);
                    // Повернуть сервопривод влево на 5 секунд
            servo.RotateContinuously(To.Left, 5000);

            // Повернуть сервопривод в середину на 3 секунды
            servo.RotateContinuously(To.Middle, 3000);

            // Повернуть сервопривод вправо на 2 секунды
            servo.RotateContinuously(To.Right, 2000);
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