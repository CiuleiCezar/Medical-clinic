window.onload = function(){
    populateWithPacients();
}

function populateWithPacients() {

    var spanToPopulate = $('#listOfPacients');  
    
    $.when(getPatients()).then(function (data){
        spanToPopulate.text(data);
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