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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
            protected void signin(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("signin", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            string email = txt_username.Text;
            string password = txt_password.Text;
            cmd.Parameters.Add(new SqlParameter("@email", email));

            SqlParameter name = cmd.Parameters.Add("@passw", SqlDbType.VarChar, 50);
            name.Value = password;

            // output parm
            SqlParameter output = cmd.Parameters.Add("@return", SqlDbType.Int);
            output.Direction = ParameterDirection.Output;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            if (output.Value.ToString().Equals("1"))
            {

                Session["LoggedInUser"] = email;
                Response.Redirect("ViewProfile.aspx");

            }
            else
            {
                Response.Write("Invalid Login Data.");
            }
        
        }
    }
}