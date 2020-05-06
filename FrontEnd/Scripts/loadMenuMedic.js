function loadMenu(){
    $('#pacients').on('click', function(){
        redirectAddPacientPage();
    })
    $('#appointment').on('click', function(){
        redirectAppointmentPage();
    })
    $('#diagnosis').on('click', function(){
        redirectDiagnosisPage();
    })
    $('#logout').on('click', function(){
        redirectLogoutPage();
    })
    populateWithPacients();
}




function redirectAddPacientPage(){
    window.location.href = 'medic_pacients.html';
}

function redirectAppointmentPage(){
    window.location.href = 'medic_appointments.html';
}

function redirectDiagnosisPage(){
    window.location.href = 'medic_diagnosis.html';
}

function redirectLogoutPage(){
    window.location.href = 'login.html';
}

function populateWithPacients() {

    var spanToPopulate = $('#listOfPacients');  
    
    $.when(getPatients()).then(function (data){
        data.forEach(function(item){
            spanToPopulate.append($('<span>').text(JSON.stringify(item)));
        });
    }).fail(function(){
        alert('error');
    })
    
}

function getPatients(){

    let promise = $.ajax({
        type: 'GET',
        url: 'https://localhost:44329/api/patient/readall',
        contentType: 'application/json',
        dataType: 'json',
        accept: 'application/json',
    });

    return promise;
}