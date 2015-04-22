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
    public partial class view_city_rating : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand view = new SqlCommand("sortcity", conn);
            view.CommandType = CommandType.StoredProcedure;
            string criteria = Request.QueryString["cname"];
            view.Parameters.Add(new SqlParameter("@criteria", criteria));
            conn.Open();
            SqlDataReader rdr = view.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                string name = rdr.GetString(rdr.GetOrdinal("name"));
                Label namee = new Label();
                namee.Text = name;
                form1.Controls.Add(namee);

                Label breakk = new Label();
                breakk.Text = "<br />";
                form1.Controls.Add(breakk);
            }
        }
    }
}