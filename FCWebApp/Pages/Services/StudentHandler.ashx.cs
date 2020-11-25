﻿using FCBackend.Dao;
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
            switch (methodName)
            {
                case "fetchCourses":
                    context.Response.Write(fetchCourses());
                    break;
            }
        }

        private string fetchCourses()
        {
            List<CourseSimpleVo> voList = PersonDao.getCoursesByStuId(2);
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