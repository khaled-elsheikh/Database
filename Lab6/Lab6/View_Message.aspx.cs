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
    public partial class View_Message : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = (string)Session["LoggedInUser"];
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand view = new SqlCommand("view_different_thread_messages", conn);
            view.CommandType = CommandType.StoredProcedure;


            view.Parameters.Add(new SqlParameter("@email", email));

            conn.Open();
            SqlDataReader rdr = view.ExecuteReader(CommandBehavior.CloseConnection);

            while (rdr.Read())
            {
                string name = rdr.GetString(rdr.GetOrdinal("email"));
                HyperLink tarek = new HyperLink();
                tarek.Text = name;
                tarek.NavigateUrl = "view_messages.aspx?email="+name;
                form1.Controls.Add(tarek);

                Label breakk = new Label();
                breakk.Text = "<br />";
                form1.Controls.Add(breakk);
            }
        }
    }
}