<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditarCursada.aspx.cs" Inherits="CuotaSystem.EditarCursada" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary" id="form">
        <div class="panel-heading">
            <h2 class="panel-title">Editar Cursada</h2>
        </div>
        <div class="form-group">
            <b>
                <asp:Label ID="lblCurso" runat="server" Text="Curso" for="txtCurso" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <asp:DropDownList ID="ddlCurso" runat="server" class="form-control" DataTextField="nombre" DataValueField="idCurso"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCurso" ControlToValidate="ddlCurso" runat="server"
                    ErrorMessage="Seleccione un Curso" ForeColor="Red" InitialValue="--Seleccione--"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group">
            <b>
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio" for="dtpFechaInicio" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="input-group date form_date col-md-3" data-date="" data-date-format="dd MM yyyy" data-link-field="dtp_input1" data-link-format="dd-mm-yyyy">
                <asp:TextBox runat="server" ID="dtpFechaInicio" class="form-control" data-date-format="dd/mm/yyyy" placeholder="dd/mm/aaaa">                    
                </asp:TextBox>
                <span class="input-group-addon" /><span class="glyphicon glyphicon-calendar" />
            </div>
            <input type="hidden" id="dtp_input1" value="" />

            <b>
                <asp:Label ID="lblFechaFin" runat="server" Text="Fecha Fin" for="dtpFechaFin" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="input-group date form_date col-md-3" data-date="" data-date-format="dd MM yyyy" data-link-field="dtp_input2" data-link-format="dd-mm-yyyy">
                <asp:TextBox runat="server" ID="dtpFechaFin" class="form-control" data-date-format="dd/mm/yyyy" placeholder="dd/mm/aaaa">                    
                </asp:TextBox>
                <span class="input-group-addon" /><span class="glyphicon glyphicon-calendar" />
            </div>
            <input type="hidden" id="dtp_input2" value="" />
        </div>

        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-4">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CausesValidation="true" class="btn btn-primary" OnClick="btnGuardar_Click" />
            </div>

            <div id="alerta" runat="server" visible="false" class="col-lg-4">
                <div class="alert alert-dismissable alert-success">
                    <button id="btnAlerta" type="button" class="close" data-dismiss="alert">&times;</button>
                    <strong>La cursada se modificó correctamente.</strong>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
