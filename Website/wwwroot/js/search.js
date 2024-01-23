const searchButton = document.getElementById('search-button');
searchButton.addEventListener('click', function (event) {
    event.preventDefault();

    const searchTerms = document.querySelector('#search input[name="SearchTerms"]').value;

    const currentUrl = window.location.href;
    const queryStringIndex = currentUrl.indexOf('?');
    const anchorIndex = currentUrl.indexOf('#');
    let urlWithoutParams = currentUrl;
    if (queryStringIndex !== -1) {
        urlWithoutParams = currentUrl.substring(0, queryStringIndex);
    }
    if (anchorIndex !== -1) {
        urlWithoutParams = urlWithoutParams.substring(0, anchorIndex);
    }


    const types = Array.from(document.querySelectorAll('#filters input[name="Types"]:checked')).map(el => el.value);
    const caloriesMin = document.querySelector('#filters input[name="CaloriesMin"]').value;
    const caloriesMax = document.querySelector('#filters input[name="CaloriesMax"]').value;
    const priceMin = document.querySelector('#filters input[name="PriceMin"]').value;
    const priceMax = document.querySelector('#filters input[name="PriceMax"]').value;

    const searchQuery = new URLSearchParams({
        SearchTerms: searchTerms,
        CaloriesMin: caloriesMin,
        CaloriesMax: caloriesMax,
        PriceMin: priceMin,
        PriceMax: priceMax
    });

    types.forEach(type => searchQuery.append('Types', type));

    window.location.href = `${urlWithoutParams}?${searchQuery.toString()}`;
});