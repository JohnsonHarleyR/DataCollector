function addQuestion() {
    if (questionInput != '') {
        // get the values
        let input = questionInput.value;
        if (attachCheck.checked === true) {
            dependentQuestionId = questionSelect.value;
            dependentAnswerId = answerSelect.value;
        } else {
            dependentQuestionId = null;
            dependentAnswerId = null;
        }
        let url = "/Add/SubmitQuestion?input=" + input + '&dependentQuestionId=' + dependentQuestionId +
            '&dependentAnswerId=' + dependentAnswerId;

        window.location.href = url;

    } else {
        errorMessage.style.display = 'block';
        errorMessage.innerHTML = "A question must be entered.";
    }
}

function attachDependent() {

    // TODO make the drop so you can sort through questions with a little more complexity?

    // check the value of the checkbox
    if (attachCheck.checked === true) {

        // make div visible
        attachDiv.style.display = "block";

        // add questions drop to div
        // TODO decide if to show all questions to select from initially or just the null ones
        addQuestionDropFromServer(null, null, true, false);

    } else {

        // make div invisible
        attachDiv.style.display = "none";

        // clear contents
        attachDiv.innerHTML = "";
        attachDropCount = 0; // reset count
        dependentQuestionId = null;
        dependentAnswerId = null;

    }
}

// TODO fix this stuff if it needs to get more complex
function changeDependentQuestionValue(id) {
    console.log('changing dependent question value');
    //let questionBox = document.getElementById(id);
    //dependentQuestionId = parseInt(questionBox.value);
}

//function changeDependentQuestionValue(id) {
//    console.log('changing dependent question value');
//    let questionBox = document.getElementById(id);
//    dependentQuestionId = parseInt(questionBox.getAttribute('questionId'));
//}

function changeDependentAnswerValue(id) {
    let answerBox = document.getElementById(id);
    dependentAnswerId = parseInt(answerBox.getAttribute('answerId'));
}

function addQuestionDropFromServer(attachedQuestionId, attachedAnswerId, showAll, addSelectPreviousOption) {
    // first get the questions to pull from the server
    let http = new XMLHttpRequest;
    http.onload = function () {
        let response = JSON.parse(this.responseText);
        addQuestionDropDiv(response.Questions, response.Answers, addSelectPreviousOption);
    }
    let htmlString = "/Ajax/getQuestions?attachedQuestionId=" + attachedQuestionId +
        "&attachedAnswerId=" + attachedAnswerId + "&showAll=" + showAll;
    http.open("POST", htmlString, true);
    http.send();
}

function addQuestionDropDiv(questionArray, answerArray, addSelectPreviousOption) {
    console.log(questionArray);
    let dropDiv = document.createElement('div');
    dropDiv.id = 'dropDiv' + attachDropCount;

    let paragraph = document.createElement('p');
    paragraph.innerHTML = 'Dependent question: ';

    // create question
    let questionDrop = document.createElement('select');
    questionDrop.id = 'questionDrop' + attachDropCount;
    questionDrop.className = 'question-drop';
    questionDrop.addEventListener('change', function () { changeDependentQuestionValue(questionDrop.id) });

    if (addSelectPreviousOption) {
        questionDrop.innerHTML += '<option>' + selectPreviousOption + '</option>';
    }

    for (let i = 0; i < questionArray.length; i++)
    {
        let questionOption = document.createElement('option');
        questionOption.text = questionArray[i].QuestionString;
        questionOption.id = 'questionOption' + i;
        /*questionDrop.innerHTML += '<option>' + questionArray[i].QuestionString + '</option>';*/
        questionOption.value = questionArray[i].Id;
        //questionOption.setAttribute('questionId', questionArray[i].Id);
        /*questionOption.addEventListener('select', function () { changeDependentQuestionValue(questionOption.id) });*/
        questionDrop.appendChild(questionOption);
    }

    /*    questionDrop.onclick = function () { console.log('change'); changeDependentQuestionValue(questionDrop.id); };*/

/*    questionDrop.addEventListener('click', function () { changeDependentQuestionValue(questionDrop.id) });*/

    // add questions to div
    paragraph.appendChild(questionDrop);

    // add line break
    paragraph.appendChild(document.createElement('br'));

    // add text
    paragraph.innerHTML += 'Dependent answer: ';

    // create answers
    let answerDrop = document.createElement('select');
    answerDrop.id = 'answerDrop' + attachDropCount;
    answerDrop.className = 'answer-drop';

    for (let i = 0; i < answerArray.length; i++) {
        answerDrop.innerHTML += '<option value="' + answerArray[i].AnswerId + '">' + answerArray[i].Answer + '</option>';
/*        answerDrop.setAttribute('answerId', answerArray[i].AnswerId);*/
    }

    // add answers to div
    paragraph.appendChild(answerDrop);

    // add paragraph to attach div
    dropDiv.appendChild(paragraph);

    // attach div to larger div
    attachDiv.appendChild(dropDiv);

    // set dependent variables to default values
    dependentQuestionId = 0;
    dependentAnswerId = 0;
    questionSelect = document.getElementById('questionDrop' + attachDropCount);
    answerSelect = document.getElementById('answerDrop' + attachDropCount);

    // change drop count
    attachDropCount++;
}


// variables
var attachDropCount = 0; // how many attach drops there are
var selectPreviousOption = "(Use above option)";

var questionSelect; // HACK
var answerSelect;
var dependentQuestionId = null;
var dependentAnswerId = null;

var questionInput = document.getElementById('questionInput');
var attachCheck = document.getElementById('attachCheck');

var attachDiv = document.getElementById('attachDiv');

var addQuestionBtn = document.getElementById('addQuestionBtn');
var errorMessage = document.getElementById('errorMessage');

// event handlers
addQuestionBtn.addEventListener('click', addQuestion);
attachCheck.addEventListener('click', attachDependent);