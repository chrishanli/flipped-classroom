using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCWebApp.Backend.Utils
{
    public class ResponseUtils
    {
        public static string makeNormalResponse(int responseCode, object responseObject)
        {
            Dictionary<String, Object> ret = new Dictionary<string, object>();
            ret.Add("errCode", responseCode);
            ret.Add("data", responseObject);

            return JsonConvert.SerializeObject(ret);
        }
        public static string makeErrorResponse(int responseCode)
        {
            Dictionary<String, Object> ret = new Dictionary<string, object>();
            ret.Add("errCode", responseCode);

            return JsonConvert.SerializeObject(ret);
        }
    }
}