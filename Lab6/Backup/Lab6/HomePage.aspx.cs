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
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("loginProcedure", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            string username = txt_username.Text;
            string password = txt_password.Text;
            cmd.Parameters.Add(new SqlParameter("@username", username));

            SqlParameter name = cmd.Parameters.Add("@password", SqlDbType.VarChar, 50);
            name.Value = password;

            // output parm
            SqlParameter count = cmd.Parameters.Add("@count", SqlDbType.Int);
            count.Direction = ParameterDirection.Output;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            if (count.Value.ToString().Equals("1"))
            {

                Response.Write("Passed");

            }
            else
            {
                Response.Write("Failed");
            }
        }
    }
}