using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibs
{
    public class DataValidity
    {
        //Check if the data is numeric
        public static bool CheckIsNumber(string s)
        {
            int a;
            if (int.TryParse(s, out a))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Check if the data is an integer
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool CheckIsNumberInt(string s)
        {
            int a;
            if (int.TryParse(s, out a))
            {
                if (int.MaxValue >= a)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Check if the date is correct
        /// </summary>
        /// <param name="sDate"></param>
        /// <returns></returns>
        public static bool CheckIsDateTime(string sDate)
        {
            DateTime dDatetime;
            if (DateTime.TryParse(sDate, out dDatetime))
            {
                return true;
            }
            return false;
        }
    }
}
