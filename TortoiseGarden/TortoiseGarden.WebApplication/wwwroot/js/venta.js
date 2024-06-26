﻿let content = document.querySelector(".content");
let containerFormVenta = document.getElementById("containerFormVenta");
let containerFormAgregarVenta = document.getElementById("containerFormAgregarVenta");
let cantMaxProducto;
content.removeChild(containerFormVenta);
content.removeChild(containerFormAgregarVenta);

let btnlistarVenta = document.getElementById("listarVenta");
let agregarVenta = document.getElementById("agregarVenta");

let RellenarCampos = () => {

    /*Campo de UsuarioId*/
    $.ajax({
        url: '/Venta/ObtenerIdUsuarios',
        method: 'GET',
        success: function (data) {
            var select = $('#IdUsuario');
            select.empty();
            data.forEach(function (idUsuario) {
                var option = $('<option></option>').text(idUsuario);
                select.append(option);
            });

        },
        error: function (err) {
            console.error('Error', err);
        }
    });
    /*Campo de producto*/
    $.ajax({
        url: '/Venta/ObtenerNombreProducto',
        method: 'GET',
        success: function (data) {
            var select = $('#NombreProducto');
            select.empty();
            data.forEach(function (producto) {
                var option = $('<option></option>').text(producto);
                select.append(option);
            });
        },
        error: function (err) {
            console.error('Error', err);
        }
    });
}
let AjustarFechaHora = () => {
    let ahora = new Date();
    ahora.setHours(0, 0, 0, 0);
    let hoyISO = ahora.toISOString().split('T')[0];
    let horaActual = new Date().toTimeString().split(' ')[0];
    return hoyISO + 'T' + horaActual;
}
let AjustarCantidad = (nombreProducto) => {
    

    $.ajax({
        url: '/Venta/ObtenerCantidadMaxima',
        method: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(nombreProducto),
        success: function (data) {
            let cantidadProducto = document.getElementById("cantidad");
            cantMaxProducto = data;
            console.log('Success:', data);
            console.log(cantMaxProducto);
        },
        error: function (err) {
            console.error('Error:', err);
        }
    });
}

btnlistarVenta.addEventListener("click", () => {
    if (content.contains(containerFormAgregarVenta)) {
        content.removeChild(containerFormAgregarVenta);
    }
    content.appendChild(containerFormVenta);
    $.ajax({
        url: '/Venta/ObtenerVentas',
        method: 'GET',
        success: function (data) {
            var tableBody = $('#ventasTable tbody');
            tableBody.empty();

            data.forEach(function (venta) {
                var row = '<tr>';
                venta.forEach(function (cell) {
                    row += '<td>' + cell + '</td>';
                });
                row += '</tr>';
                tableBody.append(row);
            });
        },
        error: function (err) {
            console.error('Error', err);
        }
    });

});
agregarVenta.addEventListener("click", () => {

    if (content.contains(containerFormVenta)) {
        content.removeChild(containerFormVenta);
    }
    content.appendChild(containerFormAgregarVenta);

    RellenarCampos();

    let btnAceptarVenta = document.getElementById("btn-AceptarRegistro");

    btnAceptarVenta.addEventListener("click", () => {
        let NombreProducto = document.getElementById("NombreProducto").value;
        setTimeout(function () {
            AjustarCantidad(NombreProducto);
        }, 3000);
        setTimeout(function () {
            let cantidad = document.getElementById("cantidad").value;
            console.log(cantidad);
            console.log(cantMaxProducto);

            if (cantidad > cantMaxProducto) {
                cantidad = cantMaxProducto;
            }
            console.log(cantidad);

            let idUsuario = document.getElementById("IdUsuario").value;
            let fechaCompleta = AjustarFechaHora();

            let datos = {
                idUsuario: idUsuario,
                fecha: fechaCompleta,
                nombreProducto: NombreProducto,
                cantidadProducto: cantidad,

            };
            console.log(datos);
            $.ajax({
                url: '/Venta/AgregarVenta',
                method: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(datos),
                success: function (data) {
                    console.log('Success:', data);


                },
                error: function (err) {
                    console.log('Error:', err);
                }
            });
        }, 10000);
       
    });
    
});