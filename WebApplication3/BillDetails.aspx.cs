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
    public partial class BillDetails : System.Web.UI.Page
    {
        protected string id = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request["value"];

              string cmdToFilter = null;
            string sql2 = null;
            int sum = 0;
            using (SqlConnection cnn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ims"].ToString()))
            {
                cmdToFilter = " select * from OrdersDetail o, Product p where o.ProductId = p.ProductId and BillId = 'B' and BillNo = " + id;


                cnn.Open();
                using (SqlCommand cmd2 = new SqlCommand(cmdToFilter, cnn))
                {
                    SqlDataReader reader = cmd2.ExecuteReader();
                    Repeater1.DataSource = reader;
                    Repeater1.DataBind();
                    reader.Close();

                }
                cnn.Close();
            }

            double mon = 0;
            double mon2 = 0;
            string sql3 = "Select sum(SumOfTotal) a from OrdersDetail where BillNo = " + id;
            string sql4 = "Select sum(DebitAmount) b from Payment where BillNo = " + id;
            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ims"].ToString()))
            {
                con.Open();

              
                using (SqlCommand cmd2 = new SqlCommand(sql4,con))
                {
                    SqlDataReader read2 = cmd2.ExecuteReader();
                    while (read2.Read())
                    {
                        double.TryParse(read2["b"].ToString(), out mon);
                    }
                    read2.Close();

                }
                
                using (SqlCommand cmd1 = new SqlCommand(sql3, con))
                {
                  
                    SqlDataReader read1 = cmd1.ExecuteReader();
                    while (read1.Read())
                    {
                       double.TryParse(read1["a"].ToString(), out mon2) ;
                    }
                    
                    read1.Close();
                }


                con.Close();

                lbl1.Text = (mon2 - mon).ToString();
            }

            


        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName== "btn")
            {
                string sql2 = "Select sum(SumOfTotal) from OrdersDetail where BillNo = " + e.CommandArgument;

                //double sum = 0;
                //double.TryParse(lbl1.Text, out sum);
                //double num2 = 0;
                //double.TryParse(t1.Text, out num2);
                //using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ims"].ToString()))
                //{
                //    string sql = "Insert into Payment (BillId, Paytype, CreditAmount, DebitAmount, DebitDate, Balance, BillNo ) ";
                //    sql += "Select 'B', 'Cash'," + (sum - num2) + "," + num2 + ",'" + DateTime.Now + "'," + (num2 - (sum - num2)) + ", 2113";

                //    using (SqlCommand cmd = new SqlCommand(sql, con))
                //    {
                //        try
                //        {
                //            con.Open();
                //            cmd.ExecuteNonQuery();
                //            lblInfo.Text = "Successful";
                //        }
                //        catch (Exception err)
                //        {
                //            lblInfo.Text = err.Message;
                //        }
                //        finally
                //        {
                //            con.Close();
                //        }
                //    }
                //}
            }
        }

        protected void btn1_Click(object sender, EventArgs e)
        {

            double sum = 0;
            double.TryParse(lbl1.Text, out sum);
            double num2 = 0;
            double.TryParse(t1.Text, out num2);
            DateTime dt = new DateTime();
            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ims"].ToString()))
            {
                

                string sql = "Insert into Payment (BillId, Paytype, CreditAmount, DebitAmount, DebitDate, Balance, BillNo ) ";
                sql += "Select 'B', '" + Request.Form["select1"] + "'," + (sum - num2) + "," + num2 + ",'" + DateTime.Now + "'," + num2 + "," + id;
                string sql2 = "Select DebitDate from Payment where BillNo = " + id;
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        //lblInfo.Text = "Successful";
                    }
                    catch (Exception err)
                    {
                        //lblInfo.Text = err.Message;
                    }
                    finally
                    {
                        con.Close();
                    }
                }

                using (SqlCommand cmd2 = new SqlCommand(sql2,con))
                {
                    SqlDataReader read1;
                    try
                    {
                        con.Open();
                        read1 = cmd2.ExecuteReader();
                        read1.Read();
                        dt = (DateTime)read1["DebitDate"];
                        read1.Close();
                    }
                    catch (Exception err)
                    {
                       // err.Message;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

            double mon = 0;
            double mon2 = 0;
            string sql3 = "Select sum(SumOfTotal) a from OrdersDetail where BillNo = " + id;
            string sql4 = "Select sum(DebitAmount) b from Payment where BillNo = " + id;
            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ims"].ToString()))
            {
                con.Open();


                using (SqlCommand cmd2 = new SqlCommand(sql4, con))
                {
                    SqlDataReader read2 = cmd2.ExecuteReader();
                    while (read2.Read())
                    {
                        double.TryParse(read2["b"].ToString(), out mon);
                    }
                    read2.Close();

                }

                using (SqlCommand cmd1 = new SqlCommand(sql3, con))
                {

                    SqlDataReader read1 = cmd1.ExecuteReader();
                    while (read1.Read())
                    {
                        double.TryParse(read1["a"].ToString(), out mon2);
                    }

                    read1.Close();
                }


                con.Close();

                if ((mon2 - mon) == 0)
                {
                    btn1.Visible = false;
                    select1.Visible = false;

                    string sql5 = "Update OrdersDetail Set Status = 'CLOSED' where BillNo = " + id;
                    using (SqlConnection con1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["ims"].ToString()))
                    {
                        con1.Open();
                        using (SqlCommand cmd5 = new SqlCommand(sql5, con1))
                        {
                            cmd5.ExecuteNonQuery();
                        }
                        con1.Close();
                    }
                }
                lbl1.Text = (mon2 - mon).ToString();
            }


            Response.Redirect("/GenerateBill.aspx?value=" + id + "&&date=" + DateTime.Now.ToString("HH:mm:ss tt"));

        }
    }
}