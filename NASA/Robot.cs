using System;
using System.Text;
using static NASA.Enums;

namespace NASA
{
    public class Robot
    {
        public static int MinX { get; set; }
        public static int MinY { get; set; }
        public static int MaxX { get; set; }
        public static int MaxY { get; set; }

        private int x { get; set; }
        private int y { get; set; }
        private RobotDirection direction { get; set; }
        private string actions;

        public Robot(int x, int y, RobotDirection direction)
        {
            this.x = x;
            this.y = y;
            this.direction = direction;
        }
        public void SetActions(string actions)
        {
            this.actions = actions;
        }
        public void RunActions()
        {
            RobotMovement movement;

            foreach (var action in actions)
            {
                Enum.TryParse(action.ToString(), out movement);

                Move(movement);
            }
        }

        private void Move(RobotMovement movement)
        {
            switch (movement)
            {
                case RobotMovement.L:
                    if (direction == RobotDirection.E)
                        direction = RobotDirection.N;
                    else
                        direction++;
                    break;
                case RobotMovement.R:
                    if (direction == RobotDirection.N)
                        direction = RobotDirection.E;
                    else
                        direction--;
                    break;
                case RobotMovement.M:
                    switch (direction)
                    {
                        case RobotDirection.N:
                            y = y < MaxY ? y + 1 : y;
                            break;
                        case RobotDirection.W:
                            x = x > MinX ? x - 1 : MinX;
                            break;
                        case RobotDirection.S:
                            y = y > MinY ? y - 1 : MinY;
                            break;
                        case RobotDirection.E:
                            x = x < MaxX ? x + 1 : x;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(x)
                         .Append(" ")
                         .Append(y)
                         .Append(" ")
                         .Append(direction.ToString());

            return stringBuilder.ToString();
        }
    }
}
