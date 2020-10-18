
using core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using core.Helper;

namespace core.Control
{
    public static class InFoControl
    {
        public static List<Info> GetData()
        {
            using (var db = new TestDBContext())
            {
                try
                {
                   return db.Info.ToList();


                }
                catch (Exception ex)
                {
                    var log = NLog.LogManager.GetCurrentClassLogger();
                    log.Debug(ex.Message);
                    return new List<Info>();
                }
            }
        }

        public static bool sendData()
        {
            try
            {
                //var data = GetData();
                //foreach (var item in data)
                //{
                //    var json = JsonConvert.SerializeObject(item);
                var json = JsonConvert.SerializeObject(new Info() { Name = "test1", Age = 20, IsFemale = false });
                    var postData = new StringContent(json, Encoding.UTF8, "application/json");
                    var result = GeneralControl.Request(Enumerations.Api.BasicInformation, postData);
                    if (result == false)
                        return false;


                //}
                return true;
            }
            catch (Exception ex)
            {
                var log = NLog.LogManager.GetCurrentClassLogger();
                log.Error(ex.Message);
                return false;
            }
            
        }
    }

    
}
