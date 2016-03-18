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
    public partial class ViewOrders : System.Web.UI.Page
    {
        int id;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            id = 0;
            Session["StaffID"] = Request["value"];


            string cmdToFilter = null;
            using (SqlConnection cnn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ims"].ToString()))
            {
                cmdToFilter = "select * from cp a, Product b, CustData c where a.productid = b.ProductId and a.customerid = c.CID ";


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
                int count = 0; ;
                string newsql = "Select Count(OrderId) as count from Orders ";
                string newsql2 = "Select OrderId from Orders";
                SqlConnection cnn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ims"].ToString());
                SqlCommand newcmd = new SqlCommand(newsql, cnn);
                SqlCommand newcmd2 = new SqlCommand(newsql2, cnn);
                SqlDataReader read1;
                SqlDataReader read2;
                cnn.Open();
                read1 = newcmd.ExecuteReader();

                if (read1.Read())
                {
                    count = read1.GetInt32(0);
                }
                read1.Close();

                int[] newid = new int[count];
                int num = 0;
                read2 = newcmd2.ExecuteReader();
                while (read2.Read())
                {
                    newid[num] = (int)read2["OrderId"];
                    // newid = reader["custid"].ToString();

                }
                read2.Close();
                cnn.Close();

                int pid = 0;
                int quant = 0;
                string dt = null;

                SqlCommand newcmd3 = new SqlCommand("Select productid,quantity,orderDate from cp where customerid = " + e.CommandArgument, cnn);
                SqlDataReader read3;
                cnn.Open();
                read3 = newcmd3.ExecuteReader();
                while (read3.Read())
                {
                    pid = (int)read3["productid"];
                    quant = (int)read3["quantity"];
                    dt = read3["orderDate"].ToString();
                }
                read3.Close();
                cnn.Close();

                string newsql3 = "Select Count(OrderDetailId) as count from OrdersDetail ";
                string newsql4 = "Select OrderDetailId,BillNo from OrdersDetail";
              
                SqlCommand newcmd4 = new SqlCommand(newsql3, cnn);
                SqlCommand newcmd5 = new SqlCommand(newsql4, cnn);
                SqlDataReader read4;
                SqlDataReader read5;
                cnn.Open();
                read4 = newcmd4.ExecuteReader();

                if (read4.Read())
                {
                    count = read4.GetInt32(0);
                }
                read4.Close();

                int[] newid2 = new int[count];
                string billNo = null;

                string number = null;
                int num2 = 0;
                read5 = newcmd5.ExecuteReader();
                while (read5.Read())
                {
                    number = read5["OrderDetailId"].ToString();
                    billNo = read5["BillNo"].ToString() ;
                    // newid = reader["custid"].ToString();

                }
                read5.Close();
                cnn.Close();

                int newbillno = 0;

                if (billNo == null)
                {
                    newbillno = 1000;
                }
                else
                {
                    int.TryParse(billNo, out newbillno);
                }

                int abc = 0;
                if (number == null)
                {
                   abc = 0;
                }
          else
                {
                    int.TryParse(number, out abc);
                }



                string sql = "Insert into Orders (OrderId, CID, StaffID, ErrorMsg ) ";
                sql += "Select " + (newid[num]+1) + "," + e.CommandArgument + ","+ Session["val1"] +", 'null'";
               // string sql2 = "  SET IDENTITY_INSERT CustData ON";
                string sql2 = "Insert into OrdersDetail (OrderDetailId, BillId, BillNo, OrderId, ProductId, Size, OrderedQuantity, DeliveredQuantity, OrderDate) ";
                sql2 += "Select " + (abc+1) + ",'B'," + (newbillno+1) + "," + (newid[num]+1) + "," + pid +",'M'," + quant + ",1, '" + dt + "'";

                string sql3 = "Delete from cp where customerid = " + e.CommandArgument;
                using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ims"].ToString()))
                {
                    con.Open();
                    try
                    {
                        
                       
                        using (SqlCommand cmd = new SqlCommand(sql, con))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd2 = new SqlCommand(sql2, con))
                        {
                            cmd2.ExecuteNonQuery();
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