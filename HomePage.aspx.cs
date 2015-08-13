using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HomePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnLogIn_Click(object sender, EventArgs e)
    {
        Server.Transfer("LogIn.aspx", true);
    }
    protected void BtnBrowse_Click(object sender, EventArgs e)
    {
        Server.Transfer("Browse.aspx", true);
    }
    protected void BtnCreate_Click(object sender, EventArgs e)
    {
        Server.Transfer("CreateAccount.aspx", true);
    }
}