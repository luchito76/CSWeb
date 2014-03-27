<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarHermano.aspx.cs" Inherits="CuotaSystem.AgregarHermano" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dos Horizontes</title>

    <link href="Bootstrap/css/bootstrap.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />

</head>
<body>
    <div class="container_popup">
        <div class="page-header">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/imagenes/logo.png" Width="200px" Height="100px" />
        </div>
        <form id="form1" class="form-horizontal" runat="server">
            <div class="panel panel-primary" id="form2">
                <div class="panel-heading">
                    <h2 class="panel-title">Agregar Hermanos</h2>
                </div>
                <div class="form-group">
                    <b>
                        <asp:Label ID="lblAlumno" runat="server" Text="Alumno" for="ddlAlumno" class="col-xs-3 control-label">      
                        </asp:Label></b>
                    <div class="col-xs-7" style="margin-bottom: 10px;">
                        <asp:DropDownList ID="ddlAlumno" runat="server" class="form-control" DataTextField="Nombre" DataValueField="idAlumno">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvAlumno" runat="server" ErrorMessage="Seleccione un Alumno" ControlToValidate="ddlAlumno"
                            Display="Static" InitialValue="0" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>

                    <b>
                        <asp:Label ID="lblHermano" runat="server" Text="Hermano" for="ddlHermano" class="col-xs-3 control-label">
                        </asp:Label></b>
                    <div class="col-xs-7">
                        <asp:DropDownList ID="ddlHermano" runat="server" CssClass="form-control" DataTextField="Nombre"
                            DataValueField="idAlumno">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvHermano" runat="server" ErrorMessage="Seleccione un Alumno" ControlToValidate="ddlAlumno"
                            Display="Static" InitialValue="0" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-2">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-primary" OnClick="btnGuardar_Click" />
                    </div>

                    <div id="alerta" runat="server" class="col-xs-6">
                        <div class="alert alert-dismissable alert-success">
                            <button id="btnAlerta" type="button" class="close" data-dismiss="alert">&times;</button>
                            <strong>El Hermano se asoció correctamente.</strong>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </div>

    <script src="Bootstrap/Bootstrap3/bootstrap.min.js"></script>
</body>
</html>
