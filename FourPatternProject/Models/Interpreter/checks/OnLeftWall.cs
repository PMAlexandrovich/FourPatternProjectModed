using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPatternProject.Models.Interpreter.checks
{
    class OnLeftWall:Expression<bool>
    {
        public override bool Interpret(IRobot robot)
        {
            return !robot.CanMove(Diraction.Left);
        }
    }
}
