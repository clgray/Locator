<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TestingMenu.ascx.cs"
    Inherits="CoreWebClient.TestingMenu" %>
<ul id="menucontainer">
    <li>
        <img src="/Images/closed.gif" alt="closed" />&nbsp;<a href="/Default.aspx">Главная</a></li>
    <asp:PlaceHolder ID="PlaceHolderAdmin" runat="server" Visible="false">
        <li>
            <img src="/Images/closed.gif" alt="closed" />&nbsp;<a href="/Manage/Admin.aspx">Администрирование</a></li></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolderStat" runat="server" Visible="false">
        <li>
            <img src="/Images/closed.gif" alt="closed" />&nbsp;<a href="/Manage/Statistics.aspx">Статистика
                тестирования</a></li></asp:PlaceHolder>
    <asp:LoginView runat="server" ID="authPanel">
        <LoggedInTemplate>
            <li>
                <img src="/Images/closed.gif" alt="closed" />&nbsp;<a href="/Manage/PrivateOffice.aspx">Личный
                    кабинет</a></li>
            <li>
                <img src="/Images/closed.gif" alt="closed" />&nbsp;<asp:LinkButton runat="server"
                    Text="Выйти" OnClick="loginButton_Click" ValidationGroup="menuGroup" /></li>
        </LoggedInTemplate>
        <AnonymousTemplate>
            <li>
                <img src="/Images/closed.gif" alt="closed" />&nbsp;<asp:LinkButton runat="server"
                    Text="Войти" OnClick="loginButton_Click" ValidationGroup="menuGroup" /></li>
        </AnonymousTemplate>
    </asp:LoginView>
</ul>
