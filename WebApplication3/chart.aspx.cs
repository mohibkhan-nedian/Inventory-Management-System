using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class chart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["StaffID"] = Request["value"];

            if (this.IsPostBack == false)
            {
                DateTimeFormatInfo info = DateTimeFormatInfo.GetInstance(null);
                for (int i = 1; i < 13; i++)
                {
                    d1.Items.Add(new ListItem(info.GetMonthName(i).ToString()));
                    d2.Items.Add(new ListItem(info.GetMonthName(i).ToString()));
                }
            }
           
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            string date1 = null;

            if (d1.SelectedIndex == 0)
            {
                date1 = "'2014-01-01' and '2014-01-31'";
            }

            if (d1.SelectedIndex == 1)
            {
                date1 = "'2014-02-01' and '2014-03-01'";

            }


            if (d1.SelectedIndex == 2)
            {
                date1 = "'2014-03-01' and '2014-04-01'";

            }

            if (d1.SelectedIndex == 3)
            {
                date1 = "'2014-04-01' and '2014-05-01'";

            }

            if (d1.SelectedIndex == 4)
            {
                date1 = "'2014-05-01' and '2014-05-01'";

            }

            if (d1.SelectedIndex == 5)
            {
                date1 = "'2014-06-01' and '2014-07-01'";

            }

            if (d1.SelectedIndex == 6)
            {
                date1 = "'2014-07-01' and '2014-08-01'";

            }


            if (d1.SelectedIndex == 7)
            {
                date1 = "'2014-08-01' and '2014-09-01'";

            }


            if (d1.SelectedIndex == 8)
            {
                date1 = "'2014-09-01' and '2014-10-01'";

            }

            if (d1.SelectedIndex == 9)
            {
                date1 = "'2014-10-01' and '2014-11-01'";

            }

            if (d1.SelectedIndex == 10)
            {
                date1 = "'2014-11-01' and '2014-12-01'";

            }

            if (d1.SelectedIndex == 11)
            {
                date1 = "'2014-12-01' and '2015-01-01'";

            }


            string date2 = null;

            if (d2.SelectedIndex == 0)
            {
                date2 = "'2014-01-01' and '2014-01-31'";
            }

            if (d2.SelectedIndex == 1)
            {
                date2 = "'2014-02-01' and '2014-03-01'";

            }


            if (d2.SelectedIndex == 2)
            {
                date2 = "'2014-03-01' and '2014-04-01'";

            }

            if (d2.SelectedIndex == 3)
            {
                date2 = "'2014-04-01' and '2014-05-01'";

            }

            if (d2.SelectedIndex == 4)
            {
                date2 = "'2014-05-01' and '2014-05-01'";

            }

            if (d2.SelectedIndex == 5)
            {
                date2 = "'2014-06-01' and '2014-07-01'";

            }

            if (d2.SelectedIndex == 6)
            {
                date2 = "'2014-07-01' and '2014-08-01'";

            }


            if (d2.SelectedIndex == 7)
            {
                date2 = "'2014-08-01' and '2014-09-01'";

            }


            if (d2.SelectedIndex == 8)
            {
                date2 = "'2014-09-01' and '2014-10-01'";

            }

            if (d2.SelectedIndex == 9)
            {
                date2 = "'2014-10-01' and '2014-11-01'";

            }

            if (d2.SelectedIndex == 10)
            {
                date2 = "'2014-11-01' and '2014-12-01'";

            }

            if (d2.SelectedIndex == 11)
            {
                date2 = "'2014-12-01' and '2015-01-01'";

            }


            //lbl3.Text = d1.SelectedIndex.ToString();

            
            string sql = "select sum(Balance) a from Payment where DebitDate Between " + date1 +  " union select sum(Balance) a from Payment where  DebitDate between " + date2;
            string sql2 = "select sum(Balance) a from Payment where DebitDate Between " + date1 + " union select sum(Balance) a from Payment where  DebitDate between " + date2;
            
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ims"].ToString());
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlCommand cmd2 = new SqlCommand(sql2, con);
            
            //  SqlCommand cmd2 = new SqlCommand(sql2, con);
            SqlDataReader read1;
            // SqlDataReader read2;//
            
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            // //DateTime dt = new DateTime();
            //SqlDataAdapter data1 = new SqlDataAdapter(cmd2);
            DataTable ds = new DataTable();
            // DataTable ds2 = new DataTable();
            Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            Chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            Chart1.ChartAreas["ChartArea1"].AxisX.Minimum = 1;

               
               
                   Chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(1.0, 1.5, d1.SelectedValue);
                   Chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(2.0, 2.5, d2.SelectedValue);
               
            //Chart1.ChartAreas["ChartArea1"].AxisX.Minimum = 4;
           
                
            Chart1.ChartAreas["ChartArea1"].AxisX.Title = "Months";
            Chart1.ChartAreas["ChartArea1"].AxisY.Minimum = 0;
            Chart1.ChartAreas["ChartArea1"].AxisY.Maximum = 10000;
            Chart1.ChartAreas["ChartArea1"].AxisY.Title = "%";
            Chart1.ChartAreas["ChartArea1"].AxisY.TextOrientation = TextOrientation.Horizontal;

            //SqlDataReader read1;

            try
            {
                con.Open();

            
              

        

                data.Fill(ds);

                if (ds.Rows.Count > 0)
                {
                    Chart1.DataSource = ds;
                    Chart1.Series["Series1"].YValueMembers = "a";
                    Chart1.DataBind();

                   
                }

              
               
                //data1.Fill(ds2);

                //if (ds2.Rows.Count > 0)
                //{
                //    Chart1.DataSource = ds2;
                //    Chart1.Series["Series1"].YValueMembers = "a";
                //    Chart1.DataBind();
                //}

                //read1 = cmd.ExecuteReader();

                //while (read1.Read())
                //{
                //    balance[num] = read1["a"].ToString();
                //    str[num] = read1["DebitDate"].ToString();
                //   int.TryParse(read1["a"].ToString(), out num );
                //   Chart1.Series["Series1"].YValuesPerPoint = num;
                //   Chart1.Series["Series1"].AxisLabel = str[num];
                //    num++;

                //}
                //Chart1.Series["Series1"].YValueMembers = balance;
                //Chart1.Series["Series1"].Points.DataBindXY(str, balance);
                //read1.Close();
                //Chart1.Series["Series1"].YValueMembers = "a";
                //Chart1.DataBind();
            }
            catch (Exception err)
            {
                lbl1.Text = err.Message;
            }
            finally
            {
                con.Close();
            }

        }
    }
}