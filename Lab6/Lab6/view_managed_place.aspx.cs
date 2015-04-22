using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace Lab6
{
    public partial class view_managed_place : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String manager = (String)Session["LoggedInUser"];
            int pid = int.Parse(Request.QueryString["placeid"]);

            Label breakk = new Label();
            breakk.Text = "<br /><br />";

            HyperLink dlt_page = new HyperLink();
            dlt_page.Text = "DELETE THIS PAGE!<br />";
            dlt_page.NavigateUrl = "delete_page.aspx?placeid=" + pid;
            form1.Controls.Add(dlt_page);

            HyperLink remove_criteria = new HyperLink();
            remove_criteria.Text = "Remove Criteria<br />";
            remove_criteria.NavigateUrl = "view_criteria.aspx?placeid=" + pid;
            form1.Controls.Add(remove_criteria);

            HyperLink remove_comment = new HyperLink();
            remove_comment.Text = "Remove Comment<br />";
            remove_comment.NavigateUrl = "view_comments.aspx?placeid=" + pid;
            form1.Controls.Add(remove_comment);

            HyperLink enter_info = new HyperLink();
            enter_info.Text = "Enter Additional Info for this place<br />";
            enter_info.NavigateUrl = "enter_info.aspx?placeid=" + pid;
            form1.Controls.Add(enter_info);

            HyperLink pics = new HyperLink();
            pics.Text = "View pictures<br />";
            pics.NavigateUrl = "view_pictures.aspx?placeid=" + pid;
            form1.Controls.Add(pics);

            HyperLink answer = new HyperLink();
            answer.Text = "Answer this place's questions<br />";
            answer.NavigateUrl = "Answer_Questions.aspx?placeid=" + pid;
            form1.Controls.Add(answer);

            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("open_page_info", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@id", pid));

            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            rdr.Read();
            string name = rdr.GetString(rdr.GetOrdinal("name"));
            float longitude = rdr.GetFloat(rdr.GetOrdinal("longitude"));
            float latitude = rdr.GetFloat(rdr.GetOrdinal("latitude"));
            DateTime date = DateTime.MinValue;
            if (!rdr.IsDBNull(rdr.GetOrdinal("building_date")))
                date = rdr.GetDateTime(rdr.GetOrdinal("building_date"));

            rdr.Close();

            Label longitudee = new Label();
            longitudee.Text = "Longitude: " + longitude.ToString() + "<br />";

            Label latitudee = new Label();
            latitudee.Text = "Latitude: " + latitude.ToString() + "<br />";

            Label namee = new Label();
            namee.Text = "Name: " + name + "<br />";

            Label datee = new Label();
            datee.Text = "Building Date: " + date + "<br />";

            form1.Controls.Add(namee);
            form1.Controls.Add(longitudee);
            form1.Controls.Add(latitudee);
            form1.Controls.Add(breakk);


            cmd = new SqlCommand("count_likes", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@pid", pid));

            conn.Open();
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            rdr.Read();

            int count = rdr.GetInt32(rdr.GetOrdinal("mohamed"));

            Label moh = new Label();
            moh.Text = "Number of Likes: " + count +"<br />"; 
            form1.Controls.Add(moh);


            conn.Close();


            cmd = new SqlCommand("avg_rating", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@place", pid));

            conn.Open();
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            rdr.Read();

            if (!rdr.IsDBNull(rdr.GetOrdinal("rating")))
            {
                int a_rating = rdr.GetInt32(rdr.GetOrdinal("rating"));
                Label avg_ratingg = new Label();
                avg_ratingg.Text = "Rating: " + a_rating + "<br />";
                form1.Controls.Add(avg_ratingg);
            }


            conn.Close();

            Label y = new Label();
            y.Text = "<br />Questions <br />";
            y.Font.Size = 20;
            form1.Controls.Add(y);

            cmd = new SqlCommand("open_page_question", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@id", pid));

            conn.Open();
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                string question = rdr.GetString(rdr.GetOrdinal("question"));
                string response = "";
                if (!rdr.IsDBNull(rdr.GetOrdinal("response")))
                {
                    response = rdr.GetString(rdr.GetOrdinal("response"));
                }

                Label questionn = new Label();
                questionn.Text = question + ": " + response + "<br />";
                form1.Controls.Add(questionn);
            }
            conn.Close();

            Label x = new Label();
            x.Text = "<br />Comments <br />";
            x.Font.Size = 20;
            form1.Controls.Add(x);


            cmd = new SqlCommand("open_page_comment", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@id", pid));

            conn.Open();
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                string fname = rdr.GetString(rdr.GetOrdinal("userr"));
                string msg = rdr.GetString(rdr.GetOrdinal("msg"));
                String hashtag = "";
                if (!rdr.IsDBNull(rdr.GetOrdinal("hashtag")))
                    hashtag = rdr.GetString(rdr.GetOrdinal("hashtag"));

                Label userr = new Label();
                userr.Text =fname + ": ";
                form1.Controls.Add(userr);
                Label message = new Label();
                message.Text = msg + " " + hashtag +"<br />";
                form1.Controls.Add(message);
            }
            conn.Close();


        }
        protected void post_comment(object sender, EventArgs e)
        {
            String msg = txt_comment.Text;
            int pid = int.Parse(Request.QueryString["placeid"]);
            Response.Redirect("post_comment.aspx?placeid=" + pid + "&msg=" + msg);
        }
        
        protected void add_criteria(object sender, EventArgs e)
        {
            String criteria_name = txt_criteria.Text;
            int pid = int.Parse(Request.QueryString["placeid"]);
            Response.Redirect("add_criteria.aspx?placeid=" + pid + "&name=" + criteria_name);
        }
       
        protected void upload_image(object sender, EventArgs e)
        {
            int pid = int.Parse(Request.QueryString["placeid"]); 
            if (FileUploadControl.HasFile)
            {
                try
                {
                    String filename = Path.GetFileName(FileUploadControl.FileName);
                    FileUploadControl.SaveAs(Server.MapPath("~/") + filename);
                    Response.Redirect("Upload_image.aspx?placeid="+pid+"&filename="+filename);
                }
                catch(Exception ex){
                    Response.Write("Could Not Upload");

                }
            }
        

        }
    }
}