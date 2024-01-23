var container = document.getElementById("search-filters-container");
var search = document.getElementById("search");
var filters = document.getElementById("filters");
var scrollPosition = window.pageYOffset || document.documentElement.scrollTop;
var lastScrollPosition = scrollPosition;

window.addEventListener("scroll", function () {
    scrollPosition = window.pageYOffset || document.documentElement.scrollTop;
    if (scrollPosition > lastScrollPosition) {
        container.classList.remove("bounce-up");
        container.classList.add("bounce-down");
        search.classList.remove("bounce-up");
        search.classList.add("bounce-down");
        filters.classList.remove("bounce-up");
        filters.classList.add("bounce-down");
    } else {
        container.classList.remove("bounce-down");
        container.classList.add("bounce-up");
        search.classList.remove("bounce-down");
        search.classList.add("bounce-up");
        filters.classList.remove("bounce-down");
        filters.classList.add("bounce-up");
    }
    lastScrollPosition = scrollPosition;
});