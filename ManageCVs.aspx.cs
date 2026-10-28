using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;


namespace JobPortal
{   

    public partial class ManageCVs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //استدعاء دالة التحميل مع تمرير النص المكتوب في مربع البحث
            LoadAllCVs(txtSearch.Text.Trim());

        }
        private void LoadAllCVs(string searchTerm = "")
        {
            string strCon = ConfigurationManager.ConnectionStrings["JobPortalDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strCon))
            
           {
                // استعلام يربط المستخدمين بجدول السير الذاتية لجلب الأسماء مع الملفات
                string sql = @"SELECT U.Name, U.Email, C.CVId, C.FilePath 
                       FROM dbo.Users U 
                       INNER JOIN dbo.CVs C ON U.UserId = C.JobSeekerId";

                if (!string.IsNullOrEmpty(searchTerm))
                    sql += " WHERE U.Name LIKE @search";

                SqlCommand cmd = new SqlCommand(sql, con);
                if (!string.IsNullOrEmpty(searchTerm))
                    cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%");

                con.Open();
                gvAllCVs.DataSource = cmd.ExecuteReader();
                gvAllCVs.DataBind();
            }
        }



    }
}