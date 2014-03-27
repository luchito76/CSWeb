<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ReportePagoMensual.aspx.cs" Inherits="CuotaSystem.Reportes.ReportePagoMensual" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="gdvReportePagoMensual" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered" OnRowDataBound="gdvReportePagoMensual_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Alumno" HeaderText="Alumno" ItemStyle-Width="20%"/>
            <asp:BoundField DataField="ValorConcepto" HeaderText="Valor de Cuota" />
            <asp:TemplateField HeaderText="Marzo" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <%--<asp:Label ID="lblMarzo" runat="server" Text='<%#Eval("Marzo") %>' />--%>
                    <asp:Image ID="imgMarzo" AlternateText='<%#Eval("Marzo") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Abril" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Image ID="imgAbril" AlternateText='<%#Eval("Abril") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Mayo" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Image ID="imgMayo" AlternateText='<%#Eval("Mayo") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Junio" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Image ID="imgJunio" AlternateText='<%#Eval("Junio") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Julio" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Image ID="imgJulio" AlternateText='<%#Eval("Julio") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Agosto" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Image ID="imgAgosto" AlternateText='<%#Eval("Agosto") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Setiembre" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Image ID="imgSetiembre" AlternateText='<%#Eval("Setiembre") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Octubre" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Image ID="imgOctubre" AlternateText='<%#Eval("Octubre") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Noviembre" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Image ID="imgNoviembre" AlternateText='<%#Eval("Noviembre") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Diciembre" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Image ID="imgDiciembre" AlternateText='<%#Eval("Diciembre") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <%--<asp:Button ID="btnPdf" runat="server" Text="PDF" OnClick="btnPdf_Click" />--%>
    <asp:ImageButton ID="ibtnPdf" ImageUrl="~/imagenes/Logo_PDF.png" Width="60 px" Height="60 px" runat="server" OnClick="btnPdf_Click" />
    <asp:ImageButton ID="btnExcel" ImageUrl="~/imagenes/Excel-Logo.jpg" Width="60 px" Height="60 px" runat="server" OnClick="btnExcel_Click" />
    <asp:GridView ID="gdvReporte" runat="server" HeaderStyle-BackColor="Red" ShowHeader="true"></asp:GridView>

</asp:Content>
