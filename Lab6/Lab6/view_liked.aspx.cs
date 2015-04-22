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
    public partial class view_liked : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String email = Request.QueryString["email"];

            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand view_likes = new SqlCommand("view_likes", conn);
            view_likes.CommandType = CommandType.StoredProcedure;
            view_likes.Parameters.Add(new SqlParameter("@email", email));

            conn.Open();
            SqlDataReader viewMyLikes = view_likes.ExecuteReader(CommandBehavior.CloseConnection);
            while (viewMyLikes.Read())
            {
                HyperLink likes = new HyperLink();
                String Place_Name = viewMyLikes.GetString(viewMyLikes.GetOrdinal("name"));
                int pid = viewMyLikes.GetInt32(viewMyLikes.GetOrdinal("p_id"));
                likes.Text = Place_Name;
                likes.NavigateUrl = "view_place_page.aspx?placeid="+pid;
                form1.Controls.Add(likes);

                Label breakk = new Label();
                breakk.Text = "<br />";
                form1.Controls.Add(breakk);
            }
        }
    }
}