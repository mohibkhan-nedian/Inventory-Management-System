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
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected string productid = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            int ses = 0;
            int.TryParse(Session.SessionID, out ses);
            productid = Request["value"].ToString();

            Label1.Text = ses.ToString();
            Session["ses1"] = productid;
            string sql = "Select PItem, PDescr, UnitPerStock, UnitCost, SupplierName,Images from Product where ProductId =" + productid;
            using (SqlConnection cnn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ims"].ToString()))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(sql,cnn))

                {
                    SqlDataReader reader1;
                    
                        reader1 = cmd.ExecuteReader();
                        while (reader1.Read())
                        {
                            byte[] imgdata = (byte[])reader1["Images"]; 
                            Heading.Text = reader1["PItem"].ToString();
                            Description.Text = reader1["PDescr"].ToString();
                            unitPerStock.Text = reader1["UnitPerStock"].ToString();
                            costprice.Text = reader1["UnitCost"].ToString();
                            supplier.Text = reader1["SupplierName"].ToString();

                            img.ImageUrl = "data:image/png;base64," + Convert.ToBase64String((Byte[])reader1["Images"], 0, ((Byte[])reader1["Images"]).Length);
     
                        }

                        int count = 0;
                        int.TryParse(unitPerStock.Text, out count);
                        for (int i = 1; i <= count; i++ )
                        {
                            d1.Items.Add(i.ToString());
                        }



                            reader1.Close();
                    
                        

                   

                }
                cnn.Close();

            }
        }

        protected void placeorder_Click(object sender, EventArgs e)
        {
            
            
            ////string sql = "Select sessionid from sessionorder  ";
       
            ////int sessionid = 0;
            //using (SqlConnection cnn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ims"].ToString()))
            //{
            //    cnn.Open();
            //    //using (SqlCommand cmd = new SqlCommand(sql, cnn))
            //    //{
            //    //    SqlDataReader reader1;

            //    //    reader1 = cmd.ExecuteReader();
            //    //    while (reader1.Read())
            //    //    {
            //    //        sessionid = (int) reader1["sessionid"] ;
            //    //    }


            //    //    reader1.Close();
            //    //}


            //    using (SqlCommand cmd2 = new SqlCommand("Insert into sessionorder (pid, sessionid) select ProductId = " + productid + ",'" + Session["ses1"].ToString() + "'", cnn))
            //    {
            //        cmd2.ExecuteNonQuery();
            //    }

            //    cnn.Close();

            //}
           
            Session[productid] = productid;

            Response.Redirect("/Customer.aspx?value=" + productid + "&&value2=" + (d1.SelectedIndex + 1));
        }
    }
}