using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPatternProject.Models
{
    class While:Expression<NotReturnValue>
    {
        Expression<bool> check;
        Expression<NotReturnValue> commands;

        public While(Expression<bool> check, Expression<NotReturnValue> commands)
        {
            this.check = check;
            this.commands = commands;
        }

        public override NotReturnValue Interpret(IRobot robot)
        {
            while (check.Interpret(robot))
            {
                commands.Interpret(robot);
            }
            return new NotReturnValue();
        }
    }
}
