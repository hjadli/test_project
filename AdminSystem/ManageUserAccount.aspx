<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageUserAccount.aspx.cs" Inherits="_1_ConfirmDelete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Account</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background: linear-gradient(135deg, #71b7e6, #9b59b6);
            height: 100vh;
            margin: 0;
            display: flex;
            justify-content: center;
            align-items: center;
        }
        .account-container {
            background: rgba(255, 255, 255, 0.2);
            border-radius: 16px;
            box-shadow: 0 4px 30px rgba(0, 0, 0, 0.1);
            backdrop-filter: blur(10px);
            -webkit-backdrop-filter: blur(10px);
            border: 1px solid rgba(255, 255, 255, 0.3);
            padding: 30px;
            max-width: 400px;
            width: 100%;
            color: white;
        }
        .account-container h2 {
            margin-bottom: 20px;
            text-align: center;
        }
        .account-container table {
            width: 100%;
        }
        .account-container table td {
            padding: 10px;
        }
        .account-container input[type="text"], .account-container input[type="password"] {
            width: 100%;
            padding: 10px;
            margin: 5px 0;
            border: none;
            border-radius: 5px;
        }
        .account-container .btn {
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            background-color: #007bff;
            color: white;
            cursor: pointer;
            margin: 5px;
            width: 100%;
        }
        .account-container .btn:hover {
            background-color: #0056b3;
        }
        .account-container .btn-delete {
            background-color: #dc3545;
        }
        .account-container .btn-delete:hover {
            background-color: #c82333;
        }
        .account-container .message {
            margin-top: 10px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="account-container">
            <h2>Manage Account</h2>
            <asp:Label ID="lblMessage" runat="server" CssClass="message" ForeColor="Red"></asp:Label>
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
                    <td colspan="2">
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete Account" CssClass="btn btn-delete" OnClick="btnDelete_Click" />
                          <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-logout" OnClick="btnLogout_Click" />
                 
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
