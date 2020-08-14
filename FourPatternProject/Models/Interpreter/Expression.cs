using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPatternProject.Models
{
    abstract class Expression<T>
    {
        public abstract T Interpret(IRobot robot);
    }
}
