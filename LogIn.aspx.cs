using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;


public partial class LogIn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnPassword_Click(object sender, EventArgs e)
    {
        LblPassword.Text = "What is your favorite city?";
        SqlConnection cn = new SqlConnection("Data Source=(local);Initial Catalog=Ring;Integrated Security=True");
        SqlCommand gd = new SqlCommand("SELECT firstpass FROM dbo.admin WHERE email=@email AND secondpass = @secondpass", cn);
        gd.Parameters.AddWithValue("@email", TbUsername.Text);
        gd.Parameters.AddWithValue("@secondpass", TbPassword.Text);
        cn.Open();
        SqlDataReader pass = gd.ExecuteReader();
        

        if (pass.Read())
        {
           Label stuff = new Label();
           stuff.Text = (string) pass[0];
           stuff.Style.Add("Color", "Black");
           RealPassword.Controls.Add(stuff);
        }
        else
        {
            LblError.Text = "Invalid Entry";
        }
        cn.Close();
    }
    protected string ConvertHexToString(string HexValue)
    {
        string StrValue = "";
        while (HexValue.Length > 0)
        {
            StrValue += System.Convert.ToChar(System.Convert.ToUInt32(HexValue.Substring(0, 2), 16)).ToString();
            HexValue = HexValue.Substring(2, HexValue.Length - 2);
        }
        return StrValue;
    }

    protected void BtnLogIn_Click(object sender, EventArgs e)
    {
        using (SqlConnection cn = new SqlConnection("Data Source=(local);Initial Catalog=Ring;Integrated Security=True"))
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from dbo.Admin where email = '" + TbUsername.Text + "' and firstpass = '" + (string) TbPassword.Text + "'", cn);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            int count = 0;
            while (dr.Read())
            {
                count += 1;
            }

            if (count == 1)
            {
                Session["username"] = TbUsername.Text;
                Server.Transfer("Account.aspx", true);
            }
            else
            {
                LblError.Text = "Error logging in. Try again";
            }

            dr.Close();
        }
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

    protected void BtnHome_Click(object sender, EventArgs e)
    {
        Server.Transfer("Homepage.aspx", true);
    }
    protected void BtnCreate_Click(object sender, EventArgs e)
    {
        using (SqlConnection cn = new SqlConnection("Data Source=(local);Initial Catalog=Ring;Integrated Security=True"))
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from dbo.Customers where email = '" + TbUsername.Text + "' and firsthash = '" + TbPassword.Text + "'", cn);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            int count = 0;
            while (dr.Read())
            {
                count += 1;
            }

            if (count == 1)
            {
                LblError.Text = "Username exists";
            }
            else
            {
                Server.Transfer("CreateAccount.aspx", true);
            }

            dr.Close();
        }
    }
}