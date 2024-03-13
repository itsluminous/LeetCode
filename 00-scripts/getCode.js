// Find the parent <code> element
var codeElement = document.querySelectorAll('code.language-csharp');

// Check if the parent <code> element exists
if (codeElement) {
    // Select all <span> elements within the parent <code> element
    var spans = codeElement[codeElement.length- 1].querySelectorAll('span');

    // Initialize an empty array to store lines
    var lines = [];

    // Iterate over each <span> element
    spans.forEach(function(span) {
        // Initialize an empty string to store words within the span
        var words = [];

        // Select all <span> elements within the current span
        var innerSpans = span.querySelectorAll('span');

        // Iterate over each inner <span> element and extract its text content
        innerSpans.forEach(function(innerSpan) {
            words.push(innerSpan.innerText);
        });

        // Concatenate the words within the span and push it to the lines array
        lines.push(words.join(''));
    });

    // Concatenate all lines with newline characters
    var textContent = lines.join('');

    // Create a temporary textarea element
    var tempTextarea = document.createElement('textarea');
    tempTextarea.value = textContent;

    // Append the textarea to the document body
    document.body.appendChild(tempTextarea);

    // Select the content of the textarea
    tempTextarea.select();

    // Copy the selected content to the clipboard
    document.execCommand('copy');

    // Remove the temporary textarea from the document
    document.body.removeChild(tempTextarea);

    // Log that the content has been copied
    console.log('Code copied to clipboard!');
} else {
    alert('Code not found!');
}
