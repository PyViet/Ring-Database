<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateAccount.aspx.cs" Inherits="CreateAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Account</title>
    <link rel="stylesheet" href="StyleSheet.css" />  
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Create your JKP Rings Account!
    
    </div>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="LblFirstname" runat="server" Text="First name" Font-Names="Calibri" Font-Size="Medium" ForeColor="White"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TbFirstname" runat="server"></asp:TextBox>
        </p>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="LblLastname" runat="server" Text="Last name" Font-Names="Calibri" Font-Size="Medium" ForeColor="White"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TbLastname" runat="server"></asp:TextBox>
        </p>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="LblUsername" runat="server" Text="Email, this will be your username" Font-Names="Calibri" Font-Size="Medium" ForeColor="White"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TbUsername" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Lblfirsthash" runat="server" Text="Password" Font-Names="Calibri" Font-Size="Medium" ForeColor="White"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="Tbfirsthash" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Lblsecondhash" runat="server" Text="Favorite City (lower case, no spaces)" Font-Names="Calibri" Font-Size="Medium" ForeColor="White"></asp:Label>
            &nbsp;
            <asp:TextBox ID="Tbsecondhash" runat="server"></asp:TextBox>
        </p>
        <p style="height: 19px">
            <asp:Label ID="LblMessage" runat="server" Text=""></asp:Label>
        </p>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="BtnCreate" runat="server" Text="Create Account" BackColor="SkyBlue" Font-Bold="True" Font-Names="Calibri" Font-Size="Large" ForeColor="White" OnClick="BtnCreate_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtnHome" runat="server" Text="Home Page" BackColor="SkyBlue" Font-Bold="True" Font-Names="Calibri" Font-Size="Large" ForeColor="White" OnClick="BtnHome_Click" />
    
            </p>
    </form>
</body>
</html>
