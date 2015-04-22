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
    public partial class delete_page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int placeid = int.Parse(Request.QueryString["placeid"]);
            String email = (String)Session["LoggedInUser"];

            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("delete_page", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@email", email));
            cmd.Parameters.Add(new SqlParameter("@pid", placeid));

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("ViewProfile.aspx");
        }
    }
}