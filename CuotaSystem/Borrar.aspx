<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Borrar.aspx.cs" Inherits="CuotaSystem.Borrar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/1.9.1/jquery.js"></script>

    <link href="Bootstrap/Bootstrap3/bootstrap.css" rel="stylesheet" />
    <script src="Bootstrap/Bootstrap3/bootstrap.js"></script>


    <script src="bootstrap3-typeahead.js"></script>

   
</head>
<body>
    
    <form runat="server">
        <div>
            <input id="county" type="text" data-provide="typeahead" autocomplete="off" />
            <asp:HiddenField ID="hdfALumno" runat="server"></asp:HiddenField>
        </div>
    </form>



    <script>

        var productNames = new Array();
        var productIds = new Object();
        $('#county').typeahead({
            source: function (query, process) {
                states = [];
                map = {};

                var data = [
                    { "stateCode": "CA", "stateName": "California" },
                    { "stateCode": "AZ", "stateName": "Arizona" },
                    { "stateCode": "NY", "stateName": "New York" },
                    { "stateCode": "NV", "stateName": "Nevada" },
                    { "stateCode": "OH", "stateName": "Ohio" }
                ];

                $.each(data, function (i, state) {
                    map[state.stateName] = state;
                    states.push(state.stateName);
                });

                process(states);
            },
            updater: function (item) {
                selectedState = map[item].stateCode;
                document.getElementById("<%=hdfALumno.ClientID%>").value = selectedState;
                return item;
            }

        });

    </script>


</body>
</html>
