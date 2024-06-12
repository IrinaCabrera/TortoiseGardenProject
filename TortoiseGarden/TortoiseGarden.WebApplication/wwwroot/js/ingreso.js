var btnRegistrarme = document.getElementsByClassName("btn-Registrarme")[0];
var contenedorRegistrarUsuario = document.getElementById("registrarUsuario");
var contenedorIngresarUsuario = document.getElementById("ingresarUsuario");
var containerForm = document.getElementsByClassName("containerForm")[0];
var btnCancelar = document.getElementsByClassName("btn-Cancelar")[0];


containerForm.removeChild(contenedorRegistrarUsuario);

btnRegistrarme.addEventListener("click", () => {
    containerForm.removeChild(contenedorIngresarUsuario);
    containerForm.appendChild(contenedorRegistrarUsuario);
});
btnCancelar.addEventListener("click", () => {
    containerForm.removeChild(contenedorRegistrarUsuario);
    containerForm.appendChild(contenedorIngresarUsuario);
});