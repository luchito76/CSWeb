<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListaHermanos.aspx.cs" Inherits="CuotaSystem.ListaHermanos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary" id="form">
        <div class="panel-heading">
            <h2 class="panel-title">Consultar Hermanos</h2>
        </div>

        <div class="form-group">
            <b>
                <asp:Label ID="lblAlumno" runat="server" Text="Alumno" for="ddlAlumno" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <asp:DropDownList ID="ddlAlumno" runat="server" CssClass="form-control" DataTextField="Hermanos" DataValueField="idAlumno" AutoPostBack="true" OnSelectedIndexChanged="ddlAlumno_SelectedIndexChanged"></asp:DropDownList>
            </div>

            <div class="col-sm-4">
                <asp:GridView ID="gdvHermanos" Visible="false" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="false" runat="server">
                    <Columns>
                        <asp:BoundField DataField="Hermanos" HeaderText="Hermanos" ItemStyle-HorizontalAlign="Center" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
