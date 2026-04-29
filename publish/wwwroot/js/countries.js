const API_BASE = "/api/countries";
let allCountries = [];

async function fetchAllCountries() {
    const loading = document.getElementById('loading');
    const grid = document.getElementById('countriesGrid');

    if (loading) loading.style.display = 'block';
    if (grid) grid.style.display = 'none';

    try {
        const res = await fetch(API_BASE);
        if (!res.ok) throw new Error("Failed to fetch");

        allCountries = await res.json();
        renderCountries(allCountries);
        populateRegionFilter();
    } catch (err) {
        console.error(err);
        if (loading) loading.innerHTML = `<p style="color:red">Failed to load countries.<br>Make sure backend is running.</p>`;
    } finally {
        if (loading) loading.style.display = 'none';
        if (grid) grid.style.display = 'grid';
    }
}

function renderCountries(countries) {
    const grid = document.getElementById('countriesGrid');
    grid.innerHTML = '';

    countries.forEach(country => {
        const card = document.createElement('div');
        card.className = 'country-card';
        card.innerHTML = `
            <img src="${country.flags.svg}" alt="${country.name.common}">
            <div class="card-body">
                <h3>${country.name.common}</h3>
                <p><strong>Capital:</strong> ${country.capital ? country.capital[0] : 'N/A'}</p>
                <p><strong>Population:</strong> ${country.population.toLocaleString()}</p>
                <p><strong>Region:</strong> ${country.region}</p>
            </div>
        `;
        card.addEventListener('click', () => {
            window.location.href = `detail.html?code=${country.cca3}`;
        });
        grid.appendChild(card);
    });
}

function populateRegionFilter() {
    const select = document.getElementById('regionFilter');
    select.innerHTML = '<option value="">All Regions</option>';
    const regions = [...new Set(allCountries.map(c => c.region))].sort();
    regions.forEach(r => {
        const opt = document.createElement('option');
        opt.value = r;
        opt.textContent = r;
        select.appendChild(opt);
    });
}

window.fetchAllCountries = fetchAllCountries;
window.renderCountries = renderCountries;