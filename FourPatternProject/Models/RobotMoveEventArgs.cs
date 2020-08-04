using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPatternProject.Models
{
    class RobotMoveEventArgs:EventArgs
    {
        public int X { get; internal set; }
        public int Y { get; internal set; }
    }
}
