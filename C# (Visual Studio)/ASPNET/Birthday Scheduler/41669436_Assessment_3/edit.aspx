<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="_41669436_Assessment_3.edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="background-color: #C0C0C0">
<head runat="server">
    <title></title>
    <style type="text/css">
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
        .left_margin {
            margin-top: 5px;
            margin-left: 10px;
        }
        .bottom_margin {
            margin-bottom: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblTitle" runat="server" Font-Size="18pt" ForeColor="#000099" Text="StarPlumb Birthday Recording System - Edit Birthdays" Font-Names="Tahoma"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblWelcome" runat="server" Text="Welcome to the editor. You are not logged in." Font-Names="Tahoma"></asp:Label>
            &nbsp;<asp:HyperLink ID="linkLogin" runat="server" NavigateUrl="~/default.aspx" Font-Names="Tahoma">Please return to the login page to login.</asp:HyperLink>
            &nbsp;<asp:HyperLink ID="linkReturn" runat="server" NavigateUrl="~/dashboard.aspx" Font-Names="Tahoma">Return to the dashboard.</asp:HyperLink>
            <br />
            <br />
            <asp:Label ID="lblHeading" runat="server" Font-Bold="True" Text="Employee birthdays:" Font-Names="Tahoma"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="gvBirthdays" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Tahoma" ForeColor="#333333" GridLines="None" Width="443px">
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
            <asp:Label ID="lblEdit" runat="server" Font-Bold="True" Font-Names="Tahoma" Text="Edit entry:"></asp:Label>
            <br />
            <asp:Label ID="lblIDEdit" runat="server" Font-Names="Tahoma" Text="Employee ID: "></asp:Label>
            <asp:DropDownList ID="ddlIDEdit" runat="server" Font-Names="Tahoma" CssClass="left_margin" AutoPostBack="True" OnSelectedIndexChanged="ddlIDEdit_SelectedIndexChanged" ValidationGroup="EditGroup">
            </asp:DropDownList>
            <br />
            <asp:Label ID="lblFNameEdit" runat="server" Font-Names="Tahoma" Text="First Name:"></asp:Label>
            <asp:TextBox ID="txtFNameEdit" runat="server" CssClass="left_margin" Font-Names="Tahoma" ValidationGroup="EditGroup"></asp:TextBox>
            <br />
            <asp:Label ID="lblLNameEdit" runat="server" Font-Names="Tahoma" Text="Last Name:"></asp:Label>
            <asp:TextBox ID="txtLNameEdit" runat="server" Font-Names="Tahoma" CssClass="left_margin bottom_margin" ValidationGroup="EditGroup"></asp:TextBox>
            <br />
            <asp:Label ID="lblBirthDateEdit" runat="server" Font-Names="Tahoma" Text="Select Birth Date:"></asp:Label>
            <asp:Calendar ID="calBirthDateEdit" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                <NextPrevStyle VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#808080" />
                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                <SelectorStyle BackColor="#CCCCCC" />
                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                <WeekendDayStyle BackColor="#FFFFCC" />
            </asp:Calendar>
            <br />
            <asp:Label ID="lblYearsAtCompanyEdit" runat="server" Font-Names="Tahoma" Text="Years At Company:"></asp:Label>
            <asp:TextBox ID="txtYearsAtCompanyEdit" runat="server" Font-Names="Tahoma" CssClass="left_margin" ValidationGroup="EditGroup"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegexValidYearsEdit" runat="server" ControlToValidate="txtYearsAtCompanyEdit" ValidationExpression="^(?:[0-9]|[1-4][0-9]|50)$" ErrorMessage="Please enter an integer between 0 and 50." Display="Dynamic" CssClass="left_margin" Font-Names="Tahoma" ForeColor="Red" ValidationGroup="EditGroup"></asp:RegularExpressionValidator>
            <br />
            <asp:Button ID="btnSubmit" runat="server" CssClass="button left_margin" Font-Names="Tahoma" Text="Submit Changes" OnClick="btnSubmit_Click" ValidationGroup="EditGroup" />
            <br />
            <br />
            <asp:Label ID="lblAdd" runat="server" Font-Bold="True" Font-Names="Tahoma" Text="Add entry:"></asp:Label>
            <br />
            <asp:Label ID="lblFNameAdd" runat="server" Font-Names="Tahoma" Text="First Name:"></asp:Label>
            <asp:TextBox ID="txtFNameAdd" runat="server" CssClass="left_margin" Font-Names="Tahoma" ValidationGroup="AddGroup"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorFNA" runat="server" ControlToValidate="txtFNameAdd" CssClass="left_margin" ErrorMessage="This field is required" Font-Names="Tahoma" ForeColor="Red" SetFocusOnError="True" ValidationGroup="AddGroup"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lblLNameAdd" runat="server" Font-Names="Tahoma" Text="Last Name:"></asp:Label>
            <asp:TextBox ID="txtLNameAdd" runat="server" Font-Names="Tahoma" CssClass="left_margin" ValidationGroup="AddGroup"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorLNA" runat="server" ControlToValidate="txtLNameAdd" CssClass="left_margin" ErrorMessage="This field is required" Font-Names="Tahoma" ForeColor="Red" SetFocusOnError="True" ValidationGroup="AddGroup"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lblBirthDateAdd" runat="server" Font-Names="Tahoma" Text="Select Birth Date:"></asp:Label>
            <asp:Calendar ID="calBirthDateAdd" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                <NextPrevStyle VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#808080" />
                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                <SelectorStyle BackColor="#CCCCCC" />
                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                <WeekendDayStyle BackColor="#FFFFCC" />
            </asp:Calendar>
            <br />
            <asp:Label ID="lblYearsAtCompanyAdd" runat="server" Font-Names="Tahoma" Text="Years At Company:"></asp:Label>
            <asp:TextBox ID="txtYearsAtCompanyAdd" runat="server" Font-Names="Tahoma" CssClass="left_margin" ValidationGroup="AddGroup"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorYCA" runat="server" ControlToValidate="txtYearsAtCompanyAdd" CssClass="left_margin" ErrorMessage="This field is required" Font-Names="Tahoma" ForeColor="Red" SetFocusOnError="True" ValidationGroup="AddGroup"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegexValidYearsAdd" runat="server" ControlToValidate="txtYearsAtCompanyAdd" ValidationExpression="^(?:[0-9]|[1-4][0-9]|50)$" ErrorMessage="Please enter an integer between 0 and 50." Display="Dynamic" CssClass="left_margin" Font-Names="Tahoma" ForeColor="Red" ValidationGroup="AddGroup"></asp:RegularExpressionValidator>
            <br />
            <asp:Button ID="btnAdd" runat="server" CssClass="button left_margin" Font-Names="Tahoma" Text="Add Entry" OnClick="btnAdd_Click" ValidationGroup="AddGroup" />
            <br />
            <br />
            <asp:Label ID="lblDelete" runat="server" Font-Bold="True" Font-Names="Tahoma" Text="Delete entry:"></asp:Label>
            <br />
            <asp:Label ID="lblIDDel" runat="server" Font-Names="Tahoma" Text="Employee ID: "></asp:Label>
            <asp:DropDownList ID="ddlIDDel" runat="server" Font-Names="Tahoma" CssClass="left_margin" ValidationGroup="DeleteGroup">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDel" runat="server" ControlToValidate="ddlIDDel" CssClass="left_margin" ErrorMessage="Please select an employee ID" Font-Names="Tahoma" ForeColor="Red" ValidationGroup="DeleteGroup"></asp:RequiredFieldValidator>
            <br />
            <asp:Button ID="btnDel" runat="server" CssClass="button left_margin" Font-Names="Tahoma" Text="Delete Entry" OnClick="btnDel_Click" ValidationGroup="DeleteGroup" />
            <br />
        </div>
    </form>
</body>
</html>
