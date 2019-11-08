<%@ Page Title="" Language="C#" MasterPageFile="~/TestorCore.Master" AutoEventWireup="true"
    CodeBehind="404.aspx.cs" Inherits="CoreWebClient.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <span style="font-size: 38pt;">404</span>
    <h1>
        Секретный уровень</h1>
    <p>
        Вы попали на секретный уровень Тестора.</p>
    <p style="margin-bottom: 0">
        Как попасть сюда еще раз:</p>
    <ul style="margin-top: 0">
        <li>ввести часть адреса русскими буквами, например: <b>иуеф</b>.yandex.ru вместо <b>
            beta</b>.testor.ru</li>
        <li>или написать особенное имя файла, например: i<b>ne</b>x.html, i<b>dn</b>ex.html
            или index.<b>htm</b> вместо index.html</li>
    </ul>
    <a href="http://terms.yandex.ru/?id=263">Что такое страница 404/403?</a>
</asp:Content>
