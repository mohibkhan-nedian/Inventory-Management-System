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
    public partial class Products2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             Search.Focus();
            //int count = 0;
            //string catSql = "Select count(*) as count from Category";
            //string catSql2 = "Select CatName from Category";

            //SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ims"].ToString());

            //    con.Open();
            //    SqlCommand cmd1 = new SqlCommand(catSql,con);
            //    SqlCommand cmd3 = new SqlCommand(catSql2,con);

            //        SqlDataReader read1;
            //        read1 = cmd1.ExecuteReader();
            //        if (read1.Read())
            //        {
            //            count = read1.GetInt32(0);
            //        }
            //        read1.Close();

            //CheckBox[] chk = new  CheckBox[count];
            //int num = 0;
            //     SqlDataReader read2;
            //    read2 = cmd3.ExecuteReader();
            //  while ( read2.Read())
            //  {
            //      chk[num] = new CheckBox();
            //      chk[num].Text = read2["CatName"].ToString();
            //      chk[num].AutoPostBack = true;
            //      Panel1.Controls.Add(chk[num]);
            //      num++;
            //  }
            //  read2.Close();
            //  con.Close();






   
            string cmdToFilter = null;
            string cmdToFilter2 = "Select * from Category";


            using (SqlConnection cnn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ims"].ToString()))
            {
                if (string.IsNullOrWhiteSpace(Search.Text) == true)
                {
                    cmdToFilter = "SELECT * FROM Product ";
                }

                if ((Search.Text == "Clothes") || (Search.Text == "clothes"))
                {
                    cmdToFilter = "Select * from Product where PItem like '%" + Search.Text + "%' or CatID =1";
                }
                else if (Search.Text == "Gadgets" && Search.Text == "gadgets")
                {
                    cmdToFilter = "Select * from Product where PItem like '%" + Search.Text + "%' or CatID =3";
                }
                else if (Search.Text == "Home Appliances" && Search.Text == "home appliances")
                {
                    cmdToFilter = "Select * from Product where PItem like '%" + Search.Text + "%' or CatID =4";
                }
                //else if (chk1.Checked && chk2.Checked)
                //{
                //    cmdToFilter = "Select * from Product where PItem like '%" + Search.Text + "%' and CatID =4 and CatID=3";
                //}
                //else if (chk1.Checked && chk3.Checked)
                //{
                //    cmdToFilter = "Select * from Product where PItem like '%" + Search.Text + "%' and CatID =4 and CatID=1";
                //}
                //else if (chk2.Checked && chk3.Checked)
                //{
                //    cmdToFilter = "Select * from Product where PItem like '%" + Search.Text + "%' and CatID =4 and CatID=3";
                //}
                else
                {
                    cmdToFilter = "Select * from Product where PItem like '%" + Search.Text + "%'";
                }

                //show all products
                cnn.Open();
                using (SqlCommand cmd2 = new SqlCommand(cmdToFilter, cnn))
                {
                    SqlDataReader reader = cmd2.ExecuteReader();
                    Repeater1.DataSource = reader;
                    Repeater1.DataBind();
                    cnn.Close();
                }
                //show all categories
                cnn.Open();
                using (SqlCommand cmd3 = new SqlCommand(cmdToFilter2, cnn))
                {
                    SqlDataReader reader = cmd3.ExecuteReader();
                    Repeater2.DataSource = reader;
                    Repeater2.DataBind();
                    cnn.Close();
                }

            }

        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "btn")
            {
                Response.Redirect("/ProductDetail2.aspx?value=" + e.CommandArgument.ToString());

            }
        }

        protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
        {




        }


        protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {



        }

        protected void check1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void Search_TextChanged(object sender, EventArgs e)
        {

        }

    }
}