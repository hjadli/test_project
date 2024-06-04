<%@ Page Language="C#" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="UserRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
</head>
<body>
   <form id="form1" runat="server">
        <div>
            <h2>Register</h2>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            <table>
                <tr>
                    <td>First Name:</td>
                    <td><asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Last Name:</td>
                    <td><asp:TextBox ID="txtLastName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Email:</td>
                    <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Address:</td>
                    <td><asp:TextBox ID="txtAddress" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Password:</td>
                    <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>