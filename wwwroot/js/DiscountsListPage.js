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
})