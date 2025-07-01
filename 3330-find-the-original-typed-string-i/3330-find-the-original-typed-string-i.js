/**
 * @param {string} word
 * @return {number}
 */
var possibleStringCount = function(word) {
    let ans = 1;    // 1 = full string
    for(let i=1; i<word.length; i++)
        if(word[i] == word[i-1])
            ans++;
    return ans;
};