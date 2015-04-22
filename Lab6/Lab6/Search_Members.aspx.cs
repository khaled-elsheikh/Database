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
    public partial class Search_Members : System.Web.UI.Page
    {
        string E_mail = null;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void view(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand searching = new SqlCommand("search_friends", conn);
            searching.CommandType = CommandType.StoredProcedure;

            string txt_Search_Bar = Search_Bar.Text;

            searching.Parameters.Add(new SqlParameter("@search", txt_Search_Bar));

            conn.Open();
            SqlDataReader rdr = searching.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                string FirstName = rdr.GetString(rdr.GetOrdinal("fname"));
                string LastName = rdr.GetString(rdr.GetOrdinal("lname"));
                E_mail = rdr.GetString(rdr.GetOrdinal("email"));

                Label fname = new Label();
                fname.Text = FirstName;
                Label lname = new Label();
                lname.Text = LastName;
                HyperLink redirect = new HyperLink();
                redirect.Text = E_mail;
                redirect.NavigateUrl = "ViewProfile.aspx?email=" + E_mail;

                form1.Controls.Add(fname);
                form1.Controls.Add(lname);
                form1.Controls.Add(redirect);
            }
        }
        
    }
}