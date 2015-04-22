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
    public partial class enter_info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int placeid = int.Parse(Request.QueryString["placeid"]);

            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("check_type", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@pid", placeid));

            SqlParameter output = cmd.Parameters.Add("@type", SqlDbType.Int);
            output.Direction = ParameterDirection.Output;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            int type = int.Parse(output.Value.ToString());
            Response.Redirect("enter_place_info.aspx?placeid=" + placeid + "&type=" + type);      
        }
    }
}