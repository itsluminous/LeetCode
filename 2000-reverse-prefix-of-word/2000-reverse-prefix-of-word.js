/**
 * @param {string} word
 * @param {character} ch
 * @return {string}
 */
var reversePrefix = function(word, ch) {
    idx = word.indexOf(ch);
    if(idx == -1) return word;

    prefix = word.substring(0, idx+1);
    reversed = prefix.split('').reverse().join('');
    return reversed + word.substring(idx+1);
};