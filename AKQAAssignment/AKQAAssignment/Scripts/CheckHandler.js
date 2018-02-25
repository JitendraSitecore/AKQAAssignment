function PrintCheque(dvCheque, txtAmount, txtName) {

    var apiURL = document.location.protocol + '//' + document.location.hostname + ':' +
        document.location.port + '/api/converter/Currency/' + $(txtAmount).val() + '/';
    
    $.get(apiURL, function (data, status) {
        var content = "Output: <br />" + $(txtName ).val() + "<br />" + data;
        $(dvCheque).html(content);
    });

    
}