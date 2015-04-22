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
    public partial class rateCriteria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int pid = int.Parse(Request.QueryString["placeid"]);
            string criteria = Request.QueryString["criteria"];
            string value = Request.QueryString["value"];

            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("rate_place", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@place", pid));
            cmd.Parameters.Add(new SqlParameter("@email", (String)Session["LoggedInUser"]));
            cmd.Parameters.Add(new SqlParameter("@rating", int.Parse(value)));
            cmd.Parameters.Add(new SqlParameter("@criteria", criteria));

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("rate.aspx?placeid=" + pid);
        }
    }
}