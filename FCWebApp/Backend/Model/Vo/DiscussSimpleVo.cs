using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCWebApp.Backend.Model.Vo
{
    public class DiscussSimpleVo
    {
        public Int64 id { get; set; }
        public String topic { get; set; }
        public Int32 sn { get; set; }
        public Int64 signinStartTime { get; set; }
        public Int64 signinEndTime { get; set; }
        public String contents { get; set; }
    }
}