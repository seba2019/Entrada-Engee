const _TypeMessage = {
    exito: "alert-success",
    error: "alert-danger",
    info: "alert-info",
    advertencia: "alert-warning"
}

function forceNumeric() {
    var $input = $(this);
    $input.val($input.val().replace(/[^0-9]/g, ''));
}
$(document).ready(() => {
    $('body').on('propertychange input', '.onlyNumber', forceNumeric);
});


var Message = {
    show: (m, t) => {
        $("#alert-text").text(m);
        $("#divAlert").addClass(t);
        $("#divAlert").removeClass("alert-hide");
    }
}

function actualTime() {
    var hours = new Date().getHours();
    var min = new Date().getMinutes();
    var time = hours.toString() + ":" + min.toString();
    $("#actualTime").text(time);
    $("#Visita_Hora").val(time);
}

function showTime() {
    setTimeout(actualTime(), 1000);
}

function buscarVisitante()
{
    var dni = $("#inputDni").val();
    if (dni != "")
    {
        $.ajax({
            url: "Home/GetVisitante",
            method: "post",
            dataType: "json",
            data: {
                dni:dni
            },
            success: (e) =>
            {
                if (e != null) {
                    $("#nombreCompletoVisitante").text(e.nombre + ' ' + e.apellido);
                    $("#Visita_Nombre").val(e.nombre);
                    $("#Visita_Apellido").val(e.apellido);
                } else
                {
                    Message.show("No se encontro ninguna persona", _TypeMessage.advertencia);
                }
            },
            error: () =>
            {
                Message.show("Ocurrio un error inesperado", _TypeMessage.error);
            }
        })
    }
}

function changeSector()
{
    var sector = $("#selectSector").val();
    if (sector != "") {
        $.ajax({
            url: "Home/GetPersonasBySector",
            method: "post",
            dataType: "json",
            data: {
                sector: sector
            },
            success: (result) => {
                var html = '<option value="">Seleccione persona</option>';
                for (var i = 0; i < result.length; i++)
                {
                    html += '<option value="' + result[i].nombre + ' ' + result[i].apellido
                        + '">'+ result[i].nombre + ' ' + result[i].apellido 
                        + '</option>'
                }

                $("#selectPersona").html(html);
                $("#selectPersona").removeAttr("disabled");
            },
            error: (e) => {
                Message.show("Ocurrio un error inesperado", _TypeMessage.error);
            }
        });
    }
}

function deleteVisita(id)
{
    var myModal = new bootstrap.Modal(document.getElementById("divModalConfirm"), {
        keyboard: false,
        backdrop: 'static'
    });

    myModal.show();

    $("#modalConfirmOk").click(() =>
    {
        $.ajax({
            url: "Home/DeleteVisita",
            method: "get",
            data: {
                id: id
            },
            success: (e) => {
                $("#divListado").html(e);
                Message.show("Se elimino correctamente", _TypeMessage.exito);
            },
            error: (e) => {
                console.log(e);
                Message.show("Ocurrio un error inesperado al eliminar", _TypeMessage.error);
            },
            complete: () =>
            {
                myModal.hide();
            }
        })
    })
}

function ingresoCompleto()
{
    $("#selectPersona").attr("disabled","true");
}


