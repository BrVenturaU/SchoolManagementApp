// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const deleteForm = document.querySelectorAll('.delete');

for (const formEl of deleteForm) {
    formEl.onsubmit = (e) => {
        const result = confirm("¿Desea eliminar el registro?")
        if (!result) {
            e.preventDefault();
            return false;
        }
    }
}