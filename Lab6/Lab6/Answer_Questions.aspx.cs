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
    public partial class Answer_Questions : System.Web.UI.Page
    {
        protected void fn_click(object sender, EventArgs e)
        {
            Button sendingButton = (Button)sender;
            string buttonID = sendingButton.ID;
            string[] splits = buttonID.Split('#');

            int pid = int.Parse(Request.QueryString["placeid"]);
            TextBox text = ((TextBox)form1.FindControl("answer_" + splits[0]));
            Response.Redirect("answerQuestion.aspx?placeid=" + pid + "&questionid=" + splits[1] + "&response=" + text.Text + "&userasking=" + splits[2]);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int pid = int.Parse(Request.QueryString["placeid"]);
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("open_page_question", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@id", pid));

            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            int count = 0;
            while (rdr.Read())
            {
                String question = rdr.GetString(rdr.GetOrdinal("question"));
                if (rdr.IsDBNull(rdr.GetOrdinal("response")))
                {
                    int question_id = rdr.GetInt32(rdr.GetOrdinal("q_id"));
                    String asking_user = rdr.GetString(rdr.GetOrdinal("userr"));

                    Label questionn = new Label();
                    questionn.Text = question;
                    form1.Controls.Add(questionn);

                    TextBox answerr = new TextBox();
                    answerr.ID = "answer_" + count;
                    form1.Controls.Add(answerr);

                    Button redirectButton = new Button();
                    redirectButton.Text = "Answer";
                    redirectButton.Click += new System.EventHandler(fn_click);
                    redirectButton.ID = count + "#" + question_id + "#" + asking_user;
                    form1.Controls.Add(redirectButton);

                    Label breakk = new Label();
                    breakk.Text = "<br />";
                    form1.Controls.Add(breakk);
                    count++;
                }
            }
        }
    }
}