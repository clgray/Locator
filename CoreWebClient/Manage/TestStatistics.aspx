<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestStatistics.aspx.cs"
    Inherits="CoreWebClient.Manage.TestStatisticsPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>
            <asp:Label runat="server" ID="lblTest" />
        </h2>
        <table>
            <asp:PlaceHolder runat="server" ID="phGroup">
                <tr>
                    <td>
                        Группа:
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblGroup" />
                    </td>
                </tr>
            </asp:PlaceHolder>
            <tr>
                <td>
                    Кол-во вопросов в тесте:
                </td>
                <td>
                    <asp:Label runat="server" ID="lblQuestionsNumber" />
                </td>
                <td>
                    Проходной балл:
                </td>
                <td>
                    <asp:Label runat="server" ID="lblPassingScore" />
                </td>
            </tr>
            <tr>
                <td>
                    Средний балл:
                </td>
                <td>
                    <asp:Label runat="server" ID="lblAverageScore" />
                </td>
                <td>
                    Выше проходного балла:
                </td>
                <td>
                    <asp:Label runat="server" ID="lblPassedPercent" />%
                </td>
            </tr>
        </table>
        <table border="1px" cellpadding="2px">
            <tr>
                <td>
                    <b>Набранный балл</b>
                </td>
                <asp:Repeater runat="server" ID="rpScore">
                    <ItemTemplate>
                        <td style="width: 30px;">
                            <%#Eval("Score")%>
                        </td>
                    </ItemTemplate>
                </asp:Repeater>
            </tr>
            <tr>
                <td>
                    <b>Кол-во сдач</b>
                </td>
                <asp:Repeater runat="server" ID="rpScoreCount">
                    <ItemTemplate>
                        <td>
                            <%#Eval("ScoreCount")%>
                        </td>
                    </ItemTemplate>
                </asp:Repeater>
            </tr>
        </table>
        <asp:PlaceHolder runat="server" ID="phScores" Visible="false">
            <br />
            <table border="1px" cellpadding="2px">
                <tr>
                    <td>
                        <b>Набранный балл</b>
                    </td>
                    <asp:Repeater runat="server" ID="rpScore1">
                        <ItemTemplate>
                            <td style="width: 30px;">
                                <%#Eval("Score")%>
                            </td>
                        </ItemTemplate>
                    </asp:Repeater>
                </tr>
                <tr>
                    <td>
                        <b>Кол-во сдач</b>
                    </td>
                    <asp:Repeater runat="server" ID="rpScoreCount1">
                        <ItemTemplate>
                            <td>
                                <%#Eval("ScoreCount")%>
                            </td>
                        </ItemTemplate>
                    </asp:Repeater>
                </tr>
            </table>
        </asp:PlaceHolder>
        <asp:Chart ID="testChart" runat="server" Width="600px">
            <Series>
                <asp:Series Name="Series1" XValueMember="Score" YValueMembers="ScoreCount">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                    <AxisY Title="Кол-во сдач" Minimum="0">
                    </AxisY>
                    <AxisX Title="Набранный балл" IsLabelAutoFit="True" Minimum="0">
                        <LabelStyle Interval="5" />
                    </AxisX>
                    <Area3DStyle Enable3D="True" />
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </div>
    </form>
</body>
</html>
