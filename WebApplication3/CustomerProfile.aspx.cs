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
    public partial class CustomerProfile : System.Web.UI.Page
    {
        protected string id = null;
        protected void Page_Load(object sender, EventArgs e)
        {

             id = Request["value"];
             lblInfo.Text = id;
             string fn = null;

             string sql = "Select Fname,Lname,Regno from CustData where CID = " + id;
             string sql2 = "Select * from CustomerEmail where CID = " + id + " and Email = " + 1;

             string sql3 = "Select * from CustomerEmail where CID = " + id + " and Email = " + 2;
             string sql4 = "Select * from CustomerAddr where CID = " + id + " and Adress = " + 1;

             string sql5 = "Select * from CustomerAddr where CID = " + id + " and Adress = " + 2;
             string sql6 = "Select * from CustomerContact where CID = " + id + " and Contact = " + 1;

             string sql7 = "Select * from CustomerContact where CID = " + id + " and Contact = " + 2;

             using (SqlConnection cnn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ims"].ToString()))
             {
                 cnn.Open();
                 using (SqlCommand cmd1 = new SqlCommand(sql, cnn))
                 {
                     SqlDataReader read1;
                     read1 = cmd1.ExecuteReader();
                     read1.Read();
                        name.Text = read1["Fname"].ToString() + "  " + read1["Lname"].ToString();
                     regno.Text = read1["Regno"].ToString();
                     read1.Close();
                 }

                 //name.Text = fn;

                 using (SqlCommand cmd2 = new SqlCommand(sql2, cnn))
                 {
                     SqlDataReader read2;
                     read2 = cmd2.ExecuteReader();
                     read2.Read();
                     email1.Text = read2["EmailAdress"].ToString();
                     read2.Close();
                 }

                 using (SqlCommand cmd3 = new SqlCommand(sql3, cnn))
                 {
                     SqlDataReader read3;
                     read3 = cmd3.ExecuteReader();
                     read3.Read();
                     email2.Text = read3["EmailAdress"].ToString();
                     read3.Close();
                 }

                 using (SqlCommand cmd4 = new SqlCommand(sql4, cnn))
                 {
                     SqlDataReader read4;
                     read4 = cmd4.ExecuteReader();
                     read4.Read();
                     addr1.Text = read4["AdressDetail"].ToString();
                     read4.Close();
                 }

                 using (SqlCommand cmd5 = new SqlCommand(sql5, cnn))
                 {
                     SqlDataReader read5;
                     read5 = cmd5.ExecuteReader();
                     read5.Read();
                     addr2.Text = read5["AdressDetail"].ToString();
                     read5.Close();
                 }

                 using (SqlCommand cmd6 = new SqlCommand(sql6, cnn))
                 {
                     SqlDataReader read6;
                     read6 = cmd6.ExecuteReader();
                     read6.Read();
                     Contact1.Text = read6["ContactNo"].ToString();
                     read6.Close();
                 }
                 using (SqlCommand cmd7 = new SqlCommand(sql7, cnn))
                 {
                     SqlDataReader read7;
                     read7 = cmd7.ExecuteReader();
                     read7.Read();
                     contact2.Text = read7["ContactNo"].ToString();
                     read7.Close();
                 }
                 cnn.Close();
             }

        }

        protected void Btn1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ViewOrder2.aspx?value=" + id);
        }

        protected void Btn2_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ViewAllBills2.aspx?value=" + id);
        }
    }
}