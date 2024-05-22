<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Page</title>
    <style>
        .navbar {
            background-color: #f8f9fa;
            padding: 10px;
            border-bottom: 1px solid #e3e3e3;
        }
        .navbar a {
            margin: 0 10px;
            text-decoration: none;
            color: #000;
        }
        .navbar a:hover {
            text-decoration: underline;
        }
        .navbar-brand {
            font-weight: bold;
            margin-right: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="navbar">
            <span class="navbar-brand">My Website</span>
            <a href="Register.aspx">Register</a>
            <a href="Login.aspx">Login</a>
        </div>
        <div>
            <h1>Welcome to the Home Page</h1>
            <p>This is the homepage of your website. Use the navigation bar to go to the Register or Login page.</p>
        </div>
    </form>
</body>
</html>
