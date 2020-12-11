using FCBackend.Dao;
using FCWebApp.Backend.Dao;
using FCWebApp.Backend.Model.Po;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FCWebApp.Pages
{
    public partial class FindPasswordPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // 提交找回密码请求, 找用户
            string username = txtUsername.Value;
            PersonPo userPo = PersonDao.getUser(username);
            if (userPo == null)
            {
                Response.Write("<script language='javascript'>");
                Response.Write("alert('你的输入有误，请重新输入');");
                Response.Write("</script>");
                return;
            }
            // 发送验证邮件
            if (userPo.email != null)
            {
                MailMessage mm = new MailMessage();
                mm.From = new MailAddress("do_not_reply@han-li.cn");
                mm.To.Add(new MailAddress(userPo.email));
                mm.Body = "尊敬的 " + userPo.alias + "先生/女士：\n有关  台端的密码找回请求已收悉。\n你的密码是：" + userPo.password + "\n请牢记密码及切勿告诉他人，以免影响信息安全。\nFlipped Classroom 小组敬上。";
                mm.Subject = "翻转课堂密码找回请求回应";

                SmtpClient sc = new SmtpClient();
                sc.Host = "smtp.ym.163.com";
                sc.Port = 25;
                sc.UseDefaultCredentials = false;
                sc.Credentials = new NetworkCredential("do_not_reply@han-li.cn", "hahaha");

                sc.Send(mm);
            }

            // 提示
            Response.Write("<script language='javascript'>");
            Response.Write("alert('如果你记录的邮件地址正确及可达，你的密码已发送至你记录的邮箱中，请查收。');");
            Response.Write("</script>");
            return;
        }
    }
}