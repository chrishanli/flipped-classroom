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
        public string signinStartTime { get; set; }
        public string signinEndTime { get; set; }
        public string signinStatus { get; set; }
        public String contents { get; set; }
    }
}