<%@ Page Title="" Language="C#" MasterPageFile="~/TestorCore.Master" AutoEventWireup="true" CodeBehind="Appeal.aspx.cs" Inherits="CoreWebClient.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%--<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />--%>
    <style type="text/css">
        .style1
        {
            width: 110px;
            vertical-align:middle;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server"> 
<table>
<tr><td class="style1"><b>Тест:</b></td><td><asp:Label runat="server" ID="lblTest" /></td></tr>
<tr><td class="style1"><b>Студент:</b></td><td><asp:Label runat="server" ID="lblUser" /></td></tr>
<tr><td class="style1"><b>Логин:</b></td><td><asp:Label runat="server" ID="lblLogin" /></td></tr>
<tr><td class="style1"><b>IP адрес:</b></td><td><asp:Label runat="server" ID="lblIPAddress" /></td></tr>
<tr><td class="style1"><b>Набранный Балл:</b></td><td><asp:Label runat="server" ID="lblScore" /><asp:TextBox runat="server" ID="txtScore" 
MaxLength="5" Width="50px" Visible="false" /><asp:Label runat="server" ID="scoreError" Visible="false" ForeColor="Red" Text="*" /><br />
<asp:LinkButton ID="lbChangeScore" runat="server" onclick="lbChangeScore_Click">Изменить</asp:LinkButton>&nbsp;<asp:LinkButton 
        ID="lbCancel" runat="server" Visible="false" onclick="lbCancel_Click">Отмена</asp:LinkButton></td></tr>
</table>  
<br />
<asp:Label runat="server" ID="lblAppeal" />
<asp:MultiView runat="server" ActiveViewIndex="0" ID="mvDelSession">
    <asp:View ID="View1" runat="server">
        <asp:LinkButton ID="lbDeleteSession" runat="server" 
            onclick="lbDeleteSession_Click">Удалить сессию</asp:LinkButton>
    </asp:View>
    <asp:View ID="View2" runat="server">
    <b>Вы действительно хотите удалить данную сессию?</b><br />
    <asp:LinkButton ID="lbDelYes" runat="server" onclick="lbDelYes_Click">Да</asp:LinkButton>&nbsp;&nbsp;&nbsp; 
        <asp:LinkButton ID="lbDelNo" runat="server" onclick="lbDelNo_Click">Нет</asp:LinkButton>
    </asp:View>
</asp:MultiView>

</asp:Content>
