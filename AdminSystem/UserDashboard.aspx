<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserDashboard.aspx.cs" Inherits="_1_DataEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

 <title>Dashboard</title>
     <style>
        body {
            font-family: Arial, sans-serif;
            background: linear-gradient(135deg, #71b7e6, #9b59b6);
            height: 100vh;
            margin: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            position: relative;
        }
        .dashboard-container {
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
            text-align: center;
            position: relative;
        }
        .dashboard-container h2 {
            margin-bottom: 20px;
        }
        .card {
            background: rgba(255, 255, 255, 0.5);
            border-radius: 10px;
            padding: 20px;
            margin: 10px 0;
            text-align: center;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
            display: flex;
            flex-direction: column;
            align-items: center;
        }
        .card .btn {
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            background-color: #007bff;
            color: white;
            cursor: pointer;
            margin-top: 10px;
            width: 100%;
        }
        .card .btn:hover {
            background-color: #0056b3;
        }
        .logout-container {
            position: absolute;
            top: 10px;
            right: 10px;
        }
        .logout-container .btn-logout {
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            background-color: #dc3545;
            color: white;
            cursor: pointer;
        }
        .logout-container .btn-logout:hover {
            background-color: #c82333;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>This is User Dashboard</h2>
            <asp:Label ID="lblWelcome" runat="server" Text=""></asp:Label>
            <br />
             <asp:Button ID="btnManageAccount" runat="server" Text="Manage Account" CssClass="btn" OnClick="BtnManageAccount_Click" />
            <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
        </div>
    </form>
</body>
</html>