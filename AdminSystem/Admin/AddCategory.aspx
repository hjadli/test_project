<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddCategory.aspx.cs" Inherits="AdminDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Admin Dashboard</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Add New Category</h1>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        <div>
            <label for="txtCategoryName">Category Name:</label>
            <asp:TextBox ID="txtCategoryName" runat="server"></asp:TextBox>
        </div>
        <div>
            <label for="txtCategoryDetails">Category Details:</label>
            <asp:TextBox ID="txtCategoryDetails" runat="server"></asp:TextBox>
        </div>
        <div>
            <label for="txtCategoryType">Category Type:</label>
            <asp:TextBox ID="txtCategoryType" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnAddCategory" runat="server" Text="Add Category" OnClick="btnAddCategory_Click" />
        </div>
    </div>
</form>
</body>
</html>
