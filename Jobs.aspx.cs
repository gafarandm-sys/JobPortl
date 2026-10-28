using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace JobPortal
{
    public partial class Jobs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // لضمان تحميل البيانات مرة واحدة فقط عند فتح الصفحة
            {
                BindJobs();
            }
        }

        private void BindJobs()
        {
            string strCon = ConfigurationManager.ConnectionStrings["JobPortalDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strCon))
            {
                // جلب كافة الوظائف من قاعدة البيانات
                string sql = "SELECT JobId, Title, Location, Salary, CreatedDate FROM Jobs ORDER BY CreatedDate DESC";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();

                try
                {
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        gvJobs.DataSource = dt;
                        gvJobs.DataBind();
                    }
                    else
                    {
                        lblInfo.Text = "لا توجد وظائف معروضة حالياً.";
                    }
                }
                catch (Exception ex)
                {
                    lblInfo.Text = "حدث خطأ أثناء جلب البيانات: " + ex.Message;
                }
            }
        }
    }
}

