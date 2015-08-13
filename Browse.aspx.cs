using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Browse : System.Web.UI.Page
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
        txtLabel1.Style.Add("Color", "White");
        firstn.Controls.Add(txtLabel1);
        Label txtLabel3 = new Label();
        txtLabel3.Text = (string)pinfo[2];
        txtLabel3.Style.Add("Color", "White");
        usern.Controls.Add(txtLabel3);
        vid.Close();

        if(!IsPostBack)
        {
            ddlGem.AppendDataBoundItems = true;
            String strRingConnectionString = ConfigurationManager.ConnectionStrings["RingConnectionString"].ConnectionString;
            String strQuery = "SELECT DISTINCT gem_type from Inventory";
            SqlConnection con = new SqlConnection(strRingConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;

            try
            {
                con.Open();
                ddlGem.DataSource = cmd.ExecuteReader();
                ddlGem.DataTextField = "gem_type";
                ddlGem.DataBind();
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
    protected void BtnHome_Click(object sender, EventArgs e)
    {
        Server.Transfer("Account.aspx", true);
    }
    protected void ddlGem_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlMetal.Items.Clear();
        ddlMetal.Items.Add(new ListItem("--SELECT METAL--", ""));
        ddlGemSize.Items.Clear();
        ddlGemSize.Items.Add(new ListItem("--SELECT GEM SIZE--", ""));
        ddlRingSize.Items.Clear();
        ddlRingSize.Items.Add(new ListItem("--SELECT RING SIZE--", ""));

        ddlMetal.AppendDataBoundItems = true;
        String strRingConnectionString = ConfigurationManager.ConnectionStrings["RingConnectionString"].ConnectionString;
        String strQuery = "SELECT DISTINCT metal from Inventory where gem_type = @gem_type";
        SqlConnection con = new SqlConnection(strRingConnectionString);
        SqlCommand cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@gem_type", ddlGem.SelectedItem.Value);
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;

        try
        {
            con.Open();
            ddlMetal.DataSource = cmd.ExecuteReader();
            ddlMetal.DataTextField = "metal";
            ddlMetal.DataBind();
            if(ddlMetal.Items.Count > 1)
            {
                ddlMetal.Enabled = true;
            }
            else
            {
                ddlMetal.Enabled = false;
                ddlGemSize.Enabled = false;
                ddlRingSize.Enabled = false;
            }
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
    protected void ddlMetal_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        ddlGemSize.Items.Clear();
        ddlGemSize.Items.Add(new ListItem("--SELECT GEM SIZE--", ""));
        ddlRingSize.Items.Clear();
        ddlRingSize.Items.Add(new ListItem("--SELECT RING SIZE--", ""));

        ddlGemSize.AppendDataBoundItems = true;
        String strRingConnectionString = ConfigurationManager.ConnectionStrings["RingConnectionString"].ConnectionString;
        String strQuery = "SELECT DISTINCT gem_size from Inventory where gem_type = @gem_type AND metal = @metal";
        SqlConnection con = new SqlConnection(strRingConnectionString);
        SqlCommand cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@gem_type", ddlGem.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@metal", ddlMetal.SelectedItem.Value);
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;

        try
        {
            con.Open();
            ddlGemSize.DataSource = cmd.ExecuteReader();
            ddlGemSize.DataTextField = "gem_size";
            ddlGemSize.DataBind();
            if (ddlGemSize.Items.Count > 1)
            {
                ddlGemSize.Enabled = true;
            }
            else
            {
                ddlGemSize.Enabled = false;
                ddlRingSize.Enabled = false;
            }
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
    protected void ddlGemSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlRingSize.Items.Clear();
        ddlRingSize.Items.Add(new ListItem("--SELECT RING SIZE--", ""));

        ddlRingSize.AppendDataBoundItems = true;
        String strRingConnectionString = ConfigurationManager.ConnectionStrings["RingConnectionString"].ConnectionString;
        String strQuery = "SELECT DISTINCT ring_size from Inventory where gem_type = @gem_type AND metal = @metal AND gem_size = @gem_size";
        SqlConnection con = new SqlConnection(strRingConnectionString);
        SqlCommand cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@gem_type", ddlGem.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@metal", ddlMetal.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@gem_size", ddlGemSize.SelectedItem.Value);
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;

        try
        {
            con.Open();
            ddlRingSize.DataSource = cmd.ExecuteReader();
            ddlRingSize.DataTextField = "ring_size";
            ddlRingSize.DataBind();
            if (ddlRingSize.Items.Count > 1)
            {
                ddlRingSize.Enabled = true;
            }
            else
            {
                ddlRingSize.Enabled = false;
            }
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
    protected void ddlRingSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        String strRingConnectionString = ConfigurationManager.ConnectionStrings["RingConnectionString"].ConnectionString;
        String strQuery = "SELECT DISTINCT TOP 1 price, jewel_ID from Inventory where gem_type = @gem_type AND metal = @metal AND gem_size = @gem_size AND ring_size=@ring_size";
        SqlConnection con = new SqlConnection(strRingConnectionString);
        SqlCommand cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@gem_type", ddlGem.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@metal", ddlMetal.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@gem_size", ddlGemSize.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@ring_size", ddlRingSize.SelectedItem.Value);
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;

        try
        {
            con.Open();
            ddlPrice.DataSource = cmd.ExecuteReader();
            ddlPrice.DataTextField = "price";
            ddlPrice.DataBind();
            con.Close();
            con.Open();
            ddlJewel.DataSource = cmd.ExecuteReader();
            ddlJewel.DataTextField = "jewel_ID";
            ddlJewel.DataBind();
           
            if (ddlPrice.Items.Count > 1)
            {
                ddlPrice.Enabled = true;
            }
            else
            {
                ddlPrice.Enabled = false;
            }
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

    protected void BtnLogIn_Click(object sender, EventArgs e)
    {
        lblResults.Text = "You have selected " + ddlGem.SelectedItem.Text + " " + ddlMetal.SelectedItem.Text + "  " + ddlGemSize.SelectedItem.Text + " ring. Your ring size is " + ddlRingSize.SelectedItem.Text;
        lblResults0.Text = "Your ring is " + ddlPrice.Text + " dollars.";

        if(ddlGem.SelectedItem.Text == "Emerald" && ddlMetal.SelectedItem.Text == "Platinum")
        {
            EmSil.Visible = true;
            emgol.Visible = false;
            diamondGol.Visible = false;
            diamondSil.Visible = false;
            sil.Visible = false;
            gold.Visible = false;
            pearlSil.Visible = false;
            pearlGol.Visible = false;
            rubySil.Visible = false;
            rubyGol.Visible = false;
            sapSil.Visible = false;
            saphGol.Visible = false;
        }
        else if(ddlGem.SelectedItem.Text == "Emerald" && ddlMetal.SelectedItem.Text == "12K Gold" || ddlMetal.SelectedItem.Text == "14K Gold" || ddlMetal.SelectedItem.Text == "16K Gold" || ddlMetal.SelectedItem.Text == "18K Gold")
        {
            EmSil.Visible = false;
            emgol.Visible = true;
            diamondGol.Visible = false;
            diamondSil.Visible = false;
            sil.Visible = false;
            gold.Visible = false;
            pearlSil.Visible = false;
            pearlGol.Visible = false;
            rubySil.Visible = false;
            rubyGol.Visible = false;
            sapSil.Visible = false;
            saphGol.Visible = false;
        }
        else if (ddlGem.SelectedItem.Text == "Diamond" && ddlMetal.SelectedItem.Text == "Platinum")
        {
            diamondSil.Visible = true;
            diamondGol.Visible = false;
            EmSil.Visible = false;
            emgol.Visible = false;
            sil.Visible = false;
            gold.Visible = false;
            pearlSil.Visible = false;
            pearlGol.Visible = false;
            rubySil.Visible = false;
            rubyGol.Visible = false;
            sapSil.Visible = false;
            saphGol.Visible = false;
        }
        else if (ddlGem.SelectedItem.Text == "Diamond" && ddlMetal.SelectedItem.Text == "12K Gold" || ddlMetal.SelectedItem.Text == "14K Gold" || ddlMetal.SelectedItem.Text == "16K Gold" || ddlMetal.SelectedItem.Text == "18K Gold")
        {
            diamondGol.Visible = true;
            diamondSil.Visible = false;
            EmSil.Visible = false;
            emgol.Visible = false;
            sil.Visible = false;
            gold.Visible = false;
            pearlSil.Visible = false;
            pearlGol.Visible = false;
            rubySil.Visible = false;
            rubyGol.Visible = false;
            sapSil.Visible = false;
            saphGol.Visible = false;
        }
        else if (ddlGem.SelectedItem.Text == "None" && ddlMetal.SelectedItem.Text == "Platinum")
        {
            sil.Visible = true;
            gold.Visible = false;
            diamondSil.Visible = false;
            diamondGol.Visible = false;
            EmSil.Visible = false;
            emgol.Visible = false;
            pearlSil.Visible = false;
            pearlGol.Visible = false;
            rubySil.Visible = false;
            rubyGol.Visible = false;
            sapSil.Visible = false;
            saphGol.Visible = false;
        }
        else if (ddlGem.SelectedItem.Text == "None" && ddlMetal.SelectedItem.Text == "12K Gold" || ddlMetal.SelectedItem.Text == "14K Gold" || ddlMetal.SelectedItem.Text == "16K Gold" || ddlMetal.SelectedItem.Text == "18K Gold")
        {
            gold.Visible = true;
            sil.Visible = false;
            diamondGol.Visible = false;
            diamondSil.Visible = false;
            EmSil.Visible = false;
            emgol.Visible = false;
            pearlSil.Visible = false;
            pearlGol.Visible = false;
            rubySil.Visible = false;
            rubyGol.Visible = false;
            sapSil.Visible = false;
            saphGol.Visible = false;
        }
        else if (ddlGem.SelectedItem.Text == "Pearl" && ddlMetal.SelectedItem.Text == "Platinum")
        {
            pearlSil.Visible = true;
            pearlGol.Visible = false;
            sil.Visible = false;
            gold.Visible = false;
            diamondSil.Visible = false;
            diamondGol.Visible = false;
            EmSil.Visible = false;
            emgol.Visible = false;
            rubySil.Visible = false;
            rubyGol.Visible = false;
            sapSil.Visible = false;
            saphGol.Visible = false;
        }
        else if (ddlGem.SelectedItem.Text == "Pearl" && ddlMetal.SelectedItem.Text == "12K Gold" || ddlMetal.SelectedItem.Text == "14K Gold" || ddlMetal.SelectedItem.Text == "16K Gold" || ddlMetal.SelectedItem.Text == "18K Gold")
        {
            pearlGol.Visible = true;
            pearlSil.Visible = false;            
            gold.Visible = false;
            sil.Visible = false;
            diamondGol.Visible = false;
            diamondSil.Visible = false;
            EmSil.Visible = false;
            emgol.Visible = false;
            rubySil.Visible = false;
            rubyGol.Visible = false;
            sapSil.Visible = false;
            saphGol.Visible = false;
        }
        else if (ddlGem.SelectedItem.Text == "Ruby" && ddlMetal.SelectedItem.Text == "Platinum")
        {
            rubySil.Visible = true;
            rubyGol.Visible = false;
            pearlSil.Visible = false;
            pearlGol.Visible = false;
            sil.Visible = false;
            gold.Visible = false;
            diamondSil.Visible = false;
            diamondGol.Visible = false;
            EmSil.Visible = false;
            emgol.Visible = false;
            sapSil.Visible = false;
            saphGol.Visible = false;
        }
        else if (ddlGem.SelectedItem.Text == "Ruby" && ddlMetal.SelectedItem.Text == "12K Gold" || ddlMetal.SelectedItem.Text == "14K Gold" || ddlMetal.SelectedItem.Text == "16K Gold" || ddlMetal.SelectedItem.Text == "18K Gold")
        {
            rubySil.Visible = false;
            rubyGol.Visible = true;
            pearlGol.Visible = false;
            pearlSil.Visible = false;
            gold.Visible = false;
            sil.Visible = false;
            diamondGol.Visible = false;
            diamondSil.Visible = false;
            EmSil.Visible = false;
            emgol.Visible = false;
            sapSil.Visible = false;
            saphGol.Visible = false;
        }
        else if (ddlGem.SelectedItem.Text == "Sapphire" && ddlMetal.SelectedItem.Text == "Platinum")
        {
            sapSil.Visible = true;
            saphGol.Visible = false;
            rubySil.Visible = false;
            rubyGol.Visible = false;
            pearlSil.Visible = false;
            pearlGol.Visible = false;
            sil.Visible = false;
            gold.Visible = false;
            diamondSil.Visible = false;
            diamondGol.Visible = false;
            EmSil.Visible = false;
            emgol.Visible = false;
        }
        else if (ddlGem.SelectedItem.Text == "Sapphire" && ddlMetal.SelectedItem.Text == "12K Gold" || ddlMetal.SelectedItem.Text == "14K Gold" || ddlMetal.SelectedItem.Text == "16K Gold" || ddlMetal.SelectedItem.Text == "18K Gold")
        {
            sapSil.Visible = false;
            saphGol.Visible = true;
            rubySil.Visible = false;
            rubyGol.Visible = false;
            pearlGol.Visible = false;
            pearlSil.Visible = false;
            gold.Visible = false;
            sil.Visible = false;
            diamondGol.Visible = false;
            diamondSil.Visible = false;
            EmSil.Visible = false;
            emgol.Visible = false;
        }
    }

    

    protected void ddlPrice_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        SqlConnection vid = new SqlConnection("Data Source=(local);Initial Catalog=Ring;Integrated Security=True");
        {
            Random rnd = new Random();
            SqlCommand orders = new SqlCommand("INSERT INTO dbo.orders (email,order_ID,month,year,jewel_ID,price,credit_Card) VALUES (@email,@order_ID,@month,@year,@jewel_ID,@price,@credit_Card)", vid);
            orders.Parameters.AddWithValue("@email", Session["username"]);
            int holder = rnd.Next(10000000,99999999);
            orders.Parameters.AddWithValue("@price", ddlPrice.Text);
            orders.Parameters.AddWithValue("@jewel_ID", ddlJewel.Text);
            holder = rnd.Next(10000000, 99999999);
            orders.Parameters.AddWithValue("@order_ID", holder.ToString());
            orders.Parameters.AddWithValue("@month", DateTime.Now.Month.ToString());
            orders.Parameters.AddWithValue("@year", DateTime.Now.Year.ToString());
            holder = rnd.Next(10000000, 99999999);
            orders.Parameters.AddWithValue("@credit_Card", holder.ToString());
            holder = rnd.Next(10000000, 99999999);
            SqlCommand inventory = new SqlCommand("UDATE dbo.Inventory SET jewel_ID='"+holder+"'WHERE jewel_ID='"+ ddlJewel.Text+"'", vid);
            vid.Open();

            orders.ExecuteNonQuery();
            inventory.ExecuteNonQuery();
            vid.Close();

            if (IsPostBack)
            {
                Server.Transfer("Account.aspx", true);
            }
        }
    }
}