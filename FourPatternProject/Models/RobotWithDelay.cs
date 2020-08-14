using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FourPatternProject.Models
{
    class RobotWithDelay:RobotDecorator
    {
        public RobotWithDelay(IRobot robot) : base(robot) { }

        public override void Down()
        {
            robot.Down();
            Wait();
        }

        public override void Left()
        {
            robot.Left();
            Wait();
        }

        public override void Right()
        {
            robot.Right();
            Wait();
        }

        public override void Up()
        {
            robot.Up();
            Wait();
        }
        private void Wait()
        {
            Thread.Sleep(500);
        }
        public override void GoTo(int x, int y)
        {
            robot.GoTo(x, y);
            Wait();
        }

        public override bool CanMove(Diraction diraction)
        {
            return robot.CanMove(diraction);
        }
    }
}
