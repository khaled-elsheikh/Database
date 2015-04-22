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
    public partial class send_message : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string mesg = Request.QueryString["msg"];
            string receiver = Request.QueryString["email"];
            string senderr = (string)Session["LoggedInUser"];

            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("send_msg", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@sender", senderr));
            cmd.Parameters.Add(new SqlParameter("@receiver", receiver));
            cmd.Parameters.Add(new SqlParameter("@msg", mesg));
           

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("ViewProfile.aspx?email="+receiver);
        }
    }
}