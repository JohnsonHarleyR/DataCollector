function goToAddItems() {
    window.location.href = "/Add/Item";
}



// variables
var addItemBtn = document.getElementById('addItemBtn');
var addQuestionBtn = document.getElementById('addQuestionBtn');
var addAnswersBtn = document.getElementById('addAnswersBtn'); 

// event handlers
addItemBtn.addEventListener('click', goToAddItems);