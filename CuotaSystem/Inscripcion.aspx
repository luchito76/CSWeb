<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Inscripcion.aspx.cs" Inherits="CuotaSystem.Inscripcion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary" id="form">
        <div class="panel-heading">
            <h2 class="panel-title">Inscripción</h2>
        </div>

        <div class="form-group">
            <b>
                <asp:Label ID="lblAlumno" runat="server" Text="Alumno" for="ddlAlumno" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <asp:DropDownList ID="ddlAlumno" runat="server" CssClass="form-control" DataTextField="nombre" DataValueField="idAlumno" AutoPostBack="false"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvAlumno" runat="server" ErrorMessage="Ingrese Alumno" ControlToValidate="ddlAlumno"
                    Display="Static" InitialValue="0" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <b>
                <asp:Label ID="lblCursada" runat="server" Text="Cursada" for="ddlCursada" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <asp:DropDownList ID="ddlCursada" runat="server" CssClass="form-control" DataTextField="nombre" DataValueField="idCursada"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCursada" runat="server" ErrorMessage="Ingrese Cursada" ControlToValidate="ddlCursada"
                    Display="Static" InitialValue="0" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>


        <div class="form-group">

            <b>
                <asp:Label ID="lblFechaInscripcion" runat="server" Text="FechaInscripción" for="dtpFechaInscripcion" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="form-group">
                <div class="input-group date form_date col-md-3" data-date="" data-date-format="dd MM yyyy" data-link-field="dtp_input2" data-link-format="dd-mm-yyyy">
                    <asp:TextBox runat="server" ID="dtpFechaInscripcion" class="form-control" data-date-format="dd/mm/yyyy" placeholder="dd/mm/aaaa">                    
                    </asp:TextBox>
                    <span class="input-group-addon" /><span class="glyphicon glyphicon-calendar" />
                </div>
                <input type="hidden" id="dtp_input2" value="" /><br />
            </div>


            <b>
                <asp:Label ID="lbObservaciones" runat="server" Text="Observaciones" for="txtObservaciones" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <asp:TextBox ID="txtObservaciones" class="form-control" Rows="2" TextMode="MultiLine" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-4">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-primary" OnClick="btnGuardar_Click" />
            </div>

            <div id="alerta" runat="server" class="col-lg-4">
                <div class="alert alert-dismissable alert-success">
                    <button id="btnAlerta" type="button" class="close" data-dismiss="alert">&times;</button>
                    <strong>El Alumno se inscribió correctamente.</strong>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
