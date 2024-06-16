<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LINQOddNumbers.aspx.cs" Inherits="Prac_3Ex.LINQOddNumbers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center>
                 <h3>
                     <asp:Label ID="Label1" runat="server" Text="Find Odd Numbers from Array"></asp:Label>
                 </h3>
               
        </center>
        <asp:Label ID="Label2" runat="server" Text="Input Data:"></asp:Label>
       
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       
        <asp:Label ID="lblInputData" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Display Odd Numbers"></asp:Label>
        <asp:Label ID="lblOdd" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
