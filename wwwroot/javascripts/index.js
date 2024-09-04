const putStudent = () => {
  const emailId = document.getElementById('email')
  return fetch('/api/Student', {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify({
      emailId
    })
  })
}

const mainFrom = document.getElementById('main-form')
mainFrom.addEventListener('submit', async (e) => {
  e.preventDefault();
  try {
    await putStudent()
  } catch (err) {
    console.error(err)
  }
})