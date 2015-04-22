using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace Lab6
{
    public partial class enter_city_info : System.Web.UI.Page
    {
        protected void enter(object sender, EventArgs e)
        {
            int placeid = int.Parse(Request.QueryString["placeid"]);

            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("enter_basic", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime dt2 = DateTime.ParseExact(txt_date.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            cmd.Parameters.Add(new SqlParameter("@pid", placeid));
            cmd.Parameters.Add(new SqlParameter("@name", txt_name.Text));
            cmd.Parameters.Add(new SqlParameter("@buildingdate", dt2));
            cmd.Parameters.Add(new SqlParameter("@longitude", txt_long.Text));
            cmd.Parameters.Add(new SqlParameter("@latitude", txt_lat.Text));

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("ViewProfile.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}