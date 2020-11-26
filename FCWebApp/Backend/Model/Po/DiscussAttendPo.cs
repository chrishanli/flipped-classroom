using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCWebApp.Backend.Model.Po
{
    public class DiscussAttendPo
    {
        public long id { get; set; }
        public long discussId { get; set; }
        public long stuId { get; set; }
        public DateTime signinTime { get; set; }
    }
}