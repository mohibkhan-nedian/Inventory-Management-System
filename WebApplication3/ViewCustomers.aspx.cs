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
    public partial class ViewCustomers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["StaffID"] = Request["value"];

            if (this.IsPostBack == false)
            {
                string cmdToFilter = null;
                using (SqlConnection cnn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ims"].ToString()))
                {
                    cmdToFilter = "SELECT * FROM CustData ";


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
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "btn")
            {
                Response.Redirect("/CustomerProfile.aspx?value=" + e.CommandArgument);
            }

            if (e.CommandName == "btn2")
            {
                string sql = "Delete from CustomerEmail where CID = " + e.CommandArgument;
                string sql1 = "Delete from CustomerContact where CID = " + e.CommandArgument;
                string sql2 = "Delete from CustomerAddr where CID = " + e.CommandArgument;
                string sql3 = "Delete from CustData where CID = " + e.CommandArgument;
                using (SqlConnection cnn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ims"].ToString()))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql,cnn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd1 = new SqlCommand(sql1, cnn))
                    {
                        cmd1.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd2 = new SqlCommand(sql2, cnn))
                    {
                        cmd2.ExecuteNonQuery();
                    }


                    using (SqlCommand cmd3 = new SqlCommand(sql3, cnn))
                    {
                        cmd3.ExecuteNonQuery();
                    }

                    cnn.Close();



                }
            }
        }
    }
}