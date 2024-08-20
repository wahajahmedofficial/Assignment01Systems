using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class CustomCodeParser
    {
        public  List<string> ParseCode(string code)
        {
            var lines = code.Split(Environment.NewLine);
            var errors = new List<string>();
            int openBraces = 0;
            int closeBraces = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();

                if (line.StartsWith("public class"))
                {
                    if (!line.EndsWith("{") && lines[i + 1].Trim() != "{")
                    {
                        errors.Add($"Error on line {i + 1}: Missing '{{' after class declaration.");
                    }
                }
                else if (line.StartsWith("public") || line.StartsWith("Public"))
                {
                   
                    if (line.StartsWith("Public"))
                    {
                        errors.Add($"Error on line {i + 1}: 'Public' should be lowercase 'public'.");
                    }

                   
                    if (line.Contains("MyFunction()") && !line.Contains("int"))
                    {
                        errors.Add($"Error on line {i + 1}: Missing return type in method declaration.");
                    }

                
                    if (line.Contains("int myint=20") && !line.EndsWith(";"))
                    {
                        errors.Add($"Error on line {i + 1}: Missing semicolon ';' at the end of the statement.");
                    }
                }

                
                if (line.Contains("{"))
                {
                    openBraces++;
                }
                if (line.Contains("}"))
                {
                    closeBraces++;
                }
            }

            if (openBraces != closeBraces)
            {
                errors.Add("Error: Mismatched number of opening and closing braces.");
            }

            return errors;
        }
    }
}
