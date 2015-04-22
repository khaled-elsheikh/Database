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
    public partial class view_visits : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String email = Request.QueryString["email"];

            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand view = new SqlCommand("view_visits", conn);
            view.CommandType = CommandType.StoredProcedure;

            view.Parameters.Add(new SqlParameter("@email", email));

            conn.Open();
            SqlDataReader rdr = view.ExecuteReader(CommandBehavior.CloseConnection);

            while (rdr.Read())
            {
                String name = rdr.GetString(rdr.GetOrdinal("name"));
                int placeid = rdr.GetInt32(rdr.GetOrdinal("p_id"));

                HyperLink place = new HyperLink();
                place.Text = name;
                place.NavigateUrl = "view_place_page.aspx?placeid="+placeid;

                form1.Controls.Add(place);

                Label breakk = new Label();
                breakk.Text = "<br />";
                form1.Controls.Add(breakk);
            }

        }
    }
}