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
    public partial class StaffSignup : System.Web.UI.Page
    {
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
                //lblInfo.Text = "Error reading the data base";
                //lblInfo.Text += err.Message;
            }
            finally
            {
                con.Close();
            }


        }

        protected void btn_ServerClick(object sender, EventArgs e)
        {
            if ( Request["fname"] == "" || Request["lname"] == "" || Request["username"] == "" || Request["password"] == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Empty field must be inserted')", true);
                  
                return;

            }

            string g;
            if (gender.SelectedIndex == 0)
            {
                g = "M";

            }
            else
            {
                g = "F";

            }


            int res = 0;
            int.TryParse(abc, out res);

            //lblInfo.Text = datepicker.Value;
            string connectionString = WebConfigurationManager.ConnectionStrings["ims"].ConnectionString;

            string selectSQL2 = "Select StaffID from StaffData";
            string insertSql = "Insert into StaffData(";
            insertSql += "Roleid,Fname,Lname,DOB,Gender,Username, Password) ";
            insertSql += "Values (" + (role.SelectedIndex + 1) + ",'" + Request["fname"] + "','" + Request["lname"];
            insertSql += "','" + datepicker.Value + "','" + g + "','" + Request["username"] + "','" + Request["password"] + "')";
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
                //lblInfo.Text = added.ToString() + " records inserted" + xyz;

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted')", true);
                 
            }
            catch (Exception err)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Username already taken')", true);
                //lblInfo.Text = "Error inserting record";
                //lblInfo.Text += err.Message;
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

    }
}