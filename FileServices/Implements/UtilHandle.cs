using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace testC01.FileServices.Implements
{
    public class UtilHandle : IUtilHandle
    {
        // chuyển đổi giá trị thẻ 52 sang mili giay
        public double ConvertToSeconds(string timeString)
        {
            timeString = Regex.Replace(timeString, @"[\s+:]", "");
            int year = int.Parse(timeString.Substring(0, 4));
            int month = int.Parse(timeString.Substring(4, 2));
            int day = int.Parse(timeString.Substring(6, 2));
            int hour = int.Parse(timeString.Substring(8, 2));
            int minute = int.Parse(timeString.Substring(10, 2));
            double second = double.Parse(timeString.Substring(12));
            // ngày hiện tại trừ ngày nhỏ nhất
            double totalSeconds = new DateTime(year, month, day).Subtract(DateTime.MinValue).TotalSeconds + hour * 60 * 60 + minute * 60 + second;
            return totalSeconds;
        }
        private const string regex = @"52=\d{8}\s+\d{2}:\d{2}:[\d\.]+";
        //so sánh giá trị thẻ 52
        private int compareLine(string x, string y)
        {
            string tag52_1 = Regex.Match(x, regex).ToString().Substring(3);
            string tag52_2 = Regex.Match(y, regex).ToString().Substring(3);
            double totalSeconds1 = ConvertToSeconds(tag52_1);
            double totalSeconds2 = ConvertToSeconds(tag52_2);
            if (totalSeconds1 > totalSeconds2)
            {
                return 1;
            }
            if (totalSeconds1 < totalSeconds2)
            {
                return -1;
            }
            return 0;
        } 
        //sắp xếp theo giá trị thẻ 52 
        public List<string> Sort(List<string> allLines)
        {
            allLines.Sort(compareLine);
            return allLines;
        }
    }
}
