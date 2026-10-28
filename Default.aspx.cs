using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobPortal
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UName"] != null)
            {
                lblUser.Text = Session["UName"].ToString();
            }
            else
            {
                lblUser.Text = "زائر";
            }

            if (!IsPostBack)
            {
                if (Session["URole"] != null)
                {
                    string role = Session["URole"].ToString();
                    if (role == "JobSeeker")
                    {
                        btnAction.Text = "ابحث عن وظيفة الآن";
                    }
                    else if (role == "Employer")
                    {
                        btnAction.Text = "انشر وظيفة جديدة";
                    }
                }
                else
                {
                    btnAction.Text = "ابدأ البحث عن عمل";
                }
            }
        }
        protected void btnAction_Click(object sender, EventArgs e)
        {
            // 1. التحقق إذا كان المستخدم مسجل دخول أصلاً
            if (Session["UID"] == null)
            {
                // إذا لم يسجل دخول، نرسله لصفحة تسجيل الدخول
                Response.Redirect("~/Account/Login.aspx");
            }
            else
            {
                // 2. التحقق من نوع المستخدم (Role) وتوجيهه
                string userRole = Session["URole"].ToString();

                if (userRole == "JobSeeker")
                {
                    // إذا كان باحث عن عمل، نرسله لصفحة تصفح الوظائف
                    Response.Redirect("~/Jobs.aspx");
                }
                else if (userRole == "Employer")
                {
                    // إذا كان صاحب عمل، نرسله لصفحة نشر وظيفة
                    Response.Redirect("~/PostJob.aspx");
                }
            }
        }


    }
}
