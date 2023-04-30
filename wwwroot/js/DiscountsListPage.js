$(".SearchArea").focusin(function () {
    event.target.value = "";
    event.target.style.color = "#808080";
})
$(".SearchArea").focusout(function () {
    event.target.value = "Введите название";
    event.target.style.color = "#D6DCE0";
})
$(function () {
    $(".ListCategoryName").each(function (index) {
        if ($(this).text() == $(".CategoryTitle").text()) {
            $(this).css('color', '#EF003C');
        }
        var CurrentCategoryOpener = $(this).text();
        CurrentCategoryOpener=CurrentCategoryOpener.replace(/\s/g, "");
        $("#" + CurrentCategoryOpener + "ListOpener").click(function () {
            var CurrentSubcategorieDiv = $("#" + CurrentCategoryOpener + "Subcategories");
            CurrentSubcategorieDiv.toggleClass("DisplayNone DisplayFlex");
        })
    })
    var pathname = window.location.pathname;
    var PageNumber = pathname.split('/')[3];
    $(".PageCounter").each(function (index) {
        if ($(this).text() == PageNumber) {
            $(this).addClass('PageCounterActive');
        }
        else {
            $(this).addClass('PageCounterNotActive');
        }  
    })
    $(".aLinked").each(function (index) {
        var FullUrl = new URL(location.href);
        var Page = FullUrl.searchParams.get('Page');
        FullUrl.searchParams.set('Page', $(this).attr('href'));
        $(this).attr('href', FullUrl);
    })
})
let list = (e) => {
    let list = e.children[1], step = list.clientWidth;
    [...list_1.querySelectorAll("[data-scroll]")].forEach(e => e.addEventListener("click", () => list.scrollLeft += Number(e.dataset.scroll) ? step : -step));
}
list(list_1);