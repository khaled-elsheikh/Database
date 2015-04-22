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
    public partial class Search_Places : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void view(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand searching = new SqlCommand("search_place", conn);
            searching.CommandType = CommandType.StoredProcedure;

            string txt_Search_Bar = Search_Bar.Text;

            searching.Parameters.Add(new SqlParameter("@search", txt_Search_Bar));

            conn.Open();
            SqlDataReader rdr = searching.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                string name = rdr.GetString(rdr.GetOrdinal("name"));
                float longitude = rdr.GetFloat(rdr.GetOrdinal("longitude"));
                float latitude = rdr.GetFloat(rdr.GetOrdinal("latitude"));
                int id = rdr.GetInt32(rdr.GetOrdinal("p_id"));

                
                Label longitudee = new Label();
                longitudee.Text = " " + longitude.ToString()+" ";

                Label latitudee = new Label();
                latitudee.Text = latitude.ToString()+" ";

                HyperLink namee = new HyperLink(); 
                namee.Text = name;
                namee.NavigateUrl = "view_place_page.aspx?placeid=" + id + " ";

                Label br = new Label();
                br.Text = "<br />";

                form1.Controls.Add(namee);
                form1.Controls.Add(longitudee);
                form1.Controls.Add(latitudee);
                form1.Controls.Add(br);
            }
        }
    }
}