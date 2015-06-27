<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="Kainos_konkurs.search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
     <table align="center">
        <tr>
            <td>Gatunek:</td>
            <td>
                <asp:DropDownList ID="DropDownListGenre" runat="server" Height="20px" Width="125px">
                    <asp:ListItem Value="All">All</asp:ListItem>
                    <asp:ListItem>Drama</asp:ListItem>
                    <asp:ListItem>Comedy</asp:ListItem>
                    <asp:ListItem>Thriller</asp:ListItem>
                    <asp:ListItem>Action</asp:ListItem>
                    <asp:ListItem>Documentary</asp:ListItem>
                    <asp:ListItem>Romance</asp:ListItem>
                    <asp:ListItem>Foreign</asp:ListItem>
                    <asp:ListItem>Horror</asp:ListItem>
                    <asp:ListItem>Family</asp:ListItem>
                    <asp:ListItem>Animation</asp:ListItem>
                    <asp:ListItem>Music</asp:ListItem>
                    <asp:ListItem>Science Fiction</asp:ListItem>
                    <asp:ListItem>Adventure</asp:ListItem>
                    <asp:ListItem>Crime</asp:ListItem>
                    <asp:ListItem>Fantasy</asp:ListItem>
                    <asp:ListItem>Mystery</asp:ListItem>
                    <asp:ListItem>History</asp:ListItem>
                    <asp:ListItem>War</asp:ListItem>
                    <asp:ListItem>TV Movie</asp:ListItem>
                    <asp:ListItem>Western</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td rowspan="2"><asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Szukaj" Width="81px" /></td>
        </tr>
            <td>Min. ocena:</td>
            <td><asp:TextBox ID="TextBoxScore" runat="server" Height="20px" Width="125px"></asp:TextBox></td>
    </table>
             
    <br />

<asp:Table ID="Table1" runat="server" Font-Size="Medium" GridLines="Both" HorizontalAlign="Center">
</asp:Table>
</asp:Content>
