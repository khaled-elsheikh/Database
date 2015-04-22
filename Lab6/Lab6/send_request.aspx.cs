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
    public partial class send_request : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String senderr = (String)Session["LoggedInUser"];
            String receiverr = Request.QueryString["email"];

            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand view = new SqlCommand("send_req", conn);
            view.CommandType = CommandType.StoredProcedure;

            view.Parameters.Add(new SqlParameter("@sender", senderr));
            view.Parameters.Add(new SqlParameter("@receiver", receiverr));

            conn.Open();
            SqlDataReader rdr = view.ExecuteReader(CommandBehavior.CloseConnection);

            Response.Redirect("ViewProfile.aspx?email=" + receiverr);
        }
    }
}