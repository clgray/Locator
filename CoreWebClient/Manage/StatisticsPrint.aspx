<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StatisticsPrint.aspx.cs"
    Inherits="CoreWebClient.Manage.StatisticsPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Печать</title>
</head>
<body style="margin: 0px; padding: 0px;" onload="javascript:window.print();">
    <form id="form1" runat="server">
    <div class="page">
        <asp:GridView ID="GridViewMain" runat="server" Width="100%" AutoGenerateColumns="False"
            EmptyDataText="Нет результатов тестирования для данных условий поиска" CellPadding="4"
            ForeColor="#333333" GridLines="None">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:BoundField DataField="RowNumber" HeaderText="№" />
                <asp:BoundField HeaderText="Тест" DataField="TestName" />
                <asp:BoundField HeaderText="Фамилия" DataField="LastName" />
                <asp:BoundField HeaderText="Имя" DataField="FirstName" />
                <asp:BoundField HeaderText="Группа" DataField="GroupName" />
                <asp:BoundField HeaderText="№ студенческого" DataField="StudNumber" />
                <asp:BoundField HeaderText="Дата" DataField="StartTime" DataFormatString="{0:dd.MM.yyyy HH:mm}"/>
                <asp:BoundField HeaderText="Максимальный Балл" DataField="MaxScore">
                    <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="PassingScore" HeaderText="Проходной Балл">
                    <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Набранный Балл" DataField="Score">
                    <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:CheckBoxField DataField="IsPassed" HeaderText="Пройден?">
                    <ItemStyle Width="50px" />
                </asp:CheckBoxField>
                <asp:BoundField HeaderText="%" DataField="Percent" DataFormatString="{0:0.0}%" Visible="false">
                    <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Оценка" DataField="Mark" DataFormatString="{0}" Visible="false">
                    <ItemStyle Width="50px" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
