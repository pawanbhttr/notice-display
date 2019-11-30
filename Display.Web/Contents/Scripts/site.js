$(document).ready(function () {
    $('#listTable').DataTable();

    $(".alert-dismissible").fadeTo(2000, 500).slideUp(500, function () {
        $(".alert-dismissible").alert('close');
    });
});

function jsonPost(link, model, refresh) {
    $.ajax({
        type: "POST",
        url: link,
        contentType: 'application/json; charset=utf-8',
        data: model,
        dataType: "json",
        success: successFunc,
        error: errorFunc
    });

    function successFunc(mes) {
        swal("Success", mes, "success")
        .then((value) => {
            closeModal(refresh);
        });
    }

    function errorFunc() {
        swal("Oops!", "Error Occured", "error");
    }
}

function closeModal(url) {
    location.href = url;
}

function matchPassword() {
    var pass = document.getElementById("Password").value;
    var cPass = document.getElementById("ConfirmPassword").value;
    if (pass != cPass) {
        document.getElementById("ConfirmPassword").nextElementSibling.style.display = "";
        document.getElementById("ConfirmPassword").nextElementSibling.innerHTML = "Password and Confirm Password doesnot matched.";
    }
    else {
        document.getElementById("ConfirmPassword").nextElementSibling.innerHTML = "";
        document.getElementById("ConfirmPassword").nextElementSibling.style.display = "none";
    }
}

function checkUsername()
{
    var username = document.getElementById("Username");
    var model = { Username: username.value };
    $.ajax({
        type: "POST",
        url: "/User/CheckUsername",
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(model),
        dataType: "json",
        success: function (mes) {
            if (mes == 0) {
                username.nextElementSibling.style.display = "";
                username.nextElementSibling.innerHTML = "Username is not available";
            }
            else {
                username.nextElementSibling.innerHTML = "";
                username.nextElementSibling.style.display = "none";
            }
        }
    });

    return availability;
}