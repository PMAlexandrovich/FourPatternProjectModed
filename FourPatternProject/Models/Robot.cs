using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FourPatternProject.Models
{
    class Robot:IRobot
    {
        private int x = 0;
        private int y = 0;

        public event EventHandler<RobotMoveEventArgs> OnRobotMove;

        public int X
        {
            get => x;
            set {
                x = value;
            }
        }
        public int Y { get => y;
            set
            {
                y = value;
            }
        }
        

        public void Up()
        {
            Y++;
            OnRobotMove(this, new RobotMoveEventArgs() { X = X, Y = Y });
        }
        public void Down()
        {
            Y--;
            OnRobotMove(this, new RobotMoveEventArgs() { X = X, Y = Y });
        }
        public void Left()
        {
            X--;
            OnRobotMove(this, new RobotMoveEventArgs() { X = X, Y = Y });
        }
        public void Right()
        {
            X++;
            OnRobotMove(this, new RobotMoveEventArgs() { X = X, Y = Y });
        }

        public void GoTo(int x, int y)
        {
            X = x;
            Y = y;
            OnRobotMove(this, new RobotMoveEventArgs() { X = X, Y = Y });
        }

    }
}
