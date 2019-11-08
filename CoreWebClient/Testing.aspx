<%@ Page Title="" Language="C#" MasterPageFile="~/DesktopLite.Master" AutoEventWireup="true"
    CodeBehind="Testing.aspx.cs" Inherits="CoreWebClient.TestingForm" EnableViewState="false" %>

<%@ Register Src="Controls/TestingUserControl.ascx" TagName="TestingUserControl"
    TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:PlaceHolder runat="server" Visible="false" ID="securityAlert">
        <div style="padding: 5px; background-color: #E00000; border-style: dotted; border-width: 1px;
            border-color: Blue; color: White;">
            ����������� ����� ����������� ������� �� ���� �����������. �������� �� ���� �������������
            � ���� ������. � ������ ���� ��� ��������� �������� � �� ������� ����� ����, ������
            �������� ���� ��������.
            <br />
            IP ����� ������� ����������:
            <asp:Label runat="server" ID="secondComputerAddress" /></div>
        <br />
    </asp:PlaceHolder>
    <asp:Label runat="server" ID="warningMessage" ForeColor="Red" Visible="false" />
    <uc:TestingUserControl ID="TestingHost" runat="server" />
</asp:Content>
