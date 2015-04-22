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
    public partial class invite_to_manage_place : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String managerr = (String)Session["LoggedInUser"];
            String userr = Request.QueryString["email"];
            int placeid = int.Parse(Request.QueryString["placeid"]);

            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("invite_member", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@email", managerr));
            cmd.Parameters.Add(new SqlParameter("@email2", userr));
            cmd.Parameters.Add(new SqlParameter("@pid", placeid));

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("ViewProfile.aspx");
        }
    }
}