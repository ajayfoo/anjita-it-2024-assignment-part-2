const getExam = () => {
  return fetch('/api/Exam/latest');
}

const getQuestion = async (id) => {
  const response = await fetch('/api/Question/' + id)
  const question = await response.json();
  return question;
}
const createAnswerElement = (answerId, answer) => {
  const answerEle = document.createElement('section')
  answerEle.classList.add('field')
  const radio = document.createElement('input')
  radio.type = 'radio'
  radio.id = answerId;

  const label = document.createElement('label')
  label.textContent = answer;
  label.setAttribute('for', answerId)

  answerEle.append(radio, label)
  return answerEle
}

const createQuestionElement = (q) => {
  const questionEle = document.createElement('fieldset')
  questionEle.id = 'question'
  const legend = document.createElement('legend')
  legend.textContent = q.content;
  const answer1Ele = createAnswerElement(q.firstAnswerId, q.firstAnswer)
  const answer2Ele = createAnswerElement(q.secondAnswerId, q.secondAnswer)
  const answer3Ele = createAnswerElement(q.thirdAnswerId, q.thirdAnswer)
  const answer4Ele = createAnswerElement(q.fourthAnswerId, q.fourthAnswer)

  questionEle.append(legend, answer1Ele, answer2Ele, answer3Ele, answer4Ele)
  return questionEle;
}

const renderQuestionOnDOM = (question) => {
  const questionArea = document.getElementById('question-area')
  questionArea.replaceChildren(createQuestionElement(question))
}

document.addEventListener('DOMContentLoaded', async () => {
  const response = await getExam();
  const payload = await response.json();
  const question = await getQuestion(1);
  renderQuestionOnDOM(question)
  console.log(payload);
  console.log(question);
})