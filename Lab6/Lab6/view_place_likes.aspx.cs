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
    public partial class view_place_likes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand view = new SqlCommand("max_city", conn);
            view.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader rdr = view.ExecuteReader(CommandBehavior.CloseConnection);
            rdr.Read();
            Label breakk = new Label();
            breakk.Text = "<br />";
            if (!rdr.IsDBNull(rdr.GetOrdinal("name"))) 
            { 
                string city = rdr.GetString(rdr.GetOrdinal("name"));
                Label cityy = new Label();
                cityy.Text = "City: "+city;
                form1.Controls.Add(cityy);
                breakk.Text = "<br />";
                form1.Controls.Add(breakk); 
            }
            rdr.Close();
            conn.Close();

            

            SqlCommand view1 = new SqlCommand("max_hotel", conn);
            view1.CommandType = CommandType.StoredProcedure;
            conn.Open();
            rdr = view1.ExecuteReader(CommandBehavior.CloseConnection);
            rdr.Read();
            if (!rdr.IsDBNull(rdr.GetOrdinal("name")))
            {
                string hotel = rdr.GetString(rdr.GetOrdinal("name"));
                Label hotell = new Label();
                hotell.Text = "Hotel: " + hotel;
                form1.Controls.Add(hotell);
                Label br = new Label();
                br.Text = "<br />";
                form1.Controls.Add(br);
            }
            rdr.Close();
            conn.Close();

            SqlCommand view2 = new SqlCommand("max_monument", conn);
            view2.CommandType = CommandType.StoredProcedure;
            conn.Open();
            rdr = view2.ExecuteReader(CommandBehavior.CloseConnection);
            rdr.Read();
            if (!rdr.IsDBNull(rdr.GetOrdinal("name"))) 
            {
            string monument = rdr.GetString(rdr.GetOrdinal("name"));
            Label monumentt = new Label();
            monumentt.Text = "Monument: " + monument;
            form1.Controls.Add(monumentt);
            Label br = new Label();
            br.Text = "<br />";
            form1.Controls.Add(br);
            }

            rdr.Close();
            conn.Close();

            SqlCommand view3 = new SqlCommand("max_museum", conn);
            view3.CommandType = CommandType.StoredProcedure;
            conn.Open();
            rdr = view3.ExecuteReader(CommandBehavior.CloseConnection);
            rdr.Read();
            if (!rdr.IsDBNull(rdr.GetOrdinal("name")))
            {
                string museum = rdr.GetString(rdr.GetOrdinal("name"));
                Label museumm = new Label();
                museumm.Text = "Museum: " + museum;
                form1.Controls.Add(museumm);
                Label br = new Label();
                br.Text = "<br />";
                form1.Controls.Add(br);
            }
            rdr.Close();
            conn.Close();

            SqlCommand view4 = new SqlCommand("max_restaurant", conn);
            view4.CommandType = CommandType.StoredProcedure;
            conn.Open();
            rdr = view4.ExecuteReader(CommandBehavior.CloseConnection);
            rdr.Read();
            if (!rdr.IsDBNull(rdr.GetOrdinal("name")))
            {
                string restaurant = rdr.GetString(rdr.GetOrdinal("name"));
                Label restaurantt = new Label();
                restaurantt.Text = "Restaurant: " + restaurant;
                form1.Controls.Add(restaurantt);
                Label br = new Label();
                br.Text = "<br />";
                form1.Controls.Add(br);
            }
            conn.Close();

        }
    }
}