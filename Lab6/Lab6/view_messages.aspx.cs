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
    public partial class view_messages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = (string)Session["LoggedInUser"];
            string email2 = Request.QueryString["email"];
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand view = new SqlCommand("view_messages", conn);
            view.CommandType = CommandType.StoredProcedure;


            view.Parameters.Add(new SqlParameter("@user1", email));
            view.Parameters.Add(new SqlParameter("@user2", email2));


            conn.Open();
            SqlDataReader rdr = view.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                string name = rdr.GetString(rdr.GetOrdinal("msg"));
                string s_fname = rdr.GetString(rdr.GetOrdinal("fname"));
                string s_lname = rdr.GetString(rdr.GetOrdinal("lname"));
                Label message = new Label();
                message.Text = s_fname+" "+s_lname+": "+name+"<br />";
                form1.Controls.Add(message);
            }
        }
    }
}