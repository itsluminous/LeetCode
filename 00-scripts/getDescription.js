// Find the div element with the title
var titleElement = document.querySelector('div.text-title-large');

// Extract text and href from the div
var title = titleElement.innerText.trim();
var link = 'https://leetcode.com' + titleElement.querySelector('a').getAttribute('href');

// Find the div element with the description
var descriptionElement = document.querySelector('[data-track-load="description_content"]');

// Check if the element exists
if (descriptionElement) {
    // Create a temporary textarea element to hold the HTML content
    var tempTextarea = document.createElement('textarea');
    
    // Modify the HTML content to prepend TITLE as a link
    var modifiedHTML = '<h1><a href="' + link + '">' + title + '</a></h1>\n\n' + descriptionElement.outerHTML;

    // Set the value of the textarea to the modified HTML content
    tempTextarea.value = modifiedHTML;
    
    // Append the textarea to the document body
    document.body.appendChild(tempTextarea);
    
    // Select the content of the textarea
    tempTextarea.select();
    
    // Copy the selected content to the clipboard
    document.execCommand('copy');
    
    // Remove the temporary textarea from the document
    document.body.removeChild(tempTextarea);
    
    // Log that the content has been copied
    console.log('Description with title and link copied to clipboard!');
} else {
    // Alert the user if the div element is not found
    alert('Description not found!');
}