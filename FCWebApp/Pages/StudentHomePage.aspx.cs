﻿using FCBackend.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FCWebApp.Pages
{
    public partial class StudentHomePage : System.Web.UI.Page
    {
        public Int64 studentId;
        public String name;
        protected void Page_Load(object sender, EventArgs e)
        {
            studentId = 4;
            // 获取学生的姓名
            name = PersonDao.getStudentName(studentId);
        }
    }
}