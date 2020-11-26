using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCWebApp.Backend.Model.Vo
{
    public class DiscussSigninVo
    {
        public Int64 id { get; set; }
        public Int64 stuId { get; set; }
        public string signInTime { get; set; }
        public Int64 discussId { get; set; }
    }
}