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
    public partial class view_requests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = null;
            if (Session["LoggedInUser"] != null)
            {
                email = (string) Session["LoggedInUser"];
            }

            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand searching = new SqlCommand("view_requests", conn);
            searching.CommandType = CommandType.StoredProcedure;


            searching.Parameters.Add(new SqlParameter("@email", email));

            conn.Open();
            SqlDataReader rdr = searching.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                string request = rdr.GetString(rdr.GetOrdinal("user1"));
                
                Label lbl_users = new Label();
                lbl_users.Text = request +"  ";
                form1.Controls.Add(lbl_users);

                HyperLink accept = new HyperLink();
                HyperLink reject = new HyperLink();
                accept.Text = "Accept";
                reject.Text = "Reject";
                accept.NavigateUrl = "acceptreject.aspx?email="+request+"&check="+1;
                reject.NavigateUrl = "acceptreject.aspx?email="+request+"&check="+0;
                form1.Controls.Add(accept);
                form1.Controls.Add(reject);
            } 
        }
    }
}