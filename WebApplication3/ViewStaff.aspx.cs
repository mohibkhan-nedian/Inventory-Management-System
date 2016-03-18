using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;


namespace WebApplication3
{
    public partial class ViewStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["StaffID"] = Request["value"];

            string cmd = null;
            using (SqlConnection cnn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ims"].ToString())) 
            {
                cmd = "Select * FROM StaffData";

                cnn.Open();
                using (SqlCommand cmd1 = new SqlCommand(cmd,cnn))
                {

                    SqlDataReader Reader = cmd1.ExecuteReader();
                    Repeater2.DataSource = Reader;
                    Repeater2.DataBind();
                    cnn.Close();

                }
            }

        }

        protected void Repeater2_command(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "btn")
            {
                Response.Redirect("/StaffProfile.aspx?value=" + e.CommandArgument);
            }

            if (e.CommandName == "btn1")
            {
                string sql = "Delete from StaffAddr where StaffID = " + e.CommandArgument;
                string sql2 = "Delete from StaffContact where StaffID = " + e.CommandArgument;
                string sql3 = "Delete from StaffData where StaffID =" + e.CommandArgument;


                using (SqlConnection cnn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ims"].ToString()))
                {
                    cnn.Open();
                    using ( SqlCommand cmd1 = new SqlCommand(sql,cnn))
                    {
                        cmd1.ExecuteNonQuery();
                    }

                    using ( SqlCommand cmd2 = new SqlCommand(sql2, cnn))
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