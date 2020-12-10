using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCWebApp.Backend.Model.Vo
{
    public class QuestionVo
    {
        public Int64 id { get; set; }
        public String questionDate { get; set; }
        public String topic { get; set; }
        public String contents { get; set; }
    }
}