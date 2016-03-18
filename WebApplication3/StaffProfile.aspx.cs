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
    public partial class StaffProfile : System.Web.UI.Page
    {
        protected string id = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request["value"];
            string fn = null;

            string sql = "Select StaffID,Fname,Lname,DOB,Gender,Username,Password from StaffData where StaffID = " + id;
            string sq12 = "Select * from StaffAddr where StaffID = " + id;
            string sql3 = "Select * from StaffContact where StaffID = " + id;


            using (SqlConnection cnn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ims"].ToString()))
            {
                cnn.Open();
                using (SqlCommand cmd1 = new SqlCommand(sql, cnn))
                {
                    SqlDataReader read;
                    read = cmd1.ExecuteReader();
                    read.Read();
                    staffno.Text = read["StaffID"].ToString();
                    name.Text = read["Fname"].ToString() + "  " + read["Lname"].ToString();
                    dob.Text = read["DOB"].ToString();
                    gender.Text = read["Gender"].ToString();
                    user.Text = read["Username"].ToString();
                    pass.Text = read["Password"].ToString();
                    read.Close();
                }
            
            
            using(SqlCommand cmd2 = new SqlCommand(sq12,cnn))
            {
                SqlDataReader read1;
                read1 = cmd2.ExecuteReader();
                read1.Read();
                address.Text = read1["AddressDetail"].ToString();
                read1.Close();
            }


            using (SqlCommand cmd3 = new SqlCommand(sql3, cnn))
            {
                SqlDataReader read2;
                read2 = cmd3.ExecuteReader();
                read2.Read();
                contact.Text = read2["Contact"].ToString();

                read2.Close();
            }
            
            
            
            
            
            }
        }
    }
}