<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserRegister.aspx.cs" Inherits="UserRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
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
        .register-container {
            background: rgba(255, 255, 255, 0.2);
            border-radius: 16px;
            box-shadow: 0 4px 30px rgba(0, 0, 0, 0.1);
            backdrop-filter: blur(10px);
            -webkit-backdrop-filter: blur(10px);
            border: 1px solid rgba(255, 255, 255, 0.3);
            padding: 30px;
            max-width: 400px;
            width: 100%;
            text-align: center;
            color: white;
        }
        #form1{
               
    box-shadow: 0 0 7px -3px;
    padding: 10px;
    border-radius: 37px;
        }
        .register-container h2 {
            margin-bottom: 20px;
        }
        .register-container table {
            width: 100%;
            margin: 0 auto;
        }
        .register-container table td {
            padding: 10px 0;
        }
        .register-container table td:first-child {
            text-align: right;
            padding-right: 10px;
        }
        .register-container table td:last-child {
            text-align: left;
        }
        .register-container table td input[type="text"],
        .register-container table td input[type="password"] {
            width: 100%;
            padding: 5px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }
        .register-container table td input[type="button"] {
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            background-color: #007bff;
            color: white;
            cursor: pointer;
        }
        .register-container table td input[type="button"]:hover {
            background-color: #0056b3;
        }
        .register-container .message {
            margin-top: 10px;
            color: red;
        }
    </style>

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
                    <td><asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" /></td><br />
                     <td><asp:Button ID="btmLogin" runat="server" Text="Go to Login" OnClick="btnUserLogin_Click" /></td>
       
                </tr>
            </table>
        </div>
    </form>
</body>
</html>