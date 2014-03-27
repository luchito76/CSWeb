<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListaAutorizados.aspx.cs" Inherits="CuotaSystem.ListaAutorizados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary" id="form">
        <div class="panel-heading">
            <h2 class="panel-title">Listado de Familiares Autorizados</h2>
        </div>
        <div class="bs-example table-responsive">
            <asp:GridView ID="gdvListaFliaAutorizada" runat="server" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="false"
                DataKeyNames="idAutorizado" EmptyDataText="No se encontraron familiares del alumno" OnRowCommand="gdvListaFliaAutorizada_RowCommand" >
                <Columns>
                    <asp:TemplateField HeaderText="Nombre y Apellido">
                        <ItemTemplate>
                            <asp:LinkButton ID="NombreCompleto" Text='<%#Eval("Autorizado")%>' CommandName="FliaAutorizada" runat="server"
                                AlternateText="Editar Autorizado" CommandArgument='<%# Eval("idAutorizado" )%>' />
                        </ItemTemplate>
                    </asp:TemplateField>                                        
                    <asp:BoundField DataField="TelefonoFijo" HeaderText="Tel. Fijo" ></asp:BoundField>
                    <asp:BoundField DataField="TelefonoCelular" HeaderText="Tel. Celular"></asp:BoundField>
                    <asp:BoundField DataField="direccion" HeaderText="Dirección" ></asp:BoundField>                    
                    <asp:BoundField DataField="Mail" HeaderText="Mail" ></asp:BoundField>
                    <asp:BoundField DataField="Alumno" HeaderText="Alumno" ></asp:BoundField>
                    <asp:BoundField DataField="Relacion" HeaderText="Relación" ></asp:BoundField>                    
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
