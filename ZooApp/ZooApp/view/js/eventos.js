$(document).ready(function () {
    //console.log("ese que pasooooo");

    function Getespecies() {
        //PREPARAR LLAMADA API

        var urlApi = 'http://localhost:51093/api/Especies';

        $.get(urlApi, function (respuesta, estado) {

            if (estado === 'success') {

                var lista = ('');
                lista += '<table>';
                lista += '    <tr>';
                lista += '        <td>Id.</td>'
                lista += '        <td>Denominación</td>'
                lista += '        <td>Acciones</td>'
                lista += '    </tr>';

                $.each(respuesta.especie, function (indice, elemento) {

                    lista += '    <tr>';
                    lista += '        <td>' + elemento.idEspecie + '</td>';
                    lista += '        <td>' + elemento.idClasificacion + '</td>';
                    lista += '        <td>' + elemento.idTipoAnimal + '</td>';
                    lista += '        <td>' + elemento.nombre + '</td>';
                    lista += '        <td>' + elemento.nPata + '</td>';
                    lista += '        <td>' + elemento.esMascota + '</td>';
                    lista += '        <td>';
                    lista += '<button data-id="' + elemento.idEspecie + '" id="eliminar">X</button>';
                    lista += '<button id="Editar">Editar</button>';
                    lista += '        <td>';
                    lista += '    </tr>';


                });

                lista += '</table>';
                $('#resultado').append(lista);
            }


            //PROCESAR LOS RESULTADOS


        });

    }

    //$('#resultado').on('click', '#eliminar', function () {
    //    var idespecie = $(this).attr('data-id');
    //    var urlAPI = 'http://localhost:51093/api/Especies';
    //    $.ajax({
    //        url: urlAPI + '/' + idespecie,
    //        type: "DELETE",
    //        success: function (respuesta) {
    //            Getespecies();
    //        },
    //        error: function (respuesta) {
    //            console.log(respuesta);
    //        }
    //    });
    //});



    //$('#btnespecies').click(function () {
    //    // debugger;
    //    var idespecie = $('#txtMarcaDenominacion').val();
    //    var urlAPI = 'http://localhost:51093/api/Especies';
    //    var dataNuevaEspe = {
    //        id: 0,
    //        denominacion: idespecie
    //    };
    //    // debugger;

    //    $.ajax({
    //        url: urlAPI,
    //        type: "POST",
    //        dataType: 'json',
    //        data: dataNuevaEspe,
    //        success: function (respuesta) {
    //            //debugger;
    //            console.log(respuesta);
    //            Getespecies();
    //        },
    //        error: function (respuesta) {
    //            console.log(respuesta);
    //        }
    //    });

    //    $.ajax({
    //        url: 'http://localhost:51093/api/Especies/5',
    //        type: "PUT",
    //        dataType: 'json',
    //        data: dataNuevaEspe,
    //        success: function (respuesta) {
    //            Getespecies();
    //        },
    //        error: function (respuesta) {
    //            console.log(respuesta);
    //        }
    //    });


    //    $.ajax({
    //        url: 'http://localhost:51093/api/Especies/5',
    //        type: "DELETE",
    //        success: function (respuesta) {
    //            Getespecies();
    //        },
    //        error: function (respuesta) {
    //            console.log(respuesta);
    //        }
    //    });


    //});

    //Getespecies();







});
