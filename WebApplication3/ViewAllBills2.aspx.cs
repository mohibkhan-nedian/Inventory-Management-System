using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class ViewAllBills2 : System.Web.UI.Page
    {
        protected string id = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["StaffID"] = Request["value"];

            id = Request["value"];


        }
    }
}