<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListaInscripciones.aspx.cs" Inherits="CuotaSystem.ListaInscripciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary" id="form">
        <div class="panel-heading">
            <h2 class="panel-title">Listado de Inscripciones</h2>
        </div>

         <div class="form-group">
            <b>
                <asp:Label ID="lblFiltro" runat="server" Text="Buscar Inscripción" for="txtNombre" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <input type="search" class="form-control light-table-filter" data-table="order-table" placeholder="Filtro" />
            </div>
        </div>

        <div id="page-selection" class="bs-example table-responsive">
            <asp:GridView ID="gdvListaInscripcion" runat="server" CssClass="table table-striped table-bordered table-hover order-table" AutoGenerateColumns="false"
                DataKeyNames="idInscripcion" EmptyDataText="No se encontraron Inscripciones" OnRowCommand="gdvListaInscripcion_RowCommand" AllowPaging="true" PageSize="10"
                OnSelectedIndexChanging="gdvListaInscripcion_SelectedIndexChanging" OnPageIndexChanging="gdvListaInscripcion_PageIndexChanging">

                <Columns>
                    <asp:TemplateField HeaderText="Apellid y Nombre" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton ID="NombreCompleto" Text='<%#Eval("Apellido") + " " + Eval("Nombre")%> ' CommandName="Alumnos" runat="server"
                                AlternateText="Lista Alumnos" CommandArgument='<%# Eval("idInscripcion" )%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="curso" HeaderText="Curso" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                    <asp:BoundField DataField="fechaInscripcion" HeaderText="Fecha de Inscripción" DataFormatString="{0:d}" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                    <asp:BoundField DataField="observaciones" HeaderText="Observaciones" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                </Columns>
                <PagerStyle CssClass="gridview" HorizontalAlign="Center" />
            </asp:GridView>
        </div>
    </div>

    <script>
        $.fn.pageMe = function (opts) {
            var $this = this,
                defaults = {
                    perPage: 7,
                    showPrevNext: false,
                    numbersPerPage: 5,
                    hidePageNumbers: false
                },
                settings = $.extend(defaults, opts);

            var listElement = $this;
            var perPage = settings.perPage;
            var children = listElement.children();
            var pager = $('.pagination');

            if (typeof settings.childSelector != "undefined") {
                children = listElement.find(settings.childSelector);
            }

            if (typeof settings.pagerSelector != "undefined") {
                pager = $(settings.pagerSelector);
            }

            var numItems = children.size();
            var numPages = Math.ceil(numItems / perPage);

            pager.data("curr", 0);

            if (settings.showPrevNext) {
                $('<li><a href="#" class="prev_link">«</a></li>').appendTo(pager);
            }

            var curr = 0;
            while (numPages > curr && (settings.hidePageNumbers == false)) {
                $('<li><a href="#" class="page_link">' + (curr + 1) + '</a></li>').appendTo(pager);
                curr++;
            }

            if (settings.numbersPerPage > 1) {
                $('.page_link').hide();
                $('.page_link').slice(pager.data("curr"), settings.numbersPerPage).show();
            }

            if (settings.showPrevNext) {
                $('<li><a href="#" class="next_link">»</a></li>').appendTo(pager);
            }

            pager.find('.page_link:first').addClass('active');
            pager.find('.prev_link').hide();
            if (numPages <= 1) {
                pager.find('.next_link').hide();
            }
            pager.children().eq(1).addClass("active");

            children.hide();
            children.slice(0, perPage).show();

            pager.find('li .page_link').click(function () {
                var clickedPage = $(this).html().valueOf() - 1;
                goTo(clickedPage, perPage);
                return false;
            });
            pager.find('li .prev_link').click(function () {
                previous();
                return false;
            });
            pager.find('li .next_link').click(function () {
                next();
                return false;
            });

            function previous() {
                var goToPage = parseInt(pager.data("curr")) - 1;
                goTo(goToPage);
            }

            function next() {
                goToPage = parseInt(pager.data("curr")) + 1;
                goTo(goToPage);
            }

            function goTo(page) {
                var startAt = page * perPage,
                    endOn = startAt + perPage;

                children.css('display', 'none').slice(startAt, endOn).show();

                if (page >= 1) {
                    pager.find('.prev_link').show();
                }
                else {
                    pager.find('.prev_link').hide();
                }

                if (page < (numPages - 1)) {
                    pager.find('.next_link').show();
                }
                else {
                    pager.find('.next_link').hide();
                }

                pager.data("curr", page);

                if (settings.numbersPerPage > 1) {
                    $('.page_link').hide();
                    $('.page_link').slice(page, settings.numbersPerPage + page).show();
                }

                pager.children().removeClass("active");
                pager.children().eq(page + 1).addClass("active");

            }
        };

        $(document).ready(function () {

            $('.gdvListaInscripcion').pageMe({ pagerSelector: '.myPager', showPrevNext: true, hidePageNumbers: false, perPage: 4 });

        });
    </script>
    <%--<script src="//raw.github.com/botmonster/jquery-bootpag/master/lib/jquery.bootpag.min.js"></script>--%>
</asp:Content>
