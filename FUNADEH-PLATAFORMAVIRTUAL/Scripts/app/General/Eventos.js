$(document).ready(function () {
    llenarTabla();
});

var fill = 0;
var id = 0;

//Funciones GET
function tablaEditar(ID) {
        id= ID ;
        _ajax(null,
            '/Eventos/Edit/' + ID,
            'GET',
            function (obj) {
                if (obj != "-1" && obj != "-2" && obj != "-3") {
                    $("#FormEditar").find("#even_Descripcion").val(obj.even_Descripcion);
                    $("#ModalEditar").modal('show');
                }
            });
    }

function tablaDetalles(ID) {
    id = ID;
    $.ajax(
        {
            url: '/Eventos/Edit/' + ID,
            method: 'GET',
            data: {
                id: ID
            }
        }
    ).done(
        function (obj) {
            console.log(obj);
            if (obj != "-1" && obj != "-2" && obj != "-3") {
                $("#ModalDetalles").find("#even_Descripcion")["0"].innerText = obj.even_Descripcion;
                $("#ModalDetalles").find("#even_FechaCrea")["0"].innerText = FechaFormato(obj.even_FechaCrea);
                $("#ModalDetalles").find("#even_FechaModifica")["0"].innerText = FechaFormato(obj.even_FechaModifica);
                $("#ModalDetalles").find("#tbUsuarios_usu_NombreUsuario")["0"].innerText = obj.tbUsuarios_usu_NombreUsuario;
                $("#ModalDetalles").find("#tbUsuarios1_usu_NombreUsuario")["0"].innerText = obj.tbUsuarios1.usu_NombreUsuario;
                //$("#ModalDetalles").find("#btnEditar")["0"].dataset.id = id;
                $('#ModalDetalles').modal('show');
            }
        }
    );
        //_ajax(null,
        //    'Eventos/Edit/' + ID,
        //    'GET',
        //    function (obj) {
        //        if (obj != "-1" && obj != "-2" && obj != "-3") {
        //            $("#ModalDetalles").find("#even_Descripcion")["0"].innerText = obj.even_Descripcion;
        //            $("#ModalDetalles").find("#even_FechaCrea")["0"].innerText = FechaFormato(obj.even_FechaCrea);
        //            $("#ModalDetalles").find("#even_FechaModifica")["0"].innerText = FechaFormato(obj.even_FechaModifica);
        //            $("#ModalDetalles").find("#tbUsuarios_usu_NombreUsuario")["0"].innerText = obj.tbUsuarios_usu_NombreUsuario;
        //            $("#ModalDetalles").find("#tbUsuarios1_usu_NombreUsuario")["0"].innerText = obj.tbUsuarios1.usu_NombreUsuario;
        //            //$("#ModalDetalles").find("#btnEditar")["0"].dataset.id = id;
        //            $('#ModalDetalles').modal('show');
        //        }
        //    });
    }


function llenarTabla() {
    _ajax(null,
        '/Eventos/llenarTabla',
        'POST',
        function (Lista) {
            tabla.clear();
            tabla.draw();
            if (validarDT(Lista)) {
                return null;
            }
            console.log(Lista);
            $.each(Lista, function (index, value) {

                var Acciones = value.even_Estado == 1
                  ? null :
                 "<div>" +
                       "<a class='btn btn-primary btn-xs' onclick='CallDetalles(this)' >Detalles</a>" +
                       "<a class='btn btn-default btn-xs ' onclick='hablilitar(this)' >Activar</a>" +
                   "</div>";
                if (value.even_Estado > fill) {
                    tabla.row.add({
                        "Número": value.even_Id,
                        Eventos: value.even_Descripcion,
                        "Eventos": value.even_Descripcion,
                        Acciones: Acciones,
                        Estado: value.even_Estado ? "Activo" : "Inactivo"

                    }).draw();
                }
            });
        });
}





$("#btnAgregar").click(function () {
    var modalnuevo = $("#ModalNuevo");
    $(modalnuevo).find("#even_Descripcion").val();
    $(modalnuevo).find("#even_Descripcion").focus();
    $(modalnuevo).modal('show');

});

$("#btnEditar").click(function () {
    _ajax(null,
        '/Eventos/Edit/' + id,
        'GET',
        function (obj) {
            if (obj != "-1" && obj != "-2" && obj != "-3") {
                CierraPopups();
                $("#ModalEditar").modal("show");
                $("#ModalEditar").find("#even_Descripcion").val(obj.even_Descripcion);
                $("#ModalEditar").find("#even_Descripcion").focus();
            }
        });
});

$("#btnInactivar").click(function () {
    CierraPopups();
    $("#ModalInactivar").modal("show");
    $("#ModalInactivar").find("#even_RazonInactivo").val("");
    $("#ModalInactivar").find("#even_RazonInactivo").focus();

});

$("#btnGuardar").click(function () {
    var data = $("#FormNuevo").serializeArray();
    data = serializar(data);
    if (data != null) {
        data = JSON.stringify({ tbEventos: data });
        _ajax(data,
            '/Eventos/Create',
            'POST',
            function (obj) {
                if (obj != "-1" && obj != "-2" && obj != "-3") {
                    CierraPopups();
                    MsgSuccess("¡Éxito!", "El registro se agregó de forma exitosa.");
                    LimpiarControles(["even_Descripcion"]);
                    llenarTabla();
                } else {
                    MsgError("Error", "No se agregó el registro, contacte al administrador.");
                }
            });
    } else {
        MsgError("Error", "Por favor llene todas las cajas de texto.");

    }
});


$("#Inactivar").click(function () {
    var data = $("#FormInactivar").serializeArray();
    data = serializar(data);
    if (data != null) {
        data.even_Id = id;
        data = JSON.stringify({ tbEventos: data });
        _ajax(data,
            '/Eventos/Delete',
            'POST',
            function (obj) {
                if (obj != "-1" && obj != "-2" && obj != "-3") {
                    CierrPopups();
                    MsgSuccess("¡Éxito!", "El registro se inactivó de forma exitosa.");
                    LimpiarControles("even_Descripcion");
                    llenarTabla();
                } else {
                    MsgError("Error", "No se inactivó el registro, contacte al administrador.");
                }
            });
    } else {
        MsgError("Error", "Por favor llene todas las cajas de texto.");

    }
});

$("#btnActualizar").click(function () {
    var data = $("FormEditar").serializeArray();
    data = serializar(data);
    if (data != null) {
        data.even_Id = id,
        data = JSON.stringify({ tbEventos: data });
        _ajax(data,
            '/Eventos/Edit',
            'POST',
            function (obj) {
                if (obj != "-1" && obj != "-2" && obj != "-3") {
                    CierraPopups();
                    MsgSuccess("¡Éxito!", "El registro se editó de forma exitosa.");
                    llenarTabla();
                } else {
                    MsgError("Error", "No se editó el registro, contacte al administrador.");
                }
            });
    } else {
        MsgError("Error", "Por favor llene todas las cajas de texto.");
    }
});


