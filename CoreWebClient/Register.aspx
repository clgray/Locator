<%@ Page Title="" Language="C#" MasterPageFile="~/TestorCore.Master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="CoreWebClient.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>

    <%--  <script type="text/javascript" src="js/jquery.cookie.js"></script>--%>
    <link rel="stylesheet" href="js/css/jquery.treeview.css" type="text/css" />

    <script type="text/javascript" src="js/jquery.treeview.js"></script>

    <script type="text/javascript">
      $(document).ready(function() {
      $("#groupTreeMainUl").treeview({
          animated: "fast",
          unique: true
      });
      });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">
            <asp:Label runat="server" ID="aspErrorMessage" ForeColor="Red" Visible="false" /><br />
            <table>
                <tr>
                    <td colspan="2">
                        <span style="color: #189BC0;">
                            <asp:Label runat="server" ID="loginPasswordText" Text="Логин и пароль"></asp:Label></span>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#189bc0" colspan="2" height="1">
                    </td>
                </tr>
                <asp:PlaceHolder runat="server" ID="loginPlace" Visible="true">
                    <tr>
                        <td>
                            <b>Логин:</b>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxLogin" runat="server" Width="377px" MaxLength="50" />&nbsp;<asp:RequiredFieldValidator
                                ID="RequiredFieldValidatorLogin" runat="server" ControlToValidate="TextBoxLogin"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </asp:PlaceHolder>
                <tr>
                    <td>
                        <b>Пароль:</b>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxPassword" runat="server" Width="377px" MaxLength="50" TextMode="Password" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxPassword"
                            ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Подтверждение пароля:</b>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxSecondPassword" runat="server" Width="377px" MaxLength="50"
                            TextMode="Password" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxSecondPassword"
                            ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Секретный код:</b>
                    </td>
                    <td>
                        <asp:Image runat="server" ID="captchaImage" alt="captcha" /><br />
                        <br />
                        <asp:TextBox ID="TextBoxCaptcha" runat="server" Width="377px" MaxLength="20" autocomplete="off"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxCaptcha"
                            ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <span style="color: #189BC0;">Информация о пользователе</span>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#189bc0" colspan="2" height="1">
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Фамилия:</b>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxLastName" runat="server" Width="377px" MaxLength="50" autocomplete="off" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                            ControlToValidate="TextBoxLastName"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Имя:</b>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxName" runat="server" Width="377px" MaxLength="50" autocomplete="off" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                            ControlToValidate="TextBoxName"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Отчество:</b>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxSecondName" runat="server" Width="377px" MaxLength="50" autocomplete="off" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Пол</b>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownListGender" runat="server" Height="18px" Width="97px">
                            <asp:ListItem Selected="True" Value="1">Муж.</asp:ListItem>
                            <asp:ListItem Value="0">Жен.</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <asp:MultiView ID="MultiViewGroup" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View7" runat="server">
                        <tr>
                            <td>
                                <b>Код группы:</b>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxGroup" runat="server" Width="377px" MaxLength="50" />
                            </td>
                        </tr>
                    </asp:View>
                    <asp:View ID="View8" runat="server">
                        <tr>
                            <td style="vertical-align: top;">
                                <b>Группа:</b>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="groupName" Font-Bold="true" /><asp:Label runat="server"
                                    ID="grpTree" />
                            </td>
                        </tr>
                    </asp:View>
                </asp:MultiView>
                <tr>
                    <td>
                        <b>Номер студенческого:</b>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxStudNumber" runat="server" Width="377px" MaxLength="50" autocomplete="off" />
                    </td>
                </tr>
                <asp:PlaceHolder runat="server" ID="emailPlace" Visible="true">
                    <tr>
                        <td>
                            <b>E-mail:</b>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxEmail" runat="server" Width="377px" MaxLength="50" autocomplete="off" /><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBoxEmail"
                                ErrorMessage="*" /><asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                    runat="server" ErrorMessage="Неверный формат" ControlToValidate="TextBoxEmail"
                                    ValidationExpression="^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$" />
                        </td>
                    </tr>
                </asp:PlaceHolder>
                <tr>
                    <td bgcolor="#189bc0" colspan="2" height="1">
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="2">
                        <asp:Button runat="server" ID="Btn_Reg" class="btn" Text="Зарегистрироваться" OnClick="Btn_Reg_Click" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <h2>
                Регистрация выполнена успешно!</h2>
            На Ваш e-mail отправлено письмо с инструкциями по активации аккаунта.<br />
            Активируйте аккаунт и выполните <a href="Login.aspx">вход</a>.
        </asp:View>
        <asp:View ID="View3" runat="server">
            <h2>
                Востановление регистрационной информации.</h2>
            <asp:Label runat="server" ID="LabelRestoreError" ForeColor="Red" Visible="false" /><br />
            Введите Ваш e-mail:<br />
            <asp:TextBox ID="TextBoxRestore" runat="server" Width="377px" MaxLength="50" /><asp:RequiredFieldValidator
                ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBoxRestore"
                ErrorMessage="*" /><asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                    runat="server" ErrorMessage="Неверный формат" ControlToValidate="TextBoxRestore"
                    ValidationExpression="^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$" /><br />
            Введите секретный код:<br />
            <br />
            <asp:Image runat="server" ID="restoreCaptchaImage" alt="captcha" /><br />
            <br />
            <asp:TextBox ID="TextBoxRestoreCaptcha" runat="server" Width="377px" MaxLength="20" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TextBoxRestoreCaptcha"
                ErrorMessage="*" /><br />
            <br />
            <asp:Button runat="server" ID="ButtonRestore" class="btn" Text="Восстановить" OnClick="ButtonRestore_Click" />
        </asp:View>
        <asp:View ID="View4" runat="server">
            <h2>
                Восстановление регистрационной информации.</h2>
            На Ваш e-mail отправлено письмо с инструкциями по восстановлению пароля.<br />
            Восстановите пароль и выполните <a href="Login.aspx">вход</a>.</asp:View>
        <asp:View ID="View5" runat="server">
            <h2>
                Изменение пароля.</h2>
            <asp:Label runat="server" ID="LabelSetNewPasswordError" ForeColor="Red" Visible="false" />
            <table>
                <tr>
                    <td>
                        <b>Новый пароль:</b>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxNewPassword" runat="server" Width="377px" MaxLength="50"
                            TextMode="Password" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBoxNewPassword"
                            ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Подтверждение пароля:</b>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxNewPasswordSecond" runat="server" Width="377px" MaxLength="50"
                            TextMode="Password" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBoxNewPasswordSecond"
                            ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <asp:Button runat="server" ID="ButtonSetNewPassword" class="btn" Text="Изменить"
                OnClick="ButtonSetNewPassword_Click" />
        </asp:View>
        <asp:View ID="View6" runat="server">
            <h2>
                Изменение пароля.</h2>
            Пароль изменён успешно.<br />
            Для продолжения работы с системой выполните <a href="Login.aspx">вход</a>.</asp:View>
    </asp:MultiView>
</asp:Content>
