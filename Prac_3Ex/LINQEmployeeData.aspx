<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LINQEmployeeData.aspx.cs" Inherits="Prac_3Ex.LINQEmployeeData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <center>
                <h3> <asp:Label ID="Label1" runat="server" Text="Employee Information Using LINQ"></asp:Label></h3>
            </center>
            <asp:Label ID="Label2" runat="server" Text="Enter Employee Id:"></asp:Label>
            <asp:TextBox ID="txtID" runat="server" style="margin-left: 58px"></asp:TextBox>
           <br />
             <asp:Label ID="Label3" runat="server" Text="Enter Employee Name:"></asp:Label>
            <asp:TextBox ID="txtName" runat="server" style="margin-left: 33px"></asp:TextBox>
           <br />
            <asp:Label ID="Label5" runat="server" Text="Enter Employee Designation"></asp:Label>
            <asp:TextBox ID="txtDesignation" runat="server"></asp:TextBox>
           <br />
            <asp:Label ID="Label4" runat="server" Text="Enter Employee Salary"></asp:Label>
            <asp:TextBox ID="txtSalary" runat="server" style="margin-left: 36px"></asp:TextBox>
           <br />
            <asp:GridView ID="GVEmployee" runat="server"></asp:GridView>
            <br />
            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"   />
            <asp:TextBox ID="txtDisplay" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
