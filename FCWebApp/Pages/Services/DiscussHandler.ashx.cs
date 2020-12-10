using FCBackend.Dao;
using FCWebApp.Backend.Dao;
using FCWebApp.Backend.Model.Vo;
using FCWebApp.Backend.Utils;
using System;
using System.Collections.Generic;
using System.IO;
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
                case "uploadFile": // 在用了
                    uploadFile(context);
                    break;
                case "getUploadedFiles":
                    sid = context.Request.Headers["id"];
                    aid = context.Request.Params["aid"];
                    context.Response.Write(getUploadedFiles(Int64.Parse(sid), Int64.Parse(aid)));
                    break;
            }
        }

        private string getUploadedFiles(long sid, long aid)
        {
            List<FileVo> voList = DiscussDao.getUploadedFiles(aid, sid);
            return voList == null ?
               ResponseUtils.makeErrorResponse(400) :
               ResponseUtils.makeNormalResponse(200, voList);
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
            bool isJoined = DiscussDao.attend(discussId, stuId);
            if (isJoined)
            {
                return "true";
            }
            return "false";
        }


        private bool uploadFile(HttpContext context)
        {
            string aid = context.Request.Headers["aid"];
            if (context.Request.Files.Count > 0)
            {
                // 全数上传
                HttpFileCollection files = context.Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    // 上传一个文件
                    HttpPostedFile file = files[i];
                    string filenameBeforeUpload = file.FileName;
                    string filenameInDB = Guid.NewGuid().ToString() + Path.GetExtension(filenameBeforeUpload);
                    string fname = context.Server.MapPath("~/UploadFiles/" + filenameInDB);
                    file.SaveAs(fname);
                    // 然后，有关数据保存入数据库
                    bool saveOK = DiscussDao.addFile(long.Parse(aid), filenameInDB, filenameBeforeUpload);
                }
                context.Response.ContentType = "text/plain";
                context.Response.Write("File Uploaded Successfully!");
            }
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