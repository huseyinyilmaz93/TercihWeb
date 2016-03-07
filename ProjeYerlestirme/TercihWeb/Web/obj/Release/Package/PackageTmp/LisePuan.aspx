<%@ Page Title="" Language="C#" MasterPageFile="~/Main2.Master" AutoEventWireup="true" CodeBehind="LisePuan.aspx.cs" Inherits="Web.LisePuan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/css/LisePuan.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style4 {
            width: 272px;
        }
        .auto-style6 {
            width: 71px;
        }
        .auto-style8 {
            height: 48px;
            text-align: left;
        }
        .auto-style9 {
            height: 47px;
            text-align: left;
        }
        .auto-style3 {
            height: 30px;
            text-align: left;
        }
        .auto-style2 {
            width: 106px;
        }
        .auto-style1 {
            height: 30px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="OrtakAlan" runat="server">
    <form runat="server" method="post">
        <h3 style="text-align:center">&nbsp;</h3>
        <h3 style="text-align:center">Lise yerleşme puanlarını bulabileceğiniz sayfamıza hoşgeldiniz </h3>
        <h3 style="text-align:center">Arama yapmak için aşağıdaki seçenekleri kullanabilirsiniz ...</h3>
        
        <br />
        <table>
            <tr>
                <th colspan ="4" class="auto-style9"> Yerleşim Yeri </th>
            </tr>
            <tr>
                <td class="auto-style6">İl : </td> <td class="auto-style4"> &nbsp;<asp:DropDownList ID="ddl_il" Width="250px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_il_SelectedIndexChanged"></asp:DropDownList> &nbsp;</td>
                <td class="auto-style6">İlçe : </td> <td> <asp:DropDownList ID="ddl_ilce" Width="250px" runat="server"></asp:DropDownList> </td>
            </tr>
            </table>
        <table>
            <tr>
                <th colspan="2" class="auto-style3">Lise Türü</th> 
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style1"><asp:CheckBoxList ID="chxl_liseTuru" runat="server"></asp:CheckBoxList></td>
            </tr>
        </table>
        
            <table>
            <tr>
                <th colspan ="4" class="auto-style8"> Puan Aralığı </th>
            </tr>
            <tr>
                <td class="auto-style6">Alt Sınır : </td> 
                <td class="auto-style4"> <asp:TextBox Width="245px" ID="txt_altSinir" runat="server"></asp:TextBox></td> 
                <td colspan ="2" rowspan="2">
                    <asp:Button CssClass="myButton" ID="btn_ara" runat="server" Text="Ara" Height="45px" OnClick="btn_ara_Click" Width="323px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Üst Sınır  : </td> 
                <td class="auto-style4"> <asp:TextBox Width="245px" ID="txt_ustSinir" runat="server"></asp:TextBox> </td>
            </tr>
        </table>
        
        <br />
        
&nbsp;<br />
&nbsp;<asp:GridView Width="100%" ID="grd_lise" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" AllowPaging="True" PageSize="25" OnPageIndexChanging="grd_lise_PageIndexChanging">
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#CCCC99" />
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
