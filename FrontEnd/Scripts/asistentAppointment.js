window.onload = function(){
    loadMenu();
    $('#deleteAppointment').on('click', function(){
        deleteAppointment();
    })
}
function deleteAppointment(){
    var idAppointment = $('#appointmentId').val();

    alert(idAppointment);
    $.when(sendAppointmentData(idAppointment)).then(function(){
        alert('Appointment deleted from database!');
    }).fail(function(){
        alert('Something went wrong!');
    })
}

function sendAppointmentData(data){

    let promise = $.ajax({
        type: 'DELETE',
        url: 'https://localhost:44329/api/appointment/DeleteById',
        contentType: 'application/json',
        dataType: 'json',
        accept: 'application/json',
        data: JSON.stringify(data)
    });
    return promise;
}