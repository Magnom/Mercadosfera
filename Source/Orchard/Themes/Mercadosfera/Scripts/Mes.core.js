
  

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