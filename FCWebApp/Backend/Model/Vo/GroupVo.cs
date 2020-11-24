using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCWebApp.Backend.Model.Vo
{
    public class GroupVo
    {
        public Int64 id { get; set; }
        public String name { get; set; }
        public Int64 courseId { get; set; }
        public Int16 classNum { get; set; }
        public Int64 leaderId { get; set; }
        public String Status { get; set; }
    }
}