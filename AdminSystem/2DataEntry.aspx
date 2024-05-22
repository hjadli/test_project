<%@ Page Language="C#" AutoEventWireup="true" CodeFile="2DataEntry.aspx.cs" Inherits="_1_DataEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
       <form id="form1" runat="server">
        <div>
            <h2>Add New Product</h2>
            <table>
                <tr>
                    <td>Product Name:</td>
                    <td><asp:TextBox ID="txtProductName" runat="server" /></td>
                </tr>
                <tr>
                    <td>Description:</td>
                    <td><asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="5" Columns="40" /></td>
                </tr>
                <tr>
                    <td>Price:</td>
                    <td><asp:TextBox ID="txtPrice" runat="server" /></td>
                </tr>
                <tr>
                    <td>Stock:</td>
                    <td><asp:TextBox ID="txtStock" runat="server" /></td>
                </tr>
                <tr>
                    <td>Category:</td>
                    <td>
                        <asp:DropDownList ID="ddlCategory" runat="server">
                            <asp:ListItem Text="Select Category" Value="" />
                            <asp:ListItem Text="1" Value="1" /> 
                            <asp:ListItem Text="2" Value="2" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Supplier:</td>
                    <td>
                        <asp:DropDownList ID="ddlSupplier" runat="server">
                            <asp:ListItem Text="Select Supplier" Value="" />
                            <asp:ListItem Text="1" Value="1" />
                            <asp:ListItem Text="2" Value="2" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button ID="btnSubmit" runat="server" Text="Add Product" OnClick="btnSubmit_Click" /></td>
                </tr>
            </table>
        </div>
    </form>

</body>
</html>
