
function getCartCount() {
    var count = sessionStorage.getItem('cartCount');
    return count ? parseInt(count) : 0;
}

function updateCartCount(count) {
    sessionStorage.setItem('cartCount', count);
    var cartBadge = document.querySelector(".cart-badge");
    cartBadge.innerText = count;
}

function addToCart(event) {
    event.preventDefault();

    var currentCount = getCartCount();
    var newCount = currentCount + 1;

    updateCartCount(newCount);
}

window.addEventListener('load', function () {
    var cartCount = getCartCount();
    updateCartCount(cartCount);
});