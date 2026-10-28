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
    public partial class PostJob : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // منع أي شخص غير مسجل من دخول هذه الصفحة
            if (Session["UID"] == null || Session["URole"].ToString() != "Employer")
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            string strCon = ConfigurationManager.ConnectionStrings["JobPortalDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strCon))
            {
                // جملة الإدخال لجدول Jobs
                string sql = "INSERT INTO Jobs (Title, Description, Location, Salary, EmployerId) " +
                             "VALUES (@title, @desc, @loc, @sal, @eid)";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@title", txtTitle.Text);
                cmd.Parameters.AddWithValue("@desc", txtDesc.Text);
                cmd.Parameters.AddWithValue("@loc", txtLocation.Text);
                cmd.Parameters.AddWithValue("@sal", decimal.Parse(txtSalary.Text));
                cmd.Parameters.AddWithValue("@eid", Session["UID"]); // جلب رقم صاحب العمل من الـ Session

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    lblMsg.Text = "تم نشر الوظيفة بنجاح!";
                    lblMsg.ForeColor = System.Drawing.Color.Green;

                    // تنظيف الحقول
                    txtTitle.Text = txtDesc.Text = txtLocation.Text = txtSalary.Text = "";
                }
                catch (Exception ex)
                {
                    lblMsg.Text = "خطأ: " + ex.Message;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}


