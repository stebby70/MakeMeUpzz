<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="OrderQueue.aspx.cs" Inherits="MakeMeUpzz.View.OrderQueue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Order Queue</h1>
    </div>
    <div>
        <h2>Unhandled Transaction</h2>
    </div>
    <div>
    <asp:GridView ID="HeaderUnhandled" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
            <asp:BoundField DataField="UserID" HeaderText="User ID" SortExpression="UserID" />
            <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" />
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button ID="handleQueuebtn" runat="server" Text="Handle Queue" CommandName="HandleQueue" CommandArgument='<%# Eval("TransactionID") %>' OnClick="handleQueuebtn_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    </div>

    <div>
        <h2>Handled Transaction</h2>
    </div>
    <div>
        <asp:GridView ID="HeaderHandled" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
        <asp:BoundField DataField="UserID" HeaderText="User ID" SortExpression="UserID" />
        <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" />
        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
    </Columns>
</asp:GridView>
    </div>
</asp:Content>
