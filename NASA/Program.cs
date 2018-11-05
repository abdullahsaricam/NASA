using System;
using static NASA.Enums;

namespace NASA
{
    class Program
    {
        static void Main(string[] args)
        {
            //generate mars
            var endLocation = Console.ReadLine();
            var endLocations = Array.ConvertAll(endLocation.Split(' '), x => Convert.ToInt32(x));

            var mars = new Mars(endLocations[0], endLocations[1]);

            //generate robot-1
            var robot1StartLocation = Console.ReadLine();
            var robot1Actions = Console.ReadLine();
            var robot1StartLocationSplitted = robot1StartLocation.Split(' ');

            var robot1X = Convert.ToInt32(robot1StartLocationSplitted[0]);
            var robot1Y = Convert.ToInt32(robot1StartLocationSplitted[1]);
            Enum.TryParse(robot1StartLocationSplitted[2], out RobotDirection robot1D);

            var robot1 = new Robot(robot1X, robot1Y, robot1D);
            robot1.SetActions(robot1Actions);
            mars.AddRobot(robot1);

            //generate robot-2
            var robot2StartLocation = Console.ReadLine();
            var robot2StartLocationSplitted = robot2StartLocation.Split(' ');
            var robot2Actions = Console.ReadLine();

            var robot2X = Convert.ToInt32(robot2StartLocationSplitted[0]);
            var robot2Y = Convert.ToInt32(robot2StartLocationSplitted[1]);
            Enum.TryParse(robot2StartLocationSplitted[2], out RobotDirection robot2D);

            var robot2 = new Robot(robot2X, robot2Y, robot2D);
            robot2.SetActions(robot2Actions);
            mars.AddRobot(robot2);

            //run simulation
            mars.Simulate();
            Console.WriteLine();
            Console.WriteLine("=============");
            Console.WriteLine();
            Console.WriteLine(mars.ToString());
            Console.ReadKey();

        }
    }
}
