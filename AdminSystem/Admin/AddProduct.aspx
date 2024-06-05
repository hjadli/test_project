<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddProduct.aspx.cs" Inherits="AddProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Add New Product</h2>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        <table>
            <tr>
                <td>Product Name:</td>
                <td><asp:TextBox ID="txtProductName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Product Description:</td>
                <td><asp:TextBox ID="txtProductDescription" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Price:</td>
                <td><asp:TextBox ID="txtPrice" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Stock:</td>
                <td><asp:TextBox ID="txtStock" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Category ID:</td>
                <td><asp:TextBox ID="txtCategoryId" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Supplier ID:</td>
                <td><asp:TextBox ID="txtSupplierId" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnAddProduct" runat="server" Text="Add Product" OnClick="btnAddProduct_Click" /></td>
            </tr>
        </table>
    </div>
</form>
</body>
</html>
