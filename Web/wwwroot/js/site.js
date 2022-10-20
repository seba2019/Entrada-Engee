function buscarVisitante()
{
    var dni = $("#inputDni").val();
    if (dni != "")
    {
        $.ajax({
            url: "Home/GetVisitante",
            method: "get",
            data: {
                dni:dni
            },
            success: (e) =>
            {
                if (e != null)
                {
                    $("#nombreCompletoVisitante").val();
                }
            },
            error: () =>
            {
                console.log("ocurrio un error")
            }
        })
    }
}

function changeSector()
{
    var sector = $("#selectSector").val();

    $.ajax({
        url: "",
        method: "get",
        data: {
            sector: sector
        },
        success: (e) => {

        },
        error: () => {

        }


    });
}

function deleteVisita()
{
    var myModal = new bootstrap.Modal(document.getElementById("divModalConfirm"), {
        keyboard: false,
        backdrop: 'static'
    });

    myModal.show();
}

function actualTime()
{
    var hours = new Date().getHours();
    var min = new Date().getMinutes();
    var time = hours.toString() + ":" + min.toString();
    $("#actualTime").text(time);
}

function showTime()
{
    setTimeout(actualTime(), 1000);
}