window.onload = function(){
    loadMenu();
}

function user(){

    let promise = $.ajax({
        type: 'GET',
        url: 'https://localhost:44329/api/patient/readall',
        contentType: 'application/json',
        dataType: 'json',
        accept: 'application/json',
    });

    return promise;
}