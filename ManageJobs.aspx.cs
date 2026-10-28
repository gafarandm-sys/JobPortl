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
    public partial class ManageJobs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    if (Session["UID"] == null) Response.Redirect("~/Account/Login.aspx");
    
    if (!IsPostBack)
    {
        BindMyJobs();
    }
}

private void BindMyJobs()
{
    string strCon = ConfigurationManager.ConnectionStrings["JobPortalDBConnectionString"].ConnectionString;
    using (SqlConnection con = new SqlConnection(strCon))
    {
        // جلب الوظائف التابعة لصاحب العمل الحالي فقط
        string sql = "SELECT JobId, Title, CreatedDate FROM Jobs WHERE EmployerId = @eid";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@eid", Session["UID"]);
        
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        
        gvMyJobs.DataSource = dt;
        gvMyJobs.DataBind();
    }
}

        }
    }
