using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCWebApp.Backend.Model.Vo
{
    public class CourseSimpleVo
    {
        public Int64 id { get; set; }
        public String name { get; set; }
        public String description { get; set; }
        public String status { get; set; }
        public Int64 classNum { get; set; }
    }
}