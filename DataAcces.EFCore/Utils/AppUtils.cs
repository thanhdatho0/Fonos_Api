using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.EFCore.Utils
{
    public static class AppUtils
    {
        public static string CalculateDurationToString(int duration)
        {
            int hours = duration / 60;
            int minutes = duration % 60;
            if (hours > 0 && minutes == 0)
                return $"{hours} giờ";
            else if (hours <= 0)
                return $"{minutes} phút";
            else
                return $"{hours} giờ {minutes} phút";
        }
    }
}
