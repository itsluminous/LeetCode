// Find the div element with the title
var titleElement = document.querySelector('div.text-title-large');

// Extract text and href from the div
var title = titleElement.innerText.trim();

// Create a temp area in page to copy the text
var tempTextarea = document.createElement('textarea');
tempTextarea.value = title;
document.body.appendChild(tempTextarea);
tempTextarea.select();
document.execCommand('copy');
document.body.removeChild(tempTextarea);

// Log that the title has been copied
console.log('Title copied to clipboard!');