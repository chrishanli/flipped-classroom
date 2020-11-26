using FCBackend.Dao;
using FCWebApp.Backend.Database;
using FCWebApp.Backend.Model.Vo;
using FCWebApp.Backend.Utils;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCWebApp.Service
{
    public class StudentServiceHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Clear();
            context.Response.ContentType = "application/json;charset=utf-8";
            string methodName = context.Request.Params["method"];
            long userId = long.Parse(context.Request.Headers["id"]);
            switch (methodName)
            {
                case "fetchCourses":
                    context.Response.Write(fetchCourses(userId));
                    break;
            }
        }

        private string fetchCourses(long id)
        {
            List<CourseSimpleVo> voList = PersonDao.getCoursesByStuId(id);
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