<%@ Page Title="" Language="C#" MasterPageFile="~/TestorCore.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="CoreWebClient.WebForm1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Expires" content="0" />
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-cache" />

    <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" src="js/jquery.autocomplete.js"></script>

    <link type="text/css" href="js/css/jquery.autocomplete.css" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="Server">
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <asp:Panel ID="PanelLoginContent" runat="server" Height="261px">
                <p style="text-align: justify">
                    Ваша авторизация необходима исключительно для статистической обработки результатов
                    тестирования. Разработчики портала берут на себя обязательства не сообщать предоставленную
                    Вами информацию третьим лицам. Таким образом, сообщаемая Вами информация не будет
                    использована для рассылки спама и других, не интересующих Вас материалов. Результаты
                    тестирования не имеют юридической силы и никоим образом не могут быть использованы
                    во вред пользователям.
                </p>
                <asp:Label ID="LabelWrongUserNamePassword" runat="server" Visible="False" ForeColor="Red">Неверное имя пользователя и/или пароль</asp:Label>
                <table>
                    <tr>
                        <td style="width: 67px">
                            <asp:Label ID="LabelLogin" runat="server" Font-Bold="true">Логин:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextboxLogin" runat="server" CssClass="textbox" Width="280" Font-Size="11pt"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 67px">
                            <asp:Label ID="LabelPassword" runat="server" Font-Bold="true">Пароль:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextboxPassword" runat="server" CssClass="textbox" Width="280" TextMode="Password"
                                Font-Size="11pt"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 67px">
                        </td>
                        <td>
                            <asp:CheckBox ID="ChRememberMe" runat="server" Font-Names="Tahoma" EnableViewState="False">
                            </asp:CheckBox>Помнить меня
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2">
                            <asp:Button ID="Btn_enter" runat="server" CssClass="btn" Width="101" Text="Войти"
                                OnClick="Btn_enter_Click"></asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2">
                            <a href="Register.aspx?Restore=true">Забыли логин/пароль?</a>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2">
                            <a href="Register.aspx">Регистрация нового пользователя</a>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <asp:PlaceHolder runat="server" ID="selUserPlace" Visible="false">
                <table style="font-family: verdana,arial,sans-serif; border-right: #7177bb 1px solid;
                    border-top: #7177bb 1px solid; border-left: #7177bb 1px solid; border-bottom: #7177bb 1px solid;"
                    cellspacing="0" cellpadding="2" width="100%" bgcolor="#bcd0ef">
                    <tr>
                        <td style="height: 20px">
                            Вход в систему<asp:Label runat="server" ID="lblWrongPassword" Text=":&nbsp;<font color='Red' size='4pt'>неверный пароль</font>"
                                Visible="false" />
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#ffffff" style="height: 32px">
                            <table style="margin: 5px;" cellspacing="0" cellpadding="2">
                                <tr>
                                    <td style="vertical-align: middle;">
                                        <b>Пользователь: </b>
                                    </td>
                                    <td style="vertical-align: middle;">
                                        <asp:Label runat="server" ID="selUser" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>Пароль: </b>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="selUserPassword" TextMode="Password" Width="309px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="height: 25px; text-align: right;">
                            <asp:Button ID="PostButton" class="btn" Style="font-family: Tahoma; font-size: 8pt;"
                                runat="server" Text="Приступить к тестированию" OnClick="postButton_Click" />
                        </td>
                    </tr>
                </table>
                <br />
            </asp:PlaceHolder>
            <table style="font-family: verdana,arial,sans-serif; border-right: #7177bb 1px solid;
                border-top: #7177bb 1px solid; border-left: #7177bb 1px solid; border-bottom: #7177bb 1px solid"
                cellspacing="0" cellpadding="2" width="100%" bgcolor="#bcd0ef">
                <tr>
                    <td style="height: 20px">
                        Выбор пользователя
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#ffffff" style="height: 32px">
                        &nbsp;Поиск:<br />
                        &nbsp;<asp:TextBox runat="server" ID="userName" Width="404px" MaxLength="50" />&nbsp;<asp:Button
                            runat="server" ID="BtnUserSearch" class="btn" Text="Найти" OnClick="BtnUserSearch_Click" />&nbsp;<asp:Button
                                runat="server" ID="ButtonClear" class="btn" Text="Очистить" OnClick="ButtonClear_Click" /><br />
                        <br />

                        <script type="text/javascript">
                            $(document).ready(function() {
                                // --- Автозаполнение ---
                                $("#<%=userName.ClientID%>").autocomplete("UserSearchHandler.aspx", {
                                    delay: 200,
                                    minChars: 2,
                                    matchSubset: 1,
                                    autoFill: false,
                                    matchContains: 1,
                                    cacheLength: 10,
                                    matchSubset: 10,
                                    selectFirst: true,
                                    maxItemsToShow: 10,
                                    onItemSelect: selectItem
                                });
                                // --- Автозаполнение ---
                            });
                            function selectItem(li) {

                                document.forms['aspnetForm'].submit();

                            }
                        </script>

                        <asp:GridView ID="GridViewUsers" runat="server" AllowPaging="true" CellPadding="4"
                            ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False"
                            PageSize="20" OnPageIndexChanging="GridViewUsers_PageIndexChanging" EmptyDataText="Пользователи не найдены"
                            OnSelectedIndexChanged="GridViewUsers_SelectedIndexChanged">
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <Columns>
                                <asp:CommandField SelectText="Выбрать" ShowSelectButton="True" />
                                <asp:BoundField DataField="LastName" HeaderText="Фамилия" />
                                <asp:BoundField DataField="FirstName" HeaderText="Имя" />
                                <asp:BoundField DataField="SecondName" HeaderText="Отчество" />
                                <asp:BoundField DataField="StudNumber" HeaderText="Номер студенческого" />
                            </Columns>
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="height: 25px">
                        <asp:HyperLink ID="HyperLinkMain" runat="server" Tag="0" NavigateUrl="~/Register.aspx">Добавить пользователя</asp:HyperLink>
                        &nbsp;|&nbsp;
                        <asp:HyperLink ID="HyperLink1" runat="server" Tag="0" NavigateUrl="~/Login.aspx?mode=2">Вход в Internet версию</asp:HyperLink>
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>
