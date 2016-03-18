using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class ViewAllBills : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["StaffID"] = Request["value"];

            string cmdToFilter = null;
            using (SqlConnection cnn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ims"].ToString()))
            {
                cmdToFilter = "select * from OrdersDetail o, Product p , Orders a where o.ProductId = p.ProductId and o.OrderId = a.OrderId and o.Status = 'Open' ";


                cnn.Open();
                using (SqlCommand cmd2 = new SqlCommand(cmdToFilter, cnn))
                {
                    SqlDataReader reader = cmd2.ExecuteReader();
                    Repeater1.DataSource = reader;
                    Repeater1.DataBind();
                    cnn.Close();
                }
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "btn")
            {
                Response.Redirect("/BillDetails.aspx?value=" + e.CommandArgument.ToString());

            }
        }
    }
}