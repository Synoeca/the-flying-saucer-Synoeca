document.addEventListener('DOMContentLoaded', function () {
    var links = document.querySelectorAll('a[data-scroll-to]');
    for (var i = 0; i < links.length; i++) {
        links[i].addEventListener('click', function (event) {
            event.preventDefault();
            var section = this.dataset.scrollTo;
            scrollToTop(section);
        });
    }
});

function scrollToTop(section) {
    if (!section || section === '') {
        if (window.location.pathname === '/') {
            if (window.pageYOffset > 0) {
                window.scrollTo({ top: 0, behavior: 'smooth' });
            } else {
                window.location.href = '/';
            }
        } else {
            window.location.href = '/';
        }
    } else if (window.location.pathname === '/') {
        window.location.hash = section;
    } else {
        window.location.href = '/#' + section;
    }
}
