<%@ Page Language="C#" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="UserRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="register" runat="server">
        <div>
            <h2>User Registration</h2>
            <label>Username:</label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox><br /><br />
            
            <label>Password:</label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br /><br />
            
            <label>Email:</label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br /><br />

            <label>Gender:</label>
            <asp:RadioButton ID="radioMale" GroupName="Gender" runat="server" Text="Male" /><br />
            <asp:RadioButton ID="radioFemale" GroupName="Gender" runat="server" Text="Female" /><br /><br />

            <asp:CheckBox ID="chkTerms" runat="server" Text="I accept the terms and conditions" /><br /><br />

            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" /><br /><br />

            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" />
        </div>
    </form>
</body>
</html>


