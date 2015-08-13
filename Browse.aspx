<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Browse.aspx.cs" Inherits="Browse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Browse Our Rings</title>
    <link rel="stylesheet" href="StyleSheet3.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Browse Our Rings,&nbsp;
            <asp:PlaceHolder id="firstn" runat="server" /> !
        
        <p>
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="Lblemail" runat="server" Text="Username:" Font-Names="Calibri" Font-Size="Medium" ForeColor="White"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:PlaceHolder id="usern" runat="server" />
        </p>
        </div>

        <div1>

        <br />
        <asp:Button ID="BtnHome" runat="server" Text="Home Page" BackColor="SkyBlue" Font-Bold="True" Font-Names="Calibri" Font-Size="Large" ForeColor="White" OnClick="BtnHome_Click" />
    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtnAccount" runat="server" Text="Go Back to Account" BackColor="SkyBlue" Font-Bold="True" Font-Names="Calibri" Font-Size="Large" ForeColor="White" OnClick="BtnHome_Click" />
    
        <br />
    
        &nbsp;<br />
    
        <asp:DropDownList ID="ddlGem" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlGem_SelectedIndexChanged">
            <asp:ListItem Text =" --SELECT GEM--" Value=""></asp:ListItem>
        </asp:DropDownList>
    
        <br />
    
        <br />

        <asp:DropDownList ID="ddlMetal" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMetal_SelectedIndexChanged" Enabled="False">
        <asp:ListItem Text =" --SELECT METAL--" Value=""></asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:DropDownList ID="ddlGemSize" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlGemSize_SelectedIndexChanged" Enabled="False">
        <asp:ListItem Text =" --SELECT GEM SIZE--" Value=""></asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:DropDownList ID="ddlRingSize" runat="server" OnSelectedIndexChanged="ddlRingSize_SelectedIndexChanged" Enabled="False">
        <asp:ListItem Text =" --SELECT RING SIZE--" Value=""></asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
    
    <asp:Button ID="BtnCreate" runat="server" Text="Create My Ring" BackColor="SkyBlue" Font-Bold="True" Font-Names="Calibri" Font-Size="Large" ForeColor="White" OnClick="BtnLogIn_Click" />
        <br />
        <br />
        <asp:DropDownList ID="ddlPrice" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPrice_SelectedIndexChanged">
            <asp:ListItem Text="--Price--" Value=""></asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="lblResults" runat="server" Font-Size="Medium"></asp:Label>
        <br />
        <asp:Label ID="lblResults0" runat="server" Font-Size="Medium"></asp:Label>
        <br />
        <br />
        <asp:Image ID="emgol" runat="server" Height="100px" ImageUrl="~/emGol.jpg" Visible="False" Width="100px" />
        <asp:Image ID="diamondGol" runat="server" Height="100px" ImageUrl="~/diamondGol.jpg" Visible="False" Width="100px" />
        <asp:Image ID="gold" runat="server" Height="100px" ImageUrl="~/gol.jpg" Visible="False" Width="100px" />
        <asp:Image ID="pearlGol" runat="server" Height="100px" ImageUrl="~/pearGol.jpg" Visible="False" Width="100px" />
        <asp:Image ID="rubyGol" runat="server" Height="100px" ImageUrl="~/rubyGol.jpg" Visible="False" Width="100px" />
        <asp:Image ID="saphGol" runat="server" Height="100px" ImageUrl="~/sapphireGol.jpg" Visible="False" Width="100px" />
        <asp:Image ID="sapSil" runat="server" Height="100px" ImageUrl="~/sapphireSil.jpg" Visible="False" Width="100px" />
        <asp:Image ID="rubySil" runat="server" Height="100px" ImageUrl="~/rubySil.jpg" Visible="False" Width="100px" />
        <asp:Image ID="pearlSil" runat="server" Height="100px" ImageUrl="~/pearlSil.jpg" Visible="False" Width="100px" />
        <asp:Image ID="sil" runat="server" Height="100px" ImageUrl="~/sil.jpg" Visible="False" Width="100px" />
        <asp:Image ID="diamondSil" runat="server" Height="100px" ImageUrl="~/diamondSil.jpg" Visible="False" Width="100px" />
        <asp:Image ID="EmSil" runat="server" Height="100px" ImageUrl="~/emSil.jpg" Visible="False" Width="100px" />
        <br />
        <br />
    
    <asp:Button ID="BtnAdd" runat="server" Text="Add To My Account" BackColor="SkyBlue" Font-Bold="True" Font-Names="Calibri" Font-Size="Large" ForeColor="White" OnClick="BtnAdd_Click" />
        <br />
        <br />
        <asp:DropDownList ID="ddlJewel" runat="server" AutoPostBack="True" Visible="False">
            <asp:ListItem>Price</asp:ListItem>
        </asp:DropDownList>
        <br />
&nbsp;&nbsp;
        &nbsp;&nbsp;
    </div1>
    </form>
</body>
</html>
