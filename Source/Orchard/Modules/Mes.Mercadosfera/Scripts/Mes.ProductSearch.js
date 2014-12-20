/* Busqueda de productos.
 * 
*/

function MesSearchObject() {
    this.ViewMode = "";
    this.Products = "";
    this.CurrentFilters = "";
    this.CurrentZone = "";
    this.CurrentCategory = "";
    this.SelectedCategories = "";
    this.SelectedZones = "";
    this.SelectedStores = "";
     
    this.Products = ko.observableArray();

    this.CatagoryFilter = ko.observableArray();
    this.ZoneFilter = ko.observableArray();
    this.StoreFilter = ko.observableArray();
   // this.Filtros = ko.observableArray();

}


//Obtiene los filtros aplicables
MesSearchObject.prototype.GetFilters = function () {
    
    //var catFilter;
    var lastCat;
    var url = window.WebserviceUrl + "/api/SeachFilters?callback&type=c";
    writeLog(url);
    //this.CatagoryFilter=[];
    $.getJSON(url, function (data) {
        for (i = 0; i < data.length; i++) {
            if (lastCat==undefined || lastCat.DescCategoria != data[i].DescCategoria) {
                lastCat = data[i];

                lastCat.Subcategorias = ko.observableArray();
                MesSearchObject.Instance().CatagoryFilter.push(data[i]);
                
                lastCat.hasSubcat = true;
                lastCat.Subcategorias.push(data[i]); //[lastCat.Subcategorias.length] = data[i];
            }
            else {
                lastCat.hasSubcat = true;
                lastCat.Subcategorias.push(data[i]); //[lastCat.Subcategorias.length] = data[i];
            }
        }

        
    });
    
    

    url = window.WebserviceUrl + "/api/SeachFilters?callback&type=z";
    writeLog(url);
    $.getJSON(url, MesSearchObject.Instance().ZoneFilter);

    url = window.WebserviceUrl + "/api/SeachFilters?callback&type=s";
    writeLog(url);
    $.getJSON(url, MesSearchObject.Instance().StoreFilter);


};


//Obtiene las zonas displonibles
MesSearchObject.prototype.GetPlaces = function () {
    alert('GetPlaces');
};

//Obtiene las tiendas disponibles
MesSearchObject.prototype.GetStores = function () {
    alert('GetStores');
};


//Realiza la búsqueda de productos
MesSearchObject.prototype.Search = function () {
    

    InitFilters();
    var url = window.WebserviceUrl + "/api/ProductosSearch?callback&d=" + $("#searchText").val() + '&c=' + this.SelectedCategories + '&z=' + this.SelectedZones + '&s=' + this.SelectedStores;
    writeLog(url);
    $.getJSON(url, this.Products);
};

MesSearchObject.prototype.GetCategories = function () {
    alert('GetCategories');
};

//Actualiz
MesSearchObject.prototype.RenderProducts = function () {
    alert('RenderProducts');
};

MesSearchObject.prototype.ParseQs = function () {
    alert('ParseQs');
};


MesSearchObject.Init = function () {
    window.MesSearch = new MesSearchObject();
};

MesSearchObject.Instance = function () {
    return window.MesSearch;
};

MesSearchObject.prototype.FillSelectFilters = function () {

   /* var FiltroCategoria = ["Categoria1", "Categoria2", "Categoria3"];
    var FiltroZona = ["Zona1", "Zona2", "Zona3"];
    var FiltroTienda = ["Tienda1", "Tienda2", "Tienda3"];
    var FiltroOrden = ["Orden1", "Orden2", "Orden3"];

    rellenaSelect("#SelectCategoria", FiltroCategoria);
    rellenaSelect("#SelectZona", FiltroZona);
    rellenaSelect("#Tienda", FiltroTienda);
    rellenaSelect("#Orden", FiltroOrden);*/
};

//---------------------------------------------------------------------
//Page functions
//---------------------------------------------------------------------
function Inicializa() {

    var valor = Querystring().search;
    if ( valor != undefined) {
        $("#searchText").val(valor);

    }
    

    MesSearchObject.Init();    
    MesSearchObject.Instance().GetFilters();
    MesSearchObject.Instance().FillSelectFilters();

    ko.applyBindings(MesSearchObject.Instance());

    setTimeout(function () {
        MesSearchObject.Instance().Search();
    }, 100);

    BindEvents();
    
}



function BindData() {

}

function BindEvents() {

    $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
        e.target // activated tab
        e.relatedTarget // previous tab        
    });

    $(".lupa").removeAttr("onClick");
    $(".lupa").click(function (event) {
        SearchUpdate('');
    });


    $(document).keypress(function (e) {
        if (e.which == 13) {
            MesSearchObject.Instance().Search();
        }
    });

    

    $('#searchForm').on('submit', function (e) {
        e.preventDefault();
        MesSearchObject.Instance().Search();
    });
}


function SearchUpdate(s) {
    MesSearchObject.Instance().Search();

}

function SetFilters(cat, valor, control) {
    var filterStore = "";
    var filterZone="";
    if ($(control).is(':checked')) {        
        if (cat == "c") {
            // $('#subcat_' + valor + ' input').addAttr('checked');
            $('#subcat_' + valor + ' input').prop('checked', true);

        }
    } else {
        //alert('desactiva ' + cat + '--->' + valor);

        if (cat == "c") {

            $('#subcat_' + valor + ' input').prop('checked', false);

        }



    }
    var filter = '';
    $('#filters_ctn input:checked').each(function () {
        if($(this).hasClass('subcategoria')) {
            filter += $(this).val() +',';
        }

        if (cat == "t") {

            filterStore += $(this).val() + ',';
        }

        if (cat == "z") {

            filterZone += $(this).val() + ',';
        }

    });

    MesSearchObject.Instance().SelectedCategories = filter;
    MesSearchObject.Instance().SelectedStores = filterStore;
    MesSearchObject.Instance().SelectedZones = filterZone;

}

function MesFilter(cat, valor, control) {

    SetFilters(cat, valor, control);

    MesSearchObject.Instance().Search();
    
}

function desplegar(c) {
    //alert();

    var cat = $(c).attr('id').split('_')[1];
    
    $(c).click(function () {
        plegar(this);
    });

    $(c).removeAttr('onclick');

    $(c).text('-');
    $('#subcat_' + cat).addClass('active');
    
}

function plegar(c) {
    //alert();

    var cat = $(c).attr('id').split('_')[1];
    $(c).click(function () {
        desplegar(this);
    });
    $('#subcat_' + cat).removeClass('active');
    $(c).text('+');
}



function InitFilters() {
    var fCategory = Querystring().c;
    if (fCategory != "") {
        if ($("#c" + fCategory).attr("checked") == undefined) {
            $("#c" + fCategory).attr("checked", true);
              SetFilters("c", $("#c" + fCategory).val(), $("#c" + fCategory));            
        }
    }

    var fZona = Querystring().z;
    if (fZona != "") {
        if ($("#z" + fZona).attr("checked") == undefined) {
            $("#z" + fZona).attr("checked", true);
            //SetFilters("z", $("#z" + fZona).val(), $("#z" + fZona));
        }
    }

    var fTienda = Querystring().t;
    if (fTienda != "") {
        if ($("#t" + fTienda).attr("checked") == undefined) {
            $("#t" + fTienda).attr("checked", true);
            //SetFilters("t", $("#t" + fTienda).val(), $("#t" + fTienda));

        }
    }    
}