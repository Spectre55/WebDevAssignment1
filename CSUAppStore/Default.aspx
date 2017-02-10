<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:SqlDataSource ID="Choices" runat="server" ConnectionString='<%$ ConnectionStrings:gameDbConnectionString %>' SelectCommand="displayChoice" SelectCommandType="StoredProcedure">
 
    </asp:SqlDataSource>

    <asp:DropDownList runat="server" ID="courseChoice">

    </asp:DropDownList>

     <asp:DropDownList runat="server" ID="genreChoice">

    </asp:DropDownList>
     <asp:DropDownList runat="server" ID="platformChoice">

    </asp:DropDownList>
     <asp:DropDownList runat="server" ID="yearChoice">

    </asp:DropDownList>
   
    <asp:DataList ID="DataList1" runat="server"></asp:DataList>
</asp:Content>

