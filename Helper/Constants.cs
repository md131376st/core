using System;
using System.Collections.Generic;
using System.Text;

namespace core.Helper
{
    public class Constants
    {
        internal class Api
        {
            internal static Dictionary<Enumerations.Api, string> Urls = new Dictionary<Enumerations.Api, string>()
               {
                    {Enumerations.Api.BasicInformation, Information.Basic}
               };
            internal static Dictionary<Enumerations.Api, string> Methods = new Dictionary<Enumerations.Api, string>()
            {
                {Enumerations.Api.BasicInformation, "POST"}
            };
            private class Information
            {
                public static readonly string Basic = "http://ctdevtest.ir/api/MonaDavari";
            }
        }
    }
}
