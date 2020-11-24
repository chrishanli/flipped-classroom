using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCWebApp.Backend.Model
{
    public class CoursePo
    {
        private Int64 id { get; set; }
        private String name { get; set; }
        private String description { get; set; }
        private Int16 weightSpeak { get; set; }
        private Int16 weightReport { get; set; }
        private Int16 weightAsk { get; set; }
        private Int64 groupingRegulationId { get; set; }
        private String status { get; set; }
    }
}