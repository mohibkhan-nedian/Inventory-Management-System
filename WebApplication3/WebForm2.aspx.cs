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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                L1.Visible = false;
                L2.Visible = false;
                L3.Visible = false;
                L4.Visible = false;
                L5.Visible = false;
                L6.Visible = false;
                L7.Visible = false;
                L8.Visible = false;
                L9.Visible = false;
                L10.Visible = false;
                catname.Visible = false;
                catdetails.Visible = false;
                TextBox1.Visible = false;
                TextBox2.Visible = false;
                productId.Visible = false;
                productItem.Visible = false;
                productDesc.Visible = false;
                catid.Visible = false;
                TextBox3.Visible = false;

                supplierName.Visible = false;

                unitCost.Visible = false;
                sellPrice.Visible = false;
                discount.Visible = false;

                unitperstock.Visible = false;
                unitInOrder.Visible = false;
                stockQuantity.Visible = false;
                d1.Visible = false;

                image.Visible = false;
                saveButton.Visible = false;
                Button2.Visible = false;

                newfunction();
            }
        }


        private void newfunction()
        {
            d1.Items.Clear();
            string connectionString = WebConfigurationManager.ConnectionStrings["ims"].ConnectionString;

            string selectSQL = "SELECT CatID, CatName from Category ";
           
            SqlConnection con = new SqlConnection(connectionString);
            //SqlConnection con2 = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(selectSQL, con);
           // SqlCommand cmd2 = new SqlCommand(selectSQL2, con);

            SqlDataReader reader;
           // SqlDataReader reader2;

            try
            {
                con.Open();

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ListItem newItem = new ListItem();
                    newItem.Text = reader["CatName"].ToString();
                    newItem.Value = reader["CatID"].ToString();
                    d1.Items.Add(newItem);
                }

                reader.Close();
              ////  reader2 = cmd2.ExecuteReader();
              //  while (reader2.Read())
              //  {

              //      abc = reader2["StaffID"].ToString();


              //  }

                //  lblInfo.Text = abc;

                //reader2.Close();
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
        protected void b1_Click(object sender, EventArgs e)
        {
            L1.Visible = true;
            L2.Visible = true;
            L3.Visible = true;
            L4.Visible = true;
            L5.Visible = true;
            L6.Visible = true;
            L7.Visible = true;
            L8.Visible = true;
            L9.Visible = true;
            L10.Visible = true;

            productId.Visible = true;
            productItem.Visible = true;
            productDesc.Visible = true;

            supplierName.Visible = true;

            unitCost.Visible = true;
            sellPrice.Visible = true;
            discount.Visible = true;

            unitperstock.Visible = true;
            unitInOrder.Visible = true;
            stockQuantity.Visible = true;
            d1.Visible = true;

            image.Visible = true;
            saveButton.Visible = true;
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (image.HasFile == false || string.IsNullOrWhiteSpace(productId.Text) == true || string.IsNullOrWhiteSpace(productItem.Text) == true || string.IsNullOrWhiteSpace(productDesc.Text) == true || string.IsNullOrWhiteSpace(supplierName.Text) == true)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Id,ProductName,ProductDescription, SupplierName and photo must be filled')", true);

            }
            else
            {
                if (image.HasFile)
                {
                    string extention = System.IO.Path.GetExtension(image.FileName);

                    if (extention != ".jpg" && extention != ".png" && extention != ".jpeg" && extention != ".gif" && extention != ".JPG" && extention != ".PNG" && extention != ".JPEG" && extention != ".GIF")
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only jpg,jpeg,png andgif files are allowed')", true);

                    else
                    {
                        Byte[] imagedata = image.FileBytes;
                        string sql = null;
                        int num1= 0;
                        int num2 = 0;
                        int num3 = 0;
                        int num4 = 0;
                        int num5 = 0;
                        int num6 = 0;
                        int num7 = 0;
                        int.TryParse(productId.Text, out num1);
                        int.TryParse(discount.Text, out num2);
                        int.TryParse(unitperstock.Text, out num3);
                        int.TryParse(unitInOrder.Text, out num4);
                        int.TryParse(unitCost.Text, out num5);
                        int.TryParse(sellPrice.Text, out num6);
                        int.TryParse(stockQuantity.Text, out num7);



                        using (SqlConnection cnn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ims"].ToString()))
                        {
                            sql = "insert into Product (ProductId,CatID,Pitem,PDescr,Discount,UnitPerStock,UnitsInOrder,UnitCost,UnitSellPrice,StockQuantity,SupplierName,Images) values (@id,@catid,@item,@descr,@disc,@ups,@uio,@uc,@usp,@sq,@sn,@im)";
                           // sql2 = "select count(*) from Verification where Name=@Name OR Address=@Address OR EmailAddress=@Email  ";
                            try
                            {
                                cnn.Open();

                                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                                {
                                    cmd.Parameters.AddWithValue("@id", num1);
                                    cmd.Parameters.AddWithValue("@catid", d1.SelectedValue);
                                    cmd.Parameters.AddWithValue("@item", productItem.Text);
                                    cmd.Parameters.AddWithValue("@descr", productDesc.Text);
                                    cmd.Parameters.AddWithValue("@disc", num2);
                                    cmd.Parameters.AddWithValue("ups", num3);
                                    cmd.Parameters.AddWithValue("@uio", num4);
                                    cmd.Parameters.AddWithValue("@uc", unitCost.Text);
                                    cmd.Parameters.AddWithValue("@usp", sellPrice.Text);
                                    cmd.Parameters.AddWithValue("@sq", stockQuantity.Text);
                                    cmd.Parameters.AddWithValue("@sn", supplierName.Text);
                                    cmd.Parameters.AddWithValue("@im", imagedata);
                                    //cmd.Parameters.AddWithValue("@Commerce", comm);

                                    //cmd.Parameters.AddWithValue("@Details", Details.Text);
                                    //cmd.Parameters.AddWithValue("@imagedata", Imgdata);
                                    //cmd.Parameters.AddWithValue("@contactdetail", vertime.Text);
                                    cmd.ExecuteNonQuery();

                                }
                                lblInfo.Text = "1 record inserted";
                            }
                            catch (Exception err)
                            {
                                lblInfo.Text = "Error inserting record";
                                lblInfo.Text += err.Message;
                            }
                            finally
                            {
                                cnn.Close();
                            }
                                    //MailMessage objMail = new MailMessage("mudassirbaig93@gmail.com", "mudassirbaig93@yahoo.com", "vs mail", "New coaching Registration Request");
                                    //NetworkCredential objNC = new NetworkCredential("mudassirbaig93@gmail.com", "03343753618");
                                    //SmtpClient objsmtp = new SmtpClient("smtp.gmail.com", 587);
                                    //objsmtp.EnableSsl = true;
                                    //objsmtp.Credentials = objNC;
                                    //objsmtp.Send(objMail);

                                    // Server.Transfer("SignUp4.aspx");
                            


                        }
                        //Session["imagedata"] = img.FileBytes;
                        //Session["Name"] = Name.Text;
                        //Session["Address"] = Address.Text;
                        //Session["Contact1"] = Contact1.Text;
                        //Session["Contact2"] = Contact2.Text;
                        //Session["img"] = img.FileName;
                        //Server.Transfer("SignUp2.aspx");

                    }
                }


            }

        }

        protected void image_Load(object sender, EventArgs e)
        {
            if (image.HasFile)
            {
                string extention = System.IO.Path.GetExtension(image.FileName);

                if (extention != ".jpg" && extention != ".png" && extention != ".jpeg" && extention != ".gif" && extention != ".JPG" && extention != ".PNG" && extention != ".JPEG" && extention != ".GIF")
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only jpg,jpeg,png andgif files are allowed')", true);

                else
                {

                    //Session["imagedata"] = image.FileBytes;
                    Image1.ImageUrl = "data:image/png;base64," + Convert.ToBase64String((Byte[])image.FileBytes, 0, ((Byte[])image.FileBytes).Length);
     
                   

                }
            }
        }

        protected void Image1_Load(object sender, EventArgs e)
        {
            if (image.HasFile)
            {
                string extention = System.IO.Path.GetExtension(image.FileName);

                if (extention != ".jpg" && extention != ".png" && extention != ".jpeg" && extention != ".gif" && extention != ".JPG" && extention != ".PNG" && extention != ".JPEG" && extention != ".GIF")
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only jpg,jpeg,png andgif files are allowed')", true);

                else
                {

                    //Session["imagedata"] = image.FileBytes;
                    Image1.ImageUrl = "data:image/png;base64," + Convert.ToBase64String((Byte[])image.FileBytes, 0, ((Byte[])image.FileBytes).Length);



                }
            }
        }

        protected void image_Unload(object sender, EventArgs e)
        {
            if (image.HasFile)
            {
                string extention = System.IO.Path.GetExtension(image.FileName);

                if (extention != ".jpg" && extention != ".png" && extention != ".jpeg" && extention != ".gif" && extention != ".JPG" && extention != ".PNG" && extention != ".JPEG" && extention != ".GIF")
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only jpg,jpeg,png andgif files are allowed')", true);

                else
                {

                    //Session["imagedata"] = image.FileBytes;
                    Image1.ImageUrl = "data:image/png;base64," + Convert.ToBase64String((Byte[])image.FileBytes, 0, ((Byte[])image.FileBytes).Length);



                }
            }
        }

        protected void image_PreRender(object sender, EventArgs e)
        {
            if (image.HasFile)
            {
                string extention = System.IO.Path.GetExtension(image.FileName);

                if (extention != ".jpg" && extention != ".png" && extention != ".jpeg" && extention != ".gif" && extention != ".JPG" && extention != ".PNG" && extention != ".JPEG" && extention != ".GIF")
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only jpg,jpeg,png andgif files are allowed')", true);

                else
                {

                    //Session["imagedata"] = image.FileBytes;
                    Image1.ImageUrl = "data:image/png;base64," + Convert.ToBase64String((Byte[])image.FileBytes, 0, ((Byte[])image.FileBytes).Length);



                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string sql = null;

            using (SqlConnection cnn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ims"].ToString()))
            {
                sql = "insert into Category ( CatID,CatName, CatDescription) Values  (@catid, @catname, @catdescription)";
                // sql2 = "select count(*) from Verification where Name=@Name OR Address=@Address OR EmailAddress=@Email  ";
                try
                {
                    cnn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.AddWithValue("@catid", TextBox3.Text);
                        cmd.Parameters.AddWithValue("@catname", TextBox1.Text);
                        cmd.Parameters.AddWithValue("@catdescription", TextBox2.Text);

                        //cmd.Parameters.AddWithValue("@Commerce", comm);

                        //cmd.Parameters.AddWithValue("@Details", Details.Text);
                        //cmd.Parameters.AddWithValue("@imagedata", Imgdata);
                        //cmd.Parameters.AddWithValue("@contactdetail", vertime.Text);
                        cmd.ExecuteNonQuery();

                    }
                    lblInfo.Text = "1 record inserted";
                }
                catch (Exception err)
                {
                    lblInfo.Text = "Error inserting record";
                    lblInfo.Text += err.Message;
                }
                finally
                {
                    cnn.Close();
                }
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            catdetails.Visible = true;
            catname.Visible = true;
            TextBox1.Visible = true;
            TextBox2.Visible = true;
            Button2.Visible = true;
            catid.Visible = true;
            TextBox3.Visible = true;
        }
    }
}