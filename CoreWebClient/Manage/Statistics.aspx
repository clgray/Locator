<%@ Page Title="" Language="C#" MasterPageFile="~/TestorCore.Master" AutoEventWireup="true"
    CodeBehind="Statistics.aspx.cs" Inherits="CoreWebClient.StatisticsForm" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            height: 25px;
        }
    </style>

    <script type="text/javascript" src="../js/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" src="../js/jquery.autocomplete.js"></script>

    <link type="text/css" href="../js/css/jquery.autocomplete.css" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <table style="font-family: verdana,arial,sans-serif; border-right: #7177bb 1px solid;
                border-top: #7177bb 1px solid; border-left: #7177bb 1px solid; border-bottom: #7177bb 1px solid"
                cellspacing="0" cellpadding="2" width="100%" bgcolor="#bcd0ef">
                <tr>
                    <td style="height: 20px">
                        Статистика тестирования
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#ffffff" style="height: 32px">
                        <asp:LinkButton ID="LinkButtonDate" runat="server" Text="Дата" OnClick="LinkButtonUser_Click"
                            Font-Bold="true" />
                        &nbsp;|&nbsp;&nbsp;<asp:LinkButton ID="LinkButtonUser" runat="server" Text="Пользователь"
                            OnClick="LinkButtonUser_Click" />
                        &nbsp;|&nbsp;&nbsp;<asp:LinkButton ID="LinkButtonTest" runat="server" Text="Тест"
                            OnClick="LinkButtonUser_Click" />&nbsp;&nbsp;|&nbsp;
                        <asp:LinkButton ID="LinkButtonGroup" runat="server" Text="Группа" OnClick="LinkButtonUser_Click" />&nbsp;&nbsp;|&nbsp;
                        <asp:LinkButton ID="LinkButtonRefresh" runat="server" Text="Обновить" OnClick="LinkButtonRefresh_Click" />&nbsp;&nbsp;|&nbsp;
                        <asp:LinkButton ID="LinkButtonAddTime" runat="server" Text="Добавить время" OnClick="LinkButtonUser_Click" />&nbsp;&nbsp;|&nbsp;
                        <asp:LinkButton ID="LinkButtonPrintAdvanced" runat="server" Text="Печать детальной статистики"
                            OnClick="LinkButtonPrintAdvanced_Click" />&nbsp;&nbsp;|&nbsp;
                        <asp:LinkButton ID="lbPrint" runat="server" Text="Печать" OnClick="LinkButtonUser_Click" /><br />
                        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                            <asp:View ID="ViewDate" runat="server">
                                <table>
                                    <tr>
                                        <td>
                                            Начальная дата
                                        </td>
                                        <td>
                                            Конечная дата
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Calendar ID="CalendarStart" runat="server" OnSelectionChanged="CalendarStart_SelectionChanged" />
                                        </td>
                                        <td>
                                            <asp:Calendar ID="CalendarEnd" runat="server" OnSelectionChanged="CalendarStart_SelectionChanged" />
                                        </td>
                                        <td style="vertical-align: top;">
                                            Начальное время:<br />
                                            <asp:TextBox runat="server" ID="StartTime" Text="00:00" /><asp:RegularExpressionValidator
                                                ID="RegularExpressionValidator2" runat="server" ErrorMessage="&nbsp;Неверный формат"
                                                ControlToValidate="StartTime" ValidationExpression="^[0-9]{1,2}:[0-9]{1,2}$" /><br />
                                            Конечное Время:<br />
                                            <asp:TextBox runat="server" ID="EndTime" Text="23:59" /><asp:RegularExpressionValidator
                                                ID="RegularExpressionValidator1" runat="server" ErrorMessage="&nbsp;Неверный формат"
                                                ControlToValidate="EndTime" ValidationExpression="^[0-9]{1,2}:[0-9]{1,2}$" /><br />
                                            <br />
                                            <asp:Button runat="server" ID="applyTime" Text="Применить" OnClick="applyTime_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="ViewUser" runat="server">
                                <br />
                                &nbsp;<asp:TextBox runat="server" ID="userName" Width="404px" />&nbsp;<asp:Button
                                    runat="server" ID="BtnUserSearch" class="btn" Text="Найти" OnClick="BtnUserSearch_Click" />&nbsp;<asp:Button
                                        ID="ButtonClear" runat="server" class="btn" OnClick="ButtonClear_Click" Text="Очистить" />
                                <br />
                                <br />
                                <asp:GridView ID="GridViewUsers" runat="server" AllowPaging="True" CellPadding="4"
                                    ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False"
                                    OnSelectedIndexChanged="GridViewUsers_SelectedIndexChanged" OnPageIndexChanging="GridViewUsers_PageIndexChanging">
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <Columns>
                                        <asp:CommandField SelectText="Выбрать" ShowSelectButton="True" />
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
                            <asp:View ID="ViewTest" runat="server">
                                <asp:TreeView ID="TreeViewTest" runat="server" ImageSet="XPFileExplorer" NodeIndent="15"
                                    OnSelectedNodeChanged="TreeViewTest_SelectedNodeChanged">
                                    <SelectedNodeStyle Font-Bold="True" Font-Underline="False" HorizontalPadding="5px"
                                        VerticalPadding="0px" />
                                    <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                        NodeSpacing="0px" VerticalPadding="2px" />
                                </asp:TreeView>
                            </asp:View>
                            <asp:View ID="ViewGroup" runat="server">
                                <asp:TreeView ID="TreeViewGroup" runat="server" ImageSet="XPFileExplorer" NodeIndent="15"
                                    OnSelectedNodeChanged="TreeViewGroup_SelectedNodeChanged">
                                    <SelectedNodeStyle Font-Bold="True" Font-Underline="False" HorizontalPadding="5px"
                                        VerticalPadding="0px" />
                                    <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                        NodeSpacing="0px" VerticalPadding="2px" />
                                </asp:TreeView>
                            </asp:View>
                            <asp:View ID="ViewAddTime" runat="server">
                                <br />
                                &nbsp;Дополнительное время:<br />
                                &nbsp;<asp:TextBox runat="server" ID="txtAddTime" />
                                &nbsp;(минут)<br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="&nbsp;Неверный формат"
                                    ControlToValidate="txtAddTime" ValidationExpression="^-?[0-9]{1,3}$" /><br />
                                &nbsp;<asp:Button runat="server" ID="btnAddTime" Text="Добавить" OnClick="btnAddTime_Click" />
                                &nbsp;<asp:Label runat="server" ID="addMessage" Visible="false" ForeColor="Red" />
                            </asp:View>
                            <asp:View ID="ViewPrint" runat="server">
                                <fieldset>
                                    <legend>Тип отчётности [<asp:LinkButton ID="lbApplyPrint" runat="server" 
                                            ValidationGroup="vgPrint" onclick="lbApplyPrint_Click">Применить</asp:LinkButton>]</legend>
                                    <asp:RadioButton ID="rbPassingScore" Text="Набранный балл. Зачёт за балл выше проходного"
                                        runat="server" Checked="true" GroupName="printGroup" /><br />
                                    <asp:RadioButton ID="rbScore" Text="Набранный балл." runat="server" GroupName="printGroup" />
                                    Балл на зачёт:&nbsp;<asp:TextBox ID="tbScore" runat="server" MaxLength="3"></asp:TextBox>&nbsp;<asp:RegularExpressionValidator
                                        ID="rvScore" runat="server" ControlToValidate="tbScore" ValidationExpression="[0-9]*"
                                        ErrorMessage="введите число" ValidationGroup="vgPrint" /><br />
                                    <asp:RadioButton ID="rbMark" Text="Оценки" runat="server" GroupName="printGroup" />
                                    <br />
                                    &nbsp;5:&nbsp;&nbsp;<asp:TextBox ID="tbMark5" runat="server" MaxLength="3" />&nbsp;<asp:RegularExpressionValidator
                                        ID="RangeValidator1" runat="server" ControlToValidate="tbMark5" ValidationExpression="[0-9]*"
                                        ErrorMessage="*" ValidationGroup="vgPrint" /><br />
                                    &nbsp;4:&nbsp;&nbsp;<asp:TextBox ID="tbMark4" runat="server" MaxLength="3" /><asp:RegularExpressionValidator
                                        ID="RangeValidator2" runat="server" ControlToValidate="tbMark4" ValidationExpression="[0-9]*"
                                        ErrorMessage="*" ValidationGroup="vgPrint" /><br />
                                    &nbsp;3:&nbsp;&nbsp;<asp:TextBox ID="tbMark3" runat="server" MaxLength="3" /><asp:RegularExpressionValidator
                                        ID="RangeValidator3" runat="server" ControlToValidate="tbMark3" ValidationExpression="[0-9]*"
                                        ErrorMessage="*" ValidationGroup="vgPrint" />
                                    <br />
                                    <asp:RadioButton ID="rbPercent" Text="Проценты" runat="server" GroupName="printGroup" />
                                </fieldset>
                                <fieldset>
                                    <legend>Формат</legend>
                                    <asp:RadioButtonList ID="rblFormat" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblFormat_SelectedIndexChanged">
                                        <asp:ListItem Value="docx" Selected="True">Microsoft Word</asp:ListItem>
                                        <asp:ListItem Value="html">HTML</asp:ListItem>
                                    </asp:RadioButtonList>
                                </fieldset>
                                <br />
                                &nbsp;&nbsp;<asp:HyperLink ID="hlPrint" runat="server" Text="Печать" Font-Size="Larger" />
                            </asp:View>
                        </asp:MultiView>
                        <h3>
                            Результаты тестирования:</h3>
                        &nbsp;Интервал времени:
                        <asp:Label runat="server" ID="selectedDate" /><br />
                        &nbsp;Пользователь:
                        <asp:Label runat="server" ID="selectedUser" /><br />
                        &nbsp;Тест:
                        <asp:Label runat="server" ID="selectedTest" />&nbsp<asp:PlaceHolder runat="server"
                            ID="phSelTestDetails" Visible="false">[<asp:HyperLink runat="server" ID="selTestDetails"
                                Text="отчёт" Target="_blank" />]</asp:PlaceHolder>
                        <br />
                        &nbsp;Группа:
                        <asp:Label runat="server" ID="selectedGroup" /><br />
                        <br />
                        <asp:GridView ID="GridViewMain" runat="server" Width="100%" CellPadding="4" ForeColor="#333333"
                            GridLines="None" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True"
                            EmptyDataText="Нет результатов тестирования для данных условий поиска" EnableSortingAndPagingCallbacks="True"
                            OnPageIndexChanging="GridViewMain_PageIndexChanging" PageSize="35" OnSorting="GridViewMain_Sorting">
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <Columns>
                                <asp:BoundField DataField="RowNumber" HeaderText="№" />
                                <asp:HyperLinkField DataNavigateUrlFormatString="Appeal.aspx?sessionId={0}" DataTextField="TestName"
                                    HeaderText="Тест" DataNavigateUrlFields="TestSessionId" Target="_blank" SortExpression="TestName" />
                                <asp:BoundField HeaderText="Фамилия" DataField="LastName" SortExpression="LastName" />
                                <asp:BoundField HeaderText="Имя" DataField="FirstName" SortExpression="FirstName" />
                                <asp:BoundField HeaderText="Отчество" DataField="SecondName" SortExpression="SecondName" />
                                <asp:BoundField HeaderText="Группа" DataField="GroupName" SortExpression="GroupName" />
                                <asp:BoundField HeaderText="№ студенческого" DataField="StudNumber" />
                                <asp:BoundField HeaderText="Дата" DataField="StartTime" SortExpression="StartTime" />
                                <asp:BoundField HeaderText="t" DataField="StrTestTime" />
                                <asp:BoundField HeaderText="Максимальный Балл" DataField="MaxScore">
                                    <ItemStyle Width="50px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PassingScore" HeaderText="Проходной Балл">
                                    <ItemStyle Width="50px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Набранный Балл" DataField="Score" SortExpression="Score">
                                    <ItemStyle Width="50px" />
                                </asp:BoundField>
                                <asp:CheckBoxField DataField="IsPassed" HeaderText="Пройден?">
                                    <ItemStyle Width="50px" />
                                </asp:CheckBoxField>
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
                    <td align="left" class="style1">
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
