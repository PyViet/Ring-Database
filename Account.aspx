<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Account.aspx.cs" Inherits="Account" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Your Account</title>
    <link rel="stylesheet" href="StyleSheet2.css" />  
</head>
<body>
    <form id="form1" runat="server">
        
            <div>
                <p>
            <asp:Label ID="Lblfirstname" runat="server" Text="First Name" Font-Names="Calibri" Font-Size="Medium" ForeColor="White"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:PlaceHolder id="firstn" runat="server" />
                    </p>
        
        <p>
            <asp:Label ID="Lbllastname" runat="server" Text="Last Name" Font-Names="Calibri" Font-Size="Medium" ForeColor="White"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:PlaceHolder id="lastn" runat="server" />
        </p>    
        <p>
            <asp:Label ID="Lblemail" runat="server" Text="Email" Font-Names="Calibri" Font-Size="Medium" ForeColor="White"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblusername" runat="server"></asp:Label>
            </p>
            
        
        <asp:Button ID="BtnBrowse" runat="server" Text="Browse Rings" BackColor="SkyBlue" Font-Bold="True" Font-Names="Calibri" Font-Size="Large" ForeColor="White" OnClick="BtnBrowse_Click" />
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtnHome" runat="server" Text="Log Out" BackColor="SkyBlue" Font-Bold="True" Font-Names="Calibri" Font-Size="Large" ForeColor="White" OnClick="BtnHome_Click" />
    
                <br />
                <br />
        <asp:DropDownList ID="ByPrice" runat="server" AutoPostBack = "true"
             OnSelectedIndexChanged="PriceIndexChanged">
        <asp:ListItem Text = "--Month of Your Order--" Value = ""></asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="ByDate" runat="server" AutoPostBack = "True"
             OnSelectedIndexChanged="DateIndexChanged">
        <asp:ListItem Text = "--Year of Your Order--" Value = ""></asp:ListItem>
        </asp:DropDownList>

                <asp:DropDownList ID="ByJewel" runat="server" AutoPostBack = "true"
             OnSelectedIndexChanged="PriceIndexChanged">
        <asp:ListItem Text = "--Order by Jewel ID--" Value = ""></asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="ByPrice1" runat="server" AutoPostBack = "true"
             OnSelectedIndexChanged="DateIndexChanged">
        <asp:ListItem Text = "--Order by Price--" Value = ""></asp:ListItem>
        </asp:DropDownList>

        </div>
            <br />
        <asp:Label ID="NewFirst" runat="server" Text="New First Name" Font-Names="Calibri" Font-Size="Medium" ForeColor="White"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="NewFName" runat="server"></asp:TextBox>

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
    &nbsp;&nbsp;<p>
        <asp:Label ID="NewLast" runat="server" Text="New Last Name" Font-Names="Calibri" Font-Size="Medium" ForeColor="White"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="NewLName" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;
    </p>
    <p>
        <asp:Label ID="NewEmail" runat="server" Text="New Email" Font-Names="Calibri" Font-Size="Medium" ForeColor="White"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="NewUsername" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <p>
        <asp:Label ID="New1Pass" runat="server" Text="New Primary Password" Font-Names="Calibri" Font-Size="Medium" ForeColor="White"></asp:Label>
        &nbsp;
        <asp:TextBox ID="NewPassword" runat="server"></asp:TextBox>
    &nbsp;&nbsp;
    </p>
    <p>
        <asp:Label ID="New2Pass" runat="server" Text="New Favorite City" Font-Names="Calibri" Font-Size="Medium" ForeColor="White"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="NewCity" runat="server"></asp:TextBox>
    &nbsp;
    </p>
            <p style="margin-left: 160px">
        &nbsp;<asp:Label ID="lblupdate" runat="server" ForeColor="Red"></asp:Label>
    </p>
    <asp:Button ID="BtnEdit" runat="server" Text="Change Personal Data" BackColor="SkyBlue" Font-Bold="True" Font-Names="Calibri" Font-Size="Large" ForeColor="White" OnClick="BtnEdit_Click" />
    <asp:Button ID="BtnDelete" runat="server" Text="Delete Your Account" BackColor="SkyBlue" Font-Bold="True" Font-Names="Calibri" Font-Size="Large" ForeColor="White" OnClick="BtnDelete_Click" />
    </form>



</body>
</html>
