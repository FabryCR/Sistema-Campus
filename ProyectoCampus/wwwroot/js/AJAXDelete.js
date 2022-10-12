
function DltMatricula(a, id) {
    Swal.fire({
        title: '¿Desea eliminar esta entrada?',
        showDenyButton: true,
        showCancelButton: false,
        confirmButtonText: 'Eliminar',
        cancelButtonText: 'Cancelar',
    }).then((result) => {
        if (result.isConfirmed) {

            $.ajax({
                type: 'POST',
                url: '/Matricula/DeleteMatricula',
                data: { 'id': id },
                dataType: 'text',
                success: function (resp) {
                    if (resp = 'Se eliminó correctamente') {
                        $(a).closest('tr').remove();
                        Swal.fire({
                            position: 'top-end',
                            icon: 'success',
                            title: 'Eliminado Correctamente',
                            showConfirmButton: false,
                            timer: 1500
                        })
                    } else {
                        Swal.fire({
                            icon: 'error',
                            title: 'Error',
                            text: 'No se puede eliminar la entrada\nEs probable que los datos estén siendo utilizados',
                        })
                    }
                },
                error: function (req, status, error) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: 'Occurrió un error al eliminar la entrada',
                    })
                }
            });
            Swal.fire('¡Eliminado!', '', 'success')
        } else if (result.isDenied) {
        }
    })
}

function DltEstudiante(a, id) {

    Swal.fire({
        title: '¿Desea eliminar esta entrada?',
        showDenyButton: true,
        showCancelButton: false,
        confirmButtonText: 'Eliminar',
        cancelButtonText: 'Cancelar',
    }).then((result) => {
        if (result.isConfirmed) {

            $.ajax({
                type: 'POST',
                url: '/Estudiante/DeleteEstudiante',
                data: { 'id': id },
                dataType: 'text',
                success: function (resp) {
                    if (resp = 'Se eliminó correctamente') {
                        $(a).closest('tr').remove();
                        Swal.fire({
                            position: 'top-end',
                            icon: 'success',
                            title: 'Eliminado Correctamente',
                            showConfirmButton: false,
                            timer: 1500
                        })
                    } else {
                        Swal.fire({
                            icon: 'error',
                            title: 'Error',
                            text: 'No se puede eliminar la entrada\nEs probable que los datos estén siendo utilizados',
                        })
                    }
                },
                error: function (req, status, error) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: 'Occurrió un error al eliminar la entrada',
                    })
                }
            });
            Swal.fire('¡Eliminado!', '', 'success')
        } else if (result.isDenied) {
        }
    })
}

function DltCurso(a, id) {

    Swal.fire({
        title: '¿Desea eliminar esta entrada?',
        showDenyButton: true,
        showCancelButton: false,
        confirmButtonText: 'Eliminar',
        cancelButtonText: 'Cancelar',
    }).then((result) => {
        if (result.isConfirmed) {

            $.ajax({
                type: 'POST',
                url: '/Cursos/DeleteCurso',
                data: { 'id': id },
                dataType: 'text',
                success: function (resp) {
                    if (resp = 'Se eliminó correctamente') {
                        $(a).closest('tr').remove();
                        Swal.fire({
                            position: 'top-end',
                            icon: 'success',
                            title: 'Eliminado Correctamente',
                            showConfirmButton: false,
                            timer: 1500
                        })
                    } else {
                        Swal.fire({
                            icon: 'error',
                            title: 'Error',
                            text: 'No se puede eliminar la entrada\nEs probable que los datos estén siendo utilizados',
                        })
                    }
                },
                error: function (req, status, error) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: 'Occurrió un error al eliminar la entrada',
                    })
                }
            });
            Swal.fire('¡Eliminado!', '', 'success')
        } else if (result.isDenied) {
        }
    })
}

function DltProfesor(a, id) {

    Swal.fire({
        title: '¿Desea eliminar esta entrada?',
        showDenyButton: true,
        showCancelButton: false,
        confirmButtonText: 'Eliminar',
        cancelButtonText: 'Cancelar',
    }).then((result) => {
        if (result.isConfirmed) {

            $.ajax({
                type: 'POST',
                url: '/Profesor/DeleteProfesor',
                data: { 'id': id },
                dataType: 'text',
                success: function (resp) {
                    if (resp = 'Se eliminó correctamente') {
                        $(a).closest('tr').remove();
                        Swal.fire({
                            position: 'top-end',
                            icon: 'success',
                            title: 'Eliminado Correctamente',
                            showConfirmButton: false,
                            timer: 1500
                        })
                    } else {
                        Swal.fire({
                            icon: 'error',
                            title: 'Error',
                            text: 'No se puede eliminar la entrada\nEs probable que los datos estén siendo utilizados',
                        })
                    }
                },
                error: function (req, status, error) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: 'Occurrió un error al eliminar la entrada',
                    })
                }
            });
            Swal.fire('¡Eliminado!', '', 'success')
        } else if (result.isDenied) {
        }
    })
}