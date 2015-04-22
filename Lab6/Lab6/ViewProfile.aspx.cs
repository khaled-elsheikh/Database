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
    public partial class ViewProfile : System.Web.UI.Page
    {
        String email = null;
      

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["email"] == null)
            {
                email = (String)Session["LoggedInUser"];
            }
            else
            {
                email = Request.QueryString["email"];
            }
            if (email == "admin@database.com")
            {
                Response.Redirect("~~ADMIN PAGE");
            }

            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand view = new SqlCommand("view_profile", conn);
            view.CommandType = CommandType.StoredProcedure;

            view.Parameters.Add(new SqlParameter("@email1", email));

            conn.Open();
            SqlDataReader rdr = view.ExecuteReader(CommandBehavior.CloseConnection);
            rdr.Read();

            string Email = rdr.GetString(rdr.GetOrdinal("email"));
            string FirstName = rdr.GetString(rdr.GetOrdinal("fname"));
            string LastName = rdr.GetString(rdr.GetOrdinal("lname"));
            string address = rdr.GetString(rdr.GetOrdinal("addres"));
            string nationality = rdr.GetString(rdr.GetOrdinal("nationality"));

            Label lbl_users = new Label();
            lbl_users.Text = "First name: " + FirstName +  "<br />" + "Last name: " + LastName +  "<br />" + "Email: " + Email +  "<br />" + "Address: "+  address +  "<br />" + "Nationality: "+  nationality + "<br />"; 
            form1.Controls.Add(lbl_users);

            Label breakk = new Label();
            breakk.Text = "<br />";
            form1.Controls.Add(breakk);
            
            rdr.Close();


            Boolean manager = false;

            SqlCommand isManager = new SqlCommand("isManager", conn);
            isManager.CommandType = CommandType.StoredProcedure;

            isManager.Parameters.Add(new SqlParameter("@email", (String)Session["LoggedInUser"]));

            SqlParameter output1 = isManager.Parameters.Add("@return", SqlDbType.Int);
            output1.Direction = ParameterDirection.Output;

            conn.Open();
            isManager.ExecuteNonQuery();
            conn.Close();

            if (output1.Value.ToString().Equals("1"))
            {
                manager = true;
            }

            if (manager && Request.QueryString["email"] == null)
            {
                HyperLink switch_view = new HyperLink();
                switch_view.Text = "Switch To Manager View";
                switch_view.NavigateUrl = "manager_profile.aspx";
                form1.Controls.Add(switch_view);

                form1.Controls.Add(breakk);

                
            }

            if (manager && Request.QueryString["email"] != null)
            {
                HyperLink invite_manager = new HyperLink();
                invite_manager.Text = "invite to manage one of my places <br />";
                invite_manager.NavigateUrl = "invite_to_manage.aspx?email=" + Request.QueryString["email"];
                form1.Controls.Add(invite_manager);
            }

            Boolean friend = false;

            SqlCommand isFriend = new SqlCommand("isFriend", conn);
            isFriend.CommandType = CommandType.StoredProcedure;

            isFriend.Parameters.Add(new SqlParameter("@email1", (String)Session["LoggedInUser"]));
            isFriend.Parameters.Add(new SqlParameter("@email2", email));

            SqlParameter output2 = isFriend.Parameters.Add("@return", SqlDbType.Int);
            output2.Direction = ParameterDirection.Output;

            conn.Open();
            isFriend.ExecuteNonQuery();
            conn.Close();

            if (output2.Value.ToString().Equals("1"))
            {
                friend = true;
            }


            if (email != Session["LoggedInUser"] && !friend)
            {
                HyperLink add = new HyperLink();
                add.Text = "Add Friend <br />";
                add.NavigateUrl = "send_request.aspx?email="+email;
                form1.Controls.Add(add);

            }

            if (email == (String)Session["LoggedInUser"] || friend)
            {
                HyperLink visits = new HyperLink();
                visits.Text = "View visited places <br />";
                visits.NavigateUrl = "view_visited.aspx?email="+email;
                form1.Controls.Add(visits);

                HyperLink likes = new HyperLink();
                likes.Text = "View liked places <br />";
                likes.NavigateUrl = "view_liked.aspx?email=" + email;
                form1.Controls.Add(likes);
            }

            if (email == (String)Session["LoggedInUser"])
            {
                HyperLink requests = new HyperLink();
                requests.Text = "View Friend Requests <br />";
                requests.NavigateUrl = "view_requests.aspx";
                form1.Controls.Add(requests);

                HyperLink friends = new HyperLink();
                friends.Text = "View Friends<br />";
                friends.NavigateUrl = "View_Friends.aspx";
                form1.Controls.Add(friends);

                HyperLink messages = new HyperLink();
                messages.Text = "View Messages<br />";
                messages.NavigateUrl = "View_Message.aspx";
                form1.Controls.Add(messages);

                HyperLink invite_m = new HyperLink();
                invite_m.Text = "View Invitations to manage a place<br />";
                invite_m.NavigateUrl = "View_Invite_m.aspx";
                form1.Controls.Add(invite_m);

                HyperLink recommend = new HyperLink();
                recommend.Text = "Recommend me places to visit<br />";
                recommend.NavigateUrl = "recommend.aspx";
                form1.Controls.Add(recommend);

                HyperLink top10 = new HyperLink();
                top10.Text = "Show me the top 10 users having most common likes with me<br />";
                top10.NavigateUrl = "top10.aspx";
                form1.Controls.Add(top10);

                HyperLink likess = new HyperLink();
                likess.Text = "View places with the highest number of likes";
                likess.NavigateUrl = "view_place_likes.aspx";
                form1.Controls.Add(likess);

                Label breakkk = new Label();
                breakkk.Text = "<br />";
                form1.Controls.Add(breakkk);

                HyperLink sortedc = new HyperLink();
                sortedc.Text = "View places sorted according to their rating criteria";
                sortedc.NavigateUrl = "View_places_criteria.aspx";
                form1.Controls.Add(sortedc);

            }
            if (friend)
            {
                lbl_message.Visible = true;
                txt_message.Visible = true;
                btn_send.Visible = true;
            }

            
            
        }
        



        protected void send_msg(object sender, EventArgs e)
        {

            string receiver = email;
            string msg = txt_message.Text;
            Response.Redirect("send_message.aspx?email="+receiver+"&msg="+msg);
        }
    }
}