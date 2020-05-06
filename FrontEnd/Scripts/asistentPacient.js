window.onload = function(){
    loadMenu();
    $('#addPatient').on('click', function(){
        alert('[ress');
        insertPatient();
    })
}

function insertPatient(){

    var email = $('#email').val();
    var firstName = $('#firstName').val();
    var lastName = $('#lastName').val();
    var age = $('#age').val();
    var birthDay = $('#birthDay').val();
    var gender = $('#gender').val();
    var phoneNumber = $('#phoneNumber').val();
    var email = $('#email').val();
    var informations = $('#informations').val();

    var patientData = {
        FirstName: firstName,
        LastName: lastName,
        Age: age,
        Gender: gender,
        BirthDate: birthDay,
        EmailAddress: email,
        PhoneNumber: phoneNumber,
        Informations: informations
    }

    $.when(sendPatientData(patientData)).then(function(){
        alert('Patient added in database!');
    }).fail(function(){
        alert('Something went wrong!');
    })
}

function sendPatientData(data){

    let promise = $.ajax({
        type: 'POST',
        url: 'https://localhost:44329/api/patient/insert',
        contentType: 'application/json',
        dataType: 'json',
        accept: 'application/json',
        data: JSON.stringify(data)
    });
    return promise;
}