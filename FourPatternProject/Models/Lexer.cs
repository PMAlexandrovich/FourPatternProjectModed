using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPatternProject.Models
{
    class Lexer
    {
        Dictionary<string, string[]> rules = new Dictionary<string, string[]>()
        {
            { "id", new string[]{"while","end"} },
            {"command", new string[]{"up","left","down","right"}},
            {"endcom",  new string[]{ ";"} },
            {"check",new string[]{"on left free","on right free", "from above free", "from below free", "on left wall", "on right wall", "from above wall", "from below wall" }},

        };
        public List<Token> Handle(string input)
        {
            var output = new List<Token>();
            StringBuilder current = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ';')
                {
                    if (current.Length != 0 || output.Last().TokenName != "command") 
                    {
                        throw new Exception();
                    }
                    else
                    {
                        output.Add(new Token("endcom", ";"));
                        continue;
                    }
                }
                current.Append(input[i]);
                string temp = current.ToString();
                if(temp == Environment.NewLine)
                {
                    current.Clear();
                }
                foreach (var id in rules["id"])
                {
                    if(temp == id)
                    {
                        output.Add(new Token("id", temp));
                        current.Clear();
                    }
                }

                foreach (var command in rules["command"])
                {
                    if (temp == command)
                    {
                        output.Add(new Token("command", temp));
                        current.Clear();
                    }
                }
                foreach (var check in rules["check"])
                {
                    if (temp == check)
                    {
                        output.Add(new Token("check", temp));
                        current.Clear();
                    }
                }
            }
            if(current.Length != 0)
            {
                throw new Exception();
            }
            return output;
        }
    }

    struct Token
    {
        public string TokenName { get; set; }
        public string Value { get; set; }
        public Token(string name,string value)
        {
            TokenName = name;
            Value = value;
        }
    }
}
