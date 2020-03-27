// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

window.onscroll = function () { myFunction() };

var navbar = document.getElementById("sticknav");
var sticky = navbar.offsetTop;
var logo = document.getElementById("logo");

function myFunction() {
    if (window.pageYOffset > sticky) {
        navbar.classList.add("sticky")
        logo.style.height = "80px";
        logo.style.width = "80px";

    } else {
        navbar.classList.remove("sticky");
        logo.style.height = "100px";
        logo.style.width = "100px";
    }
}
