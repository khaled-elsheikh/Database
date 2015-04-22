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
    public partial class view_pictures : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int pid = int.Parse(Request.QueryString["placeid"]);

            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand view = new SqlCommand("view_pics", conn);
            view.CommandType = CommandType.StoredProcedure;

            view.Parameters.Add(new SqlParameter("@p_id", pid));

            conn.Open();
            SqlDataReader rdr = view.ExecuteReader(CommandBehavior.CloseConnection);

            while (rdr.Read())
            {
                String name = rdr.GetString(rdr.GetOrdinal("fname"));
                String user_up = rdr.GetString(rdr.GetOrdinal("user_up"));

                Image i = new Image();
                i.ImageUrl = name;
                i.Height = 350;
                i.Width = 700;
                form1.Controls.Add(i);
                Label up = new Label();
                up.Text = "<br />Uploaded by: " + user_up+"<br />";
                form1.Controls.Add(up);
            }
        }
    }
}