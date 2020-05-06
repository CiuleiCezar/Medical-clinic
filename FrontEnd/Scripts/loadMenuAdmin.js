function loadMenu(){
    $('#addUser').on('click', function(){
        redirectAddUserPage();
    });
    $('#logout').on('click', function(){
        redirectLogoutPage();
    });
    $('#viewUser').on('click', function(){
        redirectViewUserPage();
    });
    $('#specialization').on('click', function(){
        redirectSpecializationPage();
    });
}

function redirectAddUserPage(){
    window.location.href='admin_add_user.html';
}

function redirectViewUserPage(){
    window.location.href = 'admin_view_users.html';
}

function redirectLogoutPage(){
    window.location.href = 'login.html';
}
function redirectSpecializationPage(){
    window.location.href = 'admin_specialization.html';
}
