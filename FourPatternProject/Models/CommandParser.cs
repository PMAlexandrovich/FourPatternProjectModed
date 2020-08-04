using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPatternProject.Models
{
    class CommandParser
    {
        public Expression Parse(string code)
        {
            if (String.IsNullOrWhiteSpace(code))
                throw new ArgumentNullException("", "Сначала введите команды");

            var commands = code.Replace(" ","")
                .Replace(Environment.NewLine,"")
                .ToLower()
                .Split(new char[] { ';' },StringSplitOptions.RemoveEmptyEntries);

            return BuildTree(commands, 0);
        }

        private Expression BuildTree(string[] commands,int index)
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
