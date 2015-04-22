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
    public partial class view_managed_places : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String email = (String)Session["LoggedInUser"];

            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand view = new SqlCommand("view_places_managing", conn);
            view.CommandType = CommandType.StoredProcedure;


            view.Parameters.Add(new SqlParameter("@email", email));


            conn.Open();
            SqlDataReader rdr = view.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                String name = rdr.GetString(rdr.GetOrdinal("name"));
                int pid = rdr.GetInt32(rdr.GetOrdinal("p_id"));

                HyperLink hpr_view = new HyperLink();
                hpr_view.Text = name + "<br />";
                hpr_view.NavigateUrl = "view_managed_place.aspx?placeid="+pid;
                form1.Controls.Add(hpr_view);
            }

        }
    }
}