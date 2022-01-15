using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace VitoshaClient.Helpers
{
    public static class UrlHelper
    {

        public static string Combine(params string[] url)
        {
            var res = String.Join("/", url);
            res = Regex.Replace(res, @"(?<!\:)\/{2,}", "/");
            return res;
        }

    }
}
