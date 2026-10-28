using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO; // ضروري للتعامل مع الملفات

namespace JobPortal
{
    public partial class Profile : System.Web.UI.Page
    {
        string strCon = ConfigurationManager.ConnectionStrings["JobPortalDBConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UID"] == null)
            {
                Response.Redirect("~/Account/Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                lblUserName.Text = Session["UName"].ToString();
                BindMyApplications();
                CheckUserCV(); // دالة للتأكد هل رفع CV سابقاً أم لا
            }
        }

        // --- وظيفة رفع السيرة الذاتية الجديدة ---
        protected void btnUploadCV_Click(object sender, EventArgs e)
        {
            // نأخذ الأداة التي سنضيفها في ملف الـ aspx (سنسميها fuCV)
            FileUpload fuCV = (FileUpload)Master.FindControl("MainContent").FindControl("fuCV");
            // ملاحظة: إذا كنت لا تستخدم Master Page بشكل معقد، استخدم fuCV مباشرة

            if (fuCV.HasFile)
            {
                try
                {
                    string ext = Path.GetExtension(fuCV.FileName).ToLower();
                    if (ext == ".pdf" || ext == ".doc" || ext == ".docx") // التحقق من نوع الملف
                    {
                        // 1. تحديد المسار واسم الملف
                        string fileName = "CV_" + Session["UID"].ToString() + "_" + Guid.NewGuid().ToString().Substring(0, 5) + ext;
                        string folderPath = Server.MapPath("~/Uploads/CVs/");

                        // إنشاء المجلد إذا لم يكن موجوداً
                        if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

                        string fullPath = folderPath + fileName;
                        fuCV.SaveAs(fullPath);

                        // 2. حفظ المسار في قاعدة البيانات (جدول dbo.CVs)
                        SaveCVPathToDB("~/Uploads/CVs/" + fileName);

                        lblCVStatus.Text = "تم رفع السيرة الذاتية بنجاح!";
                        lblCVStatus.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblCVStatus.Text = "عذراً، يسمح فقط بملفات PDF أو Word.";
                        lblCVStatus.ForeColor = System.Drawing.Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    lblCVStatus.Text = "حدث خطأ: " + ex.Message;
                }
            }
        }

        private void SaveCVPathToDB(string dbPath)
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                // نستخدم استعلام Update/Insert ذكي (Upsert)
                string sql = @"IF EXISTS (SELECT 1 FROM dbo.CVs WHERE JobSeekerId = @uid)
                               UPDATE dbo.CVs SET FilePath = @path WHERE JobSeekerId = @uid
                               ELSE
                               INSERT INTO dbo.CVs (FilePath, JobSeekerId) VALUES (@path, @uid)";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@path", dbPath);
                cmd.Parameters.AddWithValue("@uid", Session["UID"]);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void CheckUserCV()
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                string sql = "SELECT FilePath FROM dbo.CVs WHERE JobSeekerId = @uid";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@uid", Session["UID"]);
                con.Open();
                object path = cmd.ExecuteScalar();
                if (path != null)
                {
                    lblCVStatus.Text = "لديك سيرة ذاتية مرفوعة مسبقاً. يمكنك استبدالها برفع ملف جديد.";
                    lblCVStatus.ForeColor = System.Drawing.Color.Blue;
                }
            }
        }

        // --- الكود الأصلي الخاص بك (دون تغيير) ---
        private void BindMyApplications()
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                string sql = @"SELECT J.Title, J.Location, A.ApplyDate, A.Status 
                           FROM dbo.Applications A 
                           INNER JOIN Jobs J ON A.JobId = J.JobId 
                           WHERE A.JobSeekerId = @uid 
                           ORDER BY A.ApplyDate DESC";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@uid", Session["UID"]);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    gvMyApplications.DataSource = dt;
                    gvMyApplications.DataBind();
                    pnlNoData.Visible = false;
                    gvMyApplications.Visible = true;
                }
                else
                {
                    gvMyApplications.Visible = false;
                    pnlNoData.Visible = true;
                }
            }
        }

        protected string GetStatusLabelClass(object status)
        {
            if (status == null) return "label-default";
            switch (status.ToString())
            {
                case "Accepted": return "label-success";
                case "Rejected": return "label-danger";
                case "Pending": return "label-warning";
                default: return "label-default";
            }
        }
    }
}

