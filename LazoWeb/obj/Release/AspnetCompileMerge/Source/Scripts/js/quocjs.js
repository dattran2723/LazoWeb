
function myFunction() {
    var x = document.getElementById("header-left");
    if (x.className == "menu-header-left") {
        x.className += "quocjs";
    } else {
        x.className = "menu-header-left";
    }
}