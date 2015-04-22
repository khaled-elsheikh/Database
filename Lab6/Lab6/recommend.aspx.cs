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
    public partial class recommend : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand searching = new SqlCommand("recommend", conn);
            searching.CommandType = CommandType.StoredProcedure;

            String email = (String)Session["LoggedInUser"];

            searching.Parameters.Add(new SqlParameter("@email", email));

            conn.Open();
            SqlDataReader rdr = searching.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                string name = rdr.GetString(rdr.GetOrdinal("name"));
                int placeid = rdr.GetInt32(rdr.GetOrdinal("p_id"));

                
                HyperLink redirect = new HyperLink();
                redirect.Text = name;
                redirect.NavigateUrl = "view_place_page.aspx?placeid=" + placeid;

                form1.Controls.Add(redirect);
            }
        }
    }
}