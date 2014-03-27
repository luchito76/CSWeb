<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditarConcepto.aspx.cs" Inherits="CuotaSystem.EditarConcepto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary" id="form">
        <div class="panel-heading">
            <h2 class="panel-title">Modificar Conceptos</h2>
        </div>
        <div class="form-group">
            <b>
                <asp:Label ID="lblTipoDeConcepto" runat="server" Text="Tipo De Concepto" for="ddlTipoDeConcepto" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <asp:DropDownList ID="ddlTipoDeConcepto" runat="server" CssClass="form-control" DataTextField="nombre" DataValueField="idTipoDeConcepto"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvTipoDeConcepto" runat="server" ErrorMessage="Ingrese Tipo De Concepto" ControlToValidate="ddlTipoDeConcepto"
                    Display="Static" InitialValue="0" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <b>
                <asp:Label ID="lblDescripción" runat="server" Text="Descripción" for="txtDescripción" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <asp:TextBox runat="server" class="form-control" ID="txtDescripcion" placeholder="Descripción"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDescripcion" ControlToValidate="txtDescripcion" runat="server"
                    ErrorMessage="Ingrese Concepto" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>


        </div>

        <div class="form-group">
            <b>
                <asp:Label ID="lblValorConcepto" runat="server" Text="Valor Concepto" for="txtValorConcepto" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <asp:TextBox runat="server" class="form-control" ID="txtValorConcepto" placeholder="Valor Concepto"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvValorConcepto" ControlToValidate="txtValorConcepto" runat="server"
                    ErrorMessage="Ingrese Concepto" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <b>
                <asp:Label ID="lblConceptoActivo" runat="server" Text="Activo" for="conceptoActivo" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <label for="activo" class="checkbox inline">
                    <input id="conceptoActivo" type="checkbox" value="conceptoActivo" runat="server" />
                </label>
            </div>
        </div>

        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-4">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CausesValidation="true" class="btn btn-primary" OnClick="btnGuardar_Click" />
            </div>

            <div id="alerta" runat="server" visible="false" class="col-lg-4">
                <div class="alert alert-dismissable alert-success">
                    <button id="btnAlerta" type="button" class="close" data-dismiss="alert">&times;</button>
                    <strong>El Concepto se modificó correctamente.</strong><br />
                    <strong>Aguarde un Momento.</strong>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
