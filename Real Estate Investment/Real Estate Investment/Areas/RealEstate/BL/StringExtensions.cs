using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.BL
{
    public static class StringExtensions
    {
        public static string SafeReplace(this string input, string find, string replace, bool matchWholeWord)
        {
            string textToFind = matchWholeWord ? string.Format(@"\B{0}\b", find) : find;
            return Regex.Replace(input, textToFind, replace,RegexOptions.Compiled);
        }

    }
}