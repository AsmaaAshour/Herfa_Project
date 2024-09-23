using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herfa.Helpers
{
    public class CommonMethods
    {
           public static void NavigateToURL(string url)
        {
            ManageDriver.driver.Navigate().GoToUrl(url);
        }
    }
}
