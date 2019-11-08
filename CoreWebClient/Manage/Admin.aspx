<%@ Page Title="" Language="C#" MasterPageFile="~/TestorCore.Master" AutoEventWireup="true"
    CodeBehind="Admin.aspx.cs" Inherits="CoreWebClient.WebForm6" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- TinyMCE -->
    <script type="text/javascript" src="../JS/tiny_mce/tiny_mce.js"></script>
    <script type="text/javascript">
        tinyMCE.init({
            mode: "textareas",
            theme: "advanced",
            theme_advanced_toolbar_location: "top",
            theme_advanced_toolbar_align: "left"
        });
    </script>
    <!-- /TinyMCE -->
    <script type="text/javascript" src="../js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../js/jquery.autocomplete.js"></script>
    <link type="text/css" href="../js/css/jquery.autocomplete.css" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <table style="font-family: verdana,arial,sans-serif; border-right: #7177bb 1px solid;
        border-top: #7177bb 1px solid; border-left: #7177bb 1px solid; border-bottom: #7177bb 1px solid"
        cellspacing="0" cellpadding="2" width="100%" bgcolor="#bcd0ef">
        <tr>
            <td style="height: 20px">
                Администрирование<asp:Label runat="server" ID="changesIndicator" Visible="false"
                    ForeColor="Red" Font-Bold="true" />
            </td>
        </tr>
        <tr>
            <td bgcolor="#ffffff" style="height: 32px">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 80px; vertical-align: top;">
                            <asp:TreeView ID="TreeViewMain" runat="server" ImageSet="XPFileExplorer" NodeIndent="15"
                                OnSelectedNodeChanged="TreeViewMain_SelectedNodeChanged">
                                <ParentNodeStyle Font-Bold="False" />
                                <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                                <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px"
                                    VerticalPadding="0px" />
                                <Nodes>
                                    <asp:TreeNode Text="Система тестирования" Value="0" SelectAction="Expand">
                                        <asp:TreeNode Text="Пользователи" Value="2" Selected="True"></asp:TreeNode>
                                        <asp:TreeNode Text="Анонимные тесты" Value="0"></asp:TreeNode>
                                        <asp:TreeNode Text="Настройки аутентификации" Value="1"></asp:TreeNode>
                                    </asp:TreeNode>
                                </Nodes>
                                <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px"
                                    NodeSpacing="0px" VerticalPadding="2px" />
                            </asp:TreeView>
                        </td>
                        <td>
                            <asp:MultiView ID="MultiViewMain" runat="server" ActiveViewIndex="2">
                                <asp:View ID="ViewAnonym" runat="server">
                                    <asp:RadioButton ID="radioButtonAll" runat="server" Text="Разрешить анонимное тестирование для всех тестов"
                                        GroupName="rb1" /><br />
                                    <asp:RadioButton ID="radioButtonFolder" runat="server" Text="Разрешить анонимное тестирование для тестов в папке"
                                        GroupName="rb1" /><br />
                                    Выбранная папка: "<asp:Label ID="lbSelectedFolder" runat="server" Text="-" />"<br />
                                    <br />
                                    <asp:TreeView ID="TreeViewTests" runat="server" ExpandDepth="1" ImageSet="XPFileExplorer"
                                        NodeIndent="15" OnSelectedNodeChanged="TreeViewTests_SelectedNodeChanged">
                                        <ParentNodeStyle Font-Bold="False" />
                                        <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                                        <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px"
                                            VerticalPadding="0px" />
                                        <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px"
                                            NodeSpacing="0px" VerticalPadding="2px" />
                                    </asp:TreeView>
                                    <br />
                                    <asp:RadioButton ID="radioButtonNone" runat="server" Text="Запретить анонимное тестирование"
                                        GroupName="rb1" /><br />
                                </asp:View>
                                <asp:View ID="ViewLogin" runat="server">
                                    <h3>
                                        Настройки режимов работы</h3>
                                    <asp:CheckBox ID="CheckBoxAllowIntranet" runat="server" Text="Разрешить интранет режим (режим для локальной сети)."
                                        Checked="true" /><br />
                                    <asp:CheckBox ID="CheckBoxAllowPublic" runat="server" Text="Разрешить интернет режим."
                                        Checked="true" />
                                    <h3>
                                        Локальные подсети</h3>
                                    <asp:TextBox ID="TextBoxLocalNetworks" runat="server" Width="250px" />
                                    <h3>
                                        Настройки Smtp сервера</h3>
                                    <table>
                                        <tr>
                                            <td>
                                                От кого:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxFrom" runat="server" Width="250px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Smtp сервер:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxSmtpServer" runat="server" Width="250px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Логин:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxSmtpLogin" runat="server" Width="250px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Пароль:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxSmtpPassword" runat="server" TextMode="Password" Width="250px" />
                                            </td>
                                        </tr>
                                    </table>
                                    <h3>
                                        Текст сообщения подтверждения регистрации:</h3>
                                    <asp:TextBox ID="TextBoxRegMailContext" TextMode="MultiLine" runat="server" name="content"
                                        Width="100%" />
                                    <p>
                                        Вставьте {1} вместо ссылки, по которой должен пройти пользователь. И {0} вместо
                                        его логина.</p>
                                    <h3>
                                        Текст сообщения восстановления пароля:</h3>
                                    <asp:TextBox ID="TextBoxRegRestore" TextMode="MultiLine" runat="server" name="content"
                                        Width="100%" />
                                    <p>
                                        Вставьте {1} вместо ссылки, по которой должен пройти пользователь. И {0} вместо
                                        его логина.</p>
                                </asp:View>
                                <asp:View ID="ViewUsers" runat="server">
                                    &nbsp;<asp:TextBox runat="server" ID="userName" Width="404px" />&nbsp;<asp:Button
                                        runat="server" ID="BtnUserSearch" class="btn" Text="Найти" OnClick="BtnUserSearch_Click" />&nbsp;<asp:Button
                                            ID="ButtonClear" runat="server" class="btn" OnClick="ButtonClear_Click" Text="Очистить" />

                                    <script type="text/javascript">
                                        $(document).ready(function() {
                                            // --- Автозаполнение ---
                                            $("#<%=userName.ClientID%>").autocomplete("../UserSearchHandler.aspx", {
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

                                            document.getElementById('<%=BtnUserSearch.ClientID%>').click();

                                        }
                                    </script>

                                    <br />
                                    <br />
                                    <asp:PlaceHolder runat="server" ID="selUserPlace" Visible="false"><b>Выбранный пользователь:
                                    </b>
                                        <asp:Label runat="server" ID="selUser" /><br />
                                        <asp:LinkButton ID="LinkButtonChangePassword" runat="server" OnClick="LinkButtonChangePassword_Click">Редактировать</asp:LinkButton>
                                        <br />
                                        <br />
                                    </asp:PlaceHolder>
                                    <asp:GridView ID="GridViewUsers" runat="server" AllowPaging="true" PageSize="35"
                                        CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False"
                                        OnSelectedIndexChanged="GridViewUsers_SelectedIndexChanged" OnPageIndexChanging="GridViewUsers_PageIndexChanging">
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <Columns>
                                            <asp:CommandField SelectText="Выбрать" ShowSelectButton="True" />
                                            <asp:BoundField DataField="Login" HeaderText="Логин" />
                                            <asp:BoundField DataField="LastName" HeaderText="Фамилия" />
                                            <asp:BoundField DataField="FirstName" HeaderText="Имя" />
                                            <asp:BoundField DataField="SecondName" HeaderText="Отчество" />
                                        </Columns>
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#999999" />
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    </asp:GridView>
                                </asp:View>
                                <asp:View ID="ViewUserDetails" runat="server">
                                    <asp:LinkButton ID="LinkButtonBack" runat="server" OnClick="LinkButtonBack_Click"><< Назад</asp:LinkButton><br />
                                    <b>Выбранный пользователь: </b>
                                    <asp:Label runat="server" ID="LabelUserName" /><br />
                                    <asp:Label runat="server" ID="aspErrorMessage" ForeColor="Red" Visible="false" /><br />
                                    <table>
                                        <tr>
                                            <td colspan="2">
                                                <span style="color: #189BC0;">Изменение пароля</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#189bc0" colspan="2" height="1">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <b>Пароль:</b>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxPassword" runat="server" Width="377px" MaxLength="50" TextMode="Password" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <b>Подтверждение пароля:</b>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxSecondPassword" runat="server" Width="377px" MaxLength="50"
                                                    TextMode="Password" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                            </asp:MultiView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" bgcolor="#96b0de" height="28">
                <asp:Button ID="postButton" class="btn" Style="font-family: Tahoma; font-size: 8pt;"
                    runat="server" Text="Сохранить изменения" OnClick="postButton_Click" />
            </td>
        </tr>
        <tr>
            <td align="left" style="height: 25px">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
