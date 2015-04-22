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
    public partial class answerQuestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int pid = int.Parse(Request.QueryString["placeid"]);
            int qid = int.Parse(Request.QueryString["questionid"]);
            String answer = Request.QueryString["response"];
            String asking_user = Request.QueryString["userasking"];

            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("answerquestions", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@email", Session["LoggedInUser"]));
            cmd.Parameters.Add(new SqlParameter("@pid", pid));
            cmd.Parameters.Add(new SqlParameter("@qid", qid));
            cmd.Parameters.Add(new SqlParameter("@response", answer));
            cmd.Parameters.Add(new SqlParameter("@user", asking_user));

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("Answer_Questions.aspx?placeid="+pid);
        }
    }
}