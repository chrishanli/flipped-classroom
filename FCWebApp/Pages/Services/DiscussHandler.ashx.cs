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
            string sid, aid, did;
            switch (methodName)
            {
                case "checkAttended":
                    sid = context.Request.Headers["id"];
                    did = context.Request.Params["did"];
                    context.Response.Write(isJoinedDiscuss(Int64.Parse(sid), Int64.Parse(did)));
                    break;
                case "attendDiscuss":
                    sid = context.Request.Headers["id"];
                    did = context.Request.Params["did"];
                    context.Response.Write(joinDiscuss(Int64.Parse(did), Int64.Parse(sid)));
                    break;
                case "uploadFile":
                    
                    break;
            }
        }

        private string isJoinedDiscuss(long sid, long did)
        {
            bool isJoined = DiscussDao.isAttended(did, sid);
            if (isJoined)
            {
                return "true";
            }
            return "false";
        }

        private string joinDiscuss(long stuId, long discussId)
        {
            return "";
        }

        private string fetchAttendedDiscuss(long sid, long did)
        {
            List<DiscussSimpleVo> voList = DiscussDao.ge(id);
            return voList == null ?
                ResponseUtils.makeErrorResponse(400) :
                ResponseUtils.makeNormalResponse(200, voList);
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