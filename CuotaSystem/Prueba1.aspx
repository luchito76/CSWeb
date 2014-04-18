<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prueba1.aspx.cs" Inherits="CuotaSystem.Prueba1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="//datatables.net/download/build/nightly/jquery.dataTables.css" rel="stylesheet" type="text/css" />

    <script src="http://code.jquery.com/jquery-1.9.1.min.js"></script>
    <script src="//datatables.net/download/build/nightly/jquery.dataTables.js"></script>
    
    <script src="Bootstrap/Bootsrap2/DT_bootstrap.js"></script>
    
    <script type="text/javascript">

        $(document).ready(function () {
            $('#gdvPrueba').dataTable({
                "sDom": "<'row'<'span6'l><'span6'f>r>t<'row'<'span6'i><'span6'p>>"
            });
        });

        $.extend($.fn.dataTableExt.oStdClasses, {
            "sWrapper": "dataTables_wrapper form-inline"
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="search" class="light-table-filter" placeholder="Filtrer" />

            <asp:GridView ID="gdvPrueba" class="display" runat="server"></asp:GridView>
        </div>
    </form>





</body>
</html>
