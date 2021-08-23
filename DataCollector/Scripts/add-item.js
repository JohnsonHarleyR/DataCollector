function checkItem() {
    let http = new XMLHttpRequest;
    http.onload = function () {
        let response = this.responseText;
        if (response === "true") {
            errorMessage.innerHTML = "That item already exists.";
        } else {
            window.location.href = "/Add/SubmitItem?input=" + itemInput.value;
        }
    }
    http.open("POST", "/Ajax/ItemExists?input=" + itemInput.value, true);
    http.send();
}


// variables
var itemInput = document.getElementById('itemInput');
var addItemBtn = document.getElementById('addItemBtn');
var errorMessage = document.getElementById('errorMessage');

// event handlers
addItemBtn.addEventListener('click', checkItem);