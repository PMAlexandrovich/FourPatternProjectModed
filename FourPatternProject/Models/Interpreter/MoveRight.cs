using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPatternProject.Models
{
    class MoveRight:Expression<NotReturnValue>
    {
        public override NotReturnValue Interpret(IRobot robot)
        {
            robot.Right();
            return new NotReturnValue();
        }
    }
}
