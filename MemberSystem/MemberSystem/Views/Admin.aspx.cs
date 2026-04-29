using System;
using MemberSystem.Controllers;
using MemberSystem.Models;

namespace MemberSystem.Views
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User)Session["CurrentUser"];
            if (user == null || user.RoleID != 1)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                UserManager userMgr = new UserManager();
                gvUserList.DataSource = userMgr.GetAllUsers();
                gvUserList.DataBind();
            }
        }
    }
}