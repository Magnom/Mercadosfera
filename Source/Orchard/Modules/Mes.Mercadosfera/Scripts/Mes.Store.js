/* Busqueda de productos.
 * 
*/

function MesStoreObject() {
    

}


MesSearchObject.prototype.ParseQs = function () {
    alert('ParseQs');
};


MesSearchObject.Init = function () {
    window.MesStore = new MesStoreObject();
};

MesSearchObject.Instance = function () {
    return window.MesStore;
};

//---------------------------------------------------------------------
//Page functions
//---------------------------------------------------------------------
function Inicializa() {

    //var valor = Querystring().search;
    //if ( valor != undefined) {
    //    $("#searchText").val(valor);

    //}

    //MesSearchObject.Init();    
    //MesSearchObject.Instance().GetFilters();
    //MesSearchObject.Instance().FillSelectFilters();

    //ko.applyBindings(MesSearchObject.Instance());

    //MesSearchObject.Instance().Search();
    alert('Ini');
    BindEvents();
}



function BindData() {

}

function BindEvents() {

    

}


