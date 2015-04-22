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
    public partial class view_museum_criteria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand view = new SqlCommand("viewcriteriamuseum", conn);
            view.CommandType = CommandType.StoredProcedure;


            conn.Open();
            SqlDataReader rdr = view.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                string name = rdr.GetString(rdr.GetOrdinal("name"));
                HyperLink namee = new HyperLink();
                namee.Text = name;
                namee.NavigateUrl = "view_museum_rating.aspx?cname=" + name;
                form1.Controls.Add(namee);
                Label breakk = new Label();
                breakk.Text = "<br />";
                form1.Controls.Add(breakk);
            }
        }
    }
}