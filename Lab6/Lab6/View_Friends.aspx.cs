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
    public partial class SearchFriends : System.Web.UI.Page
    {
        string email = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["LoggedInUser"] != null)
            {
                email = (string)Session["LoggedInUser"];
            }
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand view = new SqlCommand("view_friends", conn);
            view.CommandType = CommandType.StoredProcedure;


            view.Parameters.Add(new SqlParameter("@email", email));

            conn.Open();
            SqlDataReader rdr = view.ExecuteReader(CommandBehavior.CloseConnection);

            while (rdr.Read())
            {
                string friend = rdr.GetString(rdr.GetOrdinal("email"));
                HyperLink x = new HyperLink();
                x.Text = friend + "<br />";
                x.NavigateUrl = "ViewProfile.aspx?email="+friend;
                form1.Controls.Add(x);
            }
            
        }
    }
}