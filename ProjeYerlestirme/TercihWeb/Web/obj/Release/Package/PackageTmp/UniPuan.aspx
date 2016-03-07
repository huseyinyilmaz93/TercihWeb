<%@ Page Title="" Language="C#" MasterPageFile="~/Main2.Master" AutoEventWireup="true" CodeBehind="UniPuan.aspx.cs" Inherits="Web.UniPuan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/css/UniPuan.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            text-align: left;
        }
        .auto-style3 {
            width: 218px;
            height: 26px;
        }
        .auto-style4 {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="OrtakAlan" runat="server">
    
    <form id="form1" runat="server">
        <h3 style="text-align:center">&nbsp;</h3>
        <h3 style="text-align:center">Üniversite taban puanlarını bulabileceğiniz sayfamıza hoşgeldiniz ... </h3>
        <h3 style="text-align:center">Arama yapmak için aşağıdaki seçenekleri kullanabilirsiniz ...</h3>
        <p style="text-align:center">&nbsp;</p>
        <table class="auto-style1">
        <thead>
            <tr>
                <th colspan="2" class="auto-style2">Üniversiteye göre arama</th>
            </tr>
        </thead>
            <tr>
                <td>
        <asp:Label ID="lbl_uniAdi" runat="server" Text="Üniversite Adı : "></asp:Label></td>
                <td><asp:DropDownList ID="ddl_uniAdi" runat="server" Width="275px" OnSelectedIndexChanged="ddl_uniAdi_SelectedIndexChanged" AutoPostBack="True">
        </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="lbl_fakAdi" runat="server" Text="Fakülte Adı : "></asp:Label></td>
                <td><asp:DropDownList ID="ddl_fakAdi" runat="server" Width="275px" AutoPostBack="True" OnSelectedIndexChanged="ddl_fakAdi_SelectedIndexChanged">
        </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="lbl_bolAdi" runat="server" Text="Bölüm Adı : "></asp:Label></td>
                <td><asp:DropDownList ID="ddl_bolAdi" runat="server" Width="275px" AutoPostBack="True" OnSelectedIndexChanged="ddl_bolAdi_SelectedIndexChanged">
        </asp:DropDownList>
                </td>
            </tr>
        </table>
        <br />
        <table style="height: 55px; width: 586px">
            <tr>
                <th colspan="2" style="text-align: left">Bölüm adı ve puana göre arama</th>
            </tr>
            <tr>
               <td class="auto-style3"> <asp:Label ID="lbl_bolum" runat="server" Text="Bölüm Adı : "></asp:Label></td> 
                <td class="auto-style4">
                   <asp:TextBox ID="txt_bolum" runat="server" Width="275px" AutoPostBack="True" OnTextChanged="txt_bolum_TextChanged"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Alt Sınır : </td>  <td> <asp:TextBox ID="txt_altSinir" runat="server"> </asp:TextBox></td>
            </tr>
            <tr>
                <td>Üst Sınır : </td> <td> <asp:TextBox ID="txt_ustSinir" runat="server"> </asp:TextBox> </td>
            </tr>
            <tr>
                <td></td> 
                <td>
                    <asp:Button CssClass="myButton" ID="btnAra" runat="server" Text="Ara" OnClick="btnAra_Click" Width="288px" />
                </td>
            </tr>
        </table>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <br />
        <asp:GridView ID="grd_uni" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="100%" AllowPaging="True" OnPageIndexChanging="grd_uni_PageIndexChanging" PageSize="25">
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#CCCC99" BorderStyle="Solid" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
        <br />
    </form>
    
</asp:Content>
