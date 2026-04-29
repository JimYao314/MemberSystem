using System;
using MemberSystem.Controllers; 
using MemberSystem.Models;   

namespace MemberSystem.Views
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

      
        protected void btnLogin_Click(object sender, EventArgs e)
        {
           
            string inputAccount = txtAccount.Text;
            string inputPassword = txtPassword.Text;

            
            UserManager userMgr = new UserManager();
            User user = userMgr.Login(inputAccount, inputPassword);

            
            if (user != null)
            {
                Session["CurrentUser"] = user;
                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                
                lblMessage.Text = "帳號或密碼錯誤，請重試。";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}