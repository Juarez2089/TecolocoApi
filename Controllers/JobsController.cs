using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TecolocoApi.Models;

namespace TecolocoApi.Controllers
{
    public class JobsController : ApiController
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "GUTDAp1soq90dwqPDnNmnsiBPmD21ZLeCEHJqhzL",
            BasePath = "https://tecoapp-b11a1.firebaseio.com/"
        };
        IFirebaseClient cliente;
        [HttpGet]
        public IEnumerable<Jobs> GetJobs()
        {
            cliente = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = cliente.Get("Jobs");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            var list = new List<Jobs>();
            if (data != null)
            {
                foreach (var item in data)
                {
                    list.Add(JsonConvert.DeserializeObject<Jobs>(((JProperty)item).Value.ToString()));
                }
            }

            return list;
        }
    }
}
