using core.Helper;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace core.Control
{
    public  static class GeneralControl
    {
        public  static bool Request(Enumerations.Api api, HttpContent data)
        {
            if (GetMethod(api) == "POST")
            {
                using var client = new HttpClient();
                
                var response = client.PostAsync(GetUrl(api), data);
                var result = response.Result;
                if ((int)result.StatusCode == 200)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        static string GetMethod(Enumerations.Api api)
        {
            return Constants.Api.Methods[api];
        }
        static string GetUrl(Enumerations.Api api)
        {
            return Constants.Api.Urls[api];
        }
    }
}
