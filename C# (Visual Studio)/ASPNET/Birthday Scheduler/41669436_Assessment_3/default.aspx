<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="_41669436_Assessment_3._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="background-color: #C0C0C0">
<head runat="server">
    <title></title>
    <style type="text/css">
        .button {
            border-style: groove;
            cursor: pointer;
            color: #0000CC;
        }
        .button:hover {
            background-color: white;
            color: grey;
        }
        .left10 {
            margin-left: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblTitle" runat="server" Font-Size="18pt" ForeColor="#000099" Text="StarPlumb Birthday Recording System" Font-Names="Tahoma"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblLogin" runat="server" Text="Please enter your login details (refer to the documentation for help):" Font-Names="Tahoma"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblUsername" runat="server" Height="24px" Text="Username:" Font-Names="Tahoma"></asp:Label>
            <asp:TextBox ID="txtUser" runat="server" CssClass="left10" Font-Names="Tahoma"></asp:TextBox>
            <asp:Label ID="lblUserError" runat="server" CssClass="left10" ForeColor="Red" Font-Names="Tahoma"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblPassword" runat="server" Height="24px" Text="Password:" Font-Names="Tahoma"></asp:Label>
            <asp:TextBox ID="txtPass" runat="server" CssClass="left10" Font-Names="Tahoma"></asp:TextBox>
            <asp:Label ID="lblPassError" runat="server" CssClass="left10" ForeColor="Red" Font-Names="Tahoma"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnLogin" runat="server" Font-Bold="True" Height="34px" OnClick="btnLogin_Click" Text="Login" Width="200px" CssClass="button" Font-Names="Tahoma" />
            <br />
            <asp:Label ID="lblError" runat="server" ForeColor="Red" Font-Names="Tahoma"></asp:Label>
        </div>
    </form>
</body>
</html>
