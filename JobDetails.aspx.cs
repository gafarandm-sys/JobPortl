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
    public partial class JobDetails : System.Web.UI.Page
    {
        string strCon = ConfigurationManager.ConnectionStrings["JobPortalDBConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            // نستخدم QueryString["id"] مباشرة للتأكد من ثبات القيمة
            if (string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                Response.Redirect("Jobs.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadJobData();
                CheckUserRole();
            }
        }

        private void LoadJobData()
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                string sql = "SELECT * FROM Jobs WHERE JobId = @id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblTitle.Text = dr["Title"].ToString();
                    lblLocation.Text = dr["Location"].ToString();
                    lblSalary.Text = dr["Salary"].ToString();
                    lblDate.Text = Convert.ToDateTime(dr["CreatedDate"]).ToShortDateString();
                    lblDesc.Text = dr["Description"].ToString();
                }
            }
        }

        private void CheckUserRole()
        {
            if (Session["URole"] != null && Session["URole"].ToString() == "JobSeeker")
            {
                btnApply.Visible = true;
            }
        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            if (Session["UID"] == null)
            {
                Response.Redirect("~/Account/Login.aspx");
                return;
            }

            int userId = Convert.ToInt32(Session["UID"]);
            string currentJobId = Request.QueryString["id"];

            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();

                // 1. الخطوة الأهم: التأكد من أن المستخدم رفع CV في جدول dbo.CVs
                string checkCVSql = "SELECT FilePath FROM dbo.CVs WHERE JobSeekerId = @uid";
                SqlCommand cvCmd = new SqlCommand(checkCVSql, con);
                cvCmd.Parameters.AddWithValue("@uid", userId);
                object cvPath = cvCmd.ExecuteScalar();

                if (cvPath == null || string.IsNullOrEmpty(cvPath.ToString()))
                {
                    lblMsg.Text = "⚠️ لا يمكنك التقديم! يرجى رفع سيرتك الذاتية في 'ملفي الشخصي' أولاً.";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    return; // التوقف عن التقديم
                }

                // 2. إذا وجدنا الـ CV، نقوم بالإدخال في جدول التقديمات
                // ملاحظة: أضفنا Status ليكون 'New' افتراضياً
                string sql = "INSERT INTO Applications (JobId, JobSeekerId, ApplyDate, Status) VALUES (@jid, @uid, GETDATE(), 'New')";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@jid", currentJobId);
                cmd.Parameters.AddWithValue("@uid", userId);

                try
                {
                    cmd.ExecuteNonQuery();
                    lblMsg.Text = "✅ تم التقديم بنجاح باستخدام سيرتك الذاتية المرفوعة!";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    btnApply.Enabled = false;
                }
                catch (Exception)
                {
                    lblMsg.Text = "خطأ: ربما قمت بالتقديم مسبقاً لهذه الوظيفة.";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}

