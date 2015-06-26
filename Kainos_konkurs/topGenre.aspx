<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="topGenre.aspx.cs" Inherits="Kainos_konkurs.topGenre" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Chart ID="Chart1" runat="server" Height="750px" Width="1000px" Palette="Pastel" ImageLocation="~/tempImages/ChartPic_#SEQ(300,3)">
        <series>
            <asp:Series ChartType="Pie" Name="Series1" CustomProperties="PieLineColor=ActiveBorder, PieLabelStyle=Outside" Font="Myriad Pro, 10pt" Label="#VALX #PERCENT">
                <SmartLabelStyle AllowOutsidePlotArea="Yes" MaxMovingDistance="100" MinMovingDistance="50" />
            </asp:Series>
        </series>
        <chartareas>
            <asp:ChartArea Name="ChartArea1" AlignmentOrientation="All" >
            </asp:ChartArea>
        </chartareas>
    </asp:Chart>
</asp:Content>
