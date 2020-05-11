"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/NotificationsHub").build();

//Disable send button until connection is established
//document.getElementById("resttest").disabled = true;

connection.on("ReceiveMessageReg", function (user, message) {
    //var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    //var encodedMsg = " Зареструвався " + user + " з кафедри " + msg;
    //var li = document.createElement("li");
    //li.textContent = encodedMsg;
    //document.getElementById("messagesList").appendChild(li);
    var encodedMsg = " Зареєструвався студент " + user + " з кафедри " + message;
    var li = document.createElement("p");
    li.textContent = encodedMsg;
    //document.getElementById("messagesList").appendChild(li);
    
    //var notificationmes = '<div class="alert alert-danger alert-dismissable">' +
      //  '<a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>'
       // + encodedMsg + '</div>';
   // $('#divNotificaion').append(notificationmes);
    var notify2 = '<div class="alert alert-primary alert-dismissible fade show" role="alert" id="messagesList" style="margin-left: 200px;margin-right: 200px; ">' +
        '<i class="fas fa-bullhorn"></i>' + '<strong>Новий користувач!</strong>' +
        encodedMsg + '<button type="button" class="close" data-dismiss="alert" aria-label="Close">' +
        '<span aria-hidden="true">×</span>' + '</button>' + '</div >';
    $('#divNotificaion2').append(notify2);
    alert(encodedMsg);

});

connection.start().then(function () {
    document.getElementById("resgist").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("resgist").addEventListener("click", function (event) {
    var user = document.getElementById("inputNameStudent").value;
    var message = document.getElementById("inputKafedratst").value;
    connection.invoke("SendMessageStudentRegister", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    //event.preventDefault();
});