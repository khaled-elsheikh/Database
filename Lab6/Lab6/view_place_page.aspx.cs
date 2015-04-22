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
    public partial class view_place_page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Label breakk = new Label();
            breakk.Text = "<br /><br />";

            int pid = int.Parse(Request.QueryString["placeid"]);

            HyperLink rate = new HyperLink();
            rate.Text = "Rate this place <br />";
            rate.NavigateUrl = "rate.aspx?placeid=" + pid;
            form1.Controls.Add(rate);

            HyperLink pics = new HyperLink();
            pics.Text = "View pictures<br />";
            pics.NavigateUrl = "view_pictures.aspx?placeid=" + pid;
            form1.Controls.Add(pics);

            HyperLink admin = new HyperLink();
            admin.Text = "Make me an Admin<br />";
            admin.NavigateUrl = "make_admin.aspx?placeid=" + pid;
            form1.Controls.Add(admin);


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

            cmd = new SqlCommand("isLiked", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@p_id", pid));
            cmd.Parameters.Add(new SqlParameter("@email", Session["LoggedInUser"]));

            SqlParameter output = cmd.Parameters.Add("@return", SqlDbType.Int);
            output.Direction = ParameterDirection.Output;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            if (output.Value.ToString().Equals("0"))
            {
                HyperLink like = new HyperLink();
                like.Text = "Like this place <br />";
                like.NavigateUrl = "like_place.aspx?placeid=" + pid;
                form1.Controls.Add(like);

            }

            cmd = new SqlCommand("isVisited", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@p_id", pid));
            cmd.Parameters.Add(new SqlParameter("@email", Session["LoggedInUser"]));

            output = cmd.Parameters.Add("@return", SqlDbType.Int);
            output.Direction = ParameterDirection.Output;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            if (output.Value.ToString().Equals("0"))
            {
                HyperLink visit = new HyperLink();
                visit.Text = "I visited this place <br />";
                visit.NavigateUrl = "visit_place.aspx?placeid=" + pid;
                form1.Controls.Add(visit);

            }

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
            int a_rating = 0;
            if (!rdr.IsDBNull(rdr.GetOrdinal("rating")))
            a_rating = rdr.GetInt32(rdr.GetOrdinal("rating"));

            Label avg_ratingg = new Label();
            avg_ratingg.Text = "Rating: " + a_rating + "<br />";
            form1.Controls.Add(avg_ratingg);


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
                questionn.Text = question + ": " +response+"<br />";
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
        protected void add_question(object sender, EventArgs e)
        {
            String question = txt_question.Text;
            int pid = int.Parse(Request.QueryString["placeid"]);
            Response.Redirect("add_question.aspx?placeid=" + pid + "&question=" + question);
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