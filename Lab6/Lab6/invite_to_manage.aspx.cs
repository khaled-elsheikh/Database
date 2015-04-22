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
    public partial class invite_to_manage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String email = Request.QueryString["email"];
            String manager = (String)Session["LoggedInUser"];

            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand view = new SqlCommand("view_places_managing", conn);
            view.CommandType = CommandType.StoredProcedure;

            view.Parameters.Add(new SqlParameter("@email", manager));

            conn.Open();
            SqlDataReader rdr = view.ExecuteReader(CommandBehavior.CloseConnection);
            while(rdr.Read())
            {
                String name = rdr.GetString(rdr.GetOrdinal("name"));
                int pid = rdr.GetInt32(rdr.GetOrdinal("p_id"));

                HyperLink hpr_view = new HyperLink();
                hpr_view.Text = name;
                hpr_view.NavigateUrl = "invite_to_manage_place.aspx?placeid=" + pid + "&email=" + email;
                form1.Controls.Add(hpr_view);
            }
        }
    }
}