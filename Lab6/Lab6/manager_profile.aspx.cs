using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab6
{
    public partial class manager_profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HyperLink switch_view = new HyperLink();
            switch_view.Text = "Switch To User View";
            switch_view.NavigateUrl = "ViewProfile.aspx";
            form1.Controls.Add(switch_view);

            Label breakk = new Label();
            breakk.Text = "<br />";
            form1.Controls.Add(breakk);

            HyperLink managed_places = new HyperLink();
            managed_places.Text = "View Places I manage";
            managed_places.NavigateUrl = "view_managed_places.aspx";
            form1.Controls.Add(managed_places);
        }
    }
}