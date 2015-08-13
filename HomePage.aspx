<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>JKP Rings</title>
    <link rel="stylesheet" href="StyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    WELCOME TO JKP RINGS!</div>
    
        <br />
    
    <asp:Button ID="BtnLogIn" runat="server" Text="Log In" BackColor="SkyBlue" Font-Bold="True" Font-Names="Calibri" Font-Size="Large" ForeColor="White" OnClick="BtnLogIn_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="BtnCreate" runat="server" Text="Create Account" BackColor="SkyBlue" Font-Bold="True" Font-Names="Calibri" Font-Size="Large" ForeColor="White" OnClick="BtnCreate_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;
            
    <p>
    <img src="r1.jpg" alt="Ring one" width="350" /></p>
        </form>

    Created by: Jasmine Rivera, Phi Tran and Kristen Harris
</body>
</html>
