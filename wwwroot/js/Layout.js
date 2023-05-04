$("#SearchTextArea").focusin(function () {
    event.target.value = "";
})
$("#SearchTextArea").focusout(function () {
    event.target.value = "Поиск...";
})
$("#SearchTextArea").keyup(function (event) {
    if (event.keyCode === 13) {
        Search(event.target.value);
    }
})
function Search(SearchValue) {
    var UrlToRedirect = new URL(window.location.origin);
    //UrlToRedirect.pathname.replace('/discounts');
    //UrlToRedirect.search.replace('?Search'+ SearchValue + '&Page=1');
    UrlToRedirect+= "discounts?Search=" + SearchValue + "&Page=1";
    //alert(UrlToRedirect);
    location.replace(UrlToRedirect);
}