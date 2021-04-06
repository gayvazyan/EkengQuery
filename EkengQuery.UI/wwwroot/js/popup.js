function PopUp(hideOrshow) {
    if (hideOrshow == 'hide') document.getElementById('wrapper').style.display = "none";
    else document.getElementById('wrapper').removeAttribute('style');
}

window.onload = function () {
    setTimeout(function () {
        PopUp('show');
        setTimeout(function () {
            PopUp('hide');
        }, 5000);
    }, 1000);
}