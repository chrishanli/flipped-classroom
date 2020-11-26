using FCBackend.Dao;
using FCWebApp.Backend.Dao;
using FCWebApp.Backend.Model.Vo;
using FCWebApp.Backend.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCWebApp.Pages.Services
{
    /// <summary>
    /// DiscussHandler 的摘要说明
    /// </summary>
    public class DiscussHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Clear();
            context.Response.ContentType = "application/json;charset=utf-8";
            string methodName = context.Request.Params["method"];
            string aid;
            switch (methodName)
            {
                case "fetchAttendedDiscuss":
                    aid = context.Request.Params["aid"];
                    context.Response.Write(fetchDiscussAttend(Int64.Parse(aid)));
                    break;
                case "uploadFile":
                    aid = context.Request.Headers["aid"];
                    context.Response.Write(fetchDiscussAttend(Int64.Parse(aid)));
                    break;
            }
        }

        private string fetchDiscussAttend(Int64 attendId)
        {
            return "";
        }

        private bool uploadFile(Int64 disAttendId)
        {
            return true;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}