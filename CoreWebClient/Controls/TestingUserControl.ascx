<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TestingUserControl.ascx.cs"
    Inherits="CoreWebClient.TestingUserControl" EnableViewState="false" %>
<table style="font-family: verdana,arial,sans-serif; border-right: #7177bb 1px solid;
    border-top: #7177bb 1px solid; border-left: #7177bb 1px solid; border-bottom: #7177bb 1px solid;"
    cellspacing="0" cellpadding="2" width="100%" bgcolor="#bcd0ef" id="TABLE1">
    <tr>
        <td style="height: 20px">
            <asp:MultiView ID="MultiViewHeader" runat="server" ActiveViewIndex="0">
                <asp:View ID="ViewQuest" runat="server">
                    <table style="width: 100%; margin: 0px; padding: 0px;">
                        <tr>
                            <td>
                                <span style="font-family: Tahoma; font-size: 9pt;"><b>Вопрос
                                    <asp:Label runat="server" ID="CurrentQuestNumber" /></b>&nbsp;из
                                    <asp:Label runat="server" ID="QuestCount" />&nbsp;(<asp:Label runat="server" ID="lblAnsQuestCount" />)</span>
                            </td>
                            <td style="width: auto; text-align: right;">
                                <asp:Label runat="server" ID="LabelShowTime" Visible="False" />
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="ViewResult" runat="server">
                    <span style="font-family: Tahoma; font-size: 9pt;"><b>Результаты тестирования</b></span>
                </asp:View>
            </asp:MultiView>
        </td>
    </tr>
    <tr>
        <td bgcolor="#ffffff" style="height: 32px">
            <asp:Label runat="server" ID="htmlContent" />
        </td>
    </tr>
    <tr>
        <td align="right" bgcolor="#96b0de" height="28">
            <asp:Button ID="postButton" runat="server" class="btn" Style="font-size: 8pt; font-family: Tahoma;
                height: 20px" Text="Ответить" value="0" EnableTheming="True" OnClick="postButton_Click" />
            &nbsp<asp:Button ID="nextButton" runat="server" class="btn" Style="font-size: 8pt;
                font-family: Tahoma; height: 20px" Text="Пропустить" value="0" EnableTheming="True"
                OnClick="nextButton_Click" />
        </td>
    </tr>
    <tr>
        <td align="left" style="height: 25px">
            <table style="width: 100%; margin: 0px; padding: 0px;">
                <tr>
                    <td>
                        <asp:Panel runat="server" ID="endTestPanel">
                            <div id="endTest">
                                <a href="#" onclick="WriteTestEnd();">Завершить тестирование</a>
                            </div>
                        </asp:Panel>
                    </td>
                    <td style="text-align: right;">
                        <asp:Label runat="server" ID="scoreLabel" Text="Набранный Балл: -" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
