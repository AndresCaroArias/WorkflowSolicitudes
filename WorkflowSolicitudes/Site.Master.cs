using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WorkflowSolicitudes
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnLogout_Click(object sender, ImageClickEventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}
