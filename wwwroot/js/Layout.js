$("#SearchTextArea").focusin(function () {
    event.target.value = "";
})
$("#SearchTextArea").focusout(function () {
    event.target.value = "Поиск...";
})