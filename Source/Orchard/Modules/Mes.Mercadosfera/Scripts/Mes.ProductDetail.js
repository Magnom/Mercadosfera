/* Busqueda de productos.
 * 
*/

function MesProductObject() {

    this.IdProducto = "";
    this.IdTienda = "";
    this.Producto = ko.observableArray();
    this.Tienda = ko.observableArray();
    this.ProductoImagenes = ko.observableArray();
    this.OtrosProductos = ko.observableArray();

}


MesProductObject.prototype.ParseQs = function () {
    alert('ParseQs');
};


MesProductObject.Init = function () {
    window.MesProduct = new MesProductObject();
};

MesProductObject.Instance = function () {
    return window.MesProduct;
};

MesProductObject.prototype.GetProducto = function () {

    var url = window.WebserviceUrl + "/api/ProductosDetalle?p=" + this.IdProducto;
    writeLog(url);
    $.getJSON(url, this.Producto);

    //h = $(".comments-1").detach();
    //h.appendTo("#valoracion");
};

MesProductObject.prototype.GetTienda = function () {

    var url = window.WebserviceUrl + "/api/Store?t=" + this.IdTienda;
    writeLog(url);
    $.getJSON(url, this.Tienda);
};

MesProductObject.prototype.GetProductoImagenes = function () {

    var url = window.WebserviceUrl + "/api/ProductosImagenes?p=" + this.IdTienda;
    writeLog(url);
    $.getJSON(url, this.ProductoImagenes);
};

//---------------------------------------------------------------------
//Page functions
//---------------------------------------------------------------------
function Inicializa() {

    MesProductObject.Init();

    $(".name").each(function () {
        if ($(this).text() == "IdTienda:") {
            MesProductObject.Instance().IdProducto = $(this).parent().find(".value").text()
        }
        if ($(this).text() == "IdProducto:") {
            MesProductObject.Instance().IdTienda = $(this).parent().find(".value").text()
        }
    })


    
    MesProductObject.Instance().GetProducto();
    MesProductObject.Instance().GetTienda();
    MesProductObject.Instance().GetProductoImagenes();

    ko.applyBindings(MesProductObject.Instance());

    
    BindEvents();
    $(".comments-1").hide();
    //$("#valoracion").attach(h);
}



function BindData() {

}

function BindEvents() {



}


