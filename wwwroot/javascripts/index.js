const putStudent = () => {
  const emailId = document.getElementById('email').value
  return fetch('/api/Student', {
    method: 'PUT',
    headers: {
      'accept': 'text/plain',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify({
      emailId
    })
  })
}

console.log('putStudent')
const mainFrom = document.getElementById('main-form')
mainFrom.addEventListener('submit', async (e) => {
  e.preventDefault();
  try {
    const response = await putStudent()
    const url = await response.text();
    location.replace(url)
  } catch (err) {
    console.error(err)
  }
})