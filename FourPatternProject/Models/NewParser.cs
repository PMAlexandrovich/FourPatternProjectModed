using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPatternProject.Models
{
    class NewParser
    {
        public Expression Parse(string code)
        {
            Lexer lexer = new Lexer();
            var tokens = lexer.Handle(code);
        }

        private Expression BuildTree(string[] commands, int index)
        {
            if (index < commands.Length - 1)
                return new Sequence(GetMoveCommand(commands[index]), BuildTree(commands, ++index));
            else
                return GetMoveCommand(commands[index]);
        }

        private Expression GetMoveCommand(string command)
        {
            switch (command)
            {
                case "up":
                    return new MoveUp();
                case "down":
                    return new MoveDown();
                case "left":
                    return new MoveLeft();
                case "right":
                    return new MoveRight();
                default:
                    throw new ArgumentException("Некоректная команда");
            }
        }
    }
}
