using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Zoom_Integration.Utilites
{
    public static class Utilities
    {
        public static string buildQueryString(string filter)
        {
            JObject jObj = (JObject)JToken.FromObject(filter);

            //Build query string
            var query = String.Join("&",
                            jObj.Children().Cast<JProperty>()
                            .Select(
                                jp => (!string.IsNullOrEmpty(jp.Value.ToString()) ? (jp.Name + "=") : string.Empty) + (!string.IsNullOrEmpty(jp.Value.ToString()) ? HttpUtility.UrlEncode(jp.Value.ToString()) : string.Empty)
                            ).Where(p => !string.IsNullOrEmpty(p.ToString()))
                            );
            return query;
        }
    }
}
