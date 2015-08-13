using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

public partial class CreateAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == true)
        {
            LblMessage.Text = "Account Created";
        }
    }
    protected void BtnCreate_Click(object sender, EventArgs e)
    {
        SqlConnection vid = new SqlConnection("Data Source=(local);Initial Catalog=Ring;Integrated Security=True");
        {
            //SqlDataReader valid;
            //SqlCommand verify = new SqlCommand("IF EXISTS (SELECT email FROM  dbo.Customers WHERE email = @email ) select 'True' else select 'False' return)", vid);
            //verify.Parameters.AddWithValue("@email", TbUsername.Text);

            SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Customers(firstname, lastname, email, firsthash, secondhash) VALUES(@firstname, @lastname, @email, @firsthash, @secondhash)", vid);
            cmd.Parameters.AddWithValue("@firstname", TbFirstname.Text);
            cmd.Parameters.AddWithValue("@lastname", TbLastname.Text);
            cmd.Parameters.AddWithValue("@email", TbUsername.Text);
            cmd.Parameters.AddWithValue("@firsthash", CalculateMD5Hash(Tbfirsthash.Text));
            cmd.Parameters.AddWithValue("@secondhash", CalculateMD5Hash(Tbsecondhash.Text));

            SqlCommand admin = new SqlCommand("INSERT INTO dbo.Admin(email, firstpass, secondpass) VALUES(@email, @firstpass, @secondpass)", vid);
            admin.Parameters.AddWithValue("@email", TbUsername.Text);
            admin.Parameters.AddWithValue("@firstpass", Tbfirsthash.Text);
            admin.Parameters.AddWithValue("@secondpass", Tbsecondhash.Text);
            vid.Open();

            cmd.ExecuteNonQuery();
            admin.ExecuteNonQuery();
            //valid = verify.ExecuteReader();
            //while (valid.Read())
            //{
            //    if ((bool)valid[0] == true)
            //    {
            //        Label txtLabel1 = new Label();
            //        txtLabel1.Text = "Email is already in use. Please enter a new one";
            //        txtLabel1.Style.Add("Color", "Black");
            //        ph1.Controls.Add(txtLabel1);
            //        valid = verify.ExecuteReader();
            //    }
            //    else
            //    {
            //        cmd.ExecuteNonQuery();
            //        admin.ExecuteNonQuery();
            //    }
            //}

            vid.Close();

            if (IsPostBack)
            {
                Server.Transfer("LogIn.aspx", true);
            }
        }
    }
    protected void BtnHome_Click(object sender, EventArgs e)
    {
        Server.Transfer("HomePage.aspx", true);
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

}

