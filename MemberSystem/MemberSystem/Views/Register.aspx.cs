using System;
using MemberSystem.Controllers; 
using MemberSystem.Models;     

namespace MemberSystem.Views
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

       
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            
            User newUser = new User();

           
            newUser.Account = txtAccount.Text;
            newUser.Password = txtPassword.Text;
            newUser.UserName = txtName.Text;

           
            newUser.Birthday = Convert.ToDateTime(txtBirthday.Text);

            newUser.Email = txtEmail.Text;

           
            newUser.RoleID = Convert.ToInt32(ddlRole.SelectedValue);

            
            UserManager userMgr = new UserManager();
            int result = userMgr.Register(newUser);

           
            if (result == 1)
            {
                lblMessage.Text = "註冊成功！歡迎加入 Small World！請前往登入。";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            else if (result == -1)
            {
                lblMessage.Text = "糟糕！這個帳號已經有人使用了，請換一個帳號。";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblMessage.Text = "系統發生未知錯誤，請稍後再試。";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}