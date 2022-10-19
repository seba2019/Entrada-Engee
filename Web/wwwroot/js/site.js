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

                }
            },
            error: () =>
            {

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