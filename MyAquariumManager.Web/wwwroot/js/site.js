// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function addAllEventListener() {
    let campos = document.querySelectorAll('input, textarea, select');
    campos.forEach(campo => {
        campo.addEventListener('input', function () {
            if (this.classList.contains('is-invalid')) {
                this.classList.remove('is-invalid');
            }
        });
    });
}