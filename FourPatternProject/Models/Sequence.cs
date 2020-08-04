using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPatternProject.Models
{
    class Sequence:Expression
    {
        Expression first;
        Expression second;

        public Sequence(Expression first, Expression second)
        {
            this.first = first;
            this.second = second;
        }

        public override void Interpret(IRobot robot)
        {
            first.Interpret(robot);
            second.Interpret(robot);
        }
    }
}
