
$(document).ready(function () {

    // View password codes


    $('#eye').click(function () {
        var a = $('#password');
        if (a.attr('type') === 'password') {
            a.attr('type', 'text');
        } else {
            a.attr('type', 'password');
        }
    });

    $('#eye-slash').click(function () {
        var a = $('#password');
        if (a.attr('type') === 'password') {
            a.attr('type', 'text');
        } else {
            a.attr('type', 'password');
        }
    });

    $('#eye-2').click(function () {
        var d = $('#password');
        if (d.attr('type') === 'password') {
            d.attr('type', 'text');
        } else {
            d.attr('type', 'password');
        }
    });

    $('#eye-slash-2').click(function () {
        var d = $('#password');
        if (d.attr('type') === 'password') {
            d.attr('type', 'text');
        } else {
            d.attr('type', 'password');
        }
    });
});


/*VALIDATION*/

function validateSignupForm() {
    var name = document.getElementById("name").value;
    var email = document.getElementById("email").value;
    var phonenumber = document.getElementById("phonenumber").value;
    var username = document.getElementById("username").value;
    var password = document.getElementById("password").value;
    var confirmpassword = document.getElementById("confirmpassword").value;

    if (name == "" || email == "" || phonenumber == "" || username == "" || password == "" || confirmpassword == "") {
        document.getElementById("errorMsg").innerHTML = "Please fill the required fields"
        return false;
    }
    else if (phonenumber.length < 11) {
        document.getElementById("errorMsg").innerHTML = "Phone number is invalid"
        return false;
    }

    else if (password.length < 8) {
        alert("Password must be at least 8 characters long.");
        return false;
    }
    else if (password != confirmpassword) {
        alert("Your Password and Confirm Password do not match.");
        return false;
    }
    else {
        //alert("Successfully Signed up");
        return true;
    }


}
function validateLoginForm() {
    var name = document.getElementById("username").value;
    var password = document.getElementById("password").value;

    if (username == "" || password == "") {
        document.getElementById("errorMsg").innerHTML = "Please fill all the required fields"
        return false;
    }

    else if (password.length < 8) {
        document.getElementById("errorMsg").innerHTML = "Your password must include atleast 8 characters"
        return false;
    }
    else {
        //alert("Successfully Logged in");
        return true;
    }
}

const showPassword = document.getElementById("show-password");
const passwordField = document.getElementById("password");
showPassword.addEventListener("click", function () {
    if (passwordField.type === "password") {
        passwordField.type = "text";
        showPasswordIcon.classList.remove("fa-eye");
        showPasswordIcon.classList.add("fa-eye-slash");
    } else {
        passwordField.type = "password";
        showPasswordIcon.classList.remove("fa-eye-slash");
        showPasswordIcon.classList.add("fa-eye");
    }
});