<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RegistrarPagos.aspx.cs" Inherits="CuotaSystem.RegistrarPagos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel-group" id="accordion">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">Registrar Pagos
                    </a>
                </h4>
            </div>
            <div id="collapseOne" class="panel-collapse collapse in">
                <div class="panel-body">
                    <div class="panel panel-primary" id="form">
                        <div class="panel-heading">
                            <h2 class="panel-title">Pagos</h2>
                        </div>

                        <div class="form-group">
                            <b>
                                <asp:Label ID="lblAlumno" runat="server" Text="Alumno" for="txtAlumno" class="col-sm-2 control-label">
                                </asp:Label></b>
                            <div id="typehead" visible="true" class="col-sm-3" runat="server">
                                <input type="text" class="form-control required typeahead" id="county" name='county' placeholder="Alumnos" autocomplete="off" />
                                <%--<asp:TextBox class="form-control required typeahead" ID="county" name="county" placeholder="Alumnos" runat="server"></asp:TextBox>--%>
                                <asp:HiddenField ID="hdnAlumno" runat="server" />
                                <asp:HiddenField ID="hdnNombreAlumno" runat="server" />
                            </div>
                            <div id="alumnoTypehead" visible="false" class="col-sm-3" runat="server">
                                <asp:TextBox ID="txtAlumno" runat="server" class="form-control" ReadOnly="true" placeholder="Alumnos"></asp:TextBox>
                            </div>


                            <b>
                                <asp:Label ID="lblFechaPago" runat="server" Text="Fecha de Pago" for="dtpFechaPago" class="col-sm-2 control-label">      
                                </asp:Label></b>

                            <div class="form-group">
                                <div class="input-group date form_date col-md-3" data-date="" data-date-format="dd MM yyyy" data-link-field="dtp_input2" data-link-format="dd-mm-yyyy">
                                    <asp:TextBox runat="server" ID="dtpFechaPago" class="form-control" data-date-format="dd/mm/yyyy" placeholder="dd/mm/aaaa">                    
                                    </asp:TextBox>
                                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar" /></span>
                                </div>
                                <input type="hidden" id="dtp_input2" value="" /><br />
                            </div>
                        </div>


                        <div class="form-group">
                            <b>
                                <asp:Label ID="lblTipoDeConcepto" runat="server" Text="Tipo De Concepto" for="ddlTipoDeConcepto" class="col-sm-2 control-label">      
                                </asp:Label></b>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="ddlTipoDeConcepto" runat="server" CssClass="form-control" DataTextField="nombre" DataValueField="idTipoDeConcepto" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoDeConcepto_SelectedIndexChanged"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvTipoDeConcepto" runat="server" ErrorMessage="Ingrese Tipo De Concepto" ControlToValidate="ddlTipoDeConcepto"
                                    Display="Static" InitialValue="0" ForeColor="Red">
                                </asp:RequiredFieldValidator>
                            </div>

                            <b>
                                <asp:Label ID="lblConcepto" runat="server" Text="Concepto" for="ddlConcepto" class="col-sm-2 control-label">
                                </asp:Label></b>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="ddlConcepto" runat="server" CssClass="form-control" DataTextField="nombre" DataValueField="idConcepto" Enabled="False">
                                </asp:DropDownList>
                                <%--<asp:TextBox ID="txtConcepto" ReadOnly="true" runat="server"></asp:TextBox>--%>
                            </div>


                        </div>

                        <div class="form-group">
                            <b>
                                <asp:Label ID="lblValorConcepto" runat="server" Text="Valor Concepto" for="txtValorConcepto" class="col-sm-2 control-label">      
                                </asp:Label></b>
                            <div class="col-sm-3">
                                <asp:TextBox runat="server" class="form-control" ID="txtValorConcepto" placeholder="Valor del Concepto" ReadOnly="true"></asp:TextBox>
                            </div>

                            <b>
                                <asp:Label ID="lblValorDePago" runat="server" Text="Valor a Pagar" for="txtValorDePago" class="col-sm-2 control-label">      
                                </asp:Label></b>
                            <div class="col-sm-3">
                                <asp:TextBox runat="server" class="form-control" ID="txtValoraPagar" placeholder="Saldo a Pagar" AutoPostBack="true" OnTextChanged="txtValorDePago_TextChanged"></asp:TextBox>
                            </div>




                        </div>

                        <div class="form-group">
                            <b>
                                <asp:Label ID="lblSaldo" runat="server" Text="Saldo" for="txtSaldo" class="col-sm-2 control-label">      
                                </asp:Label></b>
                            <div class="col-sm-3">
                                <asp:TextBox runat="server" class="form-control" ID="txtSaldo" placeholder="Saldo" ReadOnly="true"></asp:TextBox>
                            </div>

                            <b>
                                <asp:Label ID="lblObservaciones" runat="server" Text="Observaciones" for="txtObservaciones" class="col-sm-2 control-label">      
                                </asp:Label></b>
                            <div class="col-sm-3">
                                <asp:TextBox runat="server" class="form-control" ID="txtObservaciones" placeholder="Observaciones" TextMode="MultiLine" Rows="3"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <b>
                                <asp:Label ID="lblValorDeConceptoConDescuento" runat="server" Text="Concepto con Descuento" Visible="false" for="txtValorConceptoConDescuento" class="col-sm-2 control-label">      
                                </asp:Label></b>
                            <div class="col-sm-3">
                                <asp:TextBox runat="server" class="form-control" ID="txtValorConceptoConDescuento" Visible="false" ReadOnly="true"></asp:TextBox>
                            </div>



                            <div id="alerta" runat="server" class="col-lg-5" visible="true">
                                <div class="alert alert-dismissable alert-success">
                                    <button id="btnAlerta" type="button" class="close" data-dismiss="alert">&times;</button>
                                    <strong>El Pago se generó correctamente.</strong>
                                </div>
                            </div>

                            <div id="alertaAlumno" runat="server" class="col-lg-5" visible="false">
                                <div class="alert alert-dismissable alert-warning">
                                    <button id="btnAlertaAlumno" type="button" class="close" data-dismiss="alert">&times;</button>
                                    <strong>Debe seleccionar un alumno</strong>
                                </div>
                            </div>

                            <div id="error" runat="server" class="col-lg-5" visible="false">
                                <div class="alert alert-danger alert-dismissable">
                                    <button id="btnError" type="button" class="close" data-dismiss="alert">&times;</button>
                                    <strong>El Valor del Pago es mayor al Valor a Pagar.</strong>
                                </div>
                            </div>

                            <div id="inscripcionError" runat="server" class="col-lg-5" visible="false">
                                <div class="alert alert-danger alert-dismissable">
                                    <button id="btnInscripcionError" type="button" class="close" data-dismiss="alert">&times;</button>
                                    <strong>El alumno debe estar inscripto en una cursada.</strong>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-offset-2 col-sm-4">
                                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-primary" OnClick="btnGuardar_Click" />
                                <asp:Button ID="btnLImpiar" runat="server" Text="Limpiar" class="btn btn-primary" OnClick="btnLImpiar_Click" />
                            </div>
                        </div>

                        <div class="alert alert-info text-center">
                            <h3>
                                <asp:Label ID="lblConceptoAPagar" Visible="false" runat="server"></asp:Label></h3>
                            <h3 id="h3ValorAPagar" visible="false" runat="server">Valor a Pagar: $ <strong>
                                <asp:Label ID="lblValorAPagar" Visible="false" runat="server"></asp:Label></strong></h3>
                        </div>


                    </div>
                </div>
            </div>
        </div>
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">Registrar Descuentos
                    </a>
                </h4>
            </div>
            <div id="collapseTwo" class="panel-collapse collapse">
                <div class="panel-body">
                    <div class="panel panel-primary" id="form">
                        <div class="panel-heading">
                            <h2 class="panel-title">Alta Alumnos</h2>
                        </div>

                        <div class="form-group">
                            <b>
                                <asp:Label ID="Label1" runat="server" Text="Nombre" for="txtNombre" class="col-sm-2 control-label">      
                                </asp:Label></b>
                            <div class="col-sm-3">
                                <asp:TextBox runat="server" class="form-control" ID="TextBox1" placeholder="Nombre"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese un Nombre" ControlToValidate="txtNombre" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                            </div>


                            <b>
                                <asp:Label ID="Label2" runat="server" Text="Apellido" for="txtApellido" class="col-sm-2 control-label">      
                                </asp:Label></b>
                            <div class="col-sm-3">
                                <asp:TextBox runat="server" class="form-control" ID="TextBox2" placeholder="Apellido"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ingrese un Apellido" ControlToValidate="txtApellido" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>

    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/1.9.1/jquery.js"></script>

    <script src="bootstrap3-typeahead.js"></script>

   

    <script>
        var productNames = new Array();
        var productIds = new Object();
        $('#county').typeahead({
            source: function (query, process) {
                states = [];
                map = {};

                var data = <%=llenarAutocomplete()%>
                //var data = [
                //    { "stateCode": "CA", "stateName": "California" },
                //    { "stateCode": "AZ", "stateName": "Arizona" },
                //    { "stateCode": "NY", "stateName": "New York" },
                //    { "stateCode": "NV", "stateName": "Nevada" },
                //    { "stateCode": "OH", "stateName": "Ohio" }
                //];

                $.each(data, function (i, state) {
                    map[state.stateName] = state;
                    states.push(state.stateName);
                });

                process(states);
            },
            updater: function (item) {
                selectedState = map[item].stateCode;
                selectedName = map[item].stateName;
                document.getElementById("<%=hdnAlumno.ClientID%>").value = selectedState;
                document.getElementById("<%=hdnNombreAlumno.ClientID%>").value = selectedName;

                return item;
            },

        });

    </script>

</asp:Content>
