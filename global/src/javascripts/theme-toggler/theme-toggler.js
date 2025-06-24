let html = document.querySelector('html');

let toggle_button = document.querySelector('#theme-toggle');

if (localStorage.getItem('theme') === 'dark-theme') {
    html.classList.add('dark-theme');

    toggle_button.classList.add('Ativo');
} else if (localStorage.getItem('theme') === null || localStorage.getItem('theme') === "" || localStorage.getItem('theme') === 'light-theme') {
    html.classList.remove('dark-theme');
    toggle_button.classList.remove('Ativo');
}



toggle_button.addEventListener('click', function () {
    document.querySelectorAll('*').forEach(element => {
        element.style.transition = 'all 0.3s linear';
    });
    if (html.classList.contains('dark-theme')) {
        html.classList.remove('dark-theme');
        localStorage.setItem('theme', 'light-theme');
        toggle_button.classList.remove('Ativo');
    } else {
        html.classList.add('dark-theme');
        localStorage.setItem('theme', 'dark-theme');
        toggle_button.classList.add('Ativo');
    }
    setTimeout(() => {
        document.querySelectorAll('*').forEach(element => {
            element.style.transition = 'none';
        });
    }, 300);
});

