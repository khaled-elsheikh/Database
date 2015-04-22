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
    public partial class View_Invite_m : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String userr = (String)Session["LoggedInUser"];


            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("manager_invitations", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@email", userr));

            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                String manager = rdr.GetString(rdr.GetOrdinal("manager"));
                Label vmanager = new Label();
             
                String place = rdr.GetString(rdr.GetOrdinal("name"));
                int placeid = rdr.GetInt32(rdr.GetOrdinal("p_id"));

                vmanager.Text = manager + " invited you to manage " + place;
                form1.Controls.Add(vmanager);
                HyperLink accept = new HyperLink();
                HyperLink reject = new HyperLink();
                accept.Text = "Accept ";
                reject.Text = "Reject <br />";
                accept.NavigateUrl = "accept_reject_manager.aspx?placeid=" + placeid + "&value=" + 1;
                reject.NavigateUrl = "accept_reject_manager.aspx?placeid=" + placeid + "&value=" + 0;
                form1.Controls.Add(accept);
                form1.Controls.Add(reject);




            }
            
            

        }
    }
}