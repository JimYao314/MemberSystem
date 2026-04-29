using MemberSystem.Controllers;
using MemberSystem.Models;
using System;
using System.Xml.Linq;

namespace MemberSystem.Views
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentUser"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            
            if (!IsPostBack)
            {
                User loggedInUser = (User)Session["CurrentUser"];
                UserManager userMgr = new UserManager();

                
                User userInfo = userMgr.GetUserInfo(loggedInUser.UserID);

                if (userInfo != null)
                {
                    
                    lblAccount.Text = userInfo.Account;
                    txtName.Text = userInfo.UserName;
                    txtEmail.Text = userInfo.Email;

                    
                    if (userInfo.Birthday != DateTime.MinValue)
                    {
                        txtBirthday.Text = userInfo.Birthday.ToString("yyyy-MM-dd");
                    }

                    
                    if (loggedInUser.RoleID == 3)
                    {
                        
                        txtName.ReadOnly = true;
                        txtBirthday.ReadOnly = true;
                        txtEmail.ReadOnly = true;
                    }
                    else if (loggedInUser.RoleID == 2 || loggedInUser.RoleID == 1)
                    {
                        
                        btnSave.Visible = true;
                    }
                }
            }
        }

        
        protected void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}