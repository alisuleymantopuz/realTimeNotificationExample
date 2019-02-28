let connection = null;

setupConnection = () => {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("/notificationhub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.start()
        .catch(err => console.error(err.toString()));

    connection.on("BroadcastTextMessage", (msg) => {
        $.growl.notice({ title: "Notification", message: msg });
    });

    connection.on("finished", function () {
        connection.stop();
    });
};

setupConnection();

