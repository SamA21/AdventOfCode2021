using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{
    public class NavigationSubsystem
    {
        public int FindTotalSyntaxErrorScore(List<string> data)
        {
            List<char> syntaxErrors = new List<char>();
            foreach (var line in data)
            {
                var error = GetSynatxError(line);
                if(!char.IsWhiteSpace(error))
                    syntaxErrors.Add(error);
            }
            int totalError = CountErrors(syntaxErrors);
            return totalError;
        }

        private int CountErrors(List<char> errors)
        {
            int totalCount = 0;
            foreach (char error in errors)
            {
                switch (error)
                {
                    case ')':
                        totalCount += 3;
                        break;
                    case ']':
                        totalCount += 57;
                        break;
                    case '}':
                        totalCount += 1197;
                        break;
                    case '>':
                        totalCount += 25137;
                        break;
                }
            }
            return totalCount;
        }

        private char GetSynatxError(string line)
        {
            char currentSearch = ' ';
            List<(char, bool?)> errors = new List<(char, bool?)>();
            foreach(char c in line)
            {
                if (IsOpenBracket(c))
                {
                    currentSearch = c;
                    errors.Add(new(c, false));
                }
                else if(c == ClosedBracket(currentSearch))
                {
                    errors.Add(new (c, true));
                    var matchedOpen = errors.Last(x => x.Item1 == OpenBracket(c) && x.Item2.HasValue && !x.Item2.Value);
                    int matchedIndex = errors.LastIndexOf(matchedOpen);
                    matchedOpen.Item2 = true;
                    errors[matchedIndex] = matchedOpen;
                    currentSearch = errors.LastOrDefault(x => x.Item2.HasValue && !x.Item2.Value).Item1;
                }            
                else
                {
                    errors.Add(new(c, null));
                }
            }

            var hasErrors = errors.Any(x => x.Item2 == null);
            if (hasErrors)
            {
                return errors.First(x => x.Item2 == null).Item1;
            }
            else
            {
                return ' ';
            }
        }

        private bool IsOpenBracket(char c)
        {
            switch (c)
            {
                case '{':
                    return true;
                case '[':
                    return true;
                case '(':
                    return true;
                case '<':
                    return true;
                default:
                    return false;
            }
        }
        private char ClosedBracket(char c)
        {
            switch (c)
            {
                case '{':
                    return '}';
                case '[':
                    return ']';
                case '(':
                    return ')';
                case '<':
                    return '>';
                default:
                    return c;
            }
        }
        private char  OpenBracket(char c)
        {
            switch (c)
            {
                case '}':
                    return '{';
                case ']':
                    return '[';
                case ')':
                    return '(';
                case '>':
                    return '<';
                default:
                    return c;
            }
        }
    }
}
