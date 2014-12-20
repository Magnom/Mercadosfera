

function rellenaSelect(pSelect, elementos) {
    var htmlSelect = "";
    for (var i = 0; i < elementos.length; i++) {
        htmlSelect += "<option>" + elementos[i] + "</option>";
    }
    
    $(pSelect).html(htmlSelect);
}

function writeLog(stringlog) {
    try {
        if (!window.logEnabled)
            return;

        var now = new Date();
        console.log(" --> " + now + " -- " + stringlog);
    } catch (err0) {
        console.log(" Log error: " + err0);
    }
}


function Querystring() {
    var q = window.location.search.substr(1), qs = {};
    if (q.length) {
        var keys = q.split("&"), k, kv, key, val, v;
        for (k = keys.length; k--;) {
            kv = keys[k].split("=");
            key = kv[0];
            val = decodeURIComponent(kv[1]);
            if (qs[key] === undefined) {
                qs[key] = val;
            } else {
                v = qs[key];
                if (v.constructor != Array) {
                    qs[key] = [];
                    qs[key].push(v);
                }
                qs[key].push(val);
            }
        }
    }
    return qs;
}

function createPageBanner() {
    $(".media-library-picker-field-banner-image").hide();
    $(".enumeration-field-clase").hide();
    $(".text-field").hide();

    var url = $('.media-library-picker-field-banner-image').find('img').parent().attr('href');

    if (url != undefined) {
        var htmlC = "<div class=\"carousel-inner\">";
            htmlC += "<div class=\"item1 pageBanner\" style=\"background-image:url('" + url + "');\">";
                //"<img class=\"itemImg\" src=\"" + url + "\" onload=\"\" alt=\"...\">";
            htmlC += "<div class=\"carousel-caption ";
            htmlC += $(".enumeration-field-clase .value").text() + " \">" + $(".text-field .value").text();
            htmlC += "</div></div>";
        $('.bannerContainer').html(htmlC);
    }

    $("#q").hide();
}