using FCWebApp.Backend.Dao;
using FCWebApp.Backend.Model.Vo;
using FCWebApp.Backend.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCWebApp.Pages.Services
{
    public class CourseHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Clear();
            context.Response.ContentType = "application/json;charset=utf-8";
            string methodName = context.Request.Params["method"];
            switch (methodName)
            {
                case "fetchDiscuss":
                    string courseId = context.Request.Params["cid"];
                    context.Response.Write(fetchDiscuss(Int64.Parse(courseId)));
                    break;
            }
        }

        private string fetchDiscuss(Int64 courseId)
        {
            List<DiscussSimpleVo> voList = CourseDao.getDiscussByCourseId(courseId);
            return voList == null ?
                ResponseUtils.makeErrorResponse(400) :
                ResponseUtils.makeNormalResponse(200, voList);
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