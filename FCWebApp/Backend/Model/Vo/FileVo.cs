using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCWebApp.Backend.Model.Vo
{
    public class FileVo
    {
        public Int64 id { get; set; }
        public Int64 attendId { get; set; }
        public String uploadTime { get; set; }
        public String fileName { get; set; }
        public String fileUrl { get; set; }
    }
}