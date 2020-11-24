using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCWebApp.Backend.Model.Vo
{
    public class DiscussSigninVo
    {
        public Int64 id { get; set; }
        public Int64 groupId { get; set; }
        public Int64 signInTime { get; set; }
        public Int64 discussId { get; set; }
    }
}