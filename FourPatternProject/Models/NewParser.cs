using FourPatternProject.Models.Interpreter.checks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPatternProject.Models
{
    class NewParser
    {
        private Stack<Token> tokens;
        private List<Expression<NotReturnValue>> expressions = new List<Expression<NotReturnValue>>();
        private int index;
        public Expression<NotReturnValue> Parse(string code)
        {
            Lexer lexer = new Lexer();
            index = 0;
            tokens = new Stack<Token>(lexer.Handle(code).AsEnumerable());
            return MakeTree(BuildTree(),0);
        }

        private List<Expression<NotReturnValue>> BuildTree()
        {
            List<Expression<NotReturnValue>> expressions = new List<Expression<NotReturnValue>>();
            while (tokens.Count != 0)
            {
                Token token = tokens.Pop();
                if(token.TokenName == "endid")
                {
                    return expressions;
                }
                if (token.TokenName == "command")
                {
                    var secondToken = tokens.Pop();
                    if (secondToken.TokenName == "endcom")
                    {
                        index += 2;
                        expressions.Add(GetMoveCommand(token.Value));
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                else if (token.TokenName == "id")
                {
                    index += 2;
                    token = tokens.Pop();
                    expressions.Add(new While(GetCheck(token.Value), MakeTree(BuildTree(),0)));
                }
                else
                {
                    throw new Exception();
                }
            }
            return expressions;
        }

        private Expression<NotReturnValue> MakeTree(List<Expression<NotReturnValue>> expressions, int index)
        {
            if(index == expressions.Count)
            {
                return expressions[index];
            }
            else
            {
                return new Sequence(expressions[index], MakeTree(expressions, ++index));
            }
        }

        private Expression<bool> GetCheck(string check)
        {
            switch (check)
            {
                case "on left free":
                    return new OnLeftFree();
                case "on right free":
                    return new OnRightFree();
                case "from above free":
                    return new FromAboveFree();
                case "from below free":
                    return new FromBelowFree();
                case "on left wall":
                    return new OnLeftWall();
                case "on right wall":
                    return new OnRightWall();
                case "from above wall":
                    return new FromAboveWall();
                case "from below wall":
                    return new FromBelowWall();
                default:
                    throw new Exception();
            }
        }

        private Expression<NotReturnValue> GetMoveCommand(string command)
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
