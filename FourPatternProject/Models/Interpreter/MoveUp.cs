using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPatternProject.Models
{
    class MoveUp:Expression<NotReturnValue>
    {
        public override NotReturnValue Interpret(IRobot robot)
        {
            robot.Up();
            return new NotReturnValue();
        }
    }
}
