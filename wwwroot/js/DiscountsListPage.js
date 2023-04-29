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
})
let list = (e) => {
    let list = e.children[1], step = list.clientWidth;
    [...list_1.querySelectorAll("[data-scroll]")].forEach(e => e.addEventListener("click", () => list.scrollLeft += Number(e.dataset.scroll) ? step : -step));
}
list(list_1);