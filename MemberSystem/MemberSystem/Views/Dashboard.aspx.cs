using System;
using MemberSystem.Models;

namespace MemberSystem.Views
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User loggedInUser = (User)Session["CurrentUser"];
            if (loggedInUser == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                lblWelcome.Text = "歡迎回來，" + loggedInUser.UserName + "！您的權限等級是：" + loggedInUser.RoleID;

                btnChangePassword.Visible = false;
                btnViewProfile.Visible = false;  
                btnEditProfile.Visible = false;  
                btnUserList.Visible = false;      
                btnUserEdit.Visible = false;      

                
                btnChangePassword.Visible = true;

               
                if (loggedInUser.RoleID == 2 || loggedInUser.RoleID == 3)
                {
                    btnViewProfile.Visible = true;
                }

                
                if (loggedInUser.RoleID == 2)
                {
                    btnEditProfile.Visible = true;
                }

                
                if (loggedInUser.RoleID == 1)
                {
                    btnUserList.Visible = true;
                    btnUserEdit.Visible = true;
                }
            }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e) { Response.Redirect("ChangePassword.aspx"); }
        protected void btnViewProfile_Click(object sender, EventArgs e) { Response.Redirect("Profile.aspx"); }
        protected void btnEditProfile_Click(object sender, EventArgs e) { Response.Redirect("Profile.aspx"); }
        protected void btnUserList_Click(object sender, EventArgs e) { Response.Redirect("AdminList.aspx"); }
        protected void btnUserEdit_Click(object sender, EventArgs e) { Response.Redirect("AdminEdit.aspx"); }
    }
}