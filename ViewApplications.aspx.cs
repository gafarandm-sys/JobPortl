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
    public partial class ViewApplications : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // استخدام jobid بحروف صغيرة كما يظهر في الرابط الخاص بك
                if (Request.QueryString["jobid"] != null)
                {
                    int jobId = Convert.ToInt32(Request.QueryString["jobid"]);
                    BindApplicants(jobId);
                }
            }
        }

        private void BindApplicants(int jobId)
        {
            // التأكد من اسم ConnectionString كما هو في ملف الـ Web.config الخاص بك
            string strCon = ConfigurationManager.ConnectionStrings["JobPortalDBConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(strCon))
            {
                // الربط الصحيح لجلب اسم المستخدم والبريد من جدول Users
                // لاحظ استخدام A.JobSeekerId و U.UserId للربط
                string sql = @"SELECT U.Name, U.Email,A.ApplyDate, A.Status, A.ApplicationId 
                       FROM dbo.Applications A 
                       INNER JOIN dbo.Users U ON A.JobSeekerId = U.UserId 
                       WHERE A.JobId = @jid";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@jid", jobId);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                try
                {
                    sda.Fill(dt);
                    gvApplicants.DataSource = dt;
                    gvApplicants.DataBind();
                }
                catch (Exception ex)
                {
                    lblActionMsg.Text = "خطأ في حلب البيانات: " + ex.Message;
                    lblActionMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
        }



        protected void gvApplicants_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string appId = e.CommandArgument.ToString();
            string newStatus = (e.CommandName == "Accept") ? "Accepted" : (e.CommandName == "Reject") ? "Rejected" : "";

            if (!string.IsNullOrEmpty(newStatus))
            {
                UpdateApplicationStatus(appId, newStatus);
            }
        }

        private void UpdateApplicationStatus(string appId, string status)
        {
            string strCon = ConfigurationManager.ConnectionStrings["JobPortalDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strCon))
            {
                string sql = "UPDATE dbo.Applications SET Status = @status WHERE ApplicationId = @id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@id", appId);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    lblActionMsg.Text = "تم تحديث الحالة بنجاح إلى " + status;
                    lblActionMsg.ForeColor = System.Drawing.Color.Green;

                    // إعادة تحميل الجدول بعد التحديث
                    if (Request.QueryString["jobid"] != null)
                        BindApplicants(Convert.ToInt32(Request.QueryString["jobid"]));
                }
                catch (Exception ex)
                {
                    lblActionMsg.Text = "خطأ: " + ex.Message;
                    lblActionMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}