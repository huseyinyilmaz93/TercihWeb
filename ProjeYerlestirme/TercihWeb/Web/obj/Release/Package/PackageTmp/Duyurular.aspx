<%@ Page Title="" Language="C#" MasterPageFile="~/Main2.Master" AutoEventWireup="true" CodeBehind="Duyurular.aspx.cs" Inherits="Web.Duyurular" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" onload="DuyuruYukle()">
    <link href="Content/css/Duyurular.css" rel="stylesheet" />
    <script src="Content/jquery%20Source/jquery-2.1.4.js"></script>
    <script src="Content/js/Duyurular.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="OrtakAlan" runat="server">
<form runat="server" method="post">
    <h3 style="text-align:center">&nbsp;</h3>
    <h3 style="text-align:center">Duyuru görüntüleme sayfamıza hoşgeldiniz .. </h3>
    <h3 style="text-align:center">Duyuru içeriğini görmek için duyuru başlıklarına tıklayınız .. </h3>
    <p style="text-align:center">&nbsp;</p>
    <div id="duyuru">
    </div>
</form>

</asp:Content>
