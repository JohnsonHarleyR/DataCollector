function goToAddItems() {
    window.location.href = "/Add/Item";
}

function goToAddQuestions() {
    window.location.href = "/Add/Question";
}

function goToAnswerQuestions() {
    console.log('going to answer questions')
    window.location.href = "/Ask/ItemsWithQuestions";
}



// variables
var addItemBtn = document.getElementById('addItemBtn');
var addQuestionBtn = document.getElementById('addQuestionBtn');
var addAnswersBtn = document.getElementById('addAnswersBtn'); 

// event handlers
addItemBtn.addEventListener('click', goToAddItems);
addQuestionBtn.addEventListener('click', goToAddQuestions);
addAnswersBtn.addEventListener('click', goToAnswerQuestions);