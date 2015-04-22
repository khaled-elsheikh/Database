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
    public partial class post_comment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int pid = int.Parse(Request.QueryString["placeid"]);
            String msg = Request.QueryString["msg"];

            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("add_comment", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@email", Session["LoggedInUser"]));
            cmd.Parameters.Add(new SqlParameter("@place", pid));
            cmd.Parameters.Add(new SqlParameter("@comment", msg));

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("view_place_page.aspx?placeid="+pid);
        }
    }
}