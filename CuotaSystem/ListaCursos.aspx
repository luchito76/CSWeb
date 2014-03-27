<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListaCursos.aspx.cs" Inherits="CuotaSystem.Cursos.ListaCursos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary" id="form">
        <div class="panel-heading">
            <h2 class="panel-title">Listado de Cursos</h2>
        </div>
        <div class="bs-example table-responsive" id="page-selection">

            <asp:GridView ID="gdvListaCursos" runat="server" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="false"
                DataKeyNames="idCurso" EmptyDataText="No se encontraron cursos" OnRowCommand="gdvListaCursos_RowCommand" AllowPaging="true"
                PageSize="10" OnSelectedIndexChanging="gdvListaCursos_SelectedIndexChanging" OnPageIndexChanging="gdvListaCursos_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="Curso" HeaderStyle-Font-Size="Large" HeaderStyle-Font-Bold="true">
                        <ItemTemplate>
                            <asp:LinkButton ID="Planilla" Text='<%#Eval("nombre")%>' CommandName="Curso" runat="server"
                                AlternateText="Editar Curso" CommandArgument='<%# Eval("idCurso" )%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
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
                    showPrevNext: true,
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

            $('.gdvListaCursos').pageMe({ pagerSelector: '.myPager', showPrevNext: true, hidePageNumbers: false, perPage: 4 });

        });
    </script>
    <script src="//raw.github.com/botmonster/jquery-bootpag/master/lib/jquery.bootpag.min.js"></script>
</asp:Content>
