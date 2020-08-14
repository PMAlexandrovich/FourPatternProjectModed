using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPatternProject.Models
{
    class Sequence:Expression<NotReturnValue>
    {
        Expression<NotReturnValue> first;
        Expression<NotReturnValue> second;

        public Sequence(Expression<NotReturnValue> first, Expression<NotReturnValue> second)
        {
            this.first = first;
            this.second = second;
        }

        public override NotReturnValue Interpret(IRobot robot)
        {
            first.Interpret(robot);
            second.Interpret(robot);
            return new NotReturnValue();
        }
    }
}
