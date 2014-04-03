<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CuotaSystem.Login" ValidateRequest="false" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="//cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/2.3.2/css/bootstrap.css" rel="stylesheet" />

    <link href="Content/Site.css" rel="stylesheet" />

</head>
<body>
    <div id="wrap">
        <!-- Begin page content -->
        <div class="container">

            <div class="page-header">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/imagenes/logo.png" Width="300px" Height="150px" />
            </div>

            <form id="form" class="form-horizontal">
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-4">
                        <input type="button" class="button_example launch-modal" value="Entrar" />
                    </div>
                </div>

                <div align="center" style="margin-top: 70px;">
                    <asp:Image ID="imgPrincipal" runat="server" ImageUrl="~/imagenes/cuotasystem.png" ImageAlign="AbsMiddle" />
                </div>
            </form>

            <form id="form1" class="form-horizontal" runat="server">
                <div id="myModal" class="modal fade">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                <h4 class="modal-title">Ingresar a Cuota System</h4>
                            </div>
                            <div class="modal-body center-block">

                                <div class="form-group">
                                    <b>
                                        <asp:Label ID="lblUsuario" runat="server" Text="Usuario" for="txtUsuario" class="col-sm-2 control-label">      
                                        </asp:Label></b>
                                    <div class="col-sm-5">
                                        <asp:TextBox runat="server" CssClass="form-control" ID="txtUsuario" placeholder="Usuario"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <b>
                                        <asp:Label ID="lblContraseña" runat="server" Text="Contraseña" for="txtContraseña" class="col-sm-2 control-label">
                                        </asp:Label></b>
                                    <div class="col-sm-5">
                                        <asp:TextBox runat="server" CssClass="form-control" TextMode="Password" ID="txtContraseña" placeholder="Contraseña"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="alerta" runat="server" class="col-lg-4" visible="false">
                                    <div class="alert alert-dismissable alert-success">
                                        <button id="btnAlerta" type="button" class="close" data-dismiss="alert">&times;</button>
                                        <strong>Los datos ingresados son incorrectos.</strong>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button id="cargar" onserverclick="btnGuardar_Click" runat="server" type="button" class="btn btn-primary">Ingresar</button>
                            </div>
                        </div>
                        <!-- /.modal-content -->
                    </div>
                    <!-- /.modal-dialog -->
                </div>
                <!-- /.modal -->

            </form>
        </div>




        <div id="footer">
            <div class="container">
                <p class="text-muted credit">Calle Río Colorado entre Jujuy y Perón / Rincón de los Sauces, Neuquén</p>
                <p class="text-muted credit">Tels. de contacto: Tel: 54+0299+4468071 / 54+0299+155333772</p>
                <p class="text-muted credit"><a class="text-primary" href="http://doshorizontes.com.ar">www.doshorizontes.com.ar</a></p>
                <p class="dev">©2014 Luchito Fantasia</p>
            </div>
        </div>

        <script src="http://code.jquery.com/jquery.js"></script>
        <script src="//cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/2.3.2/js/bootstrap.js"></script>

        <script type="text/javascript">
            $(document).ready(function () {
                $('.launch-modal').click(function () {
                    $('#myModal').modal({
                        keyboard: true
                    });
                });
            });
        </script>

        <%--<script type="text/javascript">
        $(document).ready(function () {
            $('.launch-modal').click(function () {
                $('#myModal').modal({
                    keyboard: true
                });
            });
        });
    </script>--%>
</body>
</html>
