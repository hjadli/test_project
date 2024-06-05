<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="AdminDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Admin Dashboard</title>
    <style>
        .dashboard-container {
            text-align: center;
            margin-top: 50px;
            border:1px solid black;
        }
        .dashboard-card {
            display: inline-block;
            width: 200px;
            height: 150px;
            margin: 20px;
            text-align: center;
            border: 1px solid #ccc;
            border-radius: 10px;
            padding: 20px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        .dashboard-card h3 {
            margin: 10px 0;
            font-size: 1.2em;
        }
        .dashboard-card p {
            font-size: 1.5em;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="dashboard-container">
            <h1>Admin Dashboard</h1>
            <div class="dashboard-card">
                <h3>Registered Users</h3>
                <p><asp:Label ID="lblRegisteredUsers" runat="server" Text="0"></asp:Label></p>
            </div>
            
            <div>
                <asp:Button ID="btnAddProduct" runat="server" OnClick="BtnAddProduct_Click" Text="Add Product" />
                <asp:Button ID="btnAddCategory" runat="server" OnClick="BtnAddCategory_Click" Text="Add Category" />
                <asp:Button ID="btnLogout" runat="server" OnClick="BtnLogout_Click" Text="Logout" />
            </div>
        </div>
    </form>
</body>
</html>