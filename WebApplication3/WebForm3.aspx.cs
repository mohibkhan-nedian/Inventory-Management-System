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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gender.Items.Add("Male");
            gender.Items.Add("Female");
        }
        protected void Go_Click(object sender, EventArgs e)
        {
            if (fname.Text == "" || lname.Text == "" || username.Text == "" || password.Text == "")
            {
                info.Text = "All fields need to be inserted";
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
            string insertsql = "INSERT INTO STAFFDATA(";
            insertsql += "Roleid,Fname,Lname,DOB,Gender,Username, Password) ";
            insertsql += "VALUES(1,'" + fname.Text + "','" + lname.Text + "','" + datepicker.Value + "','" + g + "','" + username.Text + "','" + password.Text + "' )";

            string connectionString = WebConfigurationManager.ConnectionStrings["ims"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand(insertsql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            info.Text = "inserted";
        }
    }
}