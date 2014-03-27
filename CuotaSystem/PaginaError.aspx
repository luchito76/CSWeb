<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PaginaError.aspx.cs" Inherits="CuotaSystem.PaginaError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Scripts/Alerta/jquery.alerts.css" rel="stylesheet" />

    <asp:Panel ID="pnlError" runat="server" Visible="true" HorizontalAlign="Center">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/imagenes/error.jpg" Width="800px" Height="550px" />
    </asp:Panel>

    <script src="Scripts/Alerta/jquery-1.4.2.min.js"></script>
    <script src="Scripts/Alerta/jquery.alerts.mod.js"></script>
    <script src="Scripts/Alerta/jquery.ui.draggable.js"></script>
</asp:Content>
