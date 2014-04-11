<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CuotaSystem.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cuota System</title>

    <link href="../Bootstrap/css/bootstrap.css" rel="stylesheet" />
    <link href="../Bootstrap/Bootstrap3/bootstrap-datetimepicker.min.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />

    <style type="text/css">
        body {
            background: url(http://mymaplist.com/img/parallax/back.png);
            background-color: #444;
            background: url(http://mymaplist.com/img/parallax/pinlayer2.png),url(http://mymaplist.com/img/parallax/pinlayer1.png),url(http://mymaplist.com/img/parallax/back.png);
        }

        .vertical-offset-100 {
            padding-top: 100px;
        }
    </style>


</head>

<body>

    <div id="wrap">
        <!-- Begin page content -->

        <div id="container" class="container">



            <div class="row vertical-offset-100">
                <div class="col-md-4 col-md-offset-4">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h3 class="panel-title">Ingrese al Sistema</h3>
                        </div>
                        <div class="panel-body">
                            <form accept-charset="UTF-8" role="form" runat="server">                                
                                <fieldset>
                                    <div class="form-group">
                                        <asp:TextBox runat="server" CssClass="form-control" ID="txtUsuario" placeholder="Usuario"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox runat="server" CssClass="form-control" TextMode="Password" ID="txtContraseña" placeholder="Contraseña"></asp:TextBox>
                                    </div>

                                    <button id="btnEntrar" onserverclick="btnEntrar_ServerClick" runat="server" type="button" class="btn btn-lg btn-primary btn-block">Ingresar</button>
                                </fieldset>
                            </form>
                        </div>
                    </div>
                </div>
            </div>

            <div id="alerta" runat="server" class="col-lg-14">
                <div class="alert alert-dismissable alert-warning">
                    <button id="btnAlerta" type="button" class="close" data-dismiss="alert">&times;</button>
                    <strong>Los datos ingresados son incorrectos.</strong>
                </div>
            </div>
        </div>
        <!--./container -->


        <%-- <div class="container">
            <div class="page-header">
                <asp:Image ID="Image1" runat="server" ImageUrl="../imagenes/logo.png" Width="300px" Height="150px" />
            </div>
            <form id="form" class="form-horizontal" runat="server">
                <div class="panel panel-primary center-block" id="form1">
                    <div class="panel-heading">
                        <h2 class="panel-title">Ingresar al Sistema</h2>
                    </div>

                    <div class="form-group">
                        <b>
                            <asp:Label ID="lblUsuario" runat="server" Text="Usuario" for="txtUsuario" class="col-sm-2 control-label">      
                            </asp:Label></b>
                        <div class="col-sm-3">
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtUsuario" placeholder="Usuario"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <b>
                            <asp:Label ID="lblContraseña" runat="server" Text="Contraseña" for="txtContraseña" class="col-sm-2 control-label">      
                            </asp:Label></b>
                        <div class="col-sm-3">
                            <asp:TextBox runat="server" CssClass="form-control" TextMode="Password" ID="txtContraseña" placeholder="Contraseña"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-4">
                            <button id="cargar" onserverclick="btnGuardar_Click" runat="server" type="button" class="btn btn-primary">Ingresar</button>
                        </div>

                        <div id="alerta" runat="server" class="col-lg-4">
                            <div class="alert alert-dismissable alert-warning">
                                <button id="btnAlerta" type="button" class="close" data-dismiss="alert">&times;</button>
                                <strong>Los datos ingresados son incorrectos.</strong>
                            </div>
                        </div>
                    </div>
                </div>
            </form>
        </div>--%>
    </div>

    <%--<div id="footer">
        <div class="container">
            <p class="text-muted credit">Calle Río Colorado entre Jujuy y Perón / Rincón de los Sauces, Neuquén</p>
            <p class="text-muted credit">Tels. de contacto: Tel: 54+0299+4468071 / 54+0299+155333772</p>
            <p class="text-muted credit"><a class="text-primary" href="http://doshorizontes.com.ar">www.doshorizontes.com.ar</a></p>
            <p class="dev">©2014 Luchito Fantasia</p>
        </div>
    </div>--%>

    <script src="../Bootstrap/Bootstrap3/jquery-1.8.3.min.js"></script>
    <script src="../Bootstrap/Bootstrap3/bootstrap.min.js"></script>

    <script src="http://mymaplist.com/js/vendor/TweenLite.min.js"></script>

    <script>
        $(document).ready(function () {
            $(document).mousemove(function (e) {
                TweenLite.to($('body'),
                   .5,
                   {
                       css:
                         {
                             'background-position': parseInt(event.pageX / 8) + "px " + parseInt(event.pageY / 12) + "px, " + parseInt(event.pageX / 15) + "px " + parseInt(event.pageY / 15) + "px, " + parseInt(event.pageX / 30) + "px " + parseInt(event.pageY / 30) + "px"
                         }
                   });
            });
        });
    </script>
</body>
</html>
