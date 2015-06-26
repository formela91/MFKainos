<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="Kainos_konkurs.search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
     <table align="center">
        <tr>
            <td>Gatunek:</td>
            <td><asp:TextBox ID="TextBoxGenre" runat="server"></asp:TextBox></td>
            <td rowspan="2"><asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Szukaj" Width="81px" /></td>
        </tr>
            <td>Min. ocena:</td>
            <td><asp:TextBox ID="TextBoxScore" runat="server"></asp:TextBox></td>
    </table>
             
    <br />
    <br />

<asp:Table ID="Table1" runat="server" Font-Size="Medium" GridLines="Both" HorizontalAlign="Center">
</asp:Table>
</asp:Content>
