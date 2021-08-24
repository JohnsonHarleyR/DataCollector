function answerQuestion(answerId) {
    // get question index
    let questionId = questions[questionIndex].Id;
    // create url string
    let url = "/Ask/AddAnswer?itemId=" + itemId + "&questionId=" + questionId +
        "&answerId=" + answerId;

    // send information about question
    let http = new XMLHttpRequest;
    http.onload = function () {
        // on return, increment the questions and put new question - unless it is out of questions, then redirect
        questionIndex++;
        if (questionIndex >= questions.length) {
            window.location.href = "/Ask/ItemsWithQuestions";
        } else {
            question = questions[questionIndex].QuestionString;
            questionText.innerHTML = question;
        }
    }
    http.open("GET", url, true);
    http.send();
}


// variables
var questionText = document.getElementById('questionText');

var yesBtn = document.getElementById('yesBtn');
var noBtn = document.getElementById('noBtn');
var sometimesBtn = document.getElementById('sometimesBtn');
var doesNotApplyBtn = document.getElementById('doesNotApplyBtn');

// event handlers
yesBtn.addEventListener('click', function () { answerQuestion(1) });
noBtn.addEventListener('click', function () { answerQuestion(2) });
sometimesBtn.addEventListener('click', function () { answerQuestion(3) });
doesNotApplyBtn.addEventListener('click', function () { answerQuestion(4) });