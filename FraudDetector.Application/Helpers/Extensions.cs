using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FraudDetector.Application.Helpers
{
    static class Extensions
    {
        public static int GetDaysFromDate(this DateTime dateTime)
        {
            return (DateTime.Now - dateTime).Days;
        }
    }
}
