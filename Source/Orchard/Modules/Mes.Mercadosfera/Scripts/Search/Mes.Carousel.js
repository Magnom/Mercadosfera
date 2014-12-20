
var ServiceUrl = "http://localhost:8099/api/carousel";
var paso = "";

function initImagePicker(field) {    
}
function getUrlImage(pValue) {       
}
function getCaroselItems() {
    
    return JSON.stringify(carousel());
}

function mostrarfieldset() {
  /*  var i = 0;

    $("fieldset").each(function (index) {
        i++;

        if (i == 4 || i == 5 || i == 6) {
            $(this).addClass('visible');
            $(this).removeClass('oculto');
        }
        else {
            $(this).addClass('oculto');
            $(this).removeClass('visible');
        }

    });

    $(".carouselItems").hide();
    
    $(".edit-item-sidebar").hide();
    */
}
function ocultaCampos() {
 /*      
    var i = 0;

    $("fieldset").each(function (index) {
        i++;
        
        if (i == 4 || i == 5 || i == 6) {
            $(this).addClass('oculto');
            $(this).removeClass('visible');
            //console.log(index + ": " + $(this).text());
        }
        else {

            $(this).addClass('visible');
            $(this).removeClass('oculto');
        }
        
    });
    $(".carouselItems").show();
    $(".edit-item-sidebar").show();
   */ 

}

function mostrarVentana()
{


    var i = 0;
    var html = "";
    $("fieldset").each(function (index) {
        i++;

        if (i == 4 || i == 5 || i == 6) {
            //$(this).addClass('oculto');
            //$(this).removeClass('visible');
            //$(this).prependTo("#miVentana");
            //console.log(index + ": " + $(this).text());

            jQuery(this).detach().appendTo("#miVentana_contenido");
        }


    });

    var ventana = document.getElementById('miVentana');
    ventana.style.marginTop = "100px";    
    ventana.style.left = ((document.body.clientWidth-350) / 2) +  "px";
    ventana.style.display = 'block';
}

function eliminar(pControl) {
    var url = $(pControl).parent().parent().find('.image').find('img').attr('src');
    var i = 0;
    
    while (carousel()[i].url != url && i < carousel().length) i++;
    carousel.splice(i,1);
    
    //carousel() = carousel().sort(sortfunction);
    $('#Carousel_Datos').attr('value', getCaroselItems());
    
}
function seleccionar(campo) {
    //alert('a');
    switch(paso) {
        case "":
            //$('fieldset').addClass('visible');
           // mostrarfieldset();
            //mostrarVentana();
            $(campo).html("Aceptar");
            paso = "1";
            break;
        case "1":
            
            var url = $("#urlImage").attr("value");
            var text = window.parent.tinyMCE.get('Body_Text').getContent();
            var orden = $("#CarouselPage_Orden_Value").val();
            var clase = $("#CarouselWidget_Clase_Value").val();
            
            var obj = { "Descripcion": text, "url": url, "Orden": orden, "Clase": clase };
            
            carousel.push(obj);            
            window.parent.tinyMCE.activeEditor.setContent('');
            ocultaCampos();
            $(".media-library-picker-remove").click();
            $('#Carousel_Datos').attr('value', getCaroselItems());

            $("#miVentana").hide();

            paso = "";
            break;
    } 


}

function sortfunction(a, b) {
    a.orden > b.orden;
}

function aceptar() {
    //alert('a');
    //$('fieldset').addClass('visible');

}



