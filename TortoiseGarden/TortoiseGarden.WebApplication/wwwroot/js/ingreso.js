/*Containers*/
let containerForm = document.getElementById("containerForm");
let contenedorIngresoUsuario = document.getElementById("ingresarUsuario");
let contenedorRegistroUsuario = document.getElementById("registrarUsuario");

/*Buttons*/ 
let btnAceptarIngreso = document.getElementById("btn-AceptarIngreso");
let btnAceptarRegistro = document.getElementById("btn-AceptarRegistro");
let btnRegistro = document.getElementById("btn-RegistroIngreso");
let btnCancelo = document.getElementById("btn-CancelarRegistro");

/*Inputs*/
let nameIngreso = document.getElementById("nameIngreso");
let passIngreso = document.getElementById("passIngreso");

let nameRegistro = document.getElementById("nameRegistro");
let passRegistro = document.getElementById("passRegistro");
let repetirPassRegistro = document.getElementById("repetirPassRegistro");

/*No desplego el formulario de registro.*/
containerForm.removeChild(contenedorRegistroUsuario);

btnRegistro.addEventListener("click", () => {
    containerForm.removeChild(contenedorIngresoUsuario);
    containerForm.appendChild(contenedorRegistroUsuario);
});
btnCancelo.addEventListener("click", () => {
    containerForm.removeChild(contenedorRegistroUsuario);
    containerForm.appendChild(contenedorIngresoUsuario);
    
});
btnAceptarRegistro.addEventListener("click", () => {
    
    const nombre = $('#nameRegistro').val();
    const repetirPass = $('#repetirPassRegistro').val();
    const password = $('#passRegistro').val();

    if (password === repetirPass) {

        jQuery.ajax({
            url: '/Home/RegistrarUsuario',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({ name: nombre, pass: password }),
            success: function (data) {
                alert(data.message);
            },
            error: function (err) {
                console.error('Error en la solicitud AJAX:', err);
            }

        });

    } else {
        console.log("Las contraseñas no coinciden.");

    }
});

