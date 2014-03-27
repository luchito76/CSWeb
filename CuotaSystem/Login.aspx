<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CuotaSystem.Login" %>

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

            <form id="form" class="form-horizontal" runat="server">
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-4">
                        
                        <input type="button" class="button_example launch-modal" value="Entrar" />
                    </div>

                    
                </div>               

                <div align="center" style="margin-top: 70px;">

                    <asp:Image ID="imgPrincipal" runat="server" ImageUrl="~/imagenes/informevirtual.png" ImageAlign="AbsMiddle" />
                </div>

            </form>

            <div id="myModal" class="modal fade hide">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">x</button>
                    <h3>Entrar a Cuota System</h3>
                </div>
                <div class="modal-body">
                    <form method="post" action='' name="login_form">
                        <p>
                            <input type="text" class="span3" name="eid" id="email" placeholder="Email" />
                        </p>
                        <p>
                            <input type="password" class="span3" name="passwd" placeholder="Clave" />
                        </p>
                        <p>
                            <button type="submit" class="btn btn-primary">Entrar</button>
                            <a href="#">Se olvidó la clave?</a>
                        </p>
                    </form>
                </div>
                <div class="modal-footer">
                    Dos Horizontes
            <a href="#" class="btn btn-primary">Registrarse</a>
                </div>
            </div>
        </div>
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
</body>
</html>
