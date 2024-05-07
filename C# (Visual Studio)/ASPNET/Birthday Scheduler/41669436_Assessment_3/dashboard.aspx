<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="_41669436_Assessment_3.dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="background-color: #C0C0C0">
<head runat="server">
    <title></title>
    <style type="text/css">
        .left_margin {
            margin-left: 10px;
        }
        .top_margin {
            margin-top: 10px;
        }
        .bottom_margin {
            margin-bottom: 10px;
        }
        .button {
            border-style: groove;
            cursor: pointer;
            color: #0000CC;
            padding:10px;
        }
        .button:hover {
            background-color: white;
            color: grey;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblTitle" runat="server" Font-Size="18pt" ForeColor="#000099" Text="StarPlumb Birthday Recording System - Dashboard" Font-Names="Tahoma"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblWelcome" runat="server" Text="Welcome to the dashboard. You are not logged in." Font-Names="Tahoma"></asp:Label>
            &nbsp;<asp:HyperLink ID="linkLogin" runat="server" NavigateUrl="~/default.aspx" Font-Names="Tahoma">Please return to the previous page to login.</asp:HyperLink>
            &nbsp;<asp:HyperLink ID="linkLogout" runat="server" NavigateUrl="~/default.aspx" Font-Names="Tahoma">Log out.</asp:HyperLink>
            <br />
            <br />
            <asp:Label ID="lblHeading" runat="server" Font-Bold="True" Text="Employee birthdays:" Font-Names="Tahoma"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="gvBirthdays" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="443px" AutoGenerateColumns="False" Font-Names="Tahoma">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Employee ID" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                    <asp:BoundField DataField="BirthDate" DataFormatString="{0:yyyy/MM/dd}" HeaderText="Birth Date" />
                    <asp:BoundField DataField="TimeAtCompany" HeaderText="Years at Company" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <asp:Label ID="lblError" runat="server" ForeColor="Red" Font-Names="Tahoma"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblAction" runat="server" Font-Bold="False" Text="Actions:" CssClass="left_margin" Font-Names="Tahoma"></asp:Label>
            <br />
            <asp:Button ID="btnAll" runat="server" OnClick="btnAll_Click" Text="Show all" CssClass="top_margin bottom_margin button" Font-Names="Tahoma" />
            <asp:Button ID="btnEdit" runat="server" CssClass="left_margin bottom_margin button" OnClick="btnEdit_Click" Text="Edit Birthdays" />
            <br />
            <asp:Label ID="lblSort" runat="server" Font-Bold="False" Text="Sort by:" CssClass="left_margin" Font-Names="Tahoma"></asp:Label>
            <br />
            <asp:Button ID="btnThisMonth" runat="server" OnClick="btnThisMonth_Click" Text="Birthdays this month" CssClass="top_margin button" Font-Names="Tahoma" />
            <asp:Button ID="btnNextMonth" runat="server" CssClass="left_margin button" OnClick="btnNextMonth_Click" Text="Birthdays next month" Font-Names="Tahoma" />
            <br />
            <asp:Button ID="btnYearsAtCompany5" runat="server" Text="Years at Company &gt;5" OnClick="btnYearsAtCompany5_Click" CssClass="top_margin button" Font-Names="Tahoma" />
            <asp:Button ID="btnYearsAtCompany10" runat="server" Text="Years at Company &gt;10" CssClass="left_margin button" OnClick="btnYearsAtCompany10_Click" Font-Names="Tahoma" />
        </div>
    </form>
</body>
</html>
