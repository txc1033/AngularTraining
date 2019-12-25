$(document).ready(function () {
    $('#TablaEstudiantes').DataTable({
        searching: false,
        "lengthMenu": [[5, 10, 15, 25, -1], [5, 10, 15, 25, "All"]],
        language: {
            "decimal": "",
            "emptyTable": "No hay información",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        }
    });

    $("#NewStudent").click(function () {
        $.ajax({
            url: "Estudiantes/Create",
            type: 'GET',
            success: function (data) {
              
                $("#NewStudentBody").html(data);
            },
            error: function (data) {
                Swal.fire({
                    title: 'Error!',
                    text: data.responseText,
                    icon: 'error',
                    confirmButtonText: 'Entendido!'
                });
            }

        })
    });

    $("#AddStudent").click(function (event) {

        var dataString;
        event.preventDefault();
        var action = $("#formEstudiante").attr("Action");
        if ($("#formEstudiante").attr("enctype") == "multipart/form-data") {

            dataString = new FormData($("#formEstudiante").get(0));
            contentType = false;
            processData = false;
        }

        $.ajax({
            type: "POST",
            url: action,
            data: dataString,
            dataType: "json",
            contentType: contentType,
            processData: processData,
            success: function (data) {
                if (data.Data == "Se agrego correctamente") {
                    document.getElementById("formEstudiante").reset();
                    Swal.fire({
                        title: 'Exito!',
                        text: data.Data,
                        icon: 'success',
                        confirmButtonText: 'Aceptar'
                    });
                } else {
                    Swal.fire({
                        title: 'Error!',
                        text: data.Data,
                        icon: 'error',
                        confirmButtonText: 'Entendido!'
                    });
                }
                

            },
            error: function (jqXHR, textStatus, errorThrown) {
                var response = jQuery.parseJSON(jqXHR.responseText);
                Swal.fire({
                    title: 'Error!',
                    text: response.Data,
                    icon: 'error',
                    confirmButtonText: 'Entendido!'
                });

            }
        });
    });

});