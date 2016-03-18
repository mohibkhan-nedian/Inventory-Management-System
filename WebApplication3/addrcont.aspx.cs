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
    public partial class staffaddr : System.Web.UI.Page
    {
        string prevaddr;
            string connectionString = WebConfigurationManager.ConnectionStrings["ims"].ConnectionString;
            int a = 0, a1, a2, a3, p1, p2, p3;
        static int res = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
       
            string sid;
            id.Text = Session["StaffID"].ToString();
            string prevaddr = "";
            sid = Session["StaffID"].ToString();
            int.TryParse(sid, out res);
            string connectionString = WebConfigurationManager.ConnectionStrings["ims"].ConnectionString;
             string selectall="Select Username,Roleid,Fname,Lname,DOB,Password  from StaffData where StaffID='" + res + "'";
            string selectSQL2 = "Select Address,AddressDetail from StaffAddr where StaffID='" + res + "'";
            string selectSQL = "Select Contact,ContactNo from StaffContact where StaffID='" + res + "'";
            string Username,Roleid,Fname,Lname,DOB,Password;
            SqlConnection con = new SqlConnection(connectionString);
               SqlCommand basic = new SqlCommand(selectall, con);
            SqlCommand cmd2 = new SqlCommand(selectSQL2, con);
            SqlCommand cmd = new SqlCommand(selectSQL, con);
           SqlDataReader readerall;
            SqlDataReader reader2;
            SqlDataReader reader1;
            int added = 0;
            string addr = "";
            //try
            //{
            con.Open();
            readerall = basic.ExecuteReader();
            while (readerall.Read())
            {   Username = readerall["Username"].ToString();
                Password = readerall["Password"].ToString();
                Fname = readerall["Fname"].ToString();
                Lname = readerall["Lname"].ToString();
                DOB = readerall["DOB"].ToString();
                Roleid = readerall["Roleid"].ToString();
                if (una.Text == "") una.Text =  Username.ToString();
                if (password.Text == "") password.Text = Password.ToString();
                if (fname.Text == "") fname.Text = Fname.ToString();
                if (lname.Text == "") lname.Text = Lname.ToString();
                if (dob.Text == "") dob.Text = DOB.ToString();
                if (role.Text == "") role.Text = Roleid.ToString();
            }
            readerall.Close();
            reader2 = cmd2.ExecuteReader();

                while (reader2.Read())
                {
                    prevaddr = reader2["Address"].ToString();
                    addr = reader2["AddressDetail"].ToString();
                    if (prevaddr == '1'.ToString() && adres1.Text=="")
                        adres1.Text = addr.ToString();
                    else if (prevaddr == '2'.ToString() && adres2.Text == "")
                        adres2.Text = addr.ToString();
                    else if (prevaddr == '3'.ToString() && adres3.Text == "")
                        adres3.Text = addr.ToString();
                }
                reader2.Close();
                reader1 = cmd.ExecuteReader();
                while (reader1.Read())
                {
                    prevaddr = reader1["Contact"].ToString();
                    addr = reader1["ContactNo"].ToString();
                    if (prevaddr == '1'.ToString() && c1.Text=="")
                        c1.Text = addr.ToString();
                    else if (prevaddr == '2'.ToString() && c2.Text == "")
                        c2.Text = addr.ToString();
                    else if (prevaddr == '3'.ToString() && c3.Text == "")
                        c3.Text = addr.ToString();
                }

                reader1.Close();
      
                      
        }

        protected void Save_addr1(object sender, EventArgs e)
        {

            if (adres1.Text == "")
            {
                lblInfo.Text = "Please fill the address1 field.";
                return;
            }
            else
            {
                string prevaddr = "";
                string selectSQL2 = "Select Address,AddressDetail from StaffAddr where StaffID='" + res + "'";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd2 = new SqlCommand(selectSQL2, con);
                SqlDataReader reader2;
                int added = 0, a;

                string addr = "";
                try
                {
                    con.Open();
                    reader2 = cmd2.ExecuteReader();
                    while (reader2.Read())
                    {
                        prevaddr = reader2["Address"].ToString();
                        addr = reader2["AddressDetail"].ToString();
                        if (prevaddr == '1'.ToString())
                            break;
                    }

                    reader2.Close();
                    if (prevaddr == "")
                    {
                        string insaddr = "Insert into StaffAddr(";
                        insaddr += "StaffID,Address,AddressDetail)";
                        insaddr += "Values('" + res + "',1,'" + adres1.Text + "')";

                        SqlCommand cmd = new SqlCommand(insaddr, con);

                        added = cmd.ExecuteNonQuery();
                        lblInfo.Text = "Inserted";
                    }
                    else if (prevaddr == '1'.ToString())
                    {

                        string insaddr = "Update StaffAddr set AddressDetail ='" + adres1.Text + "' where Address=1 and StaffID='" + res + "' ";

                        SqlCommand cmd = new SqlCommand(insaddr, con);

                        a = cmd.ExecuteNonQuery();
                        lblInfo.Text = "updated";
                    }
                }
                catch (Exception err)
                {
                    lblInfo.Text = "Error in quer for insertion";
                    lblInfo.Text = err.Message;
                }


            }
        }

        protected void Save_addr2(object sender, EventArgs e)
        {
            if (adres2.Text == "")
            {
                lblInfo.Text = "Fill the field";
                return;
            }
            else
            {
                string selectsql1 = "Select Address from StaffAddr where StaffID='" + res + "'";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd2 = new SqlCommand(selectsql1, con);
                SqlDataReader reader2;
                int added = 0;
                string prevaddr = "";
                string addr = "";
                try
                {
                    con.Open();

                    reader2 = cmd2.ExecuteReader();
                    while (reader2.Read())
                    {
                        added = 1;
                        prevaddr = reader2["Address"].ToString();
                        //            addr = reader2["AddressDetail"].ToString();

                    }
                    reader2.Close();
                }
                catch (Exception err)
                {
                    lblInfo.Text = "Error in quer for insertion";
                    lblInfo.Text = err.Message;
                }

                int a;
                if (prevaddr == "")
                {
                    lblInfo.Text = "First save Address1 plz";
                }
                else if (prevaddr == '1'.ToString())
                {
                    int newaddr;
                    int.TryParse(prevaddr, out newaddr);

                    string insaddr = "Insert into StaffAddr(";
                    insaddr += "StaffID,Address,AddressDetail)";
                    insaddr += "Values('" + res + "','" + (newaddr + 1) + "','" + adres2.Text + "')";

                    SqlCommand cmd = new SqlCommand(insaddr, con);

                    a = cmd.ExecuteNonQuery();
                    lblInfo.Text = "Inserted";
                }
                else if (prevaddr == '2'.ToString())
                {
                    string insaddr = "Update StaffAddr set AddressDetail ='" + adres2.Text + "' where Address=2 and StaffID='" + res + "' ";

                    SqlCommand cmd = new SqlCommand(insaddr, con);

                    a = cmd.ExecuteNonQuery();
                    lblInfo.Text = "updated";
                }

            }      
                    
        }

        protected void Save_addr3(object sender, EventArgs e)
        {
            if (adres3.Text == "")
            {
                lblInfo.Text = "Fill the field";
                return;
            }
            else
            {
                string selectsql1 = "Select Address from StaffAddr where StaffID='" + res + "'";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd2 = new SqlCommand(selectsql1, con);
                SqlDataReader reader2;

                string prevaddr = "";
                string addr = "";
                try
                {
                    con.Open();

                    reader2 = cmd2.ExecuteReader();
                    while (reader2.Read())
                    {

                        prevaddr = reader2["Address"].ToString();
                    }
                    reader2.Close();
                }
                catch (Exception err)
                {
                    lblInfo.Text = "Error in quer for insertion";
                    lblInfo.Text = err.Message;
                }

                if (prevaddr == "")
                {
                    lblInfo.Text = "First save Address1 plz";
                }

                else if (prevaddr == '1'.ToString())
                {
                    lblInfo.Text = "First save Address2 plz";
                }
                int a;
                if (prevaddr == '2'.ToString())
                {
                    int newaddr;
                    int.TryParse(prevaddr, out newaddr);

                    string insaddr = "Insert into StaffAddr(";
                    insaddr += "StaffID,Address,AddressDetail)";
                    insaddr += "Values('" + res + "','" + (newaddr + 1) + "','" + adres3.Text + "')";

                    SqlCommand cmd = new SqlCommand(insaddr, con);

                    a = cmd.ExecuteNonQuery();
                    lblInfo.Text = "Inserted";
                }
                else if (prevaddr == '3'.ToString())
                {
                    string insaddr = "Update StaffAddr set AddressDetail ='" + adres3.Text + "' where Address=3 and StaffID='" + res + "' ";

                    SqlCommand cmd = new SqlCommand(insaddr, con);

                    a = cmd.ExecuteNonQuery();
                    lblInfo.Text = "updated";
                }

            }
        }


        protected void Savecont_1(object sender, EventArgs e)
        {
            if (c1.Text == "")
            {
                lblInfo.Text = "Please fill the field.";
                return;
            }

            else
            {
                string prevcont = "";
                string selectSQL2 = "Select Contact from StaffContact where StaffID='" + res + "'";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd2 = new SqlCommand(selectSQL2, con);
                SqlDataReader reader2;
                int added = 0;
                try
                {
                    con.Open();
                    reader2 = cmd2.ExecuteReader();
                    while (reader2.Read())
                    {

                        prevcont = reader2["Contact"].ToString();
                        if (prevcont == '1'.ToString())
                            break;
                    }

                    reader2.Close();
                    int a;
                    if (prevcont == "")
                    {

                        string insaddr = "Insert into StaffContact(";
                        insaddr += "StaffID,Contact,ContactNo)";
                        insaddr += "Values('" + res + "',1,'" + c1.Text + "')";

                        SqlCommand cmd = new SqlCommand(insaddr, con);

                        added = cmd.ExecuteNonQuery();
                        lblInfo.Text = "Inserted";
                    }
                    else if (prevcont == '1'.ToString())
                    {

                        string insaddr = "Update StaffContact set ContactNo ='" + c1.Text + "' where Contact=1 and StaffID='" + res + "' ";

                        SqlCommand cmd = new SqlCommand(insaddr, con);

                        a = cmd.ExecuteNonQuery();
                        lblInfo.Text = "updated";
                    }
                }
                catch (Exception err)
                {
                    lblInfo.Text = "Error in quer for insertion";
                    lblInfo.Text = err.Message;
                }




            }
        }

        protected void Savecont_2(object sender, EventArgs e)
        {
            if (c2.Text == "")
            {
                lblInfo.Text = "Please fill all the fields.";
                return;
            }

            else
            {
                string prevcont = "";
                string selectSQL2 = "Select Contact from StaffContact where StaffID='" + res + "'";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd2 = new SqlCommand(selectSQL2, con);
                SqlDataReader reader2;
                int added = 0;
                try
                {
                    con.Open();
                    reader2 = cmd2.ExecuteReader();
                    while (reader2.Read())
                    {

                        prevcont = reader2["Contact"].ToString();
                        if (prevcont == '1'.ToString())
                            break;
                    }

                    reader2.Close();
                    int a;
                    if (prevcont == "")
                        lblInfo.Text = "Insert Contact1 first";
                    else if (prevcont == '1'.ToString())
                    {

                        string insaddr = "Insert into StaffContact(";
                        insaddr += "StaffID,Contact,ContactNo)";
                        insaddr += "Values('" + res + "',2,'" + c2.Text + "')";

                        SqlCommand cmd = new SqlCommand(insaddr, con);

                        added = cmd.ExecuteNonQuery();
                        lblInfo.Text = "Inserted";
                    }
                    else if (prevcont == '2'.ToString())
                    {
                        string insaddr = "Update StaffContact set ContactNo ='" + c2.Text + "' where Contact=2 and StaffID='" + res + "' ";

                        SqlCommand cmd = new SqlCommand(insaddr, con);

                        a = cmd.ExecuteNonQuery();
                        lblInfo.Text = "updated";
                    }
                }
                catch{}
            }
        }
        protected void Savecont_3(object sender, EventArgs e)
        {

            if (c3.Text == "")
            {
                lblInfo.Text = "Please fill all the fields.";
                return;
            }

            else
            {
                string prevcont = "";
                string selectSQL2 = "Select Contact from StaffContact where StaffID='" + res + "'";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd2 = new SqlCommand(selectSQL2, con);
                SqlDataReader reader2;
                int added = 0;
                try
                {
                    con.Open();
                    reader2 = cmd2.ExecuteReader();
                    while (reader2.Read())
                    {

                        prevcont = reader2["Contact"].ToString();
                      
                    }

                    reader2.Close();
                    int a;
                    if (prevcont== "")
                        lblInfo.Text = "Insert Contact1 first";
                    else if (prevcont == '1'.ToString())
                    {

                        lblInfo.Text = "First save Contact2 plz";
                    }
                    else if (prevcont == '2'.ToString())
                    {

                        string insaddr = "Insert into StaffContact(";
                        insaddr += "StaffID,Contact,ContactNo)";
                        insaddr += "Values('" + res + "',3,'" + c3.Text + "')";

                        SqlCommand cmd = new SqlCommand(insaddr, con);

                        added = cmd.ExecuteNonQuery();
                        lblInfo.Text = "Inserted";
                    }
                    else if (prevcont == '3'.ToString())
                    {
                        string insaddr = "Update StaffContact set ContactNo ='" + c3.Text + "' where Contact=3 and StaffID='" + res + "' ";

                        SqlCommand cmd = new SqlCommand(insaddr, con);

                        a = cmd.ExecuteNonQuery();
                        lblInfo.Text = "updated";
                    }
                }
                catch { }
            }
        }
        protected void update(object sender, EventArgs e)
        {
           //if ((c1.Text > 'A'.ToString()) && (c1.Text == "Z"))
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('All the fields must be filled')", true);

            //}
           
            int added = 0;
            string update = "Update StaffData set Username ='" + una.Text + "',Roleid ='" + role.Text + "', Fname ='" + fname.Text + "', Password ='" + password.Text + "', Lname ='" + lname.Text + "', DOB='" + dob.Text + "' where  StaffID='" + res + "' ";
            SqlConnection con = new SqlConnection(connectionString);             
            SqlCommand cmdp = new SqlCommand(update, con);
            con.Open(); 
            a = cmdp.ExecuteNonQuery();

            string selectSQL2 = "Select Address,AddressDetail from StaffAddr where StaffID='" + res + "'";
            string selectSQL = "Select Contact,ContactNo from StaffContact where StaffID='" + res + "'";
            SqlDataReader reader2;
            SqlDataReader reader1;
             SqlCommand cmd2p = new SqlCommand(selectSQL2, con);
            SqlCommand cmdd = new SqlCommand(selectSQL, con);
           
           reader2 = cmd2p.ExecuteReader();

                while (reader2.Read())
                {
                    prevaddr = reader2["Address"].ToString();
                   
                }
            if(prevaddr=='0'.ToString()) {a1=0;a2=0;a3=0;}
            if (prevaddr == '1'.ToString()) { a1 = 1; a2 = 0; a3 = 0; }
              if(prevaddr=='2'.ToString()) {a1=1;a2=1;a3=0;}
              if(prevaddr=='3'.ToString()) {a1=1;a2=1;a3=1;}
               reader2.Close();

                reader1 = cmdd.ExecuteReader();
                while (reader1.Read())
                {
                    prevaddr = reader1["Contact"].ToString();
                 
                }

                reader1.Close();
          if(prevaddr=='0'.ToString()) {p1=0;p2=0;p3=0;}
          if (prevaddr == '1'.ToString()) { p1 = 1; p2 = 0; p3 = 0; }
              if(prevaddr=='2'.ToString()) {p1=1;p2=1;p3=0;}
              if(prevaddr=='3'.ToString()) {p1=1;p2=1;p3=1;}
           
                   
            if (a1==0)
            {
                string insaddr = "Insert into StaffAddr(";
                insaddr += "StaffID,Address,AddressDetail)";
                insaddr += "Values('" + res + "',1,'" + adres1.Text + "')";

                SqlCommand cmdd2 = new SqlCommand(insaddr, con);

                added = cmdd2.ExecuteNonQuery();
                lblInfo.Text = "Inserted";
            }
            else 
            {
                string insaddr = "Update StaffAddr set AddressDetail ='" + adres1.Text + "' where Address=1 and StaffID='" + res + "' ";

                SqlCommand cmd3 = new SqlCommand(insaddr, con);

                a = cmd3.ExecuteNonQuery();
                lblInfo.Text = "updated";
            }

            if (a2==0)
            {
                string insaddr = "Insert into StaffAddr(";
                insaddr += "StaffID,Address,AddressDetail)";
                insaddr += "Values('" + res + "',2,'" + adres2.Text + "')";

                SqlCommand cmd2 = new SqlCommand(insaddr, con);

                added = cmd2.ExecuteNonQuery();
                lblInfo.Text = "Inserted";
            }
            else
            {
                string insaddr = "Update StaffAddr set AddressDetail ='" + adres2.Text + "' where Address=2 and StaffID='" + res + "' ";

                SqlCommand cmd3 = new SqlCommand(insaddr, con);

                a = cmd3.ExecuteNonQuery();
                lblInfo.Text = "updated";
            }
            if (a3==0)
            {
                string insaddr = "Insert into StaffAddr(";
                insaddr += "StaffID,Address,AddressDetail)";
                insaddr += "Values('" + res + "',3,'" + adres3.Text + "')";

                SqlCommand cmd2 = new SqlCommand(insaddr, con);

                added = cmd2.ExecuteNonQuery();
                lblInfo.Text = "Inserted";
            }
            else
            {
                string insaddr = "Update StaffAddr set AddressDetail ='" + adres3.Text + "' where Address=3 and StaffID='" + res + "' ";

                SqlCommand cmd3 = new SqlCommand(insaddr, con);

                a = cmd3.ExecuteNonQuery();
                lblInfo.Text = "updated";
            }
            try
            {
                if (p1 == 0)
                {

                    string insaddr = "Insert into StaffContact(";
                    insaddr += "StaffID,Contact,ContactNo)";
                    insaddr += "Values('" + res + "',1,'" + c1.Text + "')";

                    SqlCommand cmd4 = new SqlCommand(insaddr, con);

                    added = cmd4.ExecuteNonQuery();
                    lblInfo.Text = "Inserted";
                }
                else
                {

                    string insaddr = "Update StaffContact set ContactNo ='" + c1.Text + "' where Contact=1 and StaffID='" + res + "' ";

                    SqlCommand cmd5 = new SqlCommand(insaddr, con);

                    a = cmd5.ExecuteNonQuery();
                    lblInfo.Text = "updated";
                }

                if (p2 == 0)
                {

                    string insaddr = "Insert into StaffContact(";
                    insaddr += "StaffID,Contact,ContactNo)";
                    insaddr += "Values('" + res + "',2,'" + c2.Text + "')";

                    SqlCommand cmd6 = new SqlCommand(insaddr, con);

                    added = cmd6.ExecuteNonQuery();
                    lblInfo.Text = "Inserted";
                }
                else
                {
                    string insaddr = "Update StaffContact set ContactNo ='" + c2.Text + "' where Contact=2 and StaffID='" + res + "' ";

                    SqlCommand cmd7 = new SqlCommand(insaddr, con);

                    a = cmd7.ExecuteNonQuery();
                    lblInfo.Text = "updated";
                }

                if (p3 == 0)
                {

                    string insaddr = "Insert into StaffContact(";
                    insaddr += "StaffID,Contact,ContactNo)";
                    insaddr += "Values('" + res + "',3,'" + c3.Text + "')";

                    SqlCommand cmd8 = new SqlCommand(insaddr, con);

                    added = cmd8.ExecuteNonQuery();
                    lblInfo.Text = "Inserted";
                }
                else
                {
                    string insaddr = "Update StaffContact set ContactNo ='" + c3.Text + "' where Contact=3 and StaffID='" + res + "' ";

                    SqlCommand cmd9 = new SqlCommand(insaddr, con);

                    a = cmd9.ExecuteNonQuery();
                    lblInfo.Text = "updated";
                }
            }
            catch
            {
                lblInfo.Text = "Wrong input for Contact Number";
            }
            lblInfo.Text = "updated";

        }



    }
}