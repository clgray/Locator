<%@ Page Title="" Language="C#" MasterPageFile="~/TestorCore.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="CoreWebClient.DefaultWebPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <table style="font-family: verdana,arial,sans-serif; border-right: #7177bb 1px solid;
        border-top: #7177bb 1px solid; border-left: #7177bb 1px solid; border-bottom: #7177bb 1px solid"
        cellspacing="0" cellpadding="2" width="100%" bgcolor="#bcd0ef">
        <tr>
            <td style="height: 20px">
                <asp:Label runat="server" Visible="false" ID="LabelTestname" />
            </td>
        </tr>
        <tr>
            <td bgcolor="#ffffff" style="height: 32px">
                <asp:MultiView runat="server" ID="MultiViewMain">
                    <asp:View ID="SystemRadioView" runat="server">
                        <table id="RadioButtonList1" border="0" style="font-family: Times New Roman,Tahoma,Verdana,Arial;
                            font-size: 13pt;">
                            <asp:Label runat="server" ID="NoItemsLabel" Font-Italic="True" Font-Size="Medium"
                                Text="Нет элементов" Width="238px" />
                            <asp:Repeater ID="TestRepeater" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <input type="radio" name="RadioButtonList" id='ri<%# Eval("ItemId")%>' value='<%# Eval("ItemId")%>' />
                                              <label for='ri<%# Eval("ItemId")%>'><%# Eval("ItemName")%></label>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </asp:View>
                    <asp:View ID="SystemTreeView" runat="server">
                        <asp:TreeView ID="TreeViewMain" runat="server" ExpandDepth="1" ImageSet="XPFileExplorer"
                            NodeIndent="15">
                            <ParentNodeStyle Font-Bold="False" />
                            <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                            <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px"
                                VerticalPadding="0px" />
                            <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px"
                                NodeSpacing="0px" VerticalPadding="2px" />
                        </asp:TreeView>
                    </asp:View>
                    <asp:View ID="SystemAnnotationView" runat="server">
                        <asp:Label runat="server" ID="testDetails" />
                        <asp:Panel runat="server" ID="requirementsPanel" Visible="false">
                            <br />
                            &nbsp;<b>Предварительно необходимо пройти:</b>
                            <ul>
                                <asp:Repeater runat="server" ID="requirementsRepeater">
                                    <ItemTemplate>
                                        <li><a href="/Default.aspx?objectId=<%# Eval("ItemId")%>">
                                            <%# Eval("ItemName")%></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </asp:Panel>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
        <tr>
            <td align="right" bgcolor="#96b0de" height="28">
                <asp:Button ID="postButton" class="btn" Style="font-family: Tahoma; font-size: 8pt;"
                    runat="server" Text="Выбрать" OnClick="postButton_Click" btvalue="NULL" mode="NULL" />
            </td>
        </tr>
        <tr>
            <td align="left" style="height: 25px">
                <asp:HyperLink ID="HyperLinkMain" runat="server" Tag="0" NavigateUrl="~/Default.aspx?pageMode=1">Показать все тесты</asp:HyperLink>
            </td>
        </tr>
    </table>
</asp:Content>
