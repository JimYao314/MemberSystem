using System;
using System.Web.UI.WebControls; 
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
                LoadUserList();
            }
        }

        private void LoadUserList()
        {
            UserManager userMgr = new UserManager();
            gvUserList.DataSource = userMgr.GetAllUsers();
            gvUserList.DataBind();
        }

        protected void gvUserList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "UpdateRole")
            {
                int targetUserId = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = (GridViewRow)((Button)e.CommandSource).NamingContainer;
                DropDownList ddl = (DropDownList)row.FindControl("ddlNewRole");
                int newRole = Convert.ToInt32(ddl.SelectedValue);

                UserManager userMgr = new UserManager();
                userMgr.UpdateRole(targetUserId, newRole);

                Response.Redirect("Admin.aspx");
            }
        }
    }
}