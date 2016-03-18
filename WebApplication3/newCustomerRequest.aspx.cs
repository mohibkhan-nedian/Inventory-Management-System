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
    public partial class newCustomerRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string cmdToFilter = null;
            using (SqlConnection cnn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ims"].ToString()))
            {
                cmdToFilter = "SELECT * FROM CustomerCopy ";


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
                string regno = null;
                int reg = 0;
                int add1 = 0;
                int add2 = 0;
                int add3 = 0;
                string newsql = "Select Regno from CustData";
                string newsql2 = "Select addr2 from CustomerCopy";
                string newsql3 = "Select email2 from CustomerCopy";
                string newsql4 = "Select contact2 from CustomerCopy";
                using (SqlConnection cnn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ims"].ToString()))
                {
                    cnn.Open();
                    using (SqlCommand newcmd = new SqlCommand(newsql,cnn))
                    {
                        SqlDataReader read1;
                        read1 = newcmd.ExecuteReader();
                        while (read1.Read())
                        {
                            regno = read1["Regno"].ToString();

                        }


                        read1.Close();
                    }

                    using (SqlCommand cmd2 = new SqlCommand(newsql2,cnn))
                    {
                        SqlDataReader read2;
                        read2 = cmd2.ExecuteReader();

                        while (read2.Read())
                        {
                            if (read2["addr2"].ToString() == null)
                            {
                                add1++;
                            }
                        }
                        read2.Close();
                    }



                    using (SqlCommand cmd3 = new SqlCommand(newsql3, cnn))
                    {
                        SqlDataReader read3;
                        read3 = cmd3.ExecuteReader();

                        while (read3.Read())
                        {
                            if (read3["email2"].ToString() == null)
                            {
                                add2++;
                            }
                        }
                        read3.Close();
                    }


                    using (SqlCommand cmd4 = new SqlCommand(newsql4, cnn))
                    {
                        SqlDataReader read4;
                        read4 = cmd4.ExecuteReader();

                        while (read4.Read())
                        {
                            if (read4["contact2"].ToString() == null)
                            {
                                add3++;
                            }
                        }
                        read4.Close();
                    }
                    cnn.Close();
                    int.TryParse(regno, out reg);

                }


                string sql = "Insert into CustData (CID, Regno, Fname, Lname,StaffID)";
                sql += "Select custid,"+ (reg + 1) +",fname,lname," + Session["val1"] + "from CustomerCopy where custid=" + e.CommandArgument;
                string sql2 = "  SET IDENTITY_INSERT CustData ON";

                string sql4 = null;
                if (add1 > 0)
                {
                    sql4 = " Insert into CustomerAddr (CID,Adress,AdressDetail) ";
                    sql4 += "Select " + e.CommandArgument + ",1,addr1 from CustomerCopy where custid=" + e.CommandArgument;
                }
                else
                {
                    sql4 = " Insert into CustomerAddr (CID,Adress,AdressDetail) ";
                    sql4 += "Select " + e.CommandArgument + ",1,addr1 from CustomerCopy where custid=" + e.CommandArgument + " union Select " + e.CommandArgument + ",2 , addr2 from CustomerCopy where custid = " + e.CommandArgument;
                }

                string sql5 = null;
                if (add2 > 0)
                {
                                    sql5 = " Insert into CustomerEmail (CID,Email,EmailAdress, Password) ";
                                    sql5 += "Select " + e.CommandArgument + ",1,email1, password from CustomerCopy where custid = " + e.CommandArgument;

                }
                else
                {
                    sql5 = " Insert into CustomerEmail (CID,Email,EmailAdress, Password) ";
                    sql5 += "Select " + e.CommandArgument + ",1,email1, password from CustomerCopy where custid = " + e.CommandArgument + " union Select " + e.CommandArgument + ",2,email2, password from CustomerCopy where custid = " + e.CommandArgument;

                }
                string sql6 = null;
                if ( add3 > 0)
                {
                sql6 = " Insert into CustomerContact (CID,Contact,ContactNo) ";
                sql6 += "Select " + e.CommandArgument + ",1,contact1 from CustomerCopy where custid=" + e.CommandArgument;
                }
                else
                {

                    sql6 = " Insert into CustomerContact (CID,Contact,ContactNo) ";
                    sql6 += "Select " + e.CommandArgument + ",1,contact1 from CustomerCopy where custid=" + e.CommandArgument + " union Select " + e.CommandArgument + ",2 , contact2 from CustomerCopy where custid = " + e.CommandArgument;

                }
                
                string sql3 = "Delete from CustomerCopy where custid = " + e.CommandArgument;
                using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ims"].ToString()))
                {
                    con.Open();
                    try
                    {
                     
                        using (SqlCommand cmd2 = new SqlCommand(sql2,con))
                        {
                            cmd2.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand(sql,con))
                        {
                            cmd.ExecuteNonQuery();
                        }

                        using (SqlCommand cmd4 = new SqlCommand(sql4,con))
                        {
                            cmd4.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd5 = new SqlCommand(sql5, con))
                        {
                            cmd5.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd6 = new SqlCommand(sql6, con))
                        {
                            cmd6.ExecuteNonQuery();
                        }

                        using (SqlCommand cmd3 = new SqlCommand(sql3, con))
                        {
                            cmd3.ExecuteNonQuery();
                        }

                        lblInfo.Text = "Succesful";
                    }
                    catch (Exception err)
                    {
                        lblInfo.Text += err.Message;
                    }
                    finally
                    {
                        con.Close();
                    }

                }

               // Response.Redirect("/Customer.aspx?value=" + e.CommandArgument.ToString());

            }
        }
    }
}