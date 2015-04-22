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
    public partial class view_criteria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int pid = int.Parse(Request.QueryString["placeid"]);
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("view_criteria", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@pid", pid));

            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                String cname = rdr.GetString(rdr.GetOrdinal("Rating_Criteria"));

                Label c_name = new Label();
                c_name.Text = cname;
                form1.Controls.Add(c_name);

                HyperLink criteria = new HyperLink();
                criteria.Text = "Remove";
                criteria.NavigateUrl = "remove_criteria.aspx?placeid="+pid+"&criteria="+cname;
                form1.Controls.Add(criteria);

                Label breakk = new Label();
                breakk.Text = "<br />";
                form1.Controls.Add(breakk);
            }

        }
    }
}