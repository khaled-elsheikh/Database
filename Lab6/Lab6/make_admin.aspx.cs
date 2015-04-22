using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Lab6
{
    public partial class make_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = (string)Session["LoggedInUser"];
            int pid = int.Parse(Request.QueryString["placeid"]);
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand view = new SqlCommand("send_invitation", conn);
            view.CommandType = CommandType.StoredProcedure;
            view.Parameters.Add(new SqlParameter("@sender", email));
            view.Parameters.Add(new SqlParameter("@receiver", "admin@database.com"));
            view.Parameters.Add(new SqlParameter("@msg", pid));
            conn.Open();
            view.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("view_place_page.aspx?placeid=" + pid);
        }
    }
}