
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/VisitorHub")
    .configureLogging(signalR.LogLevel.Information)
    .build();
connection.start();