let html = document.querySelector('html');

let toggle_button = document.querySelector('#theme-toggle');

if (localStorage.getItem('theme') === 'dark-theme') {
    html.classList.add('dark-theme');
    
    toggle_button.classList.add('active');
} else if (localStorage.getItem('theme') === null || localStorage.getItem('theme') === "" || localStorage.getItem('theme') === 'light-theme') {
    html.classList.remove('dark-theme');
    toggle_button.classList.remove('active');
}

toggle_button.addEventListener('click', function() {
    if (html.classList.contains('dark-theme')) {
        html.classList.remove('dark-theme');
        localStorage.setItem('theme', 'light-theme');
        toggle_button.classList.remove('active');
    } else {
        html.classList.add('dark-theme');
        localStorage.setItem('theme', 'dark-theme');
        toggle_button.classList.add('active');
    }
});

