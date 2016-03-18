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
    public partial class Show_Sales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Session["StaffID"] = Request["value"];


        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ims"].ToString());
            string sql1 = "select Sum(o.OrderedQuantity * p.UnitSellPrice) - Sum(o.OrderedQuantity * p.UnitCost) a from OrdersDetail o, Product p, Payment q where o.ProductId = p.ProductId and o.BillNo = q.BillNo and q.DebitDate between '" + datepicker.Value + "' and '" + datepicker1.Value+"'";
            string sql3 = "select Sum(Balance) a from Payment  where DebitDate between '" + datepicker.Value + "' and '" + datepicker1.Value + "'";
            string sql2 = "select Sum(o.OrderedQuantity * p.UnitSellPrice) - Sum(o.OrderedQuantity * p.UnitCost) -Sum(o.OrderedQuantity * p.UnitSellPrice) + SUM(q.Balance) a from OrdersDetail o, Product p, Payment q where o.ProductId = p.ProductId and o.BillNo = q.BillNo and q.DebitDate between '" +  datepicker.Value  + "' and '" + datepicker1.Value + "'";

            SqlCommand cmd1 = new SqlCommand(sql1,con);
            SqlCommand cmd2 = new SqlCommand(sql2,con);
               SqlCommand cmd3 = new SqlCommand(sql3,con);

            SqlDataReader read1;
            SqlDataReader read2;
            SqlDataReader read3;

            try 
            {
                con.Open();

                read1 = cmd1.ExecuteReader();

                read1.Read();
                profit1.Text = read1["a"].ToString();
                read1.Close();

                read2= cmd2.ExecuteReader();
                read2.Read();
                profit2.Text = read2["a"].ToString();

                read3 = cmd3.ExecuteReader();
                read3.Read();
                bal1.Text = read3["a"].ToString();
                read3.Close();

            }
            catch ( Exception err)
            {

            }
            finally
            {
                con.Close();
            }


        }
    }
}