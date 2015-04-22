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
    public partial class signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void signupp(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("signup", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            string email = txt_email.Text;
            string password = txt_password.Text;
            string fname = txt_fname.Text;
            string lname = txt_lname.Text;
            string nationality = txt_nationality.Text;
            string address = txt_address.Text;
            cmd.Parameters.Add(new SqlParameter("@email", email));
            cmd.Parameters.Add(new SqlParameter("@fname", fname));
            cmd.Parameters.Add(new SqlParameter("@lname", lname));
            cmd.Parameters.Add(new SqlParameter("@nationality", nationality));
            cmd.Parameters.Add(new SqlParameter("@addres", address));
            SqlParameter name = cmd.Parameters.Add("@pw", SqlDbType.VarChar, 50);
            name.Value = password;

            // output parm
            SqlParameter output = cmd.Parameters.Add("@return", SqlDbType.Int);
            output.Direction = ParameterDirection.Output;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            if (output.Value.ToString().Equals("1"))
            {
                Response.Redirect("~/login.aspx");

            }
            else
            {
                Response.Write("This email already exist in the database.");
            }
        }
    }
}