var ID = 0;
var fill = 0;
var Admin = false;
//Funciones GET
function tablaEditar(id) {
        var data = { id: id };
        _POST(data,
            '/Eventos/Edit/',
            function (obj) {
                if (obj != "-1" && obj != "-2" && obj != "-3") {
                    ID = obj.habi_Id;
                    $("#FormEditar").find("#even_Descripcion").val(obj.even_Descripcion);
                    $('#ModalEditar').modal('show');
                }
            });
    }

function tablaDetalles(id) {

        var data = { id: id };
        _POST(data,
            '/Eventos/Edit/',
            function (obj) {
                if (obj != "-1" && obj != "-2" && obj != "-3") {
                    ID = obj.habi_Id;
                    $("#ModalDetalles").find("#even_Descripcion")["0"].innerText = obj.even_Descripcion;
                    $("#ModalDetalles").find("#even_FechaCrea")["0"].innerText = FechaFormato(obj.even_FechaCrea);
                    $("#ModalDetalles").find("#even_FechaModifica")["0"].innerText = FechaFormato(obj.even_FechaModifica);
                    $("#ModalDetalles").find("#tbUsuarios_usu_NombreUsuario")["0"].innerText = obj.tbUsuarios_usu_NombreUsuario;
                    $("#ModalDetalles").find("#tbUsuarios1_usu_NombreUsuario")["0"].innerText = obj.tbUsuarios1.usu_NombreUsuario;
                    //$("#ModalDetalles").find("#btnEditar")["0"].dataset.id = id;
                    $('#ModalDetalles').modal('show');
                }
            });
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

$(document).ready(function () {
    fill = Admin == undefined ? 0 : -1;
    llenarTabla();
});



$("#btnAgregar").click(function () {
    var modalnuevo = $("#ModalNuevo");
    $(modalnuevo).find("#even_Descripcion").val();
    $(modalnuevo).find("#even_Descripcion").focus();
    $(modalnuevo).modal('show');

});
