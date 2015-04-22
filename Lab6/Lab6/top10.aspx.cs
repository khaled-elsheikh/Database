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
    public partial class top10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String email = (String)Session["LoggedInUser"];

            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand view = new SqlCommand("top10", conn);
            view.CommandType = CommandType.StoredProcedure;

            view.Parameters.Add(new SqlParameter("@email", email));

            conn.Open();
            SqlDataReader rdr = view.ExecuteReader(CommandBehavior.CloseConnection);
            while(rdr.Read()){
                String name = rdr.GetString(rdr.GetOrdinal("email"));

                HyperLink redir = new HyperLink();
                redir.Text = name+"<br />";
                redir.NavigateUrl = "ViewProfile.aspx?email=" + name;
                form1.Controls.Add(redir);
            }
        }
    }
}