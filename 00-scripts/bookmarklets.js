copyTitle
javascript:var titleElement=document.querySelector('div.text-title-large');var title=titleElement.innerText.trim();var tempTextarea=document.createElement('textarea');tempTextarea.value=title;document.body.appendChild(tempTextarea);tempTextarea.select();document.execCommand('copy');document.body.removeChild(tempTextarea);console.log('Title copied to clipboard!');

copyDesc 
javascript:var titleElement=document.querySelector('div.text-title-large');var title=titleElement.innerText.trim();var link='https://leetcode.com'+titleElement.querySelector('a').getAttribute('href');var descriptionElement=document.querySelector('[data-track-load="description_content"]');if(descriptionElement){var tempTextarea=document.createElement('textarea');var modifiedHTML='<h1><a href="'+link+'">'+title+'</a></h1>\n\n'+descriptionElement.outerHTML;tempTextarea.value=modifiedHTML;document.body.appendChild(tempTextarea);tempTextarea.select();document.execCommand('copy');document.body.removeChild(tempTextarea);console.log('Description with title and link copied to clipboard!')}else{alert('Description not found!')}

copyCode
javascript:var codeElement=document.querySelectorAll('code.language-csharp');if(codeElement){var spans=codeElement[codeElement.length-1].querySelectorAll('span');var lines=[];spans.forEach(function(span){var words=[];var innerSpans=span.querySelectorAll('span');innerSpans.forEach(function(innerSpan){words.push(innerSpan.innerText)});lines.push(words.join(''))});var textContent=lines.join('');var tempTextarea=document.createElement('textarea');tempTextarea.value=textContent;document.body.appendChild(tempTextarea);tempTextarea.select();document.execCommand('copy');document.body.removeChild(tempTextarea);console.log('Code copied to clipboard!')}else{alert('Code not found!')}