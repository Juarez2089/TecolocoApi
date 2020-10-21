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
        public Jobs GetJob(string id)
        {
            cliente = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = cliente.Get("Jobs/" + id);
            Jobs data = JsonConvert.DeserializeObject<Jobs>(response.Body);
            return data;
        }
        [HttpPost]
        public bool InsertJob(Jobs job)
        {
            bool IsOk = false;
            try
            {
                job.CreateAt = DateTime.Now;
                cliente = new FireSharp.FirebaseClient(config);
                var data = job;
                PushResponse response = cliente.Push("Jobs/", data);
                data.JobID = response.Result.name;
                SetResponse setResponse = cliente.Set("Jobs/" + data.JobID, data);
                IsOk = true;
            }
            catch (Exception ex)
            {
            }
            return IsOk;
        }git
    }
}
