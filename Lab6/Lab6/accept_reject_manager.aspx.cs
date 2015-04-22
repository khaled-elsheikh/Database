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
    public partial class accept_reject_manager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String email = (String)Session["LoggedInUser"];
            int pid = int.Parse(Request.QueryString["placeid"]);
            int value = int.Parse(Request.QueryString["value"]);

            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand searching = new SqlCommand("accept_reject_manager", conn);
            searching.CommandType = CommandType.StoredProcedure;


            searching.Parameters.Add(new SqlParameter("@email", email));
            searching.Parameters.Add(new SqlParameter("@place", pid));
            searching.Parameters.Add(new SqlParameter("@input", value));
            conn.Open();
            SqlDataReader rdr = searching.ExecuteReader(CommandBehavior.CloseConnection);

            Response.Redirect("View_invite_m.aspx");
        }
    }
}