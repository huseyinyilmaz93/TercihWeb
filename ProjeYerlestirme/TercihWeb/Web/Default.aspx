<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/css/Default.css" rel="stylesheet" />
    <script src="Content/js/Default.js"></script>
    <style type="text/css">
        .auto-style1 {
            height: 32px;
        }
    </style>
    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
            m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-69279162-1', 'auto');
        ga('send', 'pageview');
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="OrtakAlan" runat="server">
    <h3 style="text-align:center"> &nbsp;</h3>
    <h3 style="text-align:center"> Sayfamıza hoşgeldiniz .. </h3>
    <p style="text-align:center"> &nbsp;</p>
    <p> &nbsp;&nbsp;&nbsp;&nbsp; Üniversite ve lise kayıt dönemlerinde öğrencilerin en büyük problemleri, en uygun okulların bulunmasıdır. Eğitime aktif olarak devam eden ve öğrenci alan eiğitim kurumlarına ait sınav puanlarını görüntüleyebilirsiniz. </p>
    <p> &nbsp;&nbsp;&nbsp;&nbsp; Ayrıca güncel üniversite sınavları (LYS/YGS) ve lise giriş sınavı(TEOG) puan hesaplama modülümüze ulaşabilirsiniz ..</p>
    <p> &nbsp;</p>
    <table>
        <tr>
            <th colspan="2" class="auto-style1">İlgili Linkler</th>
        </tr>
        <tr>
            <td>
                <input onclick="btn_uniPuanClick()" class="myButton" id="btn_uniPuan" type="button" value="Üniversite Taban Puanları" /></td>
            <td>
                <input onclick="btn_uniPuanHesaplamaClick()" class="myButton" id="btn_uniPuanHesaplama" type="button" value="Üniversite Puan Hesaplama" /></td>
        </tr>
        <tr>
            <td>
                <input onclick="btn_lisePuanClick()" class="myButton" id="btn_lisePuan" type="button" value="Lise Taban Puanları" /></td>
            <td>
                <input onclick="btn_lisePuanHesaplamaClick()" class="myButton" id="btn_lisePuanHesaplama" type="button" value="Lise Puan Hesaplama" /></td>
        </tr>

    </table>
    <br />
</asp:Content>
