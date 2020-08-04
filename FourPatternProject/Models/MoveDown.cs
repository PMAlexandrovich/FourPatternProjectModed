﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPatternProject.Models
{
    class MoveDown:Expression
    {
        public override void Interpret(IRobot robot)
        {
            robot.Down();
        }
    }
}
