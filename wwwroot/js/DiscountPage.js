let ul = $(".DiscountImageSmallContainer");
ul.mouseenter(function () {
    let ulElementsCount = $('ul li').length;
    let width = 5 * 85;
    $(this).css('width', width);
    let rowsCount = parseInt(ulElementsCount / 5);
    if (rowsCount == 0) {
        rowsCount++;
    }
    let height =  rowsCount * 75;
    $(this).css('height', height)

})
ul.mouseleave(function () {
    $(this).css('width', 226);
    $(this).css('height', 70)
})
let li = $(".DiscountImageSmall");
li.click(function () {
    let liStyle = window.getComputedStyle((this), false);
    let currentLiUrl = liStyle.backgroundImage.slice(4, -1).replace(/"/g, "");
    $(".DiscountImageBig").attr("src",currentLiUrl);
})
$(".BackButton").click(function () {
    history.back();
})
