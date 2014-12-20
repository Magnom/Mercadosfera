window.webapi = "http://www.webpre.webapi.mercadosfera.es/api";
window.debug = true;

function writeLog(pText)
{
    if (window.debug) {
        console.log(pText);
    }
}

function deleteVendedor()
{

    $.ajax({
        url: window.webapi + "/Vendedores/" + $("#OrchardID").val(),
        type: 'DELETE',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        crossDomain: true,

        success: function (data, textStatus, xhr) {
            console.log(data);
        },
        error: function (xhr, textStatus, errorThrown) {
            if (xhr.status != 200) {
                console.log(xhr);
            }
        }
    });

}

function getVendedores() {
    
    writeLog("getVendedores");


    $.get(window.webapi + "/Vendedores", function (data) {
        $("#pLista").html(JSON.stringify(data));
    });

}

function getVendedor() {

    writeLog("getVendedor");

    $.get(window.webapi + "/Vendedores/" + $("#IdVendedor").val(), function (data) {
        $("#OrchardID").val(data.OrchardId);
        $("#Estado").val(data.Estado);
        $("#Nombre").val(data.Nombre);
        $("#Direccion").val(data.Direccion);
        $("#TipoCuenta").val(data.TipoCuenta);
    });

}


function postVendedores() {
    var vendedor = new Object();
    vendedor.OrchardId = $("#OrchardID").val();
    vendedor.Estado = $("#Estado").val();
    vendedor.Nombre = $("#Nombre").val();
    vendedor.Direccion = $("#Direccion").val();
    vendedor.TipoCuenta = $("#TipoCuenta").val();

    writeLog("postVendedores");
    writeLog(JSON.stringify(vendedor));

    $.ajax({
        url: window.webapi + "/Vendedores",
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        crossDomain: true,
        data: JSON.stringify(vendedor),
        success: function (data, textStatus, xhr) {
            console.log(data);
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });

}

function putVendedores() {
    //[{"$id":"1","OrchardId":"1","Estado":2,"Nombre":"3","Direccion":"4","TipoCuenta":1}]
    var vendedor = new Object();
    vendedor.$id = $("#OrchardID").val();
    vendedor.OrchardId = $("#OrchardID").val();
    vendedor.Estado = $("#Estado").val();
    vendedor.Nombre = $("#Nombre").val();
    vendedor.Direccion = $("#Direccion").val();
    vendedor.TipoCuenta = $("#TipoCuenta").val();
    writeLog("putVendedores");
    writeLog(JSON.stringify(vendedor));
    $.ajax({
        url: window.webapi + "/Vendedores/" + $("#OrchardID").val(),
        type: 'PUT',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        crossDomain: true,
        data: JSON.stringify(vendedor),
        success: function (data, textStatus, xhr) {
            console.log(data);
        },
        error: function (xhr, textStatus, errorThrown) {
             if(xhr.status!=200){
                 console.log(xhr);
             }
        }
    });


}