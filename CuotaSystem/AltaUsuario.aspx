<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AltaUsuario.aspx.cs" Inherits="CuotaSystem.AltaUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                <asp:Label ID="lblUsuario" runat="server" Text="Usuario" for="txtUsuario" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <asp:TextBox runat="server" class="form-control" ID="txtUsuario" placeholder="Usuario"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ErrorMessage="Ingrese un Usuario" ControlToValidate="txtUsuario" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <b>
                <asp:Label ID="lblRolUsuario" runat="server" Text="Rol de Usuario" for="txtRolUsuario" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <label for="lblRolSuper" class="radio">
                    <input id="chkRolSuper" type="radio" value="usuarioSuper" runat="server" />
                    Super Usuario                    
                </label>
                <label for="lblRolAdmin" class="radio">
                    <input id="chkrolAdmin" type="radio" value="usuarioAdmin" runat="server" checked />
                    Administrativo
                </label>
            </div>
        </div>

        <div class="form-group">
            <b>
                <asp:Label ID="lblContraseña" runat="server" Text="Contraseña" for="txtContraseña" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <asp:TextBox runat="server" class="form-control" TextMode="Password" ID="txtContraseña" placeholder="Contraseña"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese un Contraseña" ControlToValidate="txtContraseña" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>


            <b>
                <asp:Label ID="lblContraseñaValida" runat="server" Text="Repetir Contraseña" for="txtContraseñaValida" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <asp:TextBox runat="server" class="form-control" TextMode="Password" ID="txtContraseñaValida" placeholder="Contraseña"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvContraseñaValida" runat="server" ErrorMessage="Ingrese un Contraseña" ControlToValidate="txtContraseñaValida" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>

         <div class="form-group">
            <div class="col-sm-offset-2 col-sm-4">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-primary" OnClick="btnGuardar_Click" />              
            </div>

            <div id="alerta" runat="server" class="col-lg-4" visible="false">
                <div class="alert alert-dismissable alert-success">
                    <button id="btnAlerta" type="button" class="close" data-dismiss="alert">&times;</button>
                    <strong>El Usuario se creó correctamente.</strong>
                </div>
            </div>

            <div id="errorClave" runat="server" class="col-lg-4" visible="false">
                <div class="alert alert-dismissable alert-success">
                    <button id="btnClave" type="button" class="close" data-dismiss="alert">&times;</button>
                    <strong>Las contraseñas ingresadas no coinciden.</strong>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
