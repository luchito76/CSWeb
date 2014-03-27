<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditarAutorizados.aspx.cs" Inherits="CuotaSystem.EditarAutorizados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary" id="form">
        <div class="panel-heading">
            <h2 class="panel-title">Alta Flia Autorizada</h2>
        </div>
        <div class="form-group">
            <b>
                <asp:Label ID="lblNombre" runat="server" Text="Nombre" for="txtNombre" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <asp:TextBox runat="server" class="form-control" ID="txtNombre" placeholder="Nombre"></asp:TextBox>
            </div>

            <b>
                <asp:Label ID="lblApellido" runat="server" Text="Apellido" for="txtApellido" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <asp:TextBox runat="server" class="form-control" ID="txtApellido" placeholder="Apellido"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <b>
                <asp:Label ID="lblTelCelular" runat="server" Text="Tel. Celular" for="txtTelCelular" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <asp:TextBox runat="server" class="form-control" ID="txtTelCelular" placeholder="Tel. Celular"></asp:TextBox>
            </div>

            <b>
                <asp:Label ID="lblTelFijo" runat="server" Text="Tel. Fijo" for="txtTelFijo" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <asp:TextBox runat="server" class="form-control" ID="txtTelFijo" placeholder="Tel. Fijo"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <b>
                <asp:Label ID="lblDireccion" runat="server" Text="Dirección" for="txtDireccion" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <asp:TextBox runat="server" class="form-control" ID="txtDireccion" placeholder="Dirección"></asp:TextBox>
            </div>

            <b>
                <asp:Label ID="lblMail" runat="server" Text="e-Mail" for="txtMail" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <asp:TextBox runat="server" class="form-control" ID="txtMail" placeholder="e-Mail"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-4">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-primary" OnClick="btnGuardar_Click" />
                <input type="button" class="btn btn-primary launch-modal" value="Cargar Autorizados" />
            </div>

            <div id="alerta" runat="server" visible="false" class="col-lg-4">
                <div class="alert alert-dismissable alert-success">
                    <button id="btnAlerta" type="button" class="close" data-dismiss="alert">&times;</button>
                    <strong>El Familiar se modificó correctamente.</strong><br />
                    <strong>Aguarde un Momento.</strong>
                </div>
            </div>
        </div>

    </div>

    <script type="text/javascript">
        function validarNumero(evt, buttonid) {
            var carCode;
            if (window.event)
                carCode = window.event.keyCode; //IE
            else
                carCode = e.which; //firefox
            var bt = document.getElementById(buttonid);
            if (bt) {
                if (carCode < 48 || carCode > 57) {
                    if (carCode.keyCode == 13)
                        bt.click();
                    return false;
                }
            }
        }
    </script>
</asp:Content>
