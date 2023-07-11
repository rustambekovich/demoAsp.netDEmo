using demoAsp.netDemo.Domain.constatns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAsp.net.Service.Common.Helper
{
    public class TimeHelper
    {
        public static DateTime GetDateTime()
        {
            var dtTime = DateTime.UtcNow;
            dtTime.AddHours(TimeConstans.UTC);
            return dtTime;
        }
    }
}
