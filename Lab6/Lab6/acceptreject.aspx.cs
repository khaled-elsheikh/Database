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
    public partial class acceptreject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            String receiverr = (string)Session["LoggedInUser"];
         
            String senderr = Request.QueryString["email"];
            
            int checkk = int.Parse(Request.QueryString["check"]);
            
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand searching = new SqlCommand("accept_reject", conn);
            searching.CommandType = CommandType.StoredProcedure;


            searching.Parameters.Add(new SqlParameter("@email1", senderr));
            searching.Parameters.Add(new SqlParameter("@email2", receiverr));
            searching.Parameters.Add(new SqlParameter("@accept", checkk));
            conn.Open();
            SqlDataReader rdr = searching.ExecuteReader(CommandBehavior.CloseConnection);

            Response.Redirect("view_requests.aspx");

        }
    }
}