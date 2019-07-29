using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AccountingProjectWPF.Common
{
    public static class Helpers
    {
        //private static readonly Regex digitOnly = new Regex(@"^\d+(\.\d+)?$");
        private static readonly Regex digitOnly = new Regex(@"^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]*$");

        //public static bool TextOnly(char ch)
        //{
        //    return _regex.IsMatch(text);
        //}
        public static bool DigitOnly(string text)
        {
            return !digitOnly.IsMatch(text);
        }
    }
}
