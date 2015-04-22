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
    public partial class rate : System.Web.UI.Page
    {
        protected void fn_click(object sender, EventArgs e)
        {
            Button sendingButton = (Button)sender;
            string buttonID = sendingButton.ID;
            string[] splits = buttonID.Split('#');

            int pid = int.Parse(Request.QueryString["placeid"]);
            TextBox text = ((TextBox)form1.FindControl("text_" + splits[0]));
            Response.Redirect("rateCriteria.aspx?placeid="+pid+"&criteria=" + splits[1] + "&value=" + text.Text );
        }
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
            int count = 0;
            
            while (rdr.Read())
            {
                string c_name= rdr.GetString(rdr.GetOrdinal("Rating_Criteria"));
                Label lbl_rate = new Label();
                lbl_rate.Text = c_name;
                form1.Controls.Add(lbl_rate);

                TextBox txt_rating = new TextBox();
                txt_rating.ID = "text_" + count;
                form1.Controls.Add(txt_rating);

                Button redirectButton = new Button();
                redirectButton.Text = "Rate";
                redirectButton.Click += new System.EventHandler(fn_click);
                redirectButton.ID = count + "#" + c_name;
                form1.Controls.Add(redirectButton);

                Label breakk = new Label();
                breakk.Text = "<br />";
                form1.Controls.Add(breakk);
                count++;
            }

        }
    }
}