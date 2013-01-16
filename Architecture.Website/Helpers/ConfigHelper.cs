using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Architecture.Website.Helpers
{
    public class ConfigHelper
    {
        public static int PageSize()
        {
            return int.Parse(WebConfigurationManager.AppSettings["AppPageSize"]);
        }
    }
}