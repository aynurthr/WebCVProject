$.ajaxSetup({
    statusCode: {
        400: function () {
            alert("Please fill out all the required fields.");
        },
        404: function () {
            alert("The requested data was not found.");
        },
        500: function () {
            alert("There's a temporary issue on the server. Please try again soon.");
        }
    }
});