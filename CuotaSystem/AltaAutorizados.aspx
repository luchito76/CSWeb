<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AltaAutorizados.aspx.cs" Inherits="CuotaSystem.AltaFliaAutorizada" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript" src="http://code.jquery.com/jquery.min.js"></script>

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

            <div id="alerta" runat="server" class="col-lg-4">
                <div class="alert alert-dismissable alert-success">
                    <button id="btnAlerta" type="button" class="close" data-dismiss="alert">&times;</button>
                    <strong>El Familiar se creó correctamente.</strong>
                </div>
            </div>
        </div>

    </div>

    <div id="myModal" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">Familiar Autorizado</h4>
                </div>
                <div class="modal-body center-block">

                    <div class="form-group">
                        <b>
                            <asp:Label ID="lblAutorizado" runat="server" Text="Fliar Autorizado" for="ddlAutorizado" class="col-sm-2 control-label">      
                            </asp:Label></b>
                        <div class="col-sm-5">
                            <asp:DropDownList ID="ddlAutorizado" runat="server" class="form-control" DataTextField="Nombre" DataValueField="idAutorizado">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <b>
                            <asp:Label ID="lblAlumno" runat="server" Text="Alumno" for="txtAlumno" class="col-sm-2 control-label">
                            </asp:Label></b>
                        <div class="col-sm-5">
                            <asp:DropDownList ID="ddlAlumno" runat="server" CssClass="form-control" DataTextField="Nombre" DataValueField="idAlumno">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <b>
                            <asp:Label ID="lblParentesco" runat="server" Text="Parentesco" for="ddlParentesco" class="col-sm-2 control-label">      
                            </asp:Label></b>
                        <div class="col-sm-5">
                            <asp:DropDownList ID="ddlParentesco" runat="server" class="form-control" DataTextField="nombre" DataValueField="idParentesco">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <p class="text-warning"><span>Seleccione un familiar y el alumno que está autorizado a retirar.</span></p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-dismiss="modal">Cerrar</button>
                    <button id="cargar" onserverclick="cargar_Click" runat="server" type="button" class="btn btn-primary">Guardar</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->



    <script type="text/javascript">
        $(document).ready(function () {
            $('.launch-modal').click(function () {
                $('#myModal').modal({
                    keyboard: true
                });
            });
        });
    </script>

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
