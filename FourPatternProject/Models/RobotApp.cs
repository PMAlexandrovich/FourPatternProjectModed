using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPatternProject.Models
{
    class RobotApp
    {
        int maxX;
        int minX;
        int maxY;
        int minY;
        int startX;
        int startY;

        private IRobot robot;
        private CommandParser parser;

        public event EventHandler<RobotMoveEventArgs> OnRobotMove;

        public RobotApp(int maxX, int minX, int maxY, int minY,int startX,int startY)
        {
            this.maxX = maxX;
            this.minX = minX;
            this.maxY = maxY;
            this.minY = minY;
            this.startX = startX;
            this.startY = startY;
            var robot = new Robot();
            robot.OnRobotMove += RobotMove;
            this.robot = new RobotWithDelay(robot);
            parser = new CommandParser();
        }

        private void RobotMove(object sender, RobotMoveEventArgs e)
        {
            if (e.X >= minX && e.X <= maxX && e.Y >= minY && e.Y <= maxY)
            {
                OnRobotMove(robot, e);
            }
            else
                throw new ArgumentOutOfRangeException("","Робот вышел за границы !");
        }

        public void Execute(string code)
        {
            var program = parser.Parse(code);
            program.Interpret(robot);
        }

        public void MoveToStart()
        {
            robot.GoTo(startX, startY);
        }
    }
}
