/**
 * @param {number} columnNumber
 * @return {string}
 */
var convertToTitle = function(columnNumber) {
    let ans = ""
    while(columnNumber > 0){
        columnNumber--;
        const remainder = columnNumber % 26;
        columnNumber = Math.floor(columnNumber / 26);

        const ch = String.fromCharCode("A".charCodeAt(0) + remainder);
        ans = ch + ans;
    }

    return ans;
};