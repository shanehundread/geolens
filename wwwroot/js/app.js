document.addEventListener('DOMContentLoaded', () => {
    fetchAllCountries();

    document.getElementById('searchInput').addEventListener('input', (e) => {
        const term = e.target.value.toLowerCase();
        const filtered = allCountries.filter(c => 
            c.name.common.toLowerCase().includes(term)
        );
        renderCountries(filtered);
    });

    document.getElementById('regionFilter').addEventListener('change', (e) => {
        const region = e.target.value;
        const filtered = region ? allCountries.filter(c => c.region === region) : allCountries;
        renderCountries(filtered);
    });

    // Dark Mode
    const toggle = document.getElementById('themeToggle');
    const isDark = localStorage.getItem('darkMode') === 'true';
    if (isDark) document.body.classList.add('dark');
    toggle.textContent = isDark ? '☀️ Light' : '🌙 Dark';

    toggle.addEventListener('click', () => {
        document.body.classList.toggle('dark');
        const dark = document.body.classList.contains('dark');
        localStorage.setItem('darkMode', dark);
        toggle.textContent = dark ? '☀️ Light' : '🌙 Dark';
    });
});