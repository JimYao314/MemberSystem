using System;
using MemberSystem.Controllers; 
using MemberSystem.Models;      


namespace MemberSystem.Views
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["CurrentUser"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        
        protected void btnSubmitChange_Click(object sender, EventArgs e)
        {
            
            string newPwd = txtNewPassword.Text;

            
            User loggedInUser = (User)Session["CurrentUser"];

            
            UserManager userMgr = new UserManager();
            int result = userMgr.ChangePassword(loggedInUser.UserID, newPwd);

            
            if (result == 1)
            {
                lblMessage.Text = "密碼修改成功！";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMessage.Text = "密碼修改失敗，請稍後再試。";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        
    }
}