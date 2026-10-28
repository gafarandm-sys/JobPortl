using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace JobPortal
{
    public partial class AdminDashborard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // أمان: التأكد أن الداخل هو Admin فقط
            if (Session["URole"] == null || Session["URole"].ToString() != "Admin")
            {
                Response.Redirect("~/Default.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadStats();
                LoadLatestData();
            }
        }

        private void LoadLatestData()
        {
            string strCon = ConfigurationManager.ConnectionStrings["JobPortalDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strCon))
            {
                // جلب أحدث 5 وظائف
                string sqlJobs = "SELECT TOP 5 Title, CreatedDate FROM Jobs ORDER BY CreatedDate DESC";
                SqlDataAdapter sdaJobs = new SqlDataAdapter(sqlJobs, con);
                DataTable dtJobs = new DataTable();
                sdaJobs.Fill(dtJobs);
                gvLatestJobs.DataSource = dtJobs;
                gvLatestJobs.DataBind();

                // جلب أحدث 5 مستخدمين
                string sqlUsers = "SELECT TOP 5 Name, Role FROM Users ORDER BY UserId DESC";
                SqlDataAdapter sdaUsers = new SqlDataAdapter(sqlUsers, con);
                DataTable dtUsers = new DataTable();
                sdaUsers.Fill(dtUsers);
                gvRecentUsers.DataSource = dtUsers;
                gvRecentUsers.DataBind();
            }
        }

        private void LoadStats()
        {
            string strCon = ConfigurationManager.ConnectionStrings["JobPortalDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                // جلب عدد المستخدمين
                hUsersCount.InnerText = new SqlCommand("SELECT COUNT(*) FROM Users", con).ExecuteScalar().ToString();
                // جلب عدد الوظائف
                hJobsCount.InnerText = new SqlCommand("SELECT COUNT(*) FROM Jobs", con).ExecuteScalar().ToString();
                // جلب عدد طلبات التقديم
                hAppsCount.InnerText = new SqlCommand("SELECT COUNT(*) FROM Applications", con).ExecuteScalar().ToString();
                // جلب عدد الـ CVs المرفوعة
                hCVsCount.InnerText = new SqlCommand("SELECT COUNT(*) FROM CVs", con).ExecuteScalar().ToString();
            }

        }
    }
}