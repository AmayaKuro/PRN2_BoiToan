if (typeof connection === "undefined") {
    var connection = new signalR.HubConnectionBuilder()
        .withUrl("/signalrhub")
        .build();

    connection.on("ReloadList", () => {
        location.reload();
    });

    connection.start()
        .then(() => console.log("✅ SignalR connected"))
        .catch(err => console.error("❌ SignalR connect error:", err));
}