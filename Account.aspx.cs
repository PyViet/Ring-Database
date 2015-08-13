using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;
using System.Data;


public partial class Account : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection vid = new SqlConnection("Data Source=(local);Initial Catalog=Ring;Integrated Security=True");
        SqlCommand info = new SqlCommand("SELECT firstname, lastname, email FROM dbo.Customers WHERE email = @email", vid);
        info.Parameters.AddWithValue("@email", Session["username"]);

        vid.Open();
        SqlDataReader pinfo = info.ExecuteReader();
        pinfo.Read();
        Label txtLabel1 = new Label();
        txtLabel1.Text = (string)pinfo[0];
        txtLabel1.Style.Add("Color", "Black");
        firstn.Controls.Add(txtLabel1);
        Label txtLabel2 = new Label();
        txtLabel2.Text = (string)pinfo[1];
        txtLabel2.Style.Add("Color", "Black");
        lastn.Controls.Add(txtLabel2);
        Label txtLabel3 = new Label();
        txtLabel3.Text = (string)pinfo[2];
        txtLabel3.Style.Add("Color", "Black");
        lblusername.Text = (string)pinfo[2];
        vid.Close();


        if (!IsPostBack)
        {
            ByPrice.AppendDataBoundItems = true;
            ByDate.AppendDataBoundItems = true;
            ByJewel.AppendDataBoundItems = true;
            ByPrice1.AppendDataBoundItems = true;
            String strRingConnectionString = ConfigurationManager.ConnectionStrings["RingConnectionString"].ConnectionString;
            String strQuery = "Select jewel_ID, month, year, price FROM dbo.Orders WHERE email = @email ORDER BY price DESC";
            SqlConnection con = new SqlConnection(strRingConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@email", lblusername.Text);
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;

            //ByDate.AppendDataBoundItems = true;
            //ByPrice.AppendDataBoundItems = true;
            //String strQuery2 = "Select jewel_ID, month, year, price FROM dbo.Orders WHERE email = @email ORDER BY price DESC";
            //SqlCommand cmd2 = new SqlCommand();
            //cmd2.Parameters.AddWithValue("@email", lblusername.Text);
            //cmd2.CommandType = CommandType.Text;
            //cmd2.CommandText = strQuery2;
            //cmd2.Connection = con;
            try
            {
                con.Open();
                ByPrice.DataSource = cmd.ExecuteReader();
                ByPrice.DataTextField = "month";
                ByPrice.DataBind();
                con.Close();
                con.Open();
                ByDate.DataSource = cmd.ExecuteReader();
                ByDate.DataTextField = "year";
                ByDate.DataBind();
                con.Close();
                con.Open();
                ByJewel.DataSource = cmd.ExecuteReader();
                ByJewel.DataTextField = "jewel_ID";
                ByJewel.DataBind();
                con.Close();
                con.Open();
                ByPrice1.DataSource = cmd.ExecuteReader();
                ByPrice1.DataTextField = "price";
                ByPrice1.DataBind();

            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                con.Close();
                con.Dispose();
            }

        }
    }

    protected void BtnBrowse_Click(object sender, EventArgs e)
    {
        Server.Transfer("Browse.aspx", true);
    }

    protected void BtnEdit_Click(object sender, EventArgs e)
    {
        SqlConnection vid = new SqlConnection("Data Source=(local);Initial Catalog=Ring;Integrated Security=True");
        vid.Open();
        if (!string.IsNullOrWhiteSpace(NewFName.Text))
        {
            SqlCommand info1 = new SqlCommand("UPDATE dbo.Customers SET firstname = @newfirst WHERE email = @email", vid);
            info1.Parameters.AddWithValue("@email", Session["username"]);
            info1.Parameters.AddWithValue("@newfirst", NewFName.Text);
            SqlCommand first = new SqlCommand("SELECT firstname FROM dbo.Customers WHERE email = @email", vid);
            first.Parameters.AddWithValue("@email", Session["username"]);
            info1.ExecuteNonQuery();
            SqlDataReader fir = first.ExecuteReader();
            firstn.Controls.RemoveAt(0);
            fir.Read();
            Label txtLabel1 = new Label();
            txtLabel1.Text = (string)fir[0];
            txtLabel1.Style.Add("Color", "Black");
            firstn.Controls.Add(txtLabel1);
            fir.Close();
            NewFName.Text = String.Empty;           

        }
        if (!string.IsNullOrWhiteSpace(NewLName.Text))
        {
            SqlCommand info2 = new SqlCommand("UPDATE dbo.Customers SET lastname = @newlast WHERE email = @email", vid);
            info2.Parameters.AddWithValue("@email", Session["username"]);
            info2.Parameters.AddWithValue("@newlast", NewLName.Text);
            SqlCommand last = new SqlCommand("SELECT lastname FROM dbo.Customers WHERE email = @email", vid);
            last.Parameters.AddWithValue("@email", Session["username"]);
            info2.ExecuteNonQuery();
            lastn.Controls.RemoveAt(0);
            SqlDataReader las = last.ExecuteReader();
            las.Read();
            Label txtLabel2 = new Label();
            txtLabel2.Text = (string)las[0];
            txtLabel2.Style.Add("Color", "Black");
            lastn.Controls.Add(txtLabel2);
            las.Close();
            NewLName.Text = String.Empty;
        }
        if (!string.IsNullOrWhiteSpace(NewUsername.Text))
        {
            SqlCommand info3 = new SqlCommand("UPDATE dbo.Customers SET email = @newemail WHERE email = @email", vid);
            info3.Parameters.AddWithValue("@email", Session["username"]);
            info3.Parameters.AddWithValue("@newemail", NewUsername.Text);
            SqlCommand email = new SqlCommand("SELECT email FROM dbo.Customers WHERE email = @email", vid);
            email.Parameters.AddWithValue("@email", Session["username"]);
            info3.ExecuteNonQuery();
            lblusername.Controls.RemoveAt(0);
            SqlDataReader ema = email.ExecuteReader();
            ema.Read();
            Label txtLabel3 = new Label();
            txtLabel3.Text = (string)ema[0];
            txtLabel3.Style.Add("Color", "Black");
            firstn.Controls.Add(txtLabel3);
            SqlCommand info8 = new SqlCommand("UPDATE dbo.Admin SET email = @newemail WHERE email = @email", vid);
            info8.Parameters.AddWithValue("@email", Session["username"]);
            info8.Parameters.AddWithValue("@newemail", NewUsername.Text);
            info8.ExecuteNonQuery();
            SqlCommand info9 = new SqlCommand("UPDATE dbo.Orders SET email = @newemail WHERE email = @email", vid);
            info9.Parameters.AddWithValue("@email", Session["username"]);
            info9.Parameters.AddWithValue("@newemail", NewUsername.Text);
            info9.ExecuteNonQuery();
            ema.Close();
            NewUsername.Text = String.Empty;
            
        }
        if (!string.IsNullOrWhiteSpace(NewPassword.Text))
        {
            SqlCommand info4 = new SqlCommand("UPDATE dbo.Customers SET firsthash = @newpass WHERE email = @email", vid);
            info4.Parameters.AddWithValue("@email", Session["username"]);
            info4.Parameters.AddWithValue("@newpass", CalculateMD5Hash(NewPassword.Text));
            info4.ExecuteNonQuery();
            SqlCommand info7 = new SqlCommand("UPDATE dbo.Admin SET firstpass = @newpass WHERE email = @email", vid);
            info7.Parameters.AddWithValue("@email", Session["username"]);
            info7.Parameters.AddWithValue("@newpass", NewPassword.Text);
            info7.ExecuteNonQuery();
            NewPassword.Text = String.Empty;
            
        }
        if (!string.IsNullOrWhiteSpace(NewCity.Text))
        {
            SqlCommand info5 = new SqlCommand("UPDATE dbo.Customers SET secondhash = @newcity WHERE email = @email", vid);
            info5.Parameters.AddWithValue("@email", Session["username"]);
            info5.Parameters.AddWithValue("@newcity", CalculateMD5Hash(NewCity.Text));
            info5.ExecuteNonQuery();
            SqlCommand info6 = new SqlCommand("UPDATE dbo.Admin SET secondpass = @newcity WHERE email = @email", vid);
            info6.Parameters.AddWithValue("@email", Session["username"]);
            info6.Parameters.AddWithValue("@newcity", NewCity.Text);
            info6.ExecuteNonQuery();
            NewCity.Text = String.Empty;
        }
        vid.Close();
        lblupdate.Text = "Information Updated";
    }
    protected string CalculateMD5Hash(string input)
    {
        // step 1, calculate MD5 hash from input
        MD5 md5 = System.Security.Cryptography.MD5.Create();
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
        byte[] hash = md5.ComputeHash(inputBytes);

        // step 2, convert byte array to hex string
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < hash.Length; i++)
        {
            sb.Append(hash[i].ToString("X2"));
        }
        return sb.ToString();
    }
    protected string ConvertStringToHex(string asciiString)
    {
        string hex = "";
        foreach (char c in asciiString)
        {
            int tmp = c;
            hex += String.Format("{0:x2}", (uint)System.Convert.ToUInt32(tmp.ToString()));
        }
        return hex;
    }
    protected void BtnPrevOrders_Click(object sender, EventArgs e)
    {

    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        SqlConnection vid = new SqlConnection("Data Source=(local);Initial Catalog=Ring;Integrated Security=True");
        SqlCommand del1 = new SqlCommand("DELETE FROM dbo.Customers WHERE email = @email", vid);
        del1.Parameters.AddWithValue("@email", Lblemail.Text);
        SqlCommand del2 = new SqlCommand("DELETE FROM dbo.Admin WHERE email = @email", vid);
        del2.Parameters.AddWithValue("@email", Lblemail.Text);
        Server.Transfer("LogIn.aspx", true);
    }

    protected void DateIndexChanged(object sender, EventArgs e)
    {
            //ByDate.AppendDataBoundItems = true;
            //SqlConnection vid = new SqlConnection("Data Source=(local);Initial Catalog=Ring;Integrated Security=True");
            //SqlCommand orderform = new SqlCommand("Select jewel_ID, month, year, price FROM dbo.Orders WHERE email = @email GROUP BY month, year ORDER BY month DESC, year DESC", vid);
            //orderform.Parameters.AddWithValue("@email", lblusername.Text);
            //vid.Open();
            //SqlDataReader readorders = orderform.ExecuteReader();
            //while (readorders.Read())
            //{
            //    ByDate.Items.Insert(ByDate.Items.Count, new ListItem((string)readorders[3] + " " + (string)readorders[1] + "/" + (string)readorders[2] + " " + (string)readorders[4], ""));
            //}
            //vid.Close();
    }

    protected void PriceIndexChanged(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    ByPrice.AppendDataBoundItems = true;
        //    SqlConnection vid = new SqlConnection("Data Source=(local);Initial Catalog=Ring;Integrated Security=True");
        //    SqlCommand orderform = new SqlCommand("Select jewel_ID, month, year, price FROM dbo.Orders WHERE email = @email GROUP BY price ORDER BY price DESC", vid);
        //    orderform.Parameters.AddWithValue("@email", Lblemail.Text);
        //    vid.Open();
        //    SqlDataReader readorders = orderform.ExecuteReader();
        //    while (readorders.Read())
        //    {
        //        ByPrice.Items.Insert(ByPrice.Items.Count, new ListItem((string)readorders[3] + " " + (string)readorders[1] + "/" + (string)readorders[2] + " " + (string)readorders[4], ""));
        //    }
        //    vid.Close();
        //}
    }
    protected void BtnHome_Click(object sender, EventArgs e)
    {
        Server.Transfer("HomePage.aspx", true);
    }
}
