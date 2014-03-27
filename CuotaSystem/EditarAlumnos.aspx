<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditarAlumnos.aspx.cs" Inherits="CuotaSystem.EditarAlumnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="//eternicode.github.io/bootstrap-datepicker/bootstrap-datepicker/css/datepicker.css"></script>

    <div class="panel panel-primary" id="form">
        <div class="panel-heading">
            <h2 class="panel-title">Alta Alumnos</h2>
        </div>

        <div class="form-group">
            <b>
                <asp:Label ID="lblNombre" runat="server" Text="Nombre" for="txtNombre" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <asp:TextBox runat="server" class="form-control" ID="txtNombre" placeholder="Nombre"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="Ingrese un Nombre" ControlToValidate="txtNombre" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>


            <b>
                <asp:Label ID="lblApellido" runat="server" Text="Apellido" for="txtApellido" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <asp:TextBox runat="server" class="form-control" ID="txtApellido" placeholder="Apellido"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ErrorMessage="Ingrese un Apellido" ControlToValidate="txtApellido" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group">
            <b>
                <asp:Label ID="lblDni" runat="server" Text="DNI" for="txtDni" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <asp:TextBox runat="server" class="form-control" ID="txtDni" placeholder="DNI"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDni" runat="server" ErrorMessage="Ingrese DNI" ControlToValidate="txtDni" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <b>
                <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha Nacimiento" for="dtpFechaNacimiento" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <asp:TextBox runat="server" ID="dtpFechaNacimiento" class="datepicker form-control" data-date-format="dd/mm/yyyy" placeholder="dd/mm/aaaa">                    
                </asp:TextBox>
            </div>
        </div>


        <div class="form-group">
            <b>
                <asp:Label ID="lblEscuela" runat="server" Text="Escuela" for="ddlEscuela" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <asp:DropDownList ID="ddlEscuela" runat="server" CssClass="form-control" DataTextField="nombre" DataValueField="idEscuela" AutoPostBack="false"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvEscuela" runat="server" ErrorMessage="Ingrese Escuela" ControlToValidate="ddlEscuela"
                    Display="Static" InitialValue="0" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <b>
                <asp:Label ID="lblGrado" runat="server" Text="Grado en Curso" for="ddlGrado" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <asp:DropDownList ID="ddlGrado" runat="server" CssClass="form-control" DataTextField="nombre" DataValueField="idgrado"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvGrado" runat="server" ErrorMessage="Ingrese Grado" ControlToValidate="ddlGrado"
                    Display="Static" InitialValue="0" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group">
            <b>
                <asp:Label ID="lblTurno" runat="server" Text="Turno" for="ddlTurno" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <asp:DropDownList ID="ddlTurno" runat="server" CssClass="form-control">
                    <asp:ListItem Text="--Seleccione--" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Mañana" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Tarde" Value="2"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <b>
                <asp:Label ID="lblTelefono" runat="server" Text="Teléfono" for="txtTelefono" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <asp:TextBox runat="server" class="form-control" ID="txtTelefono" placeholder="Teléfono"></asp:TextBox>
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
                <asp:Label ID="lblCiudad" runat="server" Text="Ciudad" for="txtCiudad" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <asp:TextBox runat="server" class="form-control" ID="txtCiudad" placeholder="Ciudad"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <b>
                <asp:Label ID="lblTipoDeAlumno" runat="server" Text="Tipo De Alumno" for="ddlTipoDeAlumno" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <asp:DropDownList ID="ddlTipoDeAlumno" runat="server" CssClass="form-control" DataTextField="nombre" DataValueField="idTipoAlumno">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvTipoDeAlumno" runat="server" ErrorMessage="Seleccione un Tipo De Alumno" ControlToValidate="ddlTipoDeAlumno"
                    Display="Static" InitialValue="0" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <b>
                <asp:Label ID="lblObservaciones" runat="server" Text="Observaciones" for="txtObservaciones" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <asp:TextBox ID="txtObservaciones" class="form-control" Rows="2" TextMode="MultiLine" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <b>
                <asp:Label ID="lblNombrePadre" runat="server" Text="Nombre del Padre" for="txtNombrePadre" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <asp:TextBox runat="server" class="form-control" ID="txtNombrePadre" placeholder="Nombre y Apellido del Padre"></asp:TextBox>
            </div>

            <b>
                <asp:Label ID="lblNombreMadre" runat="server" Text="Nombre de la Madre" for="txtNombreMadre" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <asp:TextBox runat="server" class="form-control" ID="txtNombreMadre" placeholder="Nombre y Apellido de la Madre"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <b>
                <asp:Label ID="Label1" runat="server" Text="Libreta Sanitaria" for="option1" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <label for="LIbretaSanitaria" class="checkbox inline">
                    <input id="chkLibretaSanitaria" type="checkbox" value="cursoActivo" runat="server" />
                    Marque en caso de corresponder.              
                </label>
            </div>

            <b>
                <asp:Label ID="lblMail" runat="server" Text="e-Mail" for="txtMail" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-4">
                <asp:TextBox runat="server" class="form-control" ID="txtMail" placeholder="e-Mail"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <b>
                <asp:Label ID="lblAlumnoActivo" runat="server" Text="Activo" for="alumnoActivo" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <label for="activo" class="checkbox inline">
                    <input id="alumnoActivo" type="checkbox" value="alumnoActivo" runat="server" />
                </label>

            </div>
        </div>

        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-4">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-primary" OnClick="btnGuardar_Click" />
            </div>

            <div id="alerta" runat="server" visible="false" class="col-lg-5">
                <div class="alert alert-dismissable alert-success">
                    <button type="button" class="close" data-dismiss="alert">&times;</button>
                    <strong>El Alumno se modificó correctamente.
                        <br />
                        <br />
                        Guardando Datos...
                    </strong>
                </div>
            </div>
        </div>



    </div>

    <script type="text/javascript">
        $.getScript("https://raw.github.com/eternicode/bootstrap-datepicker/master/js/bootstrap-datepicker.js", function () {

            $('.datepicker').datepicker({
            })

            $('#dtpFechaNacimiento').datepicker()
            .on("changeDate", function (e) {
                autoclose: true;
                todayHighlight: true;
            });

            $('#dtpFechaNacimiento').datepicker()
            .on("changeDate", function (e) {
                autoclose: true;
                todayHighlight: true;
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
