<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="HataBildir.aspx.cs" Inherits="Web.HataBildir" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/css/HataBildir.css" rel="stylesheet" />
    <script src="Content/js/HataBildir.js"></script>
    <style type="text/css">
        #Text1 {
            width: 160px;
        }
        #TextArea1 {
            height: 94px;
            width: 160px;
        }
        #txt_hataTanimi {
            width: 300px;
        }
        #txt_hataAciklama {
            width: 300px;
            margin-left: 0px;
            height: 44px;
        }
        .auto-style1 {
            width: 118px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="OrtakAlan" runat="server">
    <form runat="server" method="post">
        <h3 style="text-align:center">
            Hata bildirme sayfamıza hoşgeldiniz ..
        </h3>
        <h3 style="text-align:center">
            Lütfen bir sorunla karşılaştıysanız bize bildirin ..
        </h3>
        <p style="text-align:center">
            &nbsp;</p>
        <table>
            <tr class="center">
                <th class="auto-style1">Hata Tanımı : </th> <td> 
                <input id="txt_hataTanimi" type="text" /></td>
            </tr>
            <tr class="center">
                <th class="auto-style1">Açıklama : </th> <td> 
                <textarea id="txt_hataAciklama" name="S1"></textarea></td>
            </tr>
            <tr class="center">
                <td class="auto-style1">&nbsp;</td> <td> 
                <input onclick="GeriBildirim()" class="myButton" id="btn_gonder" type="button" value="Gönder" /></td>
            </tr>
        </table>

    </form>
</asp:Content>
