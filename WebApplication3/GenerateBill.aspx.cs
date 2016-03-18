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
    public partial class GenerateBill : System.Web.UI.Page
    {
        protected string id = null;
        protected string dt = null;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            id = Request["value"];
            dt = Request["date"];
            string sql = "Select * from Payment where BillNo = " + id ;

            string sql2 = "Select Sum(Balance) a from Payment where BillNo = " + id;
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ims"].ToString());
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlCommand cmd2 = new SqlCommand(sql2, con);


            SqlDataReader read1;
            SqlDataReader read2;
            try
            {
                con.Open();
                read1 = cmd.ExecuteReader();
                while (read1.Read())
                {
                    Label1.Text = read1["DebitAmount"].ToString();
                    Label3.Text = read1["CreditAmount"].ToString();
                 
                } 
                read1.Close();

                read2 = cmd2.ExecuteReader();
                read2.Read();
                Label5.Text = read2["a"].ToString();
                read2.Close();
            }
            catch (Exception err)
            {

            }
            finally
            {
                con.Close();

            }


        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ViewAllBills.aspx");
        }
    }
}