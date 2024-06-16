<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="Prac_3Ex.PracticalDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            <br />

            <asp:DataList ID="DataList1" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
                <AlternatingItemStyle BackColor="#F7F7F7" />
                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                <ItemStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                <ItemTemplate>
                    <b>Product ID:</b> <asp:Label Text='<%# Eval("ProductId") %>' runat="server" /><br />
                    <b>Product Name:</b> <asp:Label Text='<%# Eval("ProductName") %>' runat="server" /><br />
                    <b>Product Description:</b> <asp:Label Text='<%# Eval("ProductDescription") %>' runat="server" /><br />
                    <b>Unit Price:</b> <asp:Label Text='<%# Eval("UnitPrice") %>' runat="server" /><br />
                    <hr />
                </ItemTemplate>
                <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />

            </asp:DataList>
            <br />
            <asp:Button ID="btnSubmitDataList" runat="server" Text="Submit" OnClick="btnSubmitDataList_Click" />
            <br />
            <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px">
                <Fields>
                    <asp:BoundField DataField="ProductId" HeaderText="Product ID" ReadOnly="True" />
                    <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                    <asp:BoundField DataField="ProductDescription" HeaderText="Product Description" />
                    <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" />
                </Fields>
            </asp:DetailsView>
            <br />
            <asp:Button ID="btnDetailsView" runat="server" Text="Submit" />
            <br />
            <asp:FormView ID="FormView1" runat="server">
                <ItemTemplate>
                    <table>
                        <tr>
                            <td><b>Product ID:</b></td>
                            <td><%# Eval("ProductId") %></td>
                        </tr>
                        <tr>
                            <td><b>Product Name:</b></td>
                            <td><%# Eval("ProductName") %></td>
                        </tr>
                        <tr>
                            <td><b>Product Description:</b></td>
                            <td><%# Eval("ProductDescription") %></td>
                        </tr>
                        <tr>
                            <td><b>Unit Price:</b></td>
                            <td><%# Eval("UnitPrice") %></td>
                        </tr>
                    </table>
                </ItemTemplate>
                <EmptyDataTemplate>
                    No data available.
                </EmptyDataTemplate>
            </asp:FormView>
            <br />
            <asp:Button ID="btnSubmitFromView" runat="server" Text="Submit" />
            <br />
            <asp:ListView ID="ListView1" runat="server">
                <LayoutTemplate>
                    <table>
                        <tr>
                            <th>Product ID</th>
                            <th>Product Name</th>
                            <th>Product Description</th>
                            <th>Unit Price</th>
                        </tr>
                        <tr id="itemPlaceholder" runat="server"></tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("ProductId") %></td>
                        <td><%# Eval("ProductName") %></td>
                        <td><%# Eval("ProductDescription") %></td>
                        <td><%# Eval("UnitPrice") %></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <br />

            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div style="border: 1px solid #ccc; margin-bottom: 10px; padding: 10px;">
                        <b>Product ID:</b> <%# Eval("ProductId") %><br />
                        <b>Product Name:</b> <%# Eval("ProductName") %><br />
                        <b>Product Description:</b> <%# Eval("ProductDescription") %><br />
                        <b>Unit Price:</b> <%# Eval("UnitPrice") %><br />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <br />

            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="btnSubmitListView" runat="server" Text="Submit" />
        </div>
    </form>
</body>
</html>
