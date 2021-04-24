if (typeof (App) == "undefined") {
    App = {};
}


$(document).ajaxStart(function () {
    waitingDialog.show('Cargando...');
    $(".modal-dialog").css("opacity", "0");
});

$(document).ajaxStop(function () {
    waitingDialog.hide();
    $(".modal-dialog").css("opacity", "1");
});

App.AlertSuccess = function (msg) {
    Swal.fire({
        icon: 'success',
        title: 'Exito!',
        text: msg
    });
};

App.AlertWarning = function (msg) {
    Swal.fire({
        icon: 'warning',
        title: 'Advertensia!',
        text: msg
    });
};

App.AlertError = function (msg) {
    Swal.fire({
        icon: 'error',
        title: 'Error!',
        text: msg
    });
};