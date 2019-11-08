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
                        ���������� ������������
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#ffffff" style="height: 32px">
                        <asp:LinkButton ID="LinkButtonDate" runat="server" Text="����" OnClick="LinkButtonUser_Click"
                            Font-Bold="true" />
                        &nbsp;|&nbsp;&nbsp;<asp:LinkButton ID="LinkButtonUser" runat="server" Text="������������"
                            OnClick="LinkButtonUser_Click" />
                        &nbsp;|&nbsp;&nbsp;<asp:LinkButton ID="LinkButtonTest" runat="server" Text="����"
                            OnClick="LinkButtonUser_Click" />&nbsp;&nbsp;|&nbsp;
                        <asp:LinkButton ID="LinkButtonGroup" runat="server" Text="������" OnClick="LinkButtonUser_Click" />&nbsp;&nbsp;|&nbsp;
                        <asp:LinkButton ID="LinkButtonRefresh" runat="server" Text="��������" OnClick="LinkButtonRefresh_Click" />&nbsp;&nbsp;|&nbsp;
                        <asp:LinkButton ID="LinkButtonAddTime" runat="server" Text="�������� �����" OnClick="LinkButtonUser_Click" />&nbsp;&nbsp;|&nbsp;
                        <asp:LinkButton ID="LinkButtonPrintAdvanced" runat="server" Text="������ ��������� ����������"
                            OnClick="LinkButtonPrintAdvanced_Click" />&nbsp;&nbsp;|&nbsp;
                        <asp:LinkButton ID="lbPrint" runat="server" Text="������" OnClick="LinkButtonUser_Click" /><br />
                        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                            <asp:View ID="ViewDate" runat="server">
                                <table>
                                    <tr>
                                        <td>
                                            ��������� ����
                                        </td>
                                        <td>
                                            �������� ����
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
                                            ��������� �����:<br />
                                            <asp:TextBox runat="server" ID="StartTime" Text="00:00" /><asp:RegularExpressionValidator
                                                ID="RegularExpressionValidator2" runat="server" ErrorMessage="&nbsp;�������� ������"
                                                ControlToValidate="StartTime" ValidationExpression="^[0-9]{1,2}:[0-9]{1,2}$" /><br />
                                            �������� �����:<br />
                                            <asp:TextBox runat="server" ID="EndTime" Text="23:59" /><asp:RegularExpressionValidator
                                                ID="RegularExpressionValidator1" runat="server" ErrorMessage="&nbsp;�������� ������"
                                                ControlToValidate="EndTime" ValidationExpression="^[0-9]{1,2}:[0-9]{1,2}$" /><br />
                                            <br />
                                            <asp:Button runat="server" ID="applyTime" Text="���������" OnClick="applyTime_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="ViewUser" runat="server">
                                <br />
                                &nbsp;<asp:TextBox runat="server" ID="userName" Width="404px" />&nbsp;<asp:Button
                                    runat="server" ID="BtnUserSearch" class="btn" Text="�����" OnClick="BtnUserSearch_Click" />&nbsp;<asp:Button
                                        ID="ButtonClear" runat="server" class="btn" OnClick="ButtonClear_Click" Text="��������" />
                                <br />
                                <br />
                                <asp:GridView ID="GridViewUsers" runat="server" AllowPaging="True" CellPadding="4"
                                    ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False"
                                    OnSelectedIndexChanged="GridViewUsers_SelectedIndexChanged" OnPageIndexChanging="GridViewUsers_PageIndexChanging">
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <Columns>
                                        <asp:CommandField SelectText="�������" ShowSelectButton="True" />
                                        <asp:BoundField DataField="LastName" HeaderText="�������" />
                                        <asp:BoundField DataField="FirstName" HeaderText="���" />
                                        <asp:BoundField DataField="SecondName" HeaderText="��������" />
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
                                &nbsp;�������������� �����:<br />
                                &nbsp;<asp:TextBox runat="server" ID="txtAddTime" />
                                &nbsp;(�����)<br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="&nbsp;�������� ������"
                                    ControlToValidate="txtAddTime" ValidationExpression="^-?[0-9]{1,3}$" /><br />
                                &nbsp;<asp:Button runat="server" ID="btnAddTime" Text="��������" OnClick="btnAddTime_Click" />
                                &nbsp;<asp:Label runat="server" ID="addMessage" Visible="false" ForeColor="Red" />
                            </asp:View>
                            <asp:View ID="ViewPrint" runat="server">
                                <fieldset>
                                    <legend>��� ���������� [<asp:LinkButton ID="lbApplyPrint" runat="server" 
                                            ValidationGroup="vgPrint" onclick="lbApplyPrint_Click">���������</asp:LinkButton>]</legend>
                                    <asp:RadioButton ID="rbPassingScore" Text="��������� ����. ����� �� ���� ���� ����������"
                                        runat="server" Checked="true" GroupName="printGroup" /><br />
                                    <asp:RadioButton ID="rbScore" Text="��������� ����." runat="server" GroupName="printGroup" />
                                    ���� �� �����:&nbsp;<asp:TextBox ID="tbScore" runat="server" MaxLength="3"></asp:TextBox>&nbsp;<asp:RegularExpressionValidator
                                        ID="rvScore" runat="server" ControlToValidate="tbScore" ValidationExpression="[0-9]*"
                                        ErrorMessage="������� �����" ValidationGroup="vgPrint" /><br />
                                    <asp:RadioButton ID="rbMark" Text="������" runat="server" GroupName="printGroup" />
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
                                    <asp:RadioButton ID="rbPercent" Text="��������" runat="server" GroupName="printGroup" />
                                </fieldset>
                                <fieldset>
                                    <legend>������</legend>
                                    <asp:RadioButtonList ID="rblFormat" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblFormat_SelectedIndexChanged">
                                        <asp:ListItem Value="docx" Selected="True">Microsoft Word</asp:ListItem>
                                        <asp:ListItem Value="html">HTML</asp:ListItem>
                                    </asp:RadioButtonList>
                                </fieldset>
                                <br />
                                &nbsp;&nbsp;<asp:HyperLink ID="hlPrint" runat="server" Text="������" Font-Size="Larger" />
                            </asp:View>
                        </asp:MultiView>
                        <h3>
                            ���������� ������������:</h3>
                        &nbsp;�������� �������:
                        <asp:Label runat="server" ID="selectedDate" /><br />
                        &nbsp;������������:
                        <asp:Label runat="server" ID="selectedUser" /><br />
                        &nbsp;����:
                        <asp:Label runat="server" ID="selectedTest" />&nbsp<asp:PlaceHolder runat="server"
                            ID="phSelTestDetails" Visible="false">[<asp:HyperLink runat="server" ID="selTestDetails"
                                Text="�����" Target="_blank" />]</asp:PlaceHolder>
                        <br />
                        &nbsp;������:
                        <asp:Label runat="server" ID="selectedGroup" /><br />
                        <br />
                        <asp:GridView ID="GridViewMain" runat="server" Width="100%" CellPadding="4" ForeColor="#333333"
                            GridLines="None" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True"
                            EmptyDataText="��� ����������� ������������ ��� ������ ������� ������" EnableSortingAndPagingCallbacks="True"
                            OnPageIndexChanging="GridViewMain_PageIndexChanging" PageSize="35" OnSorting="GridViewMain_Sorting">
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <Columns>
                                <asp:BoundField DataField="RowNumber" HeaderText="�" />
                                <asp:HyperLinkField DataNavigateUrlFormatString="Appeal.aspx?sessionId={0}" DataTextField="TestName"
                                    HeaderText="����" DataNavigateUrlFields="TestSessionId" Target="_blank" SortExpression="TestName" />
                                <asp:BoundField HeaderText="�������" DataField="LastName" SortExpression="LastName" />
                                <asp:BoundField HeaderText="���" DataField="FirstName" SortExpression="FirstName" />
                                <asp:BoundField HeaderText="��������" DataField="SecondName" SortExpression="SecondName" />
                                <asp:BoundField HeaderText="������" DataField="GroupName" SortExpression="GroupName" />
                                <asp:BoundField HeaderText="� �������������" DataField="StudNumber" />
                                <asp:BoundField HeaderText="����" DataField="StartTime" SortExpression="StartTime" />
                                <asp:BoundField HeaderText="t" DataField="StrTestTime" />
                                <asp:BoundField HeaderText="������������ ����" DataField="MaxScore">
                                    <ItemStyle Width="50px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PassingScore" HeaderText="��������� ����">
                                    <ItemStyle Width="50px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="��������� ����" DataField="Score" SortExpression="Score">
                                    <ItemStyle Width="50px" />
                                </asp:BoundField>
                                <asp:CheckBoxField DataField="IsPassed" HeaderText="�������?">
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
