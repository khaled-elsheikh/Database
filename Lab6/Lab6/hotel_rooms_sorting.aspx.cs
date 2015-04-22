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
    public partial class hotel_rooms_sorting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand view = new SqlCommand("sort_price_rooms", conn);
            view.CommandType = CommandType.StoredProcedure;


            conn.Open();
            SqlDataReader rdr = view.ExecuteReader(CommandBehavior.CloseConnection);
            while(rdr.Read()){
                String type = rdr.GetString(rdr.GetOrdinal("typee"));
                String name = rdr.GetString(rdr.GetOrdinal("name"));
                float price = rdr.GetFloat(rdr.GetOrdinal("price"));

                Label typee = new Label();
                typee.Text = "The room is of type: " + type + " in hotel: " + name + "having a price of: " + price + "<br />";
                form1.Controls.Add(typee);

            }
        }
    }
}