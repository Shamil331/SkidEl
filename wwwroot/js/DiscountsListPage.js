$(".SearchArea").focusin(function () {
    event.target.value = "";
    event.target.style.color = "#808080";
})
$(".SearchArea").focusout(function () {
    event.target.value = "Введите название";
    event.target.style.color = "#D6DCE0";
})
var GotShops = new URL(location.href).searchParams.getAll('Shops');
var SelectedShops = new URL(location.href).searchParams.getAll('Shops');
var FullUrl = new URL(location.href);
$(function () {
    $(".ApplyButton").addClass("DisplayNone");
    $(".ShopCheckBox").each(function (index) {
        var RequiredCheckBox = $(".ShopCheckBox").eq(index);
        GotShops.forEach(function (element) {
            if (element + "Checker" == RequiredCheckBox.attr('id')) {
                document.getElementById(RequiredCheckBox.attr('id')).checked = true;
            }
        })
        $(this).change(function () {
            if (document.getElementById($(this).attr('id')).checked == true) {
                SelectedShops.push($(this).attr('id').replace("Checker",''));
            }
            if (document.getElementById($(this).attr('id')).checked == false) {
                var IndexOf = SelectedShops.indexOf($(this).attr('id').replace("Checker",''));
                SelectedShops.splice(IndexOf,1);
            }
            if ((SelectedShops.length == GotShops.length) && SelectedShops.every(function (element, index) {
                return element === GotShops[index]
            })) {
                $(".ApplyButton").removeClass("DisplayFlex");
                $(".ApplyButton").addClass("DisplayNone");
            }
            else {
                $(".ApplyButton").removeClass("DisplayNone");
                $(".ApplyButton").addClass("DisplayFlex");
            }
        })
    })
    $(".ListCategoryName").each(function () {
        if ($(this).text() == $(".CategoryTitle").text()) {
            $(this).css('color', '#EF003C');
        }
        var CurrentCategoryOpener = $(this).text();
        CurrentCategoryOpener = CurrentCategoryOpener.replace(/\s/g, "");
        var CurrentSubcategorieDiv = $("#" + CurrentCategoryOpener + "Subcategories");
        CurrentSubcategorieDiv.toggleClass("DisplayNone DisplayFlex");
        $("#" + CurrentCategoryOpener + "ListOpener").click(function () {
            CurrentSubcategorieDiv.toggleClass("DisplayNone DisplayFlex");
        })
    })
    $(".ListSubcategorieName").each(function () {
        if ($(this).text() == $(".CategoryTitle").text()) {
            $(this).css('color', '#EF003C');
        }
    })
    var PageNumber = FullUrl.searchParams.get('Page');
    $(".PageCounter").each(function (index) {
        if ($(this).text() == PageNumber) {
            $(this).addClass('PageCounterActive');
        }
        else {
            $(this).addClass('PageCounterNotActive');
        }  
    })
    $(".PageLinks").each(function (index) {
        var Page = FullUrl.searchParams.get('Page');
        FullUrl.searchParams.set('Page', $(this).attr('href'));
        $(this).attr('href', FullUrl);
    })
    var ShopsToStand = "";
    GotShops.forEach(function (element) {
        ShopsToStand += "&Shops=" + element;
    })
    $(".aNewCategory").each(function () {
        $(this).attr('href', $(this).attr('href') + ShopsToStand);
    })
    $(".aNewSubcategory").each(function () {
        $(this).attr('href', $(this).attr('href') + ShopsToStand);
    })
})
$(".ApplyButton").click(function () {
    var UrlToRedirect = new URL(location.href);
    UrlToRedirect.searchParams.delete('Shops');
    UrlToRedirect.searchParams.delete('Page');
    var ShopsToSend="";
    SelectedShops.forEach(function (element) {
        ShopsToSend += "&Shops=" + element;
    })
    UrlToRedirect += ShopsToSend + "&Page=1";
    location.replace(UrlToRedirect);
})
let list = (e) => {
    let list = e.children[1], step = list.clientWidth;
    [...list_1.querySelectorAll("[data-scroll]")].forEach(e => e.addEventListener("click", () => list.scrollLeft += Number(e.dataset.scroll) ? step : -step));
}
list(list_1);