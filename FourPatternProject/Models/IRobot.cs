using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPatternProject.Models
{
    interface IRobot
    {
        void Up();
        void Down();
        void Left();
        void Right();
        void GoTo(int x, int y);
    }
}
