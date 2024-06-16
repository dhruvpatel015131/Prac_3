<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerConnectedArchitecture.aspx.cs" Inherits="Prac_3Ex.CustomerConnectedArchitecture" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center>
                <h3> <asp:Label ID="Label1" runat="server" Text="Customer Information Connected Architecture"></asp:Label></h3>
            </center>
            <asp:Label ID="Label2" runat="server" Text="Enter Customer Id:"></asp:Label>
            <asp:TextBox ID="txtID" runat="server" style="margin-left: 42px"></asp:TextBox>
           <br />
             <asp:Label ID="Label3" runat="server" Text="Enter Customer Name:"></asp:Label>
            <asp:TextBox ID="txtName" runat="server" style="margin-left: 16px"></asp:TextBox>
           <br />
            <asp:Label ID="Label4" runat="server" Text="Enter Customer Address:"></asp:Label>
            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
           <br />
            <asp:GridView ID="GVCustomer" runat="server"></asp:GridView>
            <br />
            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            <asp:Button ID="btnSort" runat="server" Text="Sort" OnClick="btnSort_Click" />
            <asp:TextBox ID="txtDisplay" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
