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
    public partial class remove_criteria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String email = (String)Session["LoggedInUser"];
            int pid = int.Parse(Request.QueryString["placeid"]);
            String criteria = Request.QueryString["criteria"];

            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("remove_criteria", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@criteria", criteria));
            cmd.Parameters.Add(new SqlParameter("@email", email));
            cmd.Parameters.Add(new SqlParameter("@place", pid));

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("view_criteria.aspx?placeid="+pid);

        }
    }
}