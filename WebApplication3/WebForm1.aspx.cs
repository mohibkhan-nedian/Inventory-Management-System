using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Text;

namespace WebApplication3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        int count=0;
        string abc;
        string xyz;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                fillcombo();
            }

        }
        private void fillcombo()
        {
            gender.Items.Add("Male");
            gender.Items.Add("Female");
            role.Items.Clear();
            string connectionString = WebConfigurationManager.ConnectionStrings["ims"].ConnectionString;

            string selectSQL = "SELECT Roleid, RoleName from Role ";
            string selectSQL2 = "Select StaffID from StaffData";
            SqlConnection con = new SqlConnection(connectionString);
            SqlConnection con2 = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlCommand cmd2 = new SqlCommand(selectSQL2, con);
            
            SqlDataReader reader;
            SqlDataReader reader2;

            try
            {
                con.Open();

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ListItem newItem = new ListItem();
                    newItem.Text = reader["RoleName"].ToString();
                    newItem.Value = reader["Roleid"].ToString();
                    role.Items.Add(newItem);
                }
                
                reader.Close();
                reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    
                    abc = reader2["StaffID"].ToString();

                    
                }

              //  lblInfo.Text = abc;

                reader2.Close();
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

        protected void Go_Click(object sender, EventArgs e)
        {
            if (fname.Text == "" || lname.Text == "" || username.Text == "" || password.Text == "")
            {
                lblInfo.Text = "Empty field need to be inserted";
                return;

            }

            string g;
            if (gender.SelectedIndex  == 0)
            {
                g = "M";
           
            }
            else
            {
                g = "F";
             
            }

          
            int res= 0;   
            int.TryParse(abc, out res);

            //lblInfo.Text = datepicker.Value;
            string connectionString = WebConfigurationManager.ConnectionStrings["ims"].ConnectionString;

            string selectSQL2 = "Select StaffID from StaffData";
            string insertSql = "Insert into StaffData(";
            insertSql += "Roleid,Fname,Lname,DOB,Gender,Username, Password) ";
            insertSql += "Values (" + (role.SelectedIndex + 1) + ",'" + fname.Text + "','" + lname.Text;
            insertSql += "','" + datepicker.Value + "','" + g + "','" + username.Text + "','" + password.Text + "')";
            SqlConnection con = new SqlConnection(connectionString);
            SqlConnection con2 = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(insertSql, con);
            SqlCommand cmd2 = new SqlCommand(selectSQL2, con);
            SqlDataReader reader2;


            int added = 0;
            try
            {
                con.Open();
                added = cmd.ExecuteNonQuery();

                reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {

                    xyz = reader2["StaffID"].ToString();


                }

                reader2.Close();
                lblInfo.Text = added.ToString() + " records inserted" + xyz;
            }
            catch (Exception err)
            {
                lblInfo.Text = "Error inserting record";
                lblInfo.Text += err.Message;
            }
            finally
            {
                con.Close();
            }

            if (added > 0)
            {
                fillcombo();
            }

        }

        protected void h1_Click(object sender, EventArgs e)
        {
            
            //Panel PlaceHolder1 = new Panel();
           
            //TextBox t1 = new TextBox();
            //t1.ID = "NewTextbox";
            //t1.Text = "";

            //Button b1 = new Button();
            //b1.Text = "Submit";
            //b1.Click += (asf, fdg) =>
                //{
            //          int num = 0;
            //int.TryParse(xyz,out num);
            //string connectionString = WebConfigurationManager.ConnectionStrings["ims"].ConnectionString;
            //string insertSql = "Insert into StaffAddr (";
            //insertSql += "StaffID, Address,AddressDetail) ";
            //insertSql += "Values (" + num + ", 1, '" + address.Text + "')";

            ////string insertSql2 = "Insert into StaffAddr (";
            ////insertSql2 += "StaffID, Address,AddressDetail) ";
            ////insertSql2 += "Values (" + num + ", 2, '" + t1.Text + "')";

            //SqlConnection con = new SqlConnection(connectionString);
            ////SqlConnection con2 = new SqlConnection(connectionString);
            //SqlCommand cmd = new SqlCommand(insertSql, con);
            ////SqlCommand cmd2 = new SqlCommand(insertSql2, con);
            //          int added = 0;
            //try
            //{
            //    con.Open();
            //    added = cmd.ExecuteNonQuery();
            //    //added = cmd2.ExecuteNonQuery();
            //    lblInfo.Text = added.ToString() + " records inserted";
            //}
            //catch (Exception err)
            //{
            //    lblInfo.Text = "Error inserting record";
            //    lblInfo.Text += err.Message;
            //}
            //finally
            //{
            //    con.Close();
            //}

            //if (added > 0)
            //{
            //    fillcombo();
            //}

            lblInfo.Text = xyz;
          
            //    };
            ////t1.BackColor = 
            ////Page.Controls.Add(PlaceHolder1);
            //Form.Controls.Add(PlaceHolder1);
            //// PlaceHolder PlaceHolder1 = new PlaceHolder();
            //PlaceHolder1.Controls.Add(t1);
            //PlaceHolder1.Controls.Add(b1);
        }

    }
}