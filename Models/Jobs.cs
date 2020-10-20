using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TecolocoApi.Models
{
    public class Jobs
    {
        public string JobID { get; set; }
        public string JobName { get; set; }
        public string JobTitle { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}