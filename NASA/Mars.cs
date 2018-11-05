using System.Collections.Generic;
using System.Text;

namespace NASA
{
    public class Mars
    {
        private const int START_LOCATION_X = 0;
        private const int START_LOCATION_Y = 0;
        private int endLocationX;
        private int endLocationY;

        private List<Robot> robots = new List<Robot>();

        public Mars(int endLocationX, int endLocationY)
        {
            this.endLocationX = endLocationX;
            this.endLocationY = endLocationY;
        }
        public void AddRobot(Robot robot)
        {
            robots.Add(robot);
        }
        public void Simulate()
        {
            Robot.MinX = START_LOCATION_X;
            Robot.MinY = START_LOCATION_Y;
            Robot.MaxX = endLocationX;
            Robot.MaxY = endLocationY;

            foreach (var robot in robots)
            {
                robot.RunActions();
            }
        }
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            foreach (var robot in robots)
            {
                stringBuilder.Append(robot.ToString())
                             .AppendLine("\n");
            }
            return stringBuilder.ToString();
        }
    }
}
