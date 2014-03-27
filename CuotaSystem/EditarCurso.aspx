<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditarCurso.aspx.cs" Inherits="CuotaSystem.Cursos.EditarCurso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="panel panel-primary" id="form">
        <div class="panel-heading">
            <h2 class="panel-title">Editar Curso</h2>
        </div>
        <div class="form-group">
            <b>
                <asp:Label ID="lblDescripción" runat="server" Text="Descripción" for="txtDescripción" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <asp:TextBox runat="server" class="form-control" ID="txtDescripcion" placeholder="Descripción"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDescripcion" ControlToValidate="txtDescripcion" runat="server"
                    ErrorMessage="Ingrese Descripcion" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <b>
                <asp:Label ID="lblConceptoCuota" runat="server" Text="Concepto Cuota" for="ddlConceptoCuota" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <asp:DropDownList ID="ddlConceptoCuota" runat="server" CssClass="form-control" DataTextField="nombre" DataValueField="idConcepto"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvConceptoCuota" runat="server" ErrorMessage="Ingrese Concepto Cuota" ControlToValidate="ddlConceptoCuota"
                    Display="Static" InitialValue="0" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group">
            <b>
                <asp:Label ID="lblConceptoMatricula" runat="server" Text="Concepto Matrícula" for="ddlConceptoMatricula" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <asp:DropDownList ID="ddlConceptoMatricula" runat="server" CssClass="form-control" DataTextField="nombre" DataValueField="idConcepto"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese Concepto Matrícula" ControlToValidate="ddlConceptoMatricula"
                    Display="Static" InitialValue="0" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <b>
                <asp:Label ID="lblConceptoExamen" runat="server" Text="Concepto Examen" for="ddlConceptoExamen" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <asp:DropDownList ID="ddlConceptoExamen" runat="server" CssClass="form-control" DataTextField="nombre" DataValueField="idConcepto"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvConceptoExamen" runat="server" ErrorMessage="Ingrese Concepto Examen" ControlToValidate="ddlConceptoExamen"
                    Display="Static" InitialValue="0" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group">
            <b>
                <asp:Label ID="Label1" runat="server" Text="Activo" for="txtDireccion" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <label for="activo" class="checkbox inline">
                    <input id="cursoActivo" type="checkbox" value="cursoActivo" runat="server" />
                </label>

            </div>
        </div>

        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-4">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-primary" OnClick="btnGuardar_Click"></asp:Button>
            </div>
        </div>
    </div>
    <div id="alerta" runat="server" visible="false" class="col-lg-6">
        <div class="alert alert-dismissable alert-success">
            <button type="button" class="close" data-dismiss="alert">&times;</button>
            <strong>El Curso se editó correctamente
                <br />
                <br />
                En segundos será redirigido a Alta de Cursos.
            </strong>
        </div>
    </div>

</asp:Content>
