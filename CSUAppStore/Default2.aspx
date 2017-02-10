<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="dropDownHolder">
        <asp:SqlDataSource ID="courseDataSource" runat="server" ConnectionString='<%$ ConnectionStrings:gameDbConnectionString %>' SelectCommand="SELECT [course], [id] FROM [Courses] ORDER BY [course]">
        </asp:SqlDataSource>
        <asp:DropDownList CssClass="dropDown btn btn-primary btn-lg" runat="server" ID="courseChoice" DataSourceID="courseDataSource" DataTextField="course" DataValueField="id" >
        </asp:DropDownList>

     <!--   <asp:SqlDataSource ID="GenreDataSource" runat="server" ConnectionString='<%$ ConnectionStrings:gameDbConnectionString %>' SelectCommand="SELECT [id], [genre] FROM [Genres] ORDER BY [genre]">
        </asp:SqlDataSource>
        <asp:DropDownList CssClass="dropDown btn btn-primary btn-lg" runat="server" ID="genreChoice" DataSourceID="GenreDataSource" DataTextField="genre" DataValueField="id" AutoPostBack="True">
        </asp:DropDownList>
    -->
        <asp:SqlDataSource ID="platformDataSource" runat="server" ConnectionString='<%$ ConnectionStrings:gameDbConnectionString %>' SelectCommand="SELECT [platform], [id] FROM [Platforms] ORDER BY [platform]"></asp:SqlDataSource>
        <asp:DropDownList CssClass="dropDown btn btn-primary btn-lg" runat="server" ID="platformChoice" DataSourceID="platformDataSource" DataTextField="platform" DataValueField="id">
         </asp:DropDownList>

        <asp:SqlDataSource ID="yearDataSource" runat="server" ConnectionString='<%$ ConnectionStrings:gameDbConnectionString %>' SelectCommand="SELECT DISTINCT [yr] FROM [Games]"></asp:SqlDataSource>
        <asp:DropDownList ID="yearChoice" CssClass="dropDown btn btn-primary btn-lg" runat="server" DataSourceID="yearDataSource" DataTextField="yr" DataValueField="yr">
        </asp:DropDownList>

        <asp:Button CssClass="btn btn-primary btn-lg dropDown" runat="server" Text="Search" OnClick="search" />
    </div>

    <!--           <asp:ControlParameter ControlID="courseChoice"  Name="course" PropertyName="SelectedValue" />
  -->

    <asp:SqlDataSource ID="gameTableDataSource" runat="server" ConnectionString='<%$ ConnectionStrings:gameDbConnectionString %>'>
        <SelectParameters>
            <asp:ControlParameter ControlID="courseChoice"  Name="course" PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="platformChoice"  Name="platform" PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="yearChoice"  Name="yr" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:DataList ID="gameTable" runat="server" DataSourceID="gameTableDataSource" RepeatColumns="4" CssClass="gameTable">
         <ItemTemplate>
             <table>
                 <tr>
                     <td class="gameTdArea">
                        <div>
                            <asp:Image src='<%# Eval("icon") %>' runat="server" CssClass="gameIcon" ID="iconLabel" /><br />
                            <asp:Label Text='<%# Eval("gameName") %>' runat="server" CssClass="gameIconName" ID="gameNameLabel" /><br />
                        </div>
                    </td>
                </tr>
           </table>
        </ItemTemplate>
    </asp:DataList>

</asp:Content>

