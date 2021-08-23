function goToAddItems() {
    window.location.href = "/Add/Item";
}

function goToAddQuestions() {
    window.location.href = "/Add/Question";
}



// variables
var addItemBtn = document.getElementById('addItemBtn');
var addQuestionBtn = document.getElementById('addQuestionBtn');
var addAnswersBtn = document.getElementById('addAnswersBtn'); 

// event handlers
addItemBtn.addEventListener('click', goToAddItems);
addQuestionBtn.addEventListener('click', goToAddQuestions);