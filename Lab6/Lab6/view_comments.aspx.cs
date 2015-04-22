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
    public partial class view_comments : System.Web.UI.Page
    {
        protected void fn_click(object sender, EventArgs e)
        {
            Button sendingButton = (Button)sender;
            string buttonID = sendingButton.ID;
            string[] splits = buttonID.Split('#');


            int pid = int.Parse(Request.QueryString["placeid"]);
            Response.Redirect("remove_comment.aspx?placeid=" + pid + "&commentid=" + splits[0] + "&added=" + splits[1]);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            int pid = int.Parse(Request.QueryString["placeid"]);

            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("open_page_comment", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@id", pid));
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                string msg = rdr.GetString(rdr.GetOrdinal("msg"));
                int c_id = rdr.GetInt32(rdr.GetOrdinal("c_id"));
                
                string added = rdr.GetString(rdr.GetOrdinal("added"));
                string name = rdr.GetString(rdr.GetOrdinal("userr"));

                Label msgg = new Label();
                msgg.Text = name+": "+msg;
                form1.Controls.Add(msgg);

                Button redirectButton = new Button();
                redirectButton.Text = "Delete";
                redirectButton.Click += new System.EventHandler(fn_click);
                redirectButton.ID = c_id + "#" + added;
                form1.Controls.Add(redirectButton);

                Label breakk = new Label();
                breakk.Text = "<br />";
                form1.Controls.Add(breakk);
            }

        }
    }
}