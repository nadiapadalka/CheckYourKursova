"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/NotificationsHub").build();

//Disable send button until connection is established
//document.getElementById("resttest").disabled = true;

connection.on("MessageComment", function (user, message) {

    //var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    //var encodedMsg = " Зареструвався " + user + " з кафедри " + msg;
    //var li = document.createElement("li");
    //li.textContent = encodedMsg;
    //document.getElementById("messagesList").appendChild(li);
    var encodedMsg = user + " додав коментар: " + message;
    var li = document.createElement("p");
    li.textContent = encodedMsg;
    //document.getElementById("messagesList").appendChild(li);
   
    var notify = '<div class="alert alert-success alert-dismissible fade show" role="alert" id="messagesList" style="margin-left: 200px;margin-right: 200px; ">' +
        '<i class="fas fa-bullhorn"></i>' + '<strong>Новий коментар!</strong>' +
        encodedMsg + '<button type="button" class="close" data-dismiss="alert" aria-label="Close">' +
        '<span aria-hidden="true">×</span>' + '</button>' + '</div >';
    $('#divNotificaionstud').append(notify);
    alert(encodedMsg);

});

connection.start().then(function () {
    document.getElementById("addcommemtteach").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("addcommemtteach").addEventListener("click", function (event) {
    var user = document.getElementById("teaccomment").value;
    var message = document.getElementById("inputTextCommentTeach").value;
    connection.invoke("SendMessageTeacherComment", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    //event.preventDefault();
});