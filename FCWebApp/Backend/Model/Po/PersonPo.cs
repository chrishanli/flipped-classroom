using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCWebApp.Backend.Model.Po
{
    public class PersonPo
    {
        public String type { get; set; }
        public long id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string alias { get; set; }
        public string email { get; set; }
        public string status { get; set; }
    }
}