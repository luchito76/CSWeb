<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ReporteDePagos.aspx.cs" Inherits="CuotaSystem.ReporteDePagos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group">
        <b>
            <asp:Label ID="lblFechaDesde" runat="server" Text="Fecha Desde" for="dtpFechaDesde" class="col-sm-2 control-label">      
            </asp:Label></b>
        <%-- <div class="form-group">--%>
        <div class="input-group date form_date col-md-3" data-date="" data-date-format="dd MM yyyy" data-link-field="dtp_input1" data-link-format="dd-mm-yyyy">
            <asp:TextBox runat="server" ID="dtpFechaDesde" class="form-control" data-date-format="dd/mm/yyyy" placeholder="dd/mm/aaaa">                    
            </asp:TextBox>
            <span class="input-group-addon" /><span class="glyphicon glyphicon-calendar" />
            <%-- </div>--%>
            <input type="hidden" id="dtp_input1" value="" /><br />
        </div>

        <b>
            <asp:Label ID="lblFechaHasta" runat="server" Text="Fecha Hasta" for="dtpFechaHasta" class="col-sm-2 control-label">      
            </asp:Label></b>
        <%--<div class="form-group">--%>
        <div class="input-group date form_date col-md-3" data-date="" data-date-format="dd MM yyyy" data-link-field="dtp_input2" data-link-format="dd-mm-yyyy">
            <asp:TextBox runat="server" ID="dtpFechaHasta" class="form-control" data-date-format="dd/mm/yyyy" placeholder="dd/mm/aaaa">                    
            </asp:TextBox>
            <span class="input-group-addon" /><span class="glyphicon glyphicon-calendar" />
            <%-- </div>--%>
            <input type="hidden" id="dtp_input2" value="" /><br />
        </div>
    </div>

    <div class="form-group">
        <div class="col-sm-offset-2 col-sm-4">
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" class="btn btn-primary" OnClick="btnBuscar_Click" />
        </div>
    </div>

    <div class="form-group">
        <b>
            <asp:Label ID="lblFiltro" runat="server" Text="Buscar Pago" for="txtNombre" class="col-sm-2 control-label">      
            </asp:Label></b>
        <div class="col-sm-3">
            <input type="search" class="form-control light-table-filter" data-table="order-table" placeholder="Filtro" />
        </div>
    </div>

    <asp:GridView ID="gdvReporteDiario" runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="#FF4500" ShowFooter="true"
        HeaderStyle-ForeColor="White" class="table table-bordered table-hover table-responsive order-table" OnRowDataBound="gdvReporteDiario_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="Alumno">
                <ItemTemplate>
                    <asp:Label ID="lblAlumno" runat="server" Text='<%#Eval("Alumno") %>' />
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lblAlumno" Text="Total" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="#1a7393" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pago">
                <ItemTemplate>
                    <asp:Label ID="lblPago" runat="server" Text='<%#String.Format("{0:C}", Eval("Pago")) %>' />
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lblTotal" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="#1a7393" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="FechaPago" HeaderText="Fecha de Pago" DataFormatString="{0:d}" />
            <asp:BoundField DataField="Concepto" HeaderText="Concepto" />
            <asp:BoundField DataField="Meses" HeaderText="Mes" />
        </Columns>
    </asp:GridView>

    <asp:GridView ID="gdvReporteDiarioTemp" runat="server"></asp:GridView>
    <asp:ImageButton ID="ibtnPdf" ImageUrl="~/imagenes/Logo_PDF.png" Width="60 px" Height="60 px" runat="server" OnClick="btnPdf_Click" />
    <asp:ImageButton ID="btnExcel" ImageUrl="~/imagenes/Excel-Logo.jpg" Width="60 px" Height="60 px" runat="server" OnClick="btnExcel_Click" />
</asp:Content>
