﻿using System;
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
    public partial class remove_comment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int pid = int.Parse(Request.QueryString["placeid"]);
            int cid = int.Parse(Request.QueryString["commentid"]);
            String user_added = Request.QueryString["added"];

            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("remove_comment", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@email", (String)Session["LoggedInUser"]));
            cmd.Parameters.Add(new SqlParameter("@comment", cid));
            cmd.Parameters.Add(new SqlParameter("@added", user_added));
            cmd.Parameters.Add(new SqlParameter("@place", pid));

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("view_comments.aspx?placeid="+pid);
        }
    }
}