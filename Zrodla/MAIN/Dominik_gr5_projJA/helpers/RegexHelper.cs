using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ColorToGrayScale.helpers
{
    public class RegexHelper
    {
        private string regexPattern = String.Empty;

        public string SearchString(string separator, IEnumerable<string> lines)
        {
            Regex regex = new Regex(regexPattern);

            var regexMatch = lines.Where<string>(x => regex.IsMatch(x));

            return String.Join(separator, regexMatch); 
        }

        public void AddSearchPattern(bool condition, string partialPattern)
        {
            if (condition)
            {
                AddSeparator();
                this.regexPattern += partialPattern;
            }
        }

        public void AddSeparator()
        {
            if (regexPattern.Length > 0)
            {
                regexPattern += "|";
            }
        }
    }
}
