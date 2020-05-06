window.onload = function(){
    buildlogin();
}

function buildlogin(){

    var bodyElement = document.body;
    bodyElement.className = "loginClass";

    var formElement = document.createElement('form');
    formElement.className = "formClass";

    var buttonLogin = document.createElement('input');
    buttonLogin.className = "red";
    buttonLogin.setAttribute('type', 'button');
    buttonLogin.setAttribute('value', 'Login');
    buttonLogin.onclick = function(){
        
        window.location = "admin_menu.html";
    }

    formElement.append(createFormDivSection('Username'), createFormDivSection('Password'));
    formElement.appendChild(buttonLogin);
    bodyElement.appendChild(formElement);
}

function createFormDivSection(labelText){

    var divElement = document.createElement('div');

    var spanElement = document.createElement('span');
    spanElement.innerText = labelText;
    spanElement.className = "badge";

    var input = document.createElement('input');
    input.className = "form-group";
    input.setAttribute('type', 'text');

    divElement.append(spanElement, input);

    return divElement;
}