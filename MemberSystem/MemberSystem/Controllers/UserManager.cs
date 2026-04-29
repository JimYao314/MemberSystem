using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MemberSystem.Models;

namespace MemberSystem.Controllers
{
    public class UserManager
    {
        // ==========================================
        // 登入驗證
        // ==========================================
        public User Login(string account, string password)
        {
            string connString = ConfigurationManager.ConnectionStrings["MemberDB"].ConnectionString;
            User loginUser = null;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_LoginUser", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Account", account);
                    cmd.Parameters.AddWithValue("@Password", password);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            loginUser = new User();
                            loginUser.UserID = Convert.ToInt32(reader["UserID"]);
                            loginUser.UserName = reader["UserName"].ToString();
                            loginUser.RoleID = Convert.ToInt32(reader["RoleID"]);
                        }
                    }
                }
            }
            return loginUser;
        }

        // ==========================================
        // 註冊
        // ==========================================
        public int Register(User newUser)
        {
            int result = 0;
            string connString = ConfigurationManager.ConnectionStrings["MemberDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RegisterUser", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Account", newUser.Account);
                    cmd.Parameters.AddWithValue("@Password", newUser.Password);
                    cmd.Parameters.AddWithValue("@UserName", newUser.UserName);
                    cmd.Parameters.AddWithValue("@Birthday", newUser.Birthday);
                    cmd.Parameters.AddWithValue("@Email", newUser.Email);
                    cmd.Parameters.AddWithValue("@RoleID", newUser.RoleID);

                    conn.Open();
                    object res = cmd.ExecuteScalar();
                    if (res != null)
                    {
                        result = Convert.ToInt32(res);
                    }
                }
            }
            return result;
        }

        // ==========================================
        // 修改密碼
        // ==========================================
        public int ChangePassword(int userId, string newPassword)
        {
            int result = 0;
            string connString = ConfigurationManager.ConnectionStrings["MemberDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_UpdatePassword", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@NewPassword", newPassword);

                    conn.Open();
                    object res = cmd.ExecuteScalar();
                    if (res != null)
                    {
                        result = Convert.ToInt32(res);
                    }
                }
            }
            return result;
        }
        // ==========================================
        // 調閱個人資料
        // ==========================================
        public User GetUserInfo(int userId)
        {
            string connString = ConfigurationManager.ConnectionStrings["MemberDB"].ConnectionString;
            User userInfo = null;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetUserInfo", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", userId);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userInfo = new User();
                            userInfo.UserID = userId;

                            
                            userInfo.Account = reader["Account"] != DBNull.Value ? reader["Account"].ToString() : "";
                            userInfo.UserName = reader["UserName"] != DBNull.Value ? reader["UserName"].ToString() : "";
                            userInfo.Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : "";

                            if (reader["Birthday"] != DBNull.Value)
                            {
                                userInfo.Birthday = Convert.ToDateTime(reader["Birthday"]);
                            }

                            if (reader["RoleID"] != DBNull.Value)
                            {
                                userInfo.RoleID = Convert.ToInt32(reader["RoleID"]);
                            }
                        }
                    }
                }
            }
            return userInfo;
        }
        public int UpdateUserInfo(User user)
        {
            int result = 0;
            string connString = ConfigurationManager.ConnectionStrings["MemberDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_UpdateUserInfo", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", user.UserID);
                    cmd.Parameters.AddWithValue("@UserName", user.UserName);
                    cmd.Parameters.AddWithValue("@Birthday", user.Birthday);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    conn.Open();
                    result = Convert.ToInt32(cmd.ExecuteScalar()); 
                }
            }
            return result;
        }
        public DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();
            string connString = ConfigurationManager.ConnectionStrings["MemberDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                
                string sql = "SELECT * FROM v_UserRoleList";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt); 
                    }
                }
            }
            return dt;
        }
        public void UpdateRole(int userId, int newRole)
        {
            string connString = ConfigurationManager.ConnectionStrings["MemberDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_Admin_UpdateRole", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TargetUserID", userId);
                    cmd.Parameters.AddWithValue("@NewRoleID", newRole);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}