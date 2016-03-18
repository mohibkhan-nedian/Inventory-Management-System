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
    public partial class StaffLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitid_click(object sender, EventArgs e)
        {
            int cid = 0;
            if (string.IsNullOrWhiteSpace(Request["email"]) == true || string.IsNullOrWhiteSpace(Request["pwd"]) == true)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Email or Password cannot be left empty')", true);

            }
            else
            {
                string sql2 = null;
                string admin = null;

                using (SqlConnection cnn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ims"].ToString()))
                {
                    int staffId = 0;
                    int isPresent = 0;
                    sql2 = "select count(*) from StaffData where Username=@Email AND Password=@Password  ";
                    admin = "select * from StaffData where Username=@Email AND Password=@Password";
                    cnn.Open();
                    using (SqlCommand cmd2 = new SqlCommand(sql2, cnn))
                    {

                        cmd2.Parameters.AddWithValue("@Email", Request["email"]);
                        cmd2.Parameters.AddWithValue("@Password", Request["pwd"]);
                        isPresent = (int)cmd2.ExecuteScalar();

                    }
                    if (isPresent <= 0)
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Username or Password')", true);
                    else
                    {
                        using (SqlCommand cmd3 = new SqlCommand(admin, cnn))
                        {

                            cmd3.Parameters.AddWithValue("@Email", Request["email"]);
                            cmd3.Parameters.AddWithValue("@Password", Request["pwd"]);
                            SqlDataReader reader = cmd3.ExecuteReader();
                            reader.Read();
                            cid = (int)reader["Roleid"];
                            staffId = (int)reader["StaffID"];
                            reader.Close();

                            //string insertSql = "Insert into cp Values(@id,@custid,@quantity,@datetime)";
                            //using (SqlCommand newcmd = new SqlCommand(insertSql, cnn))
                            //{
                            //    newcmd.Parameters.AddWithValue("@id", id);
                            //    newcmd.Parameters.AddWithValue("@custid", cid);
                            //    newcmd.Parameters.AddWithValue("@quantity", quant);
                            //    newcmd.Parameters.AddWithValue("@datetime", DateTime.Now);
                            //    newcmd.ExecuteNonQuery();
                            //    lblInfo.Text += " Successful";
                            //}
                            if (cid == 1)
                            {
                                Response.Redirect("/ViewStaff.aspx?value="+staffId );
                            }
                            else if (cid == 2)
                            {
                                Response.Redirect("/Products2.aspx?value=" + staffId);
                            }
                            else
                            {
                                Response.Redirect("/ViewOrders.aspx?value=" + staffId);
                            }
                        }

                    }


                }
            }

            
        }
    }
}