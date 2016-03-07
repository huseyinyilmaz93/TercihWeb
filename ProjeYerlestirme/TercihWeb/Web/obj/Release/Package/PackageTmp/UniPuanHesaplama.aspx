<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="UniPuanHesaplama.aspx.cs" Inherits="Web.UniPuanHesaplama" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/css/UniPuanHesaplama.css" rel="stylesheet" />
    <script src="Content/js/UniPuanHesaplama.js"></script>
    <style type="text/css">
        #Button1 {
            width: 291px;
        }
        #btn_hesapla {
            width: 170px;
        }
        .auto-style1 {
            height: 28px;
        }
        .auto-style2 {
            width: 166px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="OrtakAlan" runat="server">
    <form id="form1" runat="server">
    <br /> <h3 class="description"> Üniversite giriş puanı hesaplama sayfamıza hoşgeldiniz ... <br /> Arama seçeneklerini girerek aramanızı gerçekleştirebilirsiniz ...</h3>
        
        <br />
        <table>
            <tr>
                <td class="auto-style1"><asp:Label ID="lbl_okulPuani" CssClass="lbl" runat="server" Text="Öğrenci Okul Puanı (250-500) : "></asp:Label></td>
                <td class="auto-style1"> <input onchange="OkulPuaniChanged()" maxlength="3" id="txt_okulPuani" type="text" /> </td>
            </tr>
            <tr>
                <td colspan="2"><h5>* Buraya girilen puan seneden seneye farklılık gösterebilmektedir.</h5></td>
            </tr>
        </table>
        <table style="width: 342px">
            <thead>
                <tr><th class="auto-style2"> <asp:Label ID="lbl_ygsPuan" runat="server" Text="YGS Puan Hesaplama"></asp:Label></th> </tr> 
                <tr> <th class="auto-style2">Ders Adı</th> <th>Doğru</th><th>Yanlış</th><th>Net</th></tr>
            </thead>
            <tbody>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lbl_turkce" runat="server" Text="Türkçe (40) "></asp:Label>
                </td>
                <td class="description">
                    <input onchange="TurkceChanged()" id="txt_turkceDogru" class="textboxes" maxlength="2" type="text" />
                </td>
                <td class="description">
                    <input onchange="TurkceChanged()" id="txt_turkceYanlis" class="textboxes" maxlength="2" type="text" />
                </td>
                <td class="description">
                    <input onchange="TurkceNet(40)" id="txt_turkceNet" class="textboxes" maxlength="2" type="text" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2"><asp:Label ID="lbl_matematik" runat="server" Text="Matematik (40)  "></asp:Label></td>
                <td class="description">
                    <input onchange="MatematikChanged()" id="txt_matematikDogru" class="textboxes" maxlength="2" type="text" />
                </td>
                <td class="description">
                    <input onchange="MatematikChanged()" id="txt_matematikYanlis" class="textboxes" maxlength="2" type="text" />
                </td>
                <td class="description">
                    <input onchange="MatematikNet(40)" id="txt_matematikNet" class="textboxes" maxlength="2" type="text" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2"><asp:Label ID="lbl_sosyal" runat="server" Text="Sosyal (40)  "></asp:Label></td>
                <td class="description">
                    <input onchange="SosyalChanged()" id="txt_sosyalDogru" class="textboxes" maxlength="2" type="text" />
                </td>
                <td class="description">
                    <input onchange="SosyalChanged()" id="txt_sosyalYanlis" class="textboxes" maxlength="2" type="text" />
                </td>
                <td class="description">
                    <input id="txt_sosyalNet" onchange="SosyalNet(40)" class="textboxes" maxlength="2" type="text" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                     <asp:Label ID="lbl_fen" runat="server" Text="Fen (40) "></asp:Label>

                </td>
                <td class="description">
                    <input onchange="FenChanged()" id="txt_fenDogru" class="textboxes" maxlength="2" type="text" />
                </td>
                <td class="description">
                    <input onchange="FenChanged()" id="txt_fenYanlis" class="textboxes" maxlength="2" type="text" />
                </td>
                <td class="description">
                    <input onchange="FenNet(40)" id="txt_fenNet" class="textboxes" maxlength="2" type="text" />
                </td>
            </tr>
            </tbody>
        </table>
        <br />
        <table>
            <thead>
            <tr>
                <th>LYS Puan Hesaplama</th>
            </tr>
            <tr>
                <th>Ders Adı</th><th>Doğru</th><th>Yanlış</th><th>Net</th>
            </tr>
            </thead>
            <tbody>
                <tr>
                <td>
                     <asp:Label ID="lbl_mat2" runat="server" Text="Matematik (50) "></asp:Label>

                </td>
                <td class="description">
                    <input onchange="Mat2Changed()" id="txt_mat2Dogru" class="textboxes" maxlength="2" type="text" />
                </td>
                <td class="description">
                    <input onchange="Mat2Changed()" id="txt_mat2Yanlis" class="textboxes" maxlength="2" type="text" />
                </td>
                <td class="description">
                    <input onchange="Mat2Net(50)" id="txt_mat2Net" class="textboxes" maxlength="2" type="text" />
                </td>
            </tr>
                <tr>
                <td>
                     <asp:Label ID="lbl_geometri" runat="server" Text="Geometri (30) "></asp:Label>
                </td>
                <td class="description">
                    <input onchange="GeometriChanged()" id="txt_geometriDogru" class="textboxes" maxlength="2" type="text" />
                </td>
                <td class="description">
                    <input onchange="GeometriChanged()" id="txt_geometriYanlis" class="textboxes" maxlength="2" type="text" />
                </td>
                <td class="description">
                    <input onchange="GeometriNet(30)" id="txt_geometriNet" class="textboxes" maxlength="2" type="text" />
                </td>
            </tr>
                <tr>
	        <td>
        	        <asp:Label ID="lbl_fizik" runat="server" Text="Fizik (30) "></asp:Label>
                </td>
                <td class="description">
                    <input onchange="FizikChanged()" id="txt_fizikDogru" class="textboxes" maxlength="2" type="text" />
                </td>
                <td class="description">
                    <input onchange="FizikChanged()" id="txt_fizikYanlis" class="textboxes" maxlength="2" type="text" />
                </td>
                <td class="description">
                    <input onchange="FizikNet(30)" id="txt_fizikNet" class="textboxes" maxlength="2" type="text" />
                </td>
                </tr>
	        <tr>
		        <td>
        		        <asp:Label ID="lbl_kimya" runat="server" Text="Kimya (30) "></asp:Label>
	                </td>
	                <td class="description">
                    <input onchange="KimyaChanged()" id="txt_kimyaDogru" class="textboxes" maxlength="2" type="text" />
                </td>
                <td class="description">
                    <input onchange="KimyaChanged()" id="txt_kimyaYanlis" class="textboxes" maxlength="2" type="text" />
                </td>
                <td class="description">
                    <input onchange="KimyaNet(30)" id="txt_kimyaNet" class="textboxes" maxlength="2" type="text" />
                </td>
	        </tr>
	        <tr>
		        <td>
        		        <asp:Label ID="lbl_biyoloji" runat="server" Text="Biyoloji (30) "></asp:Label>
	                </td>
	                <td class="description">
                    <input onchange="BiyolojiChanged()" id="txt_biyolojiDogru" class="textboxes" maxlength="2" type="text" />
                </td>
                <td class="description">
                    <input onchange="BiyolojiChanged()" id="txt_biyolojiYanlis" class="textboxes" maxlength="2" type="text" />
                </td>
                <td class="description">
                    <input onchange="BiyolojiNet(30)" id="txt_biyolojiNet" class="textboxes" maxlength="2" type="text" />
                </td>
	        </tr>
	        <tr>
		        <td>
        		        <asp:Label ID="lbl_edebiyat" runat="server" Text="Türk Dili ve Edb. (56) "></asp:Label>
        	        </td>
        	        <td class="description">
                    <input onchange="EdebiyatChanged()" id="txt_edebiyatDogru" class="textboxes" maxlength="2" type="text" />
                </td>
                <td class="description">
                    <input onchange="EdebiyatChanged()" id="txt_edebiyatYanlis" class="textboxes" maxlength="2" type="text" />
                </td>
                <td class="description">
                    <input onchange="EdebiyatNet(56)" id="txt_edebiyatNet" class="textboxes" maxlength="2" type="text" />
                </td>
	        </tr>
	        <tr>
		        <td>
        		        <asp:Label ID="lbl_cografya1" runat="server" Text="Coğrafya 1 (24) "></asp:Label>
        	        </td>
        	        <td class="description">
                    <input onchange="Cografya1Changed()" id="txt_cografya1Dogru" class="textboxes" maxlength="2" type="text" />
                </td>
                <td class="description">
                    <input onchange="Cografya1Changed()" id="txt_cografya1Yanlis" class="textboxes" maxlength="2" type="text" />
                </td>
                <td class="description">
                    <input onchange="Cografya1Net(24)" id="txt_cografya1Net" class="textboxes" maxlength="2" type="text" />
                </td>
	        </tr>
	        <tr>
		        <td>
        		        <asp:Label ID="lbl_tarih" runat="server" Text="Tarih (44) "></asp:Label>
        	        </td>
        	        <td class="description">
                    <input onchange="TarihChanged()" id="txt_tarihDogru" class="textboxes" maxlength="2" type="text" />
                </td>
                <td class="description">
                    <input onchange="TarihChanged()" id="txt_tarihYanlis" class="textboxes" maxlength="2" type="text" />
                </td>
                <td class="description">
                    <input  onchange="TarihNet(44)"id="txt_tarihNet" class="textboxes" maxlength="2" type="text" />
                </td>
	        </tr>
	        <tr>
		        <td>
        		        <asp:Label ID="lbl_cografya2" runat="server" Text="Coğrafya 2 (16) "></asp:Label>
        	        </td>
        	        <td class="description">
                    <input onchange="Cografya2Changed()" id="txt_cografya2Dogru" class="textboxes" maxlength="2" type="text" />
                </td>
                <td class="description">
                    <input onchange="Cografya2Changed()" id="txt_cografya2Yanlis" class="textboxes" maxlength="2" type="text" />
                </td>
                <td class="description">
                    <input onchange="Cografya2Net(16)" id="txt_cografya2Net" class="textboxes" maxlength="2" type="text" />
                </td>
	        </tr>
	        <tr>
		        <td>
        		        <asp:Label ID="lbl_felsefe" runat="server" Text="Felsefe (30) "></asp:Label>
        	        </td>
        	        <td class="description">
                    <input onchange="FelsefeChanged()" id="txt_felsefeDogru" class="textboxes" maxlength="2" type="text" />
                </td>
                <td class="description">
                    <input onchange="FelsefeChanged()" id="txt_felsefeYanlis" class="textboxes" maxlength="2" type="text" />
                </td>
                <td class="description">
                    <input onchange="FelsefeNet(30)" id="txt_felsefeNet" class="textboxes" maxlength="2" type="text" />
                </td>
	        </tr>
	        <tr>
		        <td>
        		        <asp:Label ID="lbl_dil" runat="server" Text="Dil (80) "></asp:Label>
        	        </td>
        	        <td class="description">
                    <input onchange="DilChanged()" id="txt_dilDogru" class="textboxes" maxlength="2" type="text" />
                </td>
                <td class="description">
                    <input onchange="DilChanged()" id="txt_dilYanlis" class="textboxes" maxlength="2" type="text" />
                </td>
                <td class="description">
                    <input onchange="DilNet(80)" id="txt_dilNet" class="textboxes" maxlength="2" type="text" />
                </td>
	        </tr>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="4"> &nbsp; </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <input id="btn_temizle" class="myButton" onclick="Temizle()" type="button" value="Temizle" /> 
                        <input id="btn_hesapla" class="myButton" onclick="Hesapla()" type="button" value="Hesapla" /> 
                    </td>
                </tr>
            </tfoot>
        </table>
        <br />
        <div id="Puanlar">
            
        </div>
        <br />

    </form>

</asp:Content>
