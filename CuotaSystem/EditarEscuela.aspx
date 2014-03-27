<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditarEscuela.aspx.cs" Inherits="CuotaSystem.EditarEscuela" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Scripts/Alerta/jquery.alerts.css" rel="stylesheet" />
    <div class="panel panel-primary" id="form">
        <div class="panel-heading">
            <h2 class="panel-title">Editar Escuela</h2>
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
        </div>

        <div class="form-group">
            <b>
                <asp:Label ID="Label1" runat="server" Text="Activo" for="txtDireccion" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <label for="activo" class="checkbox inline">
                    <input id="escuelaActivo" type="checkbox" value="escuelaActivo" runat="server" />
                </label>
            </div>
        </div>

        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-4">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-primary" OnClick="btnGuardar_Click"></asp:Button>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function Confirmacion() {
            jMessage('La Escuela se editó correctamente', 'Editar Escuela', function (r) {
                window.location = "ListaEscuelas.aspx";
            });
        }
    </script>

    <script src="Scripts/Alerta/jquery-1.4.2.min.js"></script>
    <script src="Scripts/Alerta/jquery.alerts.mod.js"></script>
    <script src="Scripts/Alerta/jquery.ui.draggable.js"></script>
</asp:Content>
