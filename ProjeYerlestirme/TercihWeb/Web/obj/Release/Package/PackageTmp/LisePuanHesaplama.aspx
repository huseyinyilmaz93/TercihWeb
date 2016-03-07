<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="LisePuanHesaplama.aspx.cs" Inherits="Web.LisePuanHesaplama" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/css/LisePuanHesaplama.css" rel="stylesheet" />
    <script src="Content/js/LisePuanHesaplama.js"></script>
    <style type="text/css">
        .auto-style1 {
            width: 165px;
        }
        .auto-style2 {
            width: 165px;
            height: 26px;
        }
        .auto-style3 {
            text-align: center;
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="OrtakAlan" runat="server">
    <form id="form1" runat="server">
        <h3 class="description">&nbsp;</h3>
        <h3 class="description">Lise giriş puanı hesaplama sayfamıza hoşgeldiniz ... </h3>
        <h3 class="description">Arama seçeneklerini girerek aramanızı gerçekleştirebilirsiniz ...</h3>

        <br />

        <table style="width: 340px">
            <thead>
                <tr>
                    <th colspan="3">   <label for="yilsonu_basari_puani">Yılsonu Başarı Puanı</label> </th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td class="auto-style2"><label for="sinif6">6.Sınıf</label></td> <td colspan="2" class="auto-style3"> <input class="textboxes" onchange="Sinif6Changed()" id="txt_sinif6" type="text" /></td>
                </tr>
                <tr>
                    <td class="auto-style1"><label for="sinif7">7.Sınıf</label></td> <td colspan="2" class="description"> <input class="textboxes" onchange="Sinif7Changed()" id="txt_sinif7" type="text" /></td>
                </tr>
                <tr>
                    <td class="auto-style1"><label for="sinif8">8.Sınıf (Tahmini) </label></td> <td  colspan="2" class="description"> <input class="textboxes" onchange="Sinif8Changed()" id="txt_sinif8" type="text" /></td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <th colspan="3"><label for="sinav_soru_sayilari"> Derslere Göre Doğru Cevap Sayıları </label></th>
                </tr>
                 <tr>
                    <td></td>
                </tr>
                <tr>
                    <th class="auto-style1"> <label for="ders_adi">Ders Adı</label> </th>  <th> <label for="donem1">1. Dönem</label>  </th>  <th> <label for="donem2">2. Dönem</label> </th> 
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr> 
                    <td class="auto-style1"> <label for="turkce"> Türkçe (20) </label> </td> <td class="description"> <input onchange="TurkceChanged()" class="textboxes" id="txt_turkce" type="text" /></td> <td class="description"> <input onchange="Turkce2Changed()"  class="textboxes" id="txt_turkce2" type="text" /></td> 
                </tr>
                <tr> 
                    <td class="auto-style1"> <label for="matematik"> Matematik (20) </label> </td> <td class="description"> <input onchange="MatematikChanged()"  class="textboxes" id="txt_matematik" type="text" /></td> <td class="description"> <input onchange="Matematik2Changed()" class="textboxes" id="txt_matematik2" type="text" /></td>
                </tr>
                <tr> 
                    <td class="auto-style1"> <label for="fen"> Fen ve Teknoloji (20) </label> </td> <td class="description"> <input onchange="FenChanged()" class="textboxes" id="txt_fen" type="text" /></td> <td class="description"> <input onchange="Fen2Changed()" class="textboxes" id="txt_fen2" type="text" /></td>
                </tr>
                <tr> 
                    <td class="auto-style1"> <label for="inkilap"> İnkılap Tarihi (20) </label> </td> <td class="description"> <input onchange="InkilapChanged()" class="textboxes" id="txt_inkilap" type="text" /></td> <td class="description"> <input onchange="Inkilap2Changed()" class="textboxes" id="txt_inkilap2" type="text" /></td>
                </tr>
                <tr> 
                    <td class="auto-style1"> <label for="yabanci_dil"> Yabancı Dil (20) </label> </td> <td class="description"> <input onchange="YabanciDilChanged()" class="textboxes" id="txt_yabanciDil" type="text" /></td> <td class="description"> <input onchange="YabanciDil2Changed()" class="textboxes" id="txt_yabanciDil2" type="text" /></td>
                </tr>
                <tr> 
                    <td class="auto-style1"> <label for="din"> Din Kültürü (20) </label> </td> <td class="description"> <input onchange="DinChanged()" class="textboxes" id="txt_din" type="text" /></td> <td class="description"> <input onchange="Din2Changed()" class="textboxes" id="txt_din2" type="text" /></td>
                </tr>
                <tr><td colspan="3"></td></tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td> <input class="myButton" onclick="Temizle()" id="btn_Temizle" type="button" value="Temizle" /></td><td colspan="2"> <input class="myButton" id="btn_hesapla" onclick="Hesapla()" type="button" value="Hesapla" /> </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
            </tbody>
        </table>
        <div id="Puanlar"></div>
    </form>
    <br />
</asp:Content>
