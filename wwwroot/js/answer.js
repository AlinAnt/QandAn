"use strict"

var connection = new signalR.HubConnectionBuilder().withUrl("/answerHub").build();
document.getElementById("answerButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    alert("Проверочка");
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + " says " + msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("AnswerList").appendChild(li);
});

alert("Hi");
connection.start().then(function(){
    document.getElementById("answerButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("answerButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("answerInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});