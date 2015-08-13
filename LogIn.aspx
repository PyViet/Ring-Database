<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogIn.aspx.cs" Inherits="LogIn" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log In</title>
    <link rel="stylesheet" href="StyleSheet.css" />   
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Log in to your JKP Rings Account



    </div>
        <p>
            &nbsp;<asp:Label ID="LblError" runat="server" Text=""></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

            </p>


        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="LblUsername" runat="server" Text="Username" Font-Names="Calibri" Font-Size="Medium" ForeColor="White"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TbUsername" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </p>
        <p>
            <asp:Label ID="LblPassword" runat="server" Text="Password" Font-Names="Calibri" Font-Size="Medium" ForeColor="White"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TbPassword" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;</p>
        <p>
            <asp:PlaceHolder ID="RealPassword" runat="server"></asp:PlaceHolder>
        &nbsp;</p>
        <p>
            

            <br />
        </p>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="BtnLogIn2" runat="server" Text="Log In" BackColor="SkyBlue" Font-Bold="True" Font-Names="Calibri" Font-Size="Large" ForeColor="White" OnClick="BtnLogIn_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="BtnCreate" runat="server" Text="Create Account" BackColor="SkyBlue" Font-Bold="True" Font-Names="Calibri" Font-Size="Large" ForeColor="White" OnClick="BtnCreate_Click" />
            &nbsp;&nbsp;&nbsp;
    
        </p>
        <p>
        <asp:Button ID="BtnHome" runat="server" Text="Home Page" BackColor="SkyBlue" Font-Bold="True" Font-Names="Calibri" Font-Size="Large" ForeColor="White" OnClick="BtnHome_Click" />
    
        </p>
        <p>
        <asp:Button ID="Forgot" runat="server" Text="Forgot Password?" BackColor="SkyBlue" Font-Bold="True" Font-Names="Calibri" Font-Size="Large" ForeColor="White" OnClick="BtnPassword_Click" />
    
        </p>
    </form>
</body>
</html>
