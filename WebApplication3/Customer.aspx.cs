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
    public partial class Customer : System.Web.UI.Page
    {
        protected string id = null;
        protected string quant = null;
        protected string new2 = null;
        protected void Page_Load(object sender, EventArgs e)
        {

            

            lblInfo.Text = Session["ses1"].ToString();

            id = Request["value"].ToString();
            quant = Request["value2"].ToString();

            //ListBox1.Items.Add(id.ToString());

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            //string connectionString = WebConfigurationManager.ConnectionStrings["ims"].ConnectionString;
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ims"].ToString());

            string search = "Select EmailAdress from CustomerEmail ";

            string sql = "Insert into CustomerCopy Values (@fname,@lname,@addr1,@addr2,@email1,@email2,@contact1,@contact2, @pass)";
            int num = 0;
            int added = 0;
            try 
            {
                    con.Open();

                    using (SqlCommand cmd2 = new SqlCommand(search,con))
                    {
                        SqlDataReader read1 = cmd2.ExecuteReader();
                        while (read1.Read())
                        {
                            if ( (email1.Text == read1["EmailAdress"].ToString()) || (email2.Text == read1["EmailAdress"].ToString()))
                            {
                                num++;
                            }
                        }
                        read1.Close();
                   
                    }

                    if (num > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Email is already registered')", true);

                    }
                    else
                    {
                        using (SqlCommand cmd = new SqlCommand(sql, con))
                        {
                            cmd.Parameters.AddWithValue("@fname", fname.Text);
                            cmd.Parameters.AddWithValue("@lname", lname.Text);
                            cmd.Parameters.AddWithValue("@addr1", addr1.Text);
                            cmd.Parameters.AddWithValue("@addr2", addr2.Text);
                            cmd.Parameters.AddWithValue("@email1", email1.Text);
                            cmd.Parameters.AddWithValue("@email2", email2.Text);
                            cmd.Parameters.AddWithValue("@contact1", contact1.Text);
                            cmd.Parameters.AddWithValue("@contact2", contact2.Text);
                            cmd.Parameters.AddWithValue("@pass", password.Text);

                            //cmd.Parameters.AddWithValue("@Commerce", comm);

                            //cmd.Parameters.AddWithValue("@Details", Details.Text);
                            //cmd.Parameters.AddWithValue("@imagedata", Imgdata);
                            //cmd.Parameters.AddWithValue("@contactdetail", vertime.Text);
                            added = cmd.ExecuteNonQuery();

                        }
                    }
                //using( SqlCommand cmd2 = new SqlCommand(sql2,con))
                //{
                //    cmd2.Parameters.AddWithValue("@id", id);
                //    cmd2.ExecuteNonQuery();
                //}
                               lblInfo.Text= "Executed";
            }
            catch (Exception err)
            {
                 lblInfo.Text = "Error inserting record ";
                                lblInfo.Text += err.Message;
            }
            finally
            {
                con.Close();
            }

            if (added > 0)
            {
                filltable();
            }


        }

        protected void filltable()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["ims"].ConnectionString;
            int count = 0;
            string selectSQL = "SELECT custid FROM CustomerCopy ";
            string selectSQL2 = "Select Count(custid) as count From CustomerCopy";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlCommand cmd2 = new SqlCommand(selectSQL2, con);
            SqlDataReader reader;
            SqlDataReader reader2;
            try
            {
                con.Open();
                reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    count = reader2.GetInt32(0);
                }
                reader2.Close();

                 int[] newid = new int[count];
                int num = 0;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    newid[num] =(int) reader["custid"];
                   // newid = reader["custid"].ToString();
                    
                }
                lblInfo.Text += newid[num];
                reader.Close();
                string sql2 = "Insert into cp Values(@id,@custid,@quant,@date)";
                using (SqlCommand cmd3 = new SqlCommand(sql2, con))
                {
                    cmd3.Parameters.AddWithValue("@id", id);
                    cmd3.Parameters.AddWithValue("@custid", newid[num]);
                    cmd3.Parameters.AddWithValue("@quant", quant);
                    cmd3.Parameters.AddWithValue("@date", DateTime.Now);
                    cmd3.ExecuteNonQuery();
                    lblInfo.Text += " Successful";
                }

                
            }
            catch (Exception err)
            {
                lblInfo.Text = "Error reading the data base";
                lblInfo.Text += err.Message;
            }
            finally
            {
                con.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Products.aspx");
        }

        protected void Confirm_Click(object sender, EventArgs e)
        {
            int cid = 0;
            if (string.IsNullOrWhiteSpace(TextBox1.Text) == true || string.IsNullOrWhiteSpace(TextBox2.Text) == true)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Email or Password cannot be left empty')", true);

            }
            else
            {
                string sql2 = null;
                string admin = null;

                using (SqlConnection cnn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ims"].ToString()))
                {
                    int isPresent = 0;
                    sql2 = "select count(*) from CustomerEmail where EmailAdress=@Email AND Password=@Password  ";
                    admin = "select * from CustomerEmail where EmailAdress=@Email AND Password=@Password";
                    cnn.Open();
                    using (SqlCommand cmd2 = new SqlCommand(sql2, cnn))
                    {

                        cmd2.Parameters.AddWithValue("@Email", TextBox1.Text);
                        cmd2.Parameters.AddWithValue("@Password", TextBox2.Text);
                        isPresent = (int)cmd2.ExecuteScalar();

                    }
                    if (isPresent <= 0)
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Email Address or Password')", true);
                    else
                    {
                        using (SqlCommand cmd3 = new SqlCommand(admin, cnn))
                        {

                            cmd3.Parameters.AddWithValue("@Email", TextBox1.Text);
                            cmd3.Parameters.AddWithValue("@Password", TextBox2.Text);
                            SqlDataReader reader = cmd3.ExecuteReader();
                            reader.Read();
                            cid =(int) reader["CID"];
                            reader.Close();

                            string insertSql = "Insert into cp Values(@id,@custid,@quantity,@datetime)";
                            using (SqlCommand newcmd = new SqlCommand(insertSql, cnn))
                            {
                                newcmd.Parameters.AddWithValue("@id", id);
                                newcmd.Parameters.AddWithValue("@custid", cid);
                                newcmd.Parameters.AddWithValue("@quantity", quant);
                                newcmd.Parameters.AddWithValue("@datetime", DateTime.Now);
                                newcmd.ExecuteNonQuery();
                                lblInfo.Text += " Successful";
                            }
                            
                            //Response.Redirect("/Products.aspx");
                           
                        }

                    }


                }
            }

        }
    }
}