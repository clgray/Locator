<%@ Page Title="" Language="C#" MasterPageFile="~/TestorCore.Master" AutoEventWireup="true" CodeBehind="PrivateOffice.aspx.cs" Inherits="CoreWebClient.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
<asp:Repeater runat="server" ID="appointedTests">
<HeaderTemplate>
<table style="font-family:verdana,arial,sans-serif;border-right: #7177bb 1px solid; border-top: #7177bb 1px solid; border-left: #7177bb 1px solid;
border-bottom: #7177bb 1px solid" cellspacing="0" cellpadding="2"
width="100%" bgcolor="#bcd0ef">
<tr>
<td style="height: 20px">����������� �����</td>
</tr>
<tr>                 
<td bgcolor="#ffffff" style="height: 32px">
<ul>
</HeaderTemplate>
<FooterTemplate>
</ul>
</td>
</tr>
</table><br /> 
</FooterTemplate>
<ItemTemplate>
<li><a href="/Default.aspx?objectId=<%# Eval("ItemId")%>"><%# Eval("ItemName")%></a></li>
</ItemTemplate>
</asp:Repeater>
<table style="font-family:verdana,arial,sans-serif;border-right: #7177bb 1px solid; border-top: #7177bb 1px solid; border-left: #7177bb 1px solid;
                    border-bottom: #7177bb 1px solid" cellspacing="0" cellpadding="2"
                    width="100%" bgcolor="#bcd0ef">
<tr>
<td style="height: 20px">������ �������</td>
</tr>
<tr>                 
<td bgcolor="#ffffff" style="height: 32px">
<asp:FormView runat="server" ID="userForm">
<ItemTemplate>
<table>
<tr><td><b>�����:</b></td>
<td><asp:Label ID="Label1" runat="server" Text='<%#Bind("Login") %>'/></td></tr>
<tr><td><b>�������:</b></td>
<td><asp:Label ID="Label2" runat="server" Text='<%#Bind("LastName") %>'/></td></tr>
<tr><td><b>���:</b></td>
<td><asp:Label ID="Label3" runat="server" Text='<%#Bind("FirstName") %>'/></td></tr>
<tr><td><b>��������:</b></td>
<td><asp:Label ID="Label4" runat="server" Text='<%#Bind("SecondName") %>'/></td></tr>
<tr><td><b>���</b></td>
<td><asp:DropDownList ID="DropDownListGender" runat="server" Height="18px" 
        Width="97px" Enabled="false" OnLoad="userForm_Load">
    <asp:ListItem Value="true">���.</asp:ListItem>
    <asp:ListItem Value="false">���.</asp:ListItem>
    </asp:DropDownList></td></tr>
<tr><td><b>������:</b></td>
<td><asp:Repeater runat="server" DataSource='<%#Eval("UserGroups") %>'>
<ItemTemplate><asp:Label ID="Label7" runat="server" Text='<%#Bind("ItemName") %>'/>;</ItemTemplate>
</asp:Repeater>
</td></tr>
<tr><td><b>����� �������������:</b></td>
<td><asp:Label ID="Label5" runat="server" Text='<%#Bind("StudNumber") %>'/></td></tr>
<tr><td><b>E-mail:</b></td>
<td><asp:Label ID="Label6" runat="server" Text='<%#Bind("Email") %>'/></td></tr>
</table>
    </ItemTemplate>
    </asp:FormView>
    <h3>���������� ������������:</h3>
    <asp:GridView ID="GridViewSessions" runat="server" CellPadding="4" 
        EmptyDataText="�� ���� ���� �� �������" ForeColor="#333333" GridLines="None" 
        Width="100%" PageSize="15" AutoGenerateColumns="False" AllowPaging="True" 
        EnableSortingAndPagingCallbacks="True">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="TestName" HeaderText="�������� �����" />
            <asp:BoundField DataField="StartTime" HeaderText="���� �����������" />
            <asp:BoundField DataField="MaxScore" HeaderText="������������ ����" />
            <asp:BoundField DataField="Score" HeaderText="��������� ����" />
            <asp:BoundField DataField="PassingScore" HeaderText="��������� ����" />
            <asp:CheckBoxField DataField="IsPassed" HeaderText="�������?" />
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
</td>
</tr><tr><td align="left" style="height: 25px">&nbsp;</td></tr></table>
</asp:Content>
