using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPatternProject.Models
{
    abstract class RobotDecorator:IRobot
    {
        protected readonly IRobot robot;
        public RobotDecorator(IRobot robot)
        {
            this.robot = robot;
        }

        public abstract void Down();
        public abstract void Left();
        public abstract void Right();
        public abstract void Up();
        public abstract void GoTo(int x, int y);

        public abstract bool CanMove(Diraction diraction);
    }
}
