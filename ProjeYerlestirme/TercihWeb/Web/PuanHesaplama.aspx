<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="PuanHesaplama.aspx.cs" Inherits="Web.PuanHesaplama" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/css/PuanHesaplama.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="OrtakAlan" runat="server">
    <form id="form1" runat="server">
        <h3 class="description"> &nbsp;</h3>
        <h3 class="description"> Puan hesaplama sayfalarımıza aşağıdaki butonlar yardımıyla ulaşabilirsiniz ... </h3><br />
        <br /> &nbsp;
        <asp:Button CssClass="myButton" ID="btn_uniPuan" runat="server" Text="Üniversite Puan Hesaplama" Width="252px" OnClick="btn_uniPuan_Click" />&nbsp;
        <asp:Button CssClass="myButton" ID="btn_lisePuan" runat="server" Text="Lise Puan Hesaplama" Width="252px" OnClick="btn_lisePuan_Click" />
        <br />
        <br />
&nbsp;</form>
</asp:Content>
