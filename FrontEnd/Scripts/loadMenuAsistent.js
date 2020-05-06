function loadMenu(){
    $('#pacient').on('click', function(){
        redirectAddPacientPage();
    })
    $('#appointment').on('click', function(){
        redirectAppointmentPage();
    })
    $('#logout').on('click', function(){
        redirectLogoutPage();
    })
}

function redirectAddPacientPage(){
    window.location.href = 'asistent_pacient.html';
}

function redirectAppointmentPage(){
    window.location.href = 'asistent_appointment.html';
}

function redirectLogoutPage(){
    window.location.href = 'login.html';
}