<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AltaCurso.aspx.cs" Inherits="CuotaSystem.Cursos.AltaCurso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary" id="form">
        <div class="panel-heading">
            <h2 class="panel-title">Alta Cursos</h2>
        </div>
        <div class="form-group">
            <b>
                <asp:Label ID="lblDescripción" runat="server" Text="Descripción" for="txtDescripción" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <asp:TextBox runat="server" class="form-control" ID="txtDescripcion" placeholder="Descripción"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDescripcion" ControlToValidate="txtDescripcion" runat="server"
                    ErrorMessage="Ingrese Descripcion" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <b>
                <asp:Label ID="lblConceptoCuota" runat="server" Text="Concepto Cuota" for="ddlConceptoCuota" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <asp:DropDownList ID="ddlConceptoCuota" runat="server" CssClass="form-control" DataTextField="nombre" DataValueField="idConcepto"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvConceptoCuota" runat="server" ErrorMessage="Ingrese Concepto Cuota" ControlToValidate="ddlConceptoCuota"
                    Display="Static" InitialValue="0" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group">
            <b>
                <asp:Label ID="lblConceptoMatricula" runat="server" Text="Concepto Matrícula" for="ddlConceptoMatricula" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <asp:DropDownList ID="ddlConceptoMatricula" runat="server" CssClass="form-control" DataTextField="nombre" DataValueField="idConcepto"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese Concepto Matrícula" ControlToValidate="ddlConceptoMatricula"
                    Display="Static" InitialValue="0" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <b>
                <asp:Label ID="lblConceptoExamen" runat="server" Text="Concepto Examen" for="ddlConceptoExamen" class="col-sm-2 control-label">      
                </asp:Label></b>
            <div class="col-sm-3">
                <asp:DropDownList ID="ddlConceptoExamen" runat="server" CssClass="form-control" DataTextField="nombre" DataValueField="idConcepto"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvConceptoExamen" runat="server" ErrorMessage="Ingrese Concepto Examen" ControlToValidate="ddlConceptoExamen"
                    Display="Static" InitialValue="0" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>


        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-4">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CausesValidation="true" class="btn btn-primary" OnClick="btnGuardar_Click" />
            </div>
        </div>
    </div>

    <div class="panel panel-primary" id="form1">
        <div class="panel-heading">
            <h2 class="panel-title">Listado de Cursos</h2>
        </div>
        <div class="bs-example table-responsive" id="page-selection">
            <asp:GridView ID="gdvListaCursos" runat="server" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="false"
                DataKeyNames="idCurso" EmptyDataText="No se encontraron cursos" OnRowCommand="gdvListaCursos_RowCommand" AllowPaging="true"
                PageSize="5" OnSelectedIndexChanging="gdvListaCursos_SelectedIndexChanging" OnPageIndexChanging="gdvListaCursos_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="Curso" HeaderStyle-Font-Size="Large" HeaderStyle-Font-Bold="true">
                        <ItemTemplate>
                            <asp:HyperLink ID="hlinEdtitarCurso" Text='<%#Eval("nombre")%>' NavigateUrl='<%# "EditarCurso.aspx?idCurso=" + Eval("idCurso") %>' runat="server"></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
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

            $('.gdvListaCursos').pageMe({ pagerSelector: '.myPager', showPrevNext: true, hidePageNumbers: false, perPage: 4 });

        });
    </script>

</asp:Content>
