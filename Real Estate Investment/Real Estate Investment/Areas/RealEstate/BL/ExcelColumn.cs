using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.BL
{
    public class ExcelColumn
    {
        public static int toNumber(String name)
        {
            int number = 0;
            for (int i = 0; i < name.Length; i++)
            {
                number = number * 26 + (name[i] - ('A' - 1));
            }
            return number;
        }

        public static String toName(int number)
        {
            StringBuilder sb = new StringBuilder();
            while (number-- > 0)
            {
                sb.Append((char)('A' + (number % 26)));
                number /= 26;
            }
            return new string(sb.ToString().Reverse().ToArray());
        }
    }
}