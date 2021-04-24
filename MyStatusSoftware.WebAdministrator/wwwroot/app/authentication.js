if (typeof (Authentication) == "undefined") {
    Authentication = {};
}

Authentication.URL_PageHome = "/Home/Index";

Authentication.URL_ActionLogin = "/Authentication/Login";


Authentication.RedirectToHome = function () {
    window.location.replace(Authentication.URL_PageHome);
}

Authentication.Login = function () {
    var userLogin = {
        Email: $("#Email").val(),
        Password: $("#Password").val(),
        IsRemember: $("#Remember").is(":checked")
    };

    $.post(Authentication.URL_ActionLogin, userLogin, function (result) {
        if (result.success != undefined) {
            if (result.success) {
                Authentication.RedirectToHome();
            }
            else {
                App.AlertWarning(result.msg);
            }
        }
        else {
            App.AlertError(result.msg);
        }

    });
}