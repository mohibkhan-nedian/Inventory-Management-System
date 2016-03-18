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
    public partial class ProductDetail2 : System.Web.UI.Page
    {
        protected string productid = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(this.IsPostBack==false)
            { 
            int ses = 0;
            int.TryParse(Session.SessionID, out ses);
            productid = Request["value"].ToString();
            fake.Text = productid.ToString();
       //     Label1.Text = ses.ToString();
            Session["ses1"] = productid;
            string sql = "Select PItem, PDescr,Discount,UnitPerStock, UnitsInOrder, UnitPerStock, UnitCost,UnitSellPrice,StockQuantity, SupplierName,Images from Product where ProductId =" + productid;

             string str = null;

             using (SqlConnection cnn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ims"].ToString()))
             {
                 cnn.Open();
                 using (SqlCommand cmd = new SqlCommand(sql, cnn))
                 {
                     SqlDataReader reader1;

                     reader1 = cmd.ExecuteReader();
                     while (reader1.Read())
                     {
                         byte[] imgdata = (byte[])reader1["Images"];
                         Heading.Text = reader1["PItem"].ToString();
                         pdesc.Text = reader1["PDescr"].ToString();
                         ups.Text = reader1["UnitPerStock"].ToString();
                         unitcost.Text = reader1["UnitCost"].ToString();
                         suplier.Text = reader1["SupplierName"].ToString();
                         disc.Text = reader1["Discount"].ToString();
                         inorder.Text = reader1["UnitsInOrder"].ToString();
                         sellprice.Text = reader1["UnitSellPrice"].ToString();
                         stock.Text = reader1["StockQuantity"].ToString();

                         img.ImageUrl = "data:image/png;base64," + Convert.ToBase64String((Byte[])reader1["Images"], 0, ((Byte[])reader1["Images"]).Length);

                     }
                     reader1.Close();

                 }


             }

            }
        }

        protected void update_click(object sender, EventArgs e)
        {
            using (SqlConnection cnn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ims"].ToString()))
            {
                cnn.Open();
                string upprod = "Update Product set PDescr ='" + pdesc.Text + "', Discount =" + disc.Text + ", UnitPerStock=" + ups.Text + ", UnitsInOrder=" + inorder.Text + ", UnitCost=" + unitcost.Text + ", UnitSellPrice=" + sellprice.Text + ", StockQuantity=" + stock.Text + ", SupplierName='" + suplier.Text + "'  where ProductId=" + fake.Text + " ";

                SqlCommand cmd = new SqlCommand(upprod, cnn);

                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            
        }
    }
}